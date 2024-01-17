using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmManagementSystem
{
	// Class Inherit's from abstract class ItemManager<T>
	public class Taskmanager : ItemManager<Task>
	{
		public Taskmanager(List<Task> tasks) 
			: base(tasks) 
		{

		}
		public override void DisplayMenu()
		{
			Console.WriteLine("Task Management Menu.");
			Console.WriteLine("1. Add Task");
			Console.WriteLine("2. View Task");
			Console.WriteLine("3. Back to Main Menu");
		}

		//Implements methods of abstract Class
		public override void AddItem()
		{
            Console.WriteLine("Enter Task name.");
            string taskName = Console.ReadLine();
			if (ContainsDigits(taskName))
			{
				Console.WriteLine("Invalid task name. Digits are not allowed.");
				return;
			}
			Console.WriteLine("Enter a Task Description");
			string taskDescription = Console.ReadLine();
			Task task = new Task { Name = taskName, Description = taskDescription };
			items.Add(task);
        }
		private bool ContainsDigits(string input)
		{
			return input.Any(char.IsDigit);
		}
		public override void ViewItem()
		{
			if(items.Count == 0) 
			{
				Console.WriteLine("No task added yet");

			}
			else
			{
                foreach(Task task in items)
				{
                    Console.WriteLine($"{task.Name} : {task.Description}");
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
