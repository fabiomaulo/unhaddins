using System;
using Microsoft.Practices.ServiceLocation;
using uNhAddIns.Example.MultiSessionConversationUsage.BusinessLogic;
using uNhAddIns.Example.MultiSessionConversationUsage.Entities;

namespace uNhAddIns.Example.MultiSessionConversationUsage
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceLocatorProvider.Initialize();

			CreateAnimal();
			WorkWithAnimal();
			
			CreatePerson();
			WorkWithPerson();

			Console.ReadLine();
		}

		private static void WorkWithPerson()
		{
			var personModel = ServiceLocator.Current.GetInstance<IPersonCrudModel>();
			foreach (var person in personModel.GetAllPersons())
			{
				Console.WriteLine(person.Name);
			}
			personModel.AcceptAll();
		}

		private static void CreatePerson()
		{
			var personModel = ServiceLocator.Current.GetInstance<IPersonCrudModel>();
			personModel.Save(new Person {Name = "Tito"});
			personModel.Save(new Person { Name = "Pepe" });
			personModel.Save(new Person { Name = "Juancho" });
			personModel.AcceptAll();
		}

		private static void CreateAnimal()
		{
			// Instatiation of the model: you can use it from the Form or better from presenter (MVP)
			var animalModel = ServiceLocator.Current.GetInstance<IAnimalCrudModel>();

			animalModel.Save(new Animal { Description = "animal"}); // The user press Apply
			// At this point we have a persistent Family<Reptile> instance but...

			animalModel.Save(new Animal { Description = "manimal"}); // At this point we have a persistent Family<Reptile> instance and...
			animalModel.AcceptAll(); // This time the user press the Ok button	
		}

		private static void WorkWithAnimal()
		{
			var animalModel = ServiceLocator.Current.GetInstance<IAnimalCrudModel>();

			foreach (var animal in animalModel.GetAll())
			{
				Console.WriteLine(animal.Description);
			}
		}
	}
}
