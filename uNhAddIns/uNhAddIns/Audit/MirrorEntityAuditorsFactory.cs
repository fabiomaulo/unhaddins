namespace uNhAddIns.Audit
{
	public class MirrorEntityAuditorsFactory: IAuditorsFactory
	{
		public IAuditor CreateAuditor(string entityName, IAuditableMetaData metaData)
		{
			return new MirrorEntityAuditor(entityName, metaData);
		}
	}
}