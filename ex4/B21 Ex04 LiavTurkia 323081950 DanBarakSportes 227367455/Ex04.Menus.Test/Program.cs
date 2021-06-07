using System;

namespace Ex04.Menus.Test
{
	class Program
	{
		public static void Main(String[] args)
		{
			new Delegates.RootDelegate().Show();
			
			// new Menus.Interfaces.Menu(new Interfaces.RootItem()).Show();
		}
	}
}
