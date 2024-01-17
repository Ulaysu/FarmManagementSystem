using System;
using System.Collections.Generic;


namespace FarmManagementSystem
{ 
	// Class Inherit's from abstract class ItemManager<T>
	public class LivestockManager: ItemManager<LiveStock>
	{
		public LivestockManager(List<LiveStock> livestocks)
			:base(livestocks) 
		{

		}

		// Implement's methods of abstract class
		public override void DisplayMenu()
		{
			Console.WriteLine("Livestock Management Menu:");
			Console.WriteLine("1. Add Livestock");
			Console.WriteLine("2. View Livestock");
			Console.WriteLine("3. Back to Main Menu");
		}
		public override void AddItem()
		{
			Console.WriteLine("Enter a Livestock name");
			string livestockName = Console.ReadLine();

			Console.WriteLine("Enter Livestock Quantity");
			int livestockQuantity;
			while (!int.TryParse(Console.ReadLine(), out livestockQuantity) || livestockQuantity <= 0)
			{
				Console.WriteLine("Invalid input. Please Enter a valid positive Quantity.");
			}
			LiveStock liveStock = new LiveStock { Name = livestockName, Quantity = livestockQuantity };
			items.Add(liveStock);

		}
		public override void ViewItem()
		{
			if (items.Count == 0)
			{
				Console.WriteLine("No livestock added yet");
			}
			else
			{
				foreach (LiveStock liveStock in items)
				{
					Console.WriteLine($"{liveStock.Name}: {liveStock.Quantity} units");
				}
			}
		}
		public override void Run()
		{
			DisplayMenu();
			while (true)
			{
				Console.WriteLine("Enter an option to perform an Operation");
				string choice = Console.ReadLine();
				switch(choice)
				{
					case "1":
						AddItem();
						break;

					case "2":
						ViewItem(); 
						break;
					case "3":
						return;
					default:
						Console.WriteLine("Invalid choice. Please try again.");
						continue;
				}
            }
		}

	}
}
