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
		/// Id de la conversaci�n que se usar� siempre para la target-class.
		/// </summary>
		/// <remarks>
		/// Opcion�l.
		/// <para>
		/// Es de usar solo en caso se requiere siempre el mismo Id para la
		/// clase.
		/// </para>
		/// </remarks>
		public string ConversationId { get; set; }

		/// <summary>
		/// Prefijo del Id de la conversaci�n.
		/// </summary>
		/// <remarks>
		/// Opcion�l
		/// <para>
		/// El Id de la conversaci�n ser� compuesto por el IdPrefix + UniqueId
		/// </para>
		/// </remarks>
		public string IdPrefix { get; set; }
	}
}