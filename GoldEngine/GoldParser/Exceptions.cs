using System;

// C# Translation of GoldParser, by Marcus Klimstra <klimstra@home.nl>.
// Based on GOLDParser by Devin Cook <http://www.devincook.com/goldparser>.
namespace GoldParser
{
	/// Thrown by the parser when an error occures.
	/// Specialized exceptions may be added at a later time. 
	public class ParserException : Exception
	{
		/// Creates a new ParserException with the specified error string.
		internal ParserException(String p_error)
		:	base(p_error)
		{
		}
		
		/// Creates a new ParserException with the specified error string and inner-exception.
		internal ParserException(String p_error, Exception p_exception)
		:	base(p_error, p_exception)
		{
		}
	}
}
