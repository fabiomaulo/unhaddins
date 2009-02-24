using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Antlr.Runtime;
using NHibernate.Type;

namespace NHibernate.Hql.Ast.ANTLR.Tree
{
	public class ConstructorNode : SelectExpressionList, ISelectExpression 
	{
		private IType[] _constructorArgumentTypes;
		private ConstructorInfo _constructor;
		private bool _isMap;
		private bool _isList;

		public ConstructorNode(IToken token) : base(token)
		{
		}

		public IList<IType> ConstructorArgumentTypeList
		{
			get { return _constructorArgumentTypes.ToList(); }
		}

		public string[] GetAliases()
		{
			ISelectExpression[] selectExpressions = CollectSelectExpressions();
			string[] aliases = new string[selectExpressions.Length];
			for (int i = 0; i < selectExpressions.Length; i++)
			{
				string alias = selectExpressions[i].Alias;
				aliases[i] = alias == null ? i.ToString() : alias;
			}
			return aliases;
		}


		protected override IASTNode GetFirstSelectExpression()
		{
			// Collect the select expressions, skip the first child because it is the class name.
			return GetChild(1);
		}

		public void SetScalarColumnText(int i)
		{
			ISelectExpression[] selectExpressions = CollectSelectExpressions();
			// Invoke setScalarColumnText on each constructor argument.
			for (int j = 0; j < selectExpressions.Length; j++)
			{
				ISelectExpression selectExpression = selectExpressions[j];
				selectExpression.SetScalarColumnText(j);
			}
		}

		public FromElement FromElement
		{
			get { return null; }
		}

		public bool IsConstructor
		{
			get { return true; }
		}

		public bool IsReturnableEntity
		{
			get { return false; }
		}

		public bool IsScalar
		{
			get { return true; }
		}

		public string Alias
		{
			get { throw new InvalidOperationException("constructor may not be aliased"); }
			set { throw new InvalidOperationException("constructor may not be aliased"); }
		}

		public ConstructorInfo Constructor
		{
			get { return _constructor; }
		}

		public bool IsMap
		{
			get { return _isMap; }
		}

		public bool IsList
		{
			get { return _isList; }
		}


	}
}
