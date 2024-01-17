using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace FarmManagementSystem
{
	public class FarmManagementSys
	{
		private List<Crop> crops;
		private List<LiveStock> liveStocks;
		private List<Equipment> equipment;
		private List<Task> tasks;

		public FarmManagementSys()
		{
			crops = new List<Crop>();
			liveStocks = new List<LiveStock>();
			equipment = new List<Equipment>();
			tasks = new List<Task>();
			LoadData();
		}
		//Main Menu of system
		private void DisplayMenu() 
		{
			Console.WriteLine("Farm Management System Menu:");
			Console.WriteLine("1. Manage Crops");
			Console.WriteLine("2. Manage Livestock");
			Console.WriteLine("3. Manage Equipment");
			Console.WriteLine("4. Manage Tasks");
			Console.WriteLine("5. Save and Exit");
		}
		public void Run() 
		{
           DisplayMenu();
			// User Interation on system
			while (true)
			{
				Console.WriteLine("Choose an option");
				string choice = Console.ReadLine();
				switch (choice)
				{
					case "1":
						ManageCrops();
						break;
					case "2":
						ManageLiveStock();
						break;
					case "3":
						ManageEquipment();
						break;
					case "4":
						ManageTasks();
						break;	
					case "5":
						SaveData();
						return;
					default:
                        Console.WriteLine("Enter a valid option");
						continue;	
                }
			}

        }
		// Methods for calling Manager methods
		private void ManageCrops() 
		{
			CropManager cropManager = new CropManager(crops);
			cropManager.Run();
		}
		private void ManageLiveStock() 
		{
			LivestockManager livestockManager = new LivestockManager(liveStocks);
			livestockManager.Run();
		}
		private void ManageEquipment() 
		{
			EquipmentManager equipmentManager = new EquipmentManager(equipment);
			equipmentManager.Run();
		}
		private void ManageTasks()
		{
			Taskmanager taskManager = new Taskmanager(tasks);
			taskManager.Run();
		}

		// Saving data to json File
		private void SaveData()
		{
				string jsonData = JsonConvert.SerializeObject(
				new {Crop = crops, LiveStock = liveStocks, Equipment = equipment, Task = tasks });
				File.WriteAllText("farm_data.json", jsonData);
		}

		// Method for Loading saved data.
		private void LoadData()
		{
			try
			{
				string jsonData = File.ReadAllText("farm_data.json");
				var data = JsonConvert.DeserializeObject<dynamic>(jsonData);
				crops = data.Crop.ToObject<List<Crop>>();
				liveStocks = data.LiveStock.ToObject<List<LiveStock>>();
				equipment = data.Equipment.ToObject<List<Equipment>>();
				tasks = data.Task.ToObject<List<Task>>();
			}
			catch(FileNotFoundException) 
			{
				// Ignore 
				Console.WriteLine("No farm data found");

			}
		}



	}
}
