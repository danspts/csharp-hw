using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02.Interface
{
	abstract class TextBasedInterface : UI
	{
		// Subclasses should override this functions to create a Text-Based game
		protected abstract string ReadLine();

		protected abstract void WriteLine(string i_Line);

		public override Game.Player PlayGame(Game.Game i_Game)
		{
			throw new NotImplementedException();
		}

		public override int PromptForBoardSize()
		{
			throw new NotImplementedException();
		}

		public override Game.CellPosition PromptForMove(Game.Board i_Board)
		{
			throw new NotImplementedException();
		}

		public override Game.Player PromptForOpponent()
		{
			throw new NotImplementedException();
		}

		public override bool ShouldGameContinue()
		{
			throw new NotImplementedException();
		}

		public override void ShowScore(int i_Player1, int i_Player2)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("Current Score:");
			builder.AppendLine(string.Format("You: %d", i_Player1));
			builder.AppendLine(string.Format("Opponent: %d", i_Player2));
			this.WriteLine(builder.ToString());
		}
	}
}
