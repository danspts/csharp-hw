using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
	class Program
	{
		public static void Main(String[] args)
		{
			new Menus.Interfaces.Menu(new Interfaces.RootItem()).Show();
		}
	}
}
