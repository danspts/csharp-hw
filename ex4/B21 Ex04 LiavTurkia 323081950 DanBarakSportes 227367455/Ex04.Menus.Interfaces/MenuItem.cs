using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
	public abstract class MenuItem
	{
		private readonly string r_Name;

		public MenuItem(string i_Name)
		{
			this.r_Name = i_Name;
		}

		public string Name
		{
			get { return this.r_Name; }
		}
	}
}
