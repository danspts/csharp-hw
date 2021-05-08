using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02.Game
{
	class Game
	{
		public enum ePlayer
		{
			Player1,
			Player2
		}

		private Board m_Board;
		private Player m_Player1;
		private Player m_Player2;

		public Game(Board i_Board, Player i_Player1, Player i_Player2)
		{
			this.m_Board = i_Board;
			this.m_Player1 = i_Player1;
			this.m_Player2 = i_Player2;
		}

		public Board Board
		{
			get { return this.m_Board; }
			set { this.m_Board = value; }
		}

		public Player GetPlayer(ePlayer i_Who)
		{
			return i_Who == ePlayer.Player1 ? this.m_Player1 : this.m_Player2;
		}

		private void PlayMove(ePlayer i_WhoseTurn)
		{
			Player player = this.GetPlayer(i_WhoseTurn);

			Board.eCellValue cellValue;
			switch (i_WhoseTurn)
			{
				case ePlayer.Player1:
					cellValue = Board.eCellValue.Player1;
					break;
				case ePlayer.Player2:
					cellValue = Board.eCellValue.Player2;
					break;
				// Should never happen (because of the values of ePlayer)
				// But here for safety
				default:
					cellValue = Board.eCellValue.None;
					break;
			}

			this.Board.SetCell(player.Play(this.Board), cellValue);
		}


		// Returns the Winning player or null if was a tie
		public Player PlayGame(UI.UI i_UserInterface)
		{
			i_UserInterface.StartGame(this);
			int currentTurn = 0;
			while (!this.IsGameOver())
			{
				this.PlayMove(currentTurn);
				currentTurn = (currentTurn + 1) % this.Players.Length;
			}

			int winningSequence = this.Board.GetWinningSequence();
			return winningSequence >= 0 ? this.Players[winningSequence] : null;
		}
	}
}
