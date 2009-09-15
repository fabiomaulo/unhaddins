using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ChinookMediaManager.Data.Impl.Constraints;
using ChinookMediaManager.Infrastructure;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Cfg.Loquacious;
using NHibernate.Validator.Engine;
using uNhAddIns.Adapters;
using uNhAddIns.NHibernateValidator;

namespace ChinookMediaManager.GuyWire.Configurators
{
    public class NHVConfigurator : IConfigurator
    {
        #region IConfigurator Members

        public void Configure(IWindsorContainer container)
        {
            var ve = new ValidatorEngine();

            container.Register(Component.For<IEntityValidator>()
                                   .ImplementedBy<EntityValidator>());

            container.Register(Component.For<ValidatorEngine>()
                                   .Instance(ve)
                                   .LifeStyle.Singleton);

            //Register the service for ISharedEngineProvider
            container.Register(Component.For<ISharedEngineProvider>()
                                   .ImplementedBy<NHVSharedEngineProvider>());

            //Assign the shared engine provider for NHV.
            Environment.SharedEngineProvider =
                container.Resolve<ISharedEngineProvider>();

            //Configure validation framework fluently
            var configure = new FluentConfiguration();

            configure.Register(typeof (AlbumValidationDef).Assembly.ValidationDefinitions())
                .SetDefaultValidatorMode(ValidatorMode.OverrideAttributeWithExternal)
                .IntegrateWithNHibernate.ApplyingDDLConstraints().And.RegisteringListeners();

            ve.Configure(configure);
        }

        #endregion
    }
}