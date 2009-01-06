using System;
using System.Collections.Generic;
using Iesi.Collections.Generic;
using uNhAddIns.Example.ConversationUsage.BusinessLogic;
using uNhAddIns.Example.ConversationUsage.Entities;
using uNhAddIns.Example.ConversationUsage.MultiTiers;

namespace uNhAddIns.Example.ConversationUsage
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			AppConfigure();
			CreateNewCrocodileFamilyInOneForm();

			Console.ReadLine();
		}

		private static void AppConfigure()
		{
			ServiceLocator.Load((new ServiceLocatorProvider()).GetServiceLocator());
		}

		private static void CreateNewCrocodileFamilyInOneForm()
		{
			// Instatiation of the model: you can use it from the Form or better from presenter (MVP)
			var familyCrudModel = ServiceLocator.GetService<IFamilyCrudModel<Reptile>>();

			// work outside the model
			Family<Reptile> rfamily = CreateReptileFamily();

			familyCrudModel.Save(rfamily); // The user press Apply
			// At this point we have a persistent Family<Reptile> instance but...

			familyCrudModel.CancelAll(); // The user press Cancel
			// At this point all our instance are in a inconsistent state
			// CancelAll is the abort of conversation but...
			// we can continue working in a clear conversation
			// a possible "Refresh" of all existing Family<Reptile>
			IList<Family<Reptile>> l = familyCrudModel.GetEntirelyList();
			Console.WriteLine("Saved Family<Reptile> after Abort; count:" + l.Count);

			// work outside the model
			rfamily = CreateReptileFamily();

			familyCrudModel.Save(rfamily); // At this point we have a persistent Family<Reptile> instance and...
			familyCrudModel.AcceptAll(); // This time the user press the Ok button
			// AcceptAll is the End of conversation but...
			// we can continue working in a clear conversation
			// a possible "Refresh" of all existing Family<Reptile>
			l = familyCrudModel.GetEntirelyList();
			Console.WriteLine("Saved Family<Reptile> after Accept; count:" + l.Count);

			ShowTheReptileFamily(l[0]); // we can access to the lazy relationship/collections

			familyCrudModel.CancelAll(); // This is like the close of the Form
		}

		private static Family<Reptile> CreateReptileFamily()
		{
			var rf = new Reptile {Description = "Crocodile Father"};
			var rm = new Reptile {Description = "Crocodile Mother"};
			var rc1 = new Reptile {Description = "Crocodile Child1"};
			var rc2 = new Reptile {Description = "Crocodile Child2"};
			return new Family<Reptile> {Father = rf, Mother = rm, Childs = new HashedSet<Reptile> {rc1, rc2}};
		}

		private static void ShowTheReptileFamily(Family<Reptile> family)
		{
			Console.WriteLine();
			Console.WriteLine("The Reptile family is :");
			Console.WriteLine("Father=> " + family.Father.Description);
			Console.WriteLine("Mother=> " + family.Mother.Description);
			foreach (Reptile reptile in family.Childs)
			{
				Console.WriteLine("Child=> " + reptile.Description);
			}
			Console.WriteLine("-----------------------");
		}
	}
}