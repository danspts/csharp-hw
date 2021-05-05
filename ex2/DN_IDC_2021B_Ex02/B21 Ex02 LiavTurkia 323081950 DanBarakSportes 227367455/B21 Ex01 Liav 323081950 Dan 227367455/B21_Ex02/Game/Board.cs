using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02
{
	class Board
	{
		private readonly int m_Size;

		private int[,] m_Cells;

		public Board(int i_Size)
		{
			this.m_Size = i_Size;
			this.m_Cells = new int[i_Size, i_Size];
		}

		public int Size
		{
			get { return this.m_Size; }
		}

		public void SetCell(CellPosition i_Position, int i_PlayerID)
		{
			this.m_Cells[i_Position.X, i_Position.Y] = i_PlayerID;
		}

		// Returns whether every cell of the board is full
		public bool IsBoardFull()
		{
			// TODO
			return false;
		}

		// Returns the winning coin, or -1 if it doesn't exist
		public int GetWinningSequence()
		{
			// TODO
			return -1;
		}
	}
}
