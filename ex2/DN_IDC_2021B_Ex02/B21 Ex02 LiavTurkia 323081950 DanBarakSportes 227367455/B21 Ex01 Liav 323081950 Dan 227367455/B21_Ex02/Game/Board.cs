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

		public enum eCellSequenceStatus
		{
			None,
			Player1,
			Player2,
			Tie
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

		// Returns the first sequence found, or None if there is none currently
		public eCellSequenceStatus GetCellSequence()
		{
			// TODO
			return eCellSequenceStatus.None;
		}
	}
}
