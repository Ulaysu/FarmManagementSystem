using System;
using System.Collections.Generic;


namespace FarmManagementSystem
{
	// Class Inherit's from abstract class ItemManager<T>

	public class CropManager : ItemManager<Crop>
	{
		
		public CropManager(List<Crop> crops)
			: base(crops) 
		{
			
		}

		//Implements method of abstract Class
		public override void DisplayMenu()
		{
			Console.WriteLine("Crop Management Menu:");
			Console.WriteLine("1. Add Crop");
			Console.WriteLine("2. View Crops");
			Console.WriteLine("3. Back to Main Menu");

		}
		public override void AddItem()
		{
			Console.WriteLine("Enter a Crop name");
			string cropName = Console.ReadLine();

			Console.WriteLine("Enter Crop Quantity");
			int cropQuantity;
			while (!int.TryParse(Console.ReadLine(), out cropQuantity) || cropQuantity <= 0)
			{
				Console.WriteLine("Invalid input. Please Enter a valid positive Quantity.");
			}
			Crop crop = new Crop { Name = cropName, Quantity = cropQuantity };
			items.Add(crop);

		}
		public override void ViewItem()
		{
			if(items.Count == 0) 
			{
                Console.WriteLine("No crops added yet");
            }
			else
			{
				foreach (Crop crop in items)
				{
                    	Console.WriteLine($"{crop.Name}: {crop.Quantity} units");
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
