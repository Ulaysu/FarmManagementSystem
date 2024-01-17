using System.Collections.Generic;


namespace FarmManagementSystem
{
	public abstract class ItemManager<T>
	{
		protected List<T> items;
		protected ItemManager(List<T> itemList) 
		{
			items = itemList;
		}
		public abstract void DisplayMenu();
		public abstract void AddItem();
		public abstract void ViewItem();
		public abstract void Run();

	}
}
