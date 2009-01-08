namespace uNhAddIns.Adapters
{
	///<summary>
	/// Define the way each method will be included in a persistent conversation.
	///</summary>
	public enum MethodsIncludeMode
	{
		///<summary>
		/// Each method is involved in a persistence-conversation if not explicitly excluded.
		///</summary>
		Implicit,

		///<summary>
		/// Methods involved must be explicitly declared.
		///</summary>
		Explicit
	}
}