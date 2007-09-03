using NHibernate;
using uNhAddIns.GenericImpl;
using uNhAddIns.NH;
using uNhAddIns.Transform;

namespace uNhAddIns.Test.Pagination
{
	// In this case we use a concrete implementation PaginableQuery only because
	// we want be secure that the IResultTransformer is exactly the transformmer for NoFoo class.
	// The NoFooService is responsible of query construction according NoFoo class.
	public class NoFooPaginable : PaginableQuery<NoFoo> 
	{
		public NoFooPaginable(ISession session, IDetachedQuery detachedQuery)
			: base(session, detachedQuery)
		{
			detachedQuery.SetResultTransformer(
				new PositionalToBeanResultTransformer(typeof (NoFoo), new string[] {"name", "description"}));
		}
	}
}