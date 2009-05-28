namespace uNhAddIns.Audit
{
	public class ParallelEntityAuditorsFactory: IAuditorsFactory
	{
		public IAuditor CreateAuditor(string entityName, IAuditableMetaData metaData)
		{
			return new ParallelEntityAuditor(entityName, metaData);
		}
	}
}