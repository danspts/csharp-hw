using B21_Ex02.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02.Interface
{
	class ConsoleInterface : TextBasedInterface
	{
		protected sealed override string ReadLine()
		{
			string result = System.Console.ReadLine();
			if (result == "Q")
			{
				System.Environment.Exit(0);
			}

			return result;
		}

		protected sealed override void WriteLine(string i_Line)
		{
			System.Console.WriteLine(i_Line);
		}
	}
}
