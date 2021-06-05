using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test.Interfaces
{
	class ShowTime : Menus.Interfaces.MenuItem, Menus.Interfaces.IDescribable
	{
		public ShowTime()
			: base("Show Time")
		{
		}

		public string Description
		{
			get { return DateTime.Now.ToString("h:mm tt"); }
		}
	}
}
