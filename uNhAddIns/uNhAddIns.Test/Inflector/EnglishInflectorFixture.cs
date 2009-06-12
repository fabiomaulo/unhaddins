using System;
using System.Collections.Generic;
using NUnit.Framework;
using uNhAddIns.Inflector;

namespace uNhAddIns.Test.Inflector
{
	[TestFixture]
	public class EnglishInflectorFixture
	{
		/// Originally implemented by http://andrewpeters.net/inflectornet/
    #region Fixture Data

    public readonly Dictionary<string, string> SingularToPlural = new Dictionary<string, string>();
    public readonly Dictionary<string, string> PascalToUnderscore = new Dictionary<string, string>();
    public readonly Dictionary<string, string> UnderscoreToCamel = new Dictionary<string, string>();

    public readonly Dictionary<string, string> PascalToUnderscoreWithoutReverse =
      new Dictionary<string, string>();

    public readonly Dictionary<string, string> CamelWithModuleToUnderscoreWithSlash =
      new Dictionary<string, string>();

    public readonly Dictionary<string, string> UnderscoreToHuman = new Dictionary<string, string>();
    public readonly Dictionary<string, string> MixtureToTitleCase = new Dictionary<string, string>();
    public readonly Dictionary<string, string> OrdinalNumbers = new Dictionary<string, string>();
    public readonly Dictionary<string, string> UnderscoresToDashes = new Dictionary<string, string>();

    public EnglishInflectorFixture()
    {
      SingularToPlural.Add("search", "searches");
      SingularToPlural.Add("switch", "switches");
      SingularToPlural.Add("fix", "fixes");
      SingularToPlural.Add("box", "boxes");
      SingularToPlural.Add("process", "processes");
      SingularToPlural.Add("address", "addresses");
      SingularToPlural.Add("case", "cases");
      SingularToPlural.Add("stack", "stacks");
      SingularToPlural.Add("wish", "wishes");
      SingularToPlural.Add("fish", "fish");

      SingularToPlural.Add("category", "categories");
      SingularToPlural.Add("query", "queries");
      SingularToPlural.Add("ability", "abilities");
      SingularToPlural.Add("agency", "agencies");
      SingularToPlural.Add("movie", "movies");

      SingularToPlural.Add("archive", "archives");

      SingularToPlural.Add("index", "indices");

      SingularToPlural.Add("wife", "wives");
      SingularToPlural.Add("safe", "saves");
      SingularToPlural.Add("half", "halves");

      SingularToPlural.Add("move", "moves");

      SingularToPlural.Add("salesperson", "salespeople");
      SingularToPlural.Add("person", "people");

      SingularToPlural.Add("spokesman", "spokesmen");
      SingularToPlural.Add("man", "men");
      SingularToPlural.Add("woman", "women");

      SingularToPlural.Add("basis", "bases");
      SingularToPlural.Add("diagnosis", "diagnoses");

      SingularToPlural.Add("datum", "data");
      SingularToPlural.Add("medium", "media");
      SingularToPlural.Add("analysis", "analyses");

      SingularToPlural.Add("node_child", "node_children");
      SingularToPlural.Add("child", "children");

      SingularToPlural.Add("experience", "experiences");
      SingularToPlural.Add("day", "days");

      SingularToPlural.Add("comment", "comments");
      SingularToPlural.Add("foobar", "foobars");
      SingularToPlural.Add("newsletter", "newsletters");

      SingularToPlural.Add("old_news", "old_news");
      SingularToPlural.Add("news", "news");

      SingularToPlural.Add("series", "series");
      SingularToPlural.Add("species", "species");

      SingularToPlural.Add("quiz", "quizzes");

      SingularToPlural.Add("perspective", "perspectives");

      SingularToPlural.Add("ox", "oxen");
      SingularToPlural.Add("photo", "photos");
      SingularToPlural.Add("buffalo", "buffaloes");
      SingularToPlural.Add("tomato", "tomatoes");
      SingularToPlural.Add("dwarf", "dwarves");
      SingularToPlural.Add("elf", "elves");
      SingularToPlural.Add("information", "information");
      SingularToPlural.Add("equipment", "equipment");
      SingularToPlural.Add("bus", "buses");
      SingularToPlural.Add("status", "statuses");
      SingularToPlural.Add("status_code", "status_codes");
      SingularToPlural.Add("mouse", "mice");

      SingularToPlural.Add("louse", "lice");
      SingularToPlural.Add("house", "houses");
      SingularToPlural.Add("octopus", "octopi");
      SingularToPlural.Add("virus", "viri");
      SingularToPlural.Add("alias", "aliases");
      SingularToPlural.Add("portfolio", "portfolios");

      SingularToPlural.Add("vertex", "vertices");
      SingularToPlural.Add("matrix", "matrices");

      SingularToPlural.Add("axis", "axes");
      SingularToPlural.Add("testis", "testes");
      SingularToPlural.Add("crisis", "crises");

      SingularToPlural.Add("rice", "rice");
      SingularToPlural.Add("shoe", "shoes");

      SingularToPlural.Add("horse", "horses");
      SingularToPlural.Add("prize", "prizes");
      SingularToPlural.Add("edge", "edges");

      PascalToUnderscore.Add("Product", "product");
      PascalToUnderscore.Add("SpecialGuest", "special_guest");
      PascalToUnderscore.Add("ApplicationController", "application_controller");
      PascalToUnderscore.Add("Area51Controller", "area51_controller");

      UnderscoreToCamel.Add("product", "product");
      UnderscoreToCamel.Add("special_guest", "specialGuest");
      UnderscoreToCamel.Add("application_controller", "applicationController");
      UnderscoreToCamel.Add("area51_controller", "area51Controller");

      PascalToUnderscoreWithoutReverse.Add("HTMLTidy", "html_tidy");
      PascalToUnderscoreWithoutReverse.Add("HTMLTidyGenerator", "html_tidy_generator");
      PascalToUnderscoreWithoutReverse.Add("FreeBSD", "free_bsd");
      PascalToUnderscoreWithoutReverse.Add("HTML", "html");

      UnderscoreToHuman.Add("employee_salary", "Employee salary");
      UnderscoreToHuman.Add("employee_id", "Employee id");
      UnderscoreToHuman.Add("underground", "Underground");

      MixtureToTitleCase.Add("active_record", "Active Record");
      MixtureToTitleCase.Add("ActiveRecord", "Active Record");
      MixtureToTitleCase.Add("action web service", "Action Web Service");
      MixtureToTitleCase.Add("Action Web Service", "Action Web Service");
      MixtureToTitleCase.Add("Action web service", "Action Web Service");
      MixtureToTitleCase.Add("actionwebservice", "Actionwebservice");
      MixtureToTitleCase.Add("Actionwebservice", "Actionwebservice");

      OrdinalNumbers.Add("0", "0th");
      OrdinalNumbers.Add("1", "1st");
      OrdinalNumbers.Add("2", "2nd");
      OrdinalNumbers.Add("3", "3rd");
      OrdinalNumbers.Add("4", "4th");
      OrdinalNumbers.Add("5", "5th");
      OrdinalNumbers.Add("6", "6th");
      OrdinalNumbers.Add("7", "7th");
      OrdinalNumbers.Add("8", "8th");
      OrdinalNumbers.Add("9", "9th");
      OrdinalNumbers.Add("10", "10th");
      OrdinalNumbers.Add("11", "11th");
      OrdinalNumbers.Add("12", "12th");
      OrdinalNumbers.Add("13", "13th");
      OrdinalNumbers.Add("14", "14th");
      OrdinalNumbers.Add("20", "20th");
      OrdinalNumbers.Add("21", "21st");
      OrdinalNumbers.Add("22", "22nd");
      OrdinalNumbers.Add("23", "23rd");
      OrdinalNumbers.Add("24", "24th");
      OrdinalNumbers.Add("100", "100th");
      OrdinalNumbers.Add("101", "101st");
      OrdinalNumbers.Add("102", "102nd");
      OrdinalNumbers.Add("103", "103rd");
      OrdinalNumbers.Add("104", "104th");
      OrdinalNumbers.Add("110", "110th");
      OrdinalNumbers.Add("1000", "1000th");
      OrdinalNumbers.Add("1001", "1001st");

      UnderscoresToDashes.Add("street", "street");
      UnderscoresToDashes.Add("street_address", "street-address");
      UnderscoresToDashes.Add("person_street_address", "person-street-address");

    	EnglInflector = new EnglishInflector();
    }

    #endregion
		public IInflector EnglInflector { get; set; } 

    [Test]
    public void PluralizePlurals()
    {
      Assert.AreEqual("plurals", EnglInflector.Pluralize("plurals"));
      Assert.AreEqual("Plurals", EnglInflector.Pluralize("Plurals"));
    }

    [Test]
    public void Pluralize()
    {
      foreach (KeyValuePair<string, string> keyValuePair in SingularToPlural)
      {
        Assert.AreEqual(keyValuePair.Value, EnglInflector.Pluralize(keyValuePair.Key));
        Assert.AreEqual(EnglInflector.Capitalize(keyValuePair.Value),
                        EnglInflector.Pluralize(EnglInflector.Capitalize(keyValuePair.Key)));
      }
    }

    [Test]
    public void Singularize()
    {
      foreach (KeyValuePair<string, string> keyValuePair in SingularToPlural)
      {
        Assert.AreEqual(keyValuePair.Key, EnglInflector.Singularize(keyValuePair.Value));
        Assert.AreEqual(EnglInflector.Capitalize(keyValuePair.Key),
                        EnglInflector.Singularize(EnglInflector.Capitalize(keyValuePair.Value)));
      }
    }

    [Test]
    public void TitleCase()
    {
      foreach (KeyValuePair<string, string> keyValuePair in MixtureToTitleCase)
      {
        Assert.AreEqual(keyValuePair.Value, EnglInflector.Titleize(keyValuePair.Key));
      }
    }

    [Test]
    public void Pascalize()
    {
			foreach (KeyValuePair<string, string> keyValuePair in PascalToUnderscore)
      {
        Assert.AreEqual(keyValuePair.Key, EnglInflector.Pascalize(keyValuePair.Value));
      }
    }

    [Test]
    public void Camelize()
    {
      foreach (KeyValuePair<string, string> keyValuePair in UnderscoreToCamel)
      {
        Assert.AreEqual(keyValuePair.Value, EnglInflector.Camelize(keyValuePair.Key));
      }
    }

    [Test]
    public void Underscore()
    {
      foreach (KeyValuePair<string, string> keyValuePair in PascalToUnderscore)
      {
        Assert.AreEqual(keyValuePair.Value, EnglInflector.Underscore(keyValuePair.Key));
      }

      foreach (KeyValuePair<string, string> keyValuePair in PascalToUnderscoreWithoutReverse)
      {
        Assert.AreEqual(keyValuePair.Value, EnglInflector.Underscore(keyValuePair.Key));
      }

      foreach (KeyValuePair<string, string> keyValuePair in UnderscoreToCamel)
      {
        Assert.AreEqual(keyValuePair.Key, EnglInflector.Underscore(keyValuePair.Value));
      }

      foreach (KeyValuePair<string, string> keyValuePair in UnderscoreToHuman)
      {
        Assert.AreEqual(keyValuePair.Key, EnglInflector.Underscore(keyValuePair.Value));
      }
    }

    [Test]
    public void Humanize()
    {
      foreach (KeyValuePair<string, string> keyValuePair in UnderscoreToHuman)
      {
        Assert.AreEqual(keyValuePair.Value, EnglInflector.Humanize(keyValuePair.Key));
      }
    }

    [Test]
    public void Ordinal()
    {
      foreach (KeyValuePair<string, string> keyValuePair in OrdinalNumbers)
      {
        Assert.AreEqual(keyValuePair.Value, EnglInflector.Ordinalize(keyValuePair.Key));
      }
    }

    [Test]
    public void Dasherize()
    {
      foreach (KeyValuePair<string, string> keyValuePair in UnderscoresToDashes)
      {
        Assert.AreEqual(keyValuePair.Value, EnglInflector.Dasherize(keyValuePair.Key));
      }
    }
	}
}