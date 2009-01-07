using System.Collections.Generic;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.ModelBuilder.Inspectors;

namespace uNhAddIns.CastleAdapters.AutomaticConversationManagement
{
	public class PersistenceConversationalComponentInspector : MethodMetaInspector
	{
		private ConversationMetaInfoStore metaStore;

		public override void ProcessModel(IKernel kernel, ComponentModel model)
		{
			if (metaStore == null)
			{
				metaStore = (ConversationMetaInfoStore) kernel[typeof (ConversationMetaInfoStore)];
			}

			ConfigureBasedOnAttributes(model);
			Validate(model, metaStore);

			AddTransactionInterceptorIfIsTransactional(model, metaStore);
		}

		private static void AddTransactionInterceptorIfIsTransactional(ComponentModel model, ConversationMetaInfoStore store)
		{
			ConversationMetaInfo meta = store.GetMetaFor(model.Implementation);

			if (meta == null)
			{
				return;
			}

			model.Dependencies.Add(new DependencyModel(DependencyType.Service, null, typeof (ConversationInterceptor), false));
			model.Interceptors.AddFirst(new InterceptorReference(typeof (ConversationInterceptor)));
		}

		private static void Validate(ComponentModel model, ConversationMetaInfoStore store)
		{
			if (model.Service == null || model.Service.IsInterface)
			{
				return;
			}

			ConversationMetaInfo meta = store.GetMetaFor(model.Implementation);

			if (meta == null)
			{
				return;
			}

			var problematicMethods = new List<string>(10);

			foreach (MethodInfo method in meta.Methods)
			{
				if (!method.IsVirtual)
				{
					problematicMethods.Add(method.Name);
				}
			}

			if (problematicMethods.Count != 0)
			{
				string[] methodNames = problematicMethods.ToArray();

				string message =
					string.Format(
						"The class {0} wants to use persistence-conversation interception, "
						+ "however the methods must be marked as virtual in order to do so. Please correct "
						+ "the following methods: {1}", model.Implementation.FullName, string.Join(", ", methodNames));

				throw new FacilityException(message);
			}
		}

		private void ConfigureBasedOnAttributes(ComponentModel model)
		{
			metaStore.CreateMetaFromType(model.Implementation);
		}

		#region Overrides of MethodMetaInspector

		protected override string ObtainNodeName()
		{
			return "NotSupportedYet";
		}

		#endregion
	}
}