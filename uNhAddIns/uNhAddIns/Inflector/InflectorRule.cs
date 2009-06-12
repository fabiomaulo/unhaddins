using System;
using System.Text.RegularExpressions;

namespace uNhAddIns.Inflector
{
	public class InflectorRule
	{
		private readonly Regex regex;
		private readonly int hashCode;

		public InflectorRule(string pattern, string replacement)
		{
			if (string.IsNullOrEmpty(pattern))
			{
				throw new ArgumentNullException("pattern");
			}
			if (replacement == null)
			{
				throw new ArgumentNullException("replacement");
			}
			regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
			Pattern = pattern;
			Replacement = replacement;
			hashCode = 397 ^ Replacement.GetHashCode() ^ Pattern.GetHashCode();
		}

		public string Replacement { get; private set; }

		public string Pattern { get; private set; }

		public string Apply(string word)
		{
			if (!regex.IsMatch(word))
			{
				return null;
			}

			return regex.Replace(word, Replacement);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as InflectorRule);
		}

		public bool Equals(InflectorRule other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}
			if (ReferenceEquals(this, other))
			{
				return true;
			}
			return Equals(other.Pattern, Pattern) && Equals(other.Replacement, Replacement);
		}

		public override int GetHashCode()
		{
			return hashCode;
		}
	}
}