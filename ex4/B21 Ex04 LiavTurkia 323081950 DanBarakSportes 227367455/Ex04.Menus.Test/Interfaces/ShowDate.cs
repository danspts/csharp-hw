using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test.Interfaces
{
	class ShowDate : Menus.Interfaces.MenuItem, Menus.Interfaces.IDescribable
	{
		public ShowDate()
			: base("Show Date")
		{
		}

		public string Description
		{
			get { return DateTime.Now.ToString("dd/MM/yyyy"); }
		}
	}
}
