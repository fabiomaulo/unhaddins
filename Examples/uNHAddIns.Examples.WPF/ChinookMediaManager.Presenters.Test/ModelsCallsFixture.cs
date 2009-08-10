using System.Collections.Generic;
using System.Linq;
using Caliburn.PresentationFramework.Actions;
using Mono.Cecil;
using Mono.Cecil.Cil;
using NUnit.Framework;

namespace ChinookMediaManager.Presenters.Test
{
    [TestFixture]
    public class ModelsCallsFixture
    {
        private IEnumerable<string> models;
        private AssemblyDefinition presenters;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            models = AssemblyFactory
                .GetAssembly("ChinookMediaManager.Domain.dll")
                .MainModule.Types.OfType<TypeReference>()
                .Where(t => t.Namespace.EndsWith("Model"))
                .Select(m => m.FullName);
            presenters = AssemblyFactory.GetAssembly("ChinookMediaManager.Presenters.dll");
        }


        private bool MethodIsAsync(ICustomAttributeProvider methodDefinition)
        {
            IEnumerable<string> query = methodDefinition.CustomAttributes
                .OfType<CustomAttribute>()
                .Select(c => c.Constructor.DeclaringType.FullName);

            return query.Contains(typeof (AsyncActionAttribute).FullName);
        }


        private void should_not_contains_a_model_call(IMemberReference type,
                                                      MethodDefinition method)
        {
            if (method.Body == null) return;

            foreach (Instruction instruction in method.Body.Instructions)
            {
                if (instruction.Operand == null) continue;

                var methodOperand = instruction.Operand as MemberReference;
                if (methodOperand != null)
                    if (models.Contains(methodOperand.DeclaringType.FullName))
                        ThrowAssertException(type, method, methodOperand);

                var methodCall = instruction.Operand as MethodReference;
                if (methodCall != null)
                {
                    var methodDef = methodCall.GetOriginalMethod() as MethodDefinition;
                    if (methodDef != null)
                    {
                        //recursive-call
                        should_not_contains_a_model_call(methodCall.DeclaringType, methodDef);
                    }
                }
            }
        }

        private static void ThrowAssertException(IMemberReference type, IMemberReference method,
                                                 MemberReference methodOperand)
        {
            throw new AssertionException(
                string.Format("The method {0} in the class {1} uses the model {2} but is not async."
                              , method.Name, type.Name, methodOperand.DeclaringType.Name));
        }

        /// <summary>
        ///"All  MODELS call from Presenters  (this means calls that use nhibernate session) 
        /// should be made inside [AsyncActions] methods."
        /// </summary>
        [Test]
        public void models_calls_occurs_on_async_thread()
        {
            IEnumerable<TypeDefinition> concreteTypes = presenters.MainModule
                .Types.OfType<TypeDefinition>()
                .Where(t => !t.IsInterface && !t.IsAbstract);
            foreach (TypeDefinition type in concreteTypes)
            {
                //public and not async methods.
                IEnumerable<MethodDefinition> publicMethods = type.Methods.OfType<MethodDefinition>()
                    .Where(m => m.IsPublic && !MethodIsAsync(m));

                foreach (MethodDefinition method in publicMethods)
                {
                    should_not_contains_a_model_call(type, method);
                }
            }
        }
    }
}