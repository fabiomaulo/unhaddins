using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace uNhAddIns.Inflector
{
	/// <summary>
	/// Base implementation.
	/// </summary>
	/// <remarks>
	/// Originally implemented by http://andrewpeters.net/inflectornet/
	/// </remarks>
	public abstract class AbstractInflector : IInflector
	{
		private readonly List<IRule> plurals = new List<IRule>();
		private readonly List<IRule> singulars = new List<IRule>();
		private readonly HashSet<string> uncountables = new HashSet<string>();
		private readonly HashSet<IRule> unaccentRules = new HashSet<IRule>();
		private readonly Regex wordsSplit = new Regex(@"([A-Z]+[a-z\d]*)|[_\s]", RegexOptions.Compiled);
		private readonly Regex wordsWhiteSpaces = new Regex(@"[_\s]", RegexOptions.Compiled);
		
		protected AbstractInflector()
		{
			AddUnaccent("([¿¡¬√ƒ≈∆])", "A");
			AddUnaccent("([«])", "C");
			AddUnaccent("([»… À])", "E");
			AddUnaccent("([ÃÕŒœ])", "I");
			AddUnaccent("([–])", "D");
			AddUnaccent("([—])", "N");
			AddUnaccent("([“”‘’÷ÿ])", "O");
			AddUnaccent("([Ÿ⁄€‹])", "U");
			AddUnaccent("([›])", "Y");
			AddUnaccent("([ﬁ])", "T");
			AddUnaccent("([ﬂ])", "s");
			AddUnaccent("([‡·‚„‰ÂÊ])", "a");
			AddUnaccent("([Á])", "c");
			AddUnaccent("([ËÈÍÎ])", "e");
			AddUnaccent("([ÏÌÓÔ])", "i");
			AddUnaccent("([])", "e");
			AddUnaccent("([Ò])", "n");
			AddUnaccent("([ÚÛÙıˆ¯])", "o");
			AddUnaccent("([˘˙˚¸])", "u");
			AddUnaccent("([˝])", "y");
			AddUnaccent("([˛])", "t");
			AddUnaccent("([ˇ])", "y");
		}

		protected virtual string ApplyFirstMatchRule(IList<IRule> rules, string word)
		{
			string result = word;

			if (!uncountables.Contains(word.ToLower()))
			{
				for (int i = rules.Count - 1; i >= 0; i--)
				{
					if ((result = rules[i].Apply(word)) != null)
					{
						break;
					}
				}
			}
			return result;
		}

		protected virtual string ApplyRules(IEnumerable<IRule> rules, string word)
		{
			string result = word;
			foreach (var rule in rules)
			{
				result = rule.Apply(result);
			}
			return result;
		}

		protected void AddIrregular(string singular, string plural)
		{
			AddPlural("(" + singular[0] + ")" + singular.Substring(1) + "$", "$1" + plural.Substring(1));
			AddSingular("(" + plural[0] + ")" + plural.Substring(1) + "$", "$1" + singular.Substring(1));
		}

		protected void AddUncountable(string word)
		{
			uncountables.Add(word.ToLower());
		}

		protected void AddPlural(string rule, string replacement)
		{
			plurals.Add(new NounsRule(rule, replacement));
		}

		protected void AddUnaccent(string rule, string replacement)
		{
			unaccentRules.Add(new CaseSensitiveRule(rule, replacement));
		}

		protected void AddSingular(string rule, string replacement)
		{
			singulars.Add(new NounsRule(rule, replacement));
		}

		public virtual string Pluralize(string word)
		{
			return ApplyFirstMatchRule(plurals, word);
		}

		public virtual string Singularize(string word)
		{
			return ApplyFirstMatchRule(singulars, word);
		}

		public string Titleize(string word)
		{
			return Regex.Replace(Humanize(Underscore(word)), @"\b([a-z])", match => match.Captures[0].Value.ToUpper());
		}

		public string Humanize(string lowercaseAndUnderscoredWord)
		{
			return Capitalize(Regex.Replace(lowercaseAndUnderscoredWord, @"_", " "));
		}

		public string Pascalize(string lowercaseAndUnderscoredWord)
		{
			return Regex.Replace(lowercaseAndUnderscoredWord, "(?:^|_)(.)", match => match.Groups[1].Value.ToUpper());
		}

		public string Camelize(string lowercaseAndUnderscoredWord)
		{
			return Uncapitalize(Pascalize(lowercaseAndUnderscoredWord));
		}

		public string Underscore(string pascalCasedWord)
		{
			return Regex.Replace(
				Regex.Replace(
					Regex.Replace(pascalCasedWord, @"([A-Z]+)([A-Z][a-z])", "$1_$2"), @"([a-z\d])([A-Z])",
					"$1_$2"), @"[-\s]", "_").ToLower();
		}

		public string Capitalize(string word)
		{
			return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
		}

		public string Uncapitalize(string word)
		{
			return word.Substring(0, 1).ToLower() + word.Substring(1);
		}

		public abstract string Ordinalize(string number);

		public string Dasherize(string underscoredWord)
		{
			return underscoredWord.Replace('_', '-');
		}

		public virtual string Unaccent(string word)
		{
			return ApplyRules(unaccentRules, word);
		}

		public virtual string Tableize(string className)
		{
			if (string.IsNullOrEmpty(className))
			{
				throw new ArgumentNullException("className");
			}
			var result = new StringBuilder(className.Length);
			foreach (var word in className.SplitWords())
			{
				if (wordsWhiteSpaces.IsMatch(word))
				{
					result.Append(word);
				}
				else
				{
					result.Append(Unaccent(Pluralize(word)));
				}
			}
			return result.ToString();
		}

		public string ForeignKey(string className, bool separateClassNameAndId)
		{
			return Unaccent(className + (separateClassNameAndId ? "_ID":"Id"));
		}
	}
}