using uNhAddIns.Entities;

namespace uNhAddIns.DataAccessObjects.Tests {
	public class Foo : AbstractEntity<int> {
		public override int Id { get; protected set; }
		public virtual string Name { get; set; }
	}
}