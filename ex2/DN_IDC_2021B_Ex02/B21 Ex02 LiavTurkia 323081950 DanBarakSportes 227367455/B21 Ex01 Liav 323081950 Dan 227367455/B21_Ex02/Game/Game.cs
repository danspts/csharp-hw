using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02
{
	class Game
	{
		private Board m_Board;
		private Player[] m_Players;

		public Game(Board i_Board, Player[] i_Players)
		{
			this.m_Board = i_Board;
			this.m_Players = i_Players;
		}

		public Board Board
		{
			get { return this.m_Board; }
			set { this.m_Board = value; }
		}

		public Player[] Players
		{
			get { return this.m_Players; }
		}

		private void PlayMove(int i_WhoseTurn)
		{
			Player player = this.Players[i_WhoseTurn];

			this.Board.SetCell(player.Play(this.Board), i_WhoseTurn);
		}

		private bool IsGameOver()
		{
			return this.Board.IsBoardFull() || this.Board.GetWinningSequence() != -1;
		}

		// Returns the Winning player or null if was a tie
		public Player PlayGame()
		{
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
