using uNhAddIns.NH;
using uNhAddIns.Test.aReposEmul;
using uNhAddIns.Transform;

namespace uNhAddIns.Test.Pagination
{
	// In this case we use a concrete implementation GenericPaginableDAO only because
	// we want be secure that the IResultTransformer is exactly the transformmer for NoFoo class.
	// The NoFooService is responsible of query construction according NoFoo class.
	public class NoFooPaginable : GenericPaginableDAO<NoFoo> 
	{
		public NoFooPaginable(TestCase workingTest, IDetachedQuery detachedQuery)
			: base(workingTest, detachedQuery)
		{
			DetachedQuery.SetResultTransformer(
				new PositionalToBeanResultTransformer(typeof (NoFoo), new string[] {"name", "description"}));
		}
	}
}