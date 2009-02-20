using NHibernate.Hql.Ast.ANTLR.Tree;

namespace NHibernate.Hql.Ast.ANTLR.Util
{
	public class ColumnHelper
	{
		public static void GenerateSingleScalarColumn(HqlSqlWalkerNode node, int i)
		{
			ASTUtil.CreateSibling(node.ASTFactory, HqlSqlWalker.SELECT_COLUMNS, " as " + NameGenerator.ScalarName(i, 0), node);
		}

		/// <summary>
		/// Generates the scalar column AST nodes for a given array of SQL columns
		/// </summary>
		public static void GenerateScalarColumns(HqlSqlWalkerNode node, string[] sqlColumns, int i) 
		{
			if ( sqlColumns.Length == 1 ) 
			{
				GenerateSingleScalarColumn( node, i );
			}
			else 
			{
				node.SetText( sqlColumns[0] );	// Use the DOT node to emit the first column name.

				// Create the column names, folled by the column aliases.
				for ( int j = 0; j < sqlColumns.Length; j++ ) 
				{
					if ( j > 0 ) 
					{
						node = (HqlSqlWalkerNode) ASTUtil.CreateSibling( node.ASTFactory, HqlSqlWalker.SQL_TOKEN, sqlColumns[j], node );
					}

					node = (HqlSqlWalkerNode) ASTUtil.CreateSibling(node.ASTFactory, HqlSqlWalker.SELECT_COLUMNS, " as " + NameGenerator.ScalarName(i, j), node);
				}
			}
		}

	}
}
