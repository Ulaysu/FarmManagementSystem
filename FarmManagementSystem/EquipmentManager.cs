using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace FarmManagementSystem
{
	// Class Inherit's from abstract class ItemManager<T>
	public class EquipmentManager : ItemManager<Equipment>
	{
		public EquipmentManager(List<Equipment> equipment)
			:base(equipment)
		{
			
		}

		//Implements method of abstract Class
		public override void DisplayMenu()
		{
            Console.WriteLine("Equipment Management Menu.");
            Console.WriteLine("1. Add Equipment");
            Console.WriteLine("2. View Equipment");
			Console.WriteLine("3. Back to Main Menu");
        }
		public override void AddItem()
		{
            Console.WriteLine("Enter Equipment name");
			string equipmentName = Console.ReadLine();

            Console.WriteLine("Enter Equipment Quantity");
			int equipmentQuantity;
			while (!int.TryParse(Console.ReadLine(),out equipmentQuantity) || equipmentQuantity <= 0) 
			{
				Console.WriteLine("Invalid input. Please Enter a valid positive Quantity.");
			}
            Equipment equipment = new Equipment { Name= equipmentName, Quantity = equipmentQuantity};
			items.Add(equipment);
        }
		public override void ViewItem()
		{
			if(items.Count == 0) 
			{
				Console.WriteLine("Equipment not added yet.");
			}
            else
            {
                foreach(Equipment equipment in items)
				{
					Console.WriteLine($"{equipment.Name}: {equipment.Quantity} ");
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
				switch (choice)
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
