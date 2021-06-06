using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
	class Program
	{
		public static void Main(String[] args)
		{
			Delegates.RootDelegate.Show(new Delegates.RootDelegate());
			
			new Menus.Interfaces.Menu(new Interfaces.RootItem()).Show();
		}
	}
}
