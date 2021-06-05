using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test.Interfaces
{
	class ShowVersion : Menus.Interfaces.MenuItem, Menus.Interfaces.IDescribable
	{
		public ShowVersion()
			: base("Show Version")
		{
		}

		public string Description
		{
			get { return "App Version: 21.1.4.8930";  }
		}
	}
}
