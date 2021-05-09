using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02
{
	class Program
	{
		private static void RunGame(Game.Player i_User, Interface.UI i_UserInterface)
		{
			int boardSize = i_UserInterface.PromptForBoardSize();
			Game.Player opponent = i_UserInterface.PromptForOpponent();

			int userScore = 0;
			int opponentScore = 0;
			do
			{
				Game.Player winner = i_UserInterface.PlayGame(new Game.Game(new Game.Board(boardSize), i_User, opponent));
				if (winner == i_User)
				{
					++userScore;
				}
				else
				{
					++opponentScore;
				}

				i_UserInterface.ShowScore(userScore, opponentScore);
			}
			while (i_UserInterface.ShouldGameContinue());
		}

		public static void Main()
		{
			Interface.UI userInterface = new Interface.ConsoleInterface();
			Program.RunGame(new Game.HumanPlayer(userInterface), userInterface);
		}
	}
}
