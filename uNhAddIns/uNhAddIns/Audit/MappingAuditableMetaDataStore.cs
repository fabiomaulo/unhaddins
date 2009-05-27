using System;
using System.Collections.Generic;
using NHibernate.Cfg;

namespace uNhAddIns.Audit
{
	public class MappingAuditableMetaDataStore : IAuditableMetaDataStore
	{
		private readonly Dictionary<string, IAuditableMetaData> store = new Dictionary<string, IAuditableMetaData>();

		public MappingAuditableMetaDataStore(Configuration cfg)
		{
			if (cfg == null)
			{
				throw new ArgumentNullException("cfg");
			}
			Cfg = cfg;
		}

		protected Configuration Cfg { get; private set; }

		public virtual bool RegisterAuditableEntityIfNeeded(string entityName)
		{
			var pc = Cfg.GetClassMapping(entityName);
			if(pc == null)
			{
				return false;
			}
			if (!pc.MetaAttributes.ContainsKey(GetAuditableClassMarker()))
			{
				return false;
			}
			var meta = new AuditableMetaData(entityName);
			store.Add(entityName, meta);
			return true;
		}

		protected virtual string GetAuditableClassMarker()
		{
			return "Auditable";
		}

		public bool Contains(string entityName)
		{
			if (string.IsNullOrEmpty(entityName))
			{
				return false;
			}
			return store.ContainsKey(entityName);
		}

		public virtual IAuditableMetaData GetAuditableMetaData(string entityName)
		{
			if (string.IsNullOrEmpty(entityName))
			{
				return null;
			}
			IAuditableMetaData result;
			store.TryGetValue(entityName, out result);
			return result;
		}
	}
}