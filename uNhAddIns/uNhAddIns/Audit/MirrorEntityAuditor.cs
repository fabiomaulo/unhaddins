using System;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Event;
using NHibernate.Util;
using uNhAddIns.Mapping;

namespace uNhAddIns.Audit
{
	public class MirrorEntityAuditor : AbstractEntityAuditor
	{
		private string auditEntityName;

		public MirrorEntityAuditor(string entityName, IAuditableMetaData meta) : base(entityName, meta)
		{
			auditEntityName = StringHelper.UnqualifyEntityName(entityName).Trim() + "Audit";
		}

		public override void Initialize(Configuration cfg)
		{
			var originalPc = cfg.GetClassMapping(EntityName);
			var auditPc = originalPc.Clone();
			Dialect dialect = Dialect.GetDialect(cfg.Properties);
			var mappings = cfg.CreateMappings(dialect);

		}

		public override void Inserting(PreInsertEvent eventArgs)
		{
			throw new NotImplementedException();
		}

		public override void Updating(PreUpdateEvent eventArgs)
		{
			throw new NotImplementedException();
		}

		public override void Deleting(PreDeleteEvent eventArgs)
		{
			throw new NotImplementedException();
		}

		public override void Inserted(PostInsertEvent eventArgs)
		{
			throw new NotImplementedException();
		}

		public override void Updated(PostUpdateEvent eventArgs)
		{
			throw new NotImplementedException();
		}

		public override void Deleted(PostDeleteEvent eventArgs)
		{
			throw new NotImplementedException();
		}
	}
}