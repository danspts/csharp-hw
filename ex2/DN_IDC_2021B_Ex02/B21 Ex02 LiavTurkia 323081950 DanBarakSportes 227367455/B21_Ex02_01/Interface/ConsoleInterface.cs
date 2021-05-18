using B21_Ex02.Game;

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

		protected sealed override void ClearScreen()
		{
			Ex02.ConsoleUtils.Screen.Clear();
		}
	}
}
