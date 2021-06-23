using System;

namespace Ex04.Menus.Test
{
	public class Program
	{
		public static void Main()
		{
			new Menus.Interfaces.Menu(new Interfaces.RootItem()).Show();

			new Delegates.RootDelegate().Show();
		}
	}
}
