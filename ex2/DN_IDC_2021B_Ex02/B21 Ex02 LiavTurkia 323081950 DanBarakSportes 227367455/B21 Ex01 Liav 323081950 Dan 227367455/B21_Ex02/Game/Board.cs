using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02.Game
{
	class Board
	{
		public enum eCellValue
		{
			None,
			Player1,
			Player2
		}

		private readonly int m_Size;

		private eCellValue[,] m_Cells;

		public Board(int i_Size)
		{
			this.m_Size = i_Size;
			this.m_Cells = new eCellValue[i_Size, i_Size];
		}

		public int Size
		{
			get { return this.m_Size; }
		}

		public void SetCell(CellPosition i_Position, eCellValue i_CellValue)
		{
			this.m_Cells[i_Position.X, i_Position.Y] = i_CellValue;
		}

		public eCellValue GetCell(CellPosition i_Position)
		{
			return this.m_Cells[i_Position.X, i_Position.Y];
		}

		public bool IsCellObstructed(CellPosition i_Position)
		{
			return this.GetCell(i_Position) != eCellValue.None;
		}

		// Returns the winning coin, or -1 if it doesn't exist
		public eCellValue GetWinningSequence(out bool o_IsTie)
		{
			// TODO
			o_IsTie = false;
			return eCellValue.None;
		}
	}
}
