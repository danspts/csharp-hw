using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test.Interfaces
{
	class ShowDateTime : Menus.Interfaces.MenuItem, Menus.Interfaces.IParental
	{
		public ShowDateTime()
			: base("Show Date/Time")
		{
		}

		public List<Menus.Interfaces.MenuItem> GetChildren()
		{
			return new List<Menus.Interfaces.MenuItem>()
			{
				new ShowTime(),
				new ShowDate(),
			};
		}
	}
}
