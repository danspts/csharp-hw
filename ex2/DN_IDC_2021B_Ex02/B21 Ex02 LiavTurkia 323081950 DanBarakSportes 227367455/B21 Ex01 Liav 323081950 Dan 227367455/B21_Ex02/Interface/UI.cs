using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02.Interface
{
	abstract class UI
	{
		public abstract int PromptForBoardSize();

		public abstract Game.Player PromptForOpponent();

		public abstract Game.Player PlayGame(Game.Game i_Game);

		public abstract void ShowScore(int i_Player1, int i_Player2, int ties);

		public abstract Game.CellPosition PromptForMove(Game.Board i_Board);

		public abstract bool ShouldGameContinue();
	}
}
