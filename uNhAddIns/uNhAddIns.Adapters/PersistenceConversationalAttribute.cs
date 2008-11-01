using System;

namespace uNhAddIns.Adapters
{
	/// <summary>
	/// Decorate a class as involved in a persistentes conversation.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class PersistenceConversationalAttribute : Attribute
	{
		/// <summary>
		/// Id de la conversación que se usará siempre para la target-class.
		/// </summary>
		/// <remarks>
		/// Opcionál.
		/// <para>
		/// Es de usar solo en caso se requiere siempre el mismo Id para la
		/// clase.
		/// </para>
		/// </remarks>
		public string ConversationId { get; set; }

		/// <summary>
		/// Prefijo del Id de la conversación.
		/// </summary>
		/// <remarks>
		/// Opcionál
		/// <para>
		/// El Id de la conversación será compuesto por el IdPrefix + UniqueId
		/// </para>
		/// </remarks>
		public string IdPrefix { get; set; }
	}
}