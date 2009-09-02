namespace uNhAddIns.Entities
{
	public class Entity : AbstractEntity<int>, IEntity
	{
		public override int Id { get; protected set; }
	}
}