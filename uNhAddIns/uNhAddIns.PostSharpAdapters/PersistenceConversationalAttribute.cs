using System;
using PostSharp.Extensibility;

namespace uNhAddIns.PostSharpAdapters
{
	/// <summary>
	/// Indicates that every public method is involved in a persistence conversation.
	/// To explictly exclude a method use [ImplicitConversational(AttributeExclude = True)]
	/// </summary>
	[Serializable]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property
		, Inherited = true, AllowMultiple = false)]
	[MulticastAttributeUsage(MulticastTargets.Method, 
		TargetMemberAttributes = MulticastAttributes.Public, AllowMultiple = true)]
	public class ImplicitConversationAttribute : PersistenceConversationalBase
	{}

	/// <summary>
	/// Indicates that a method is involved in a persistence conversation.
	/// This aspect is suitable for private members.
	/// This aspect can't be used at class level, use ImplicitConversational.
	/// </summary>
	[Serializable]
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
	[MulticastAttributeUsage(MulticastTargets.Method, AllowMultiple = false)]
	public class PersistenceConversationAttribute : PersistenceConversationalBase
	{ }
}
