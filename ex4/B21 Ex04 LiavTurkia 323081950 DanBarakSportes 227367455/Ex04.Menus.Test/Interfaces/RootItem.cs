using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test.Interfaces
{
	class RootItem : Menus.Interfaces.MenuItem, Menus.Interfaces.IParental
	{
		public RootItem()
			: base("Main Menu")
		{
		}

		public List<Menus.Interfaces.MenuItem> GetChildren()
		{
			return new List<Menus.Interfaces.MenuItem>()
			{ 
				new VersionAndSpaces(),
				new ShowDateTime(),
			};
		}
	}
}
