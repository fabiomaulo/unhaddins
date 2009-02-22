using System.Collections.Generic;
using System.Reflection;
using NHibernate.Cfg;
using NHibernate.Engine;
using NHibernate.Tool.hbm2ddl;

namespace uNhAddIns.TestUtils.NhIntegration
{
	public interface IMappingLoader
	{
		void LoadMappings(Configuration configuration);
	}

	public class NoOpMappingsLoader : IMappingLoader
	{
		#region Implementation of IMappingLoader

		public void LoadMappings(Configuration configuration) {}

		#endregion
	}

	public class AssemblyMappingsLoader : IMappingLoader
	{
		private readonly Assembly assembly;

		public AssemblyMappingsLoader(Assembly assembly)
		{
			this.assembly = assembly;
		}

		#region Implementation of IMappingLoader

		public void LoadMappings(Configuration configuration)
		{
			configuration.AddAssembly(assembly);
		}

		#endregion
	}

	public class NamespaceMappingsLoader : IMappingLoader
	{
		private readonly Assembly assembly;
		private readonly string mappingNamespace;

		public NamespaceMappingsLoader(Assembly assembly, string mappingNamespace)
		{
			this.assembly = assembly;
			this.mappingNamespace = mappingNamespace;
		}

		#region Implementation of IMappingLoader

		public void LoadMappings(Configuration configuration)
		{
			foreach (string resource in assembly.GetManifestResourceNames())
			{
				if (resource.StartsWith(mappingNamespace) && resource.EndsWith(".hbm.xml"))
				{
					configuration.AddResource(resource, assembly);
				}
			}
		}

		#endregion
	}

	public class ResourceWithRelativeNameMappingsLoader : IMappingLoader
	{
		private readonly Assembly assembly;
		private readonly string baseName;
		private readonly string[] mappingsName;

		public ResourceWithRelativeNameMappingsLoader(Assembly assembly, string baseName, string[] mappingsName)
		{
			this.assembly = assembly;
			this.baseName = baseName;
			this.mappingsName = mappingsName;
		}

		#region Implementation of IMappingLoader

		public void LoadMappings(Configuration configuration)
		{
			foreach (string file in mappingsName)
			{
				configuration.AddResource(baseName + "." + file, assembly);
			}
		}

		#endregion
	}

	public class DefaultFunctionalTestSettings : IFunctionalTestSettings
	{
		private readonly IMappingLoader mappingLoader;

		public DefaultFunctionalTestSettings(IMappingLoader mappingLoader)
		{
			this.mappingLoader = mappingLoader;
		}

		#region Implementation of IFunctionalTestSettings

		public IEnumerable<string> MappingResourceRelativeNames { get; set; }

		public string BaseMappingsNameSpace { get; set; }

		public bool AssertAllDataRemoved
		{
			get { return true; }
		}

		public virtual void Configure(Configuration configuration)
		{
			configuration.Configure();
		}

		public virtual void SchemaSetup(Configuration configuration)
		{
			new SchemaExport(configuration).Create(false, true);
		}

		public void SchemaShutdown(Configuration configuration)
		{
			new SchemaExport(configuration).Drop(false, true);
		}

		public bool SchemaShutdownAfterFailure
		{
			get { return true; }
		}

		public void LoadMappings(Configuration configuration)
		{
			mappingLoader.LoadMappings(configuration);
		}

		public virtual void BeforeSessionFactoryBuilt(Configuration configuration) {}

		public virtual void AfterSessionFactoryBuilt(ISessionFactoryImplementor sessionFactory) {}

		#endregion
	}
}