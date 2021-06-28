using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex05
{
	class Program
	{
		public static void Main()
		{
			Interface.UI userInterface = new Interface.WinFormsUI();
			userInterface.Start();
		}
	}
}
