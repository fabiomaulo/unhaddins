namespace uNhAddIns.Adapters
{
	///<summary>
	/// Enum types to decide what to do with the conversation after executing the current action
	/// 
	///</summary>
	public enum EndMode
	{
		///<summary>
		/// Continue the conversation
		///</summary>
		Continue, 
		///<summary>
		/// end and accept the changes
		///</summary>
		End, 
		///<summary>
		/// end and abort the changes
		///</summary>
		Abort
	}
}