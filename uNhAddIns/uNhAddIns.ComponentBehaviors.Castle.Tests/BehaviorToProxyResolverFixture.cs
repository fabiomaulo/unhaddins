using System;
using System.ComponentModel;
using System.Linq;
using Moq;
using NUnit.Framework;
using uNhAddIns.ComponentBehaviors.Castle.Configuration;
using uNhAddIns.NHibernateTypeResolver;

namespace uNhAddIns.ComponentBehaviors.Castle.Tests
{

    public class A
    {}

    public abstract class B : A, INotifyPropertyChanged, IDataErrorInfo, IEditableObject
    {
        public abstract event PropertyChangedEventHandler PropertyChanged;

        
        public abstract string this[string columnName] { get; }

        
        public abstract string Error { get; }

       
        public abstract void BeginEdit();

        
        public abstract void EndEdit();

        
        public abstract void CancelEdit();
    }

    [TestFixture]
    public class BehaviorToProxyResolverFixture
    {
        [Test]
        public void behaviors_none_should_return_empty_interceptors_and_additionalinterfaces()
        {
            var behaviorStore = new Mock<IBehaviorStore>();
            behaviorStore.Setup(bs => bs.GetBehaviorsForType(typeof (A)))
                         .Returns(Behaviors.None);
            
            var behaviorToProxyResolver = new BehaviorToProxyResolver(behaviorStore.Object);
            //Method under test.
            var proxyInfo = behaviorToProxyResolver.GetProxyInformation(typeof (A));
            proxyInfo.AdditionalInterfaces.Should().Be.Empty();
            proxyInfo.InterceptorTypes.Should().Be.Empty();
        }

        [Test]
        public void already_implemented_interfaces_in_target_are_evicted()
        {
            var behaviorStore = new Mock<IBehaviorStore>();

            behaviorStore.Setup(bs => bs.GetBehaviorsForType(typeof(B)))
                         .Returns(Behaviors.NotifiableBehavior 
                                | Behaviors.EditableBehavior 
                                | Behaviors.DataErrorInfoBehavior);

            var behaviorToProxyResolver = new BehaviorToProxyResolver(behaviorStore.Object);
            //Method under test.
            var proxyInfo = behaviorToProxyResolver.GetProxyInformation(typeof(B));
            proxyInfo.AdditionalInterfaces.Should()
                .Not.Contain(typeof(IDataErrorInfo))
                .And.Not.Contain(typeof(IEditableObject))
                .And.Not.Contain(typeof(INotifyPropertyChanged));
        }

        [Test]
        public void notify_property_changed_return_correct_interceptor()
        {
            VerifyInterceptor(Behaviors.NotifiableBehavior, typeof(PropertyChangedInterceptor));
        }
        
        [Test]
        public void data_error_info_return_correct_interceptor()
        {
            VerifyInterceptor(Behaviors.DataErrorInfoBehavior, typeof(DataErrorInfoInterceptor));
        }

        [Test]
        public void editable_behavior_return_correct_interceptor()
        {
            VerifyInterceptor(Behaviors.EditableBehavior, typeof(EditableBehaviorInterceptor));
        }


        [Test]
        public void notify_property_changed_return_correct_interface()
        {
            VerifyInterface(Behaviors.NotifiableBehavior, typeof(INotifyPropertyChanged));
        }

        [Test]
        public void data_error_info_return_correct_interface()
        {
            VerifyInterface(Behaviors.DataErrorInfoBehavior, typeof(IDataErrorInfo));
        }

        [Test]
        public void editable_behavior_return_correct_interface()
        {
            VerifyInterface(Behaviors.EditableBehavior, typeof(IEditableObject));
        }

        [Test]
        public void all_proxy_should_contain_mark_proxy()
        {
            contain_mark_proxy(Behaviors.DataErrorInfoBehavior);
            contain_mark_proxy(Behaviors.NotifiableBehavior);
            contain_mark_proxy(Behaviors.EditableBehavior);
        }

        
        
        public void contain_mark_proxy(Behaviors selectedBehavior)
        {
            var behaviorStore = new Mock<IBehaviorStore>();
            
            behaviorStore.Setup(bs => bs.GetBehaviorsForType(typeof(B)))
                .Returns(selectedBehavior);

            var behaviorToProxyResolver = new BehaviorToProxyResolver(behaviorStore.Object);
            //Method under test.
            var proxyInfo = behaviorToProxyResolver.GetProxyInformation(typeof(B));

            proxyInfo.InterceptorTypes
                .Should().Satisfy(irs => irs.Any(ir => ir.Equals(typeof(GetEntityNameInterceptor))));

            proxyInfo.AdditionalInterfaces
                .Should().Satisfy(interfaces => interfaces.Any(i => i.Equals(typeof(IWellKnownProxy))));
        }


        private static void VerifyInterceptor(Behaviors selectedBehavior, Type expectedInterceptor)
        {
            var behaviorStore = new Mock<IBehaviorStore>();

            
            behaviorStore.Setup(bs => bs.GetBehaviorsForType(typeof(B)))
                .Returns(selectedBehavior);

            var behaviorToProxyResolver = new BehaviorToProxyResolver(behaviorStore.Object);
            //Method under test.
            var proxyInfo = behaviorToProxyResolver.GetProxyInformation(typeof(B));
            
            proxyInfo.InterceptorTypes
                .Should().Satisfy(irs => irs.Any(ir => ir.Equals(expectedInterceptor)));
        }

        private static void VerifyInterface(Behaviors selectedBehavior, Type expectedInterface)
        {
            var behaviorStore = new Mock<IBehaviorStore>();


            behaviorStore.Setup(bs => bs.GetBehaviorsForType(typeof(A)))
                .Returns(selectedBehavior);

            var behaviorToProxyResolver = new BehaviorToProxyResolver(behaviorStore.Object);
            //Method under test.
            var proxyInfo = behaviorToProxyResolver.GetProxyInformation(typeof(A));

            proxyInfo.AdditionalInterfaces
                 .Should().Satisfy(adi => adi.Any(i => i.Equals(expectedInterface)));
        }
    }
}