using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test.Interfaces
{
	class VersionAndSpaces : Menus.Interfaces.MenuItem, Menus.Interfaces.IParental
	{
		public VersionAndSpaces()
			: base("Version and Spaces")
		{
		}

		public List<Menus.Interfaces.MenuItem> GetChildren()
		{
			return new List<Menus.Interfaces.MenuItem>()
			{
				new ShowVersion(),
				new CountSpaces(),
			};
		}
	}
}
