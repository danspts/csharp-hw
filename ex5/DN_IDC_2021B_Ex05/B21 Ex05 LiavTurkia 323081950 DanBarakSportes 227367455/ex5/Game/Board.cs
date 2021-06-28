using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex05.Game
{
    public class Board
    {
        public delegate void CellEventHandler(Board i_Sender, CellPosition i_Position, eCellValue i_CellValue);

        public event CellEventHandler CellUpdated;

        public enum eCellSequenceStatus
        {
            None = 0,
            Player1,
            Player2,
            Tie,
        }

        public enum eCellValue
        {
            None = 0,
            Player1,
            Player2,
        }

        private readonly int r_Size;

        private readonly eCellValue[,] r_Cells;

        private readonly BoardCount[] r_BoardCountRow;
        private readonly BoardCount[] r_BoardCountColumn;
        private readonly BoardCount[] r_BoardCountDiagonal;

        private int m_NumberFullCells = 0;

        public Board(int i_Size)
        {
            this.r_Size = i_Size;
            this.r_Cells = new eCellValue[i_Size, i_Size];
            BoardCount.InitBoardCounts(ref this.r_BoardCountRow, i_Size);
            BoardCount.InitBoardCounts(ref this.r_BoardCountColumn, i_Size);
            BoardCount.InitBoardCounts(ref this.r_BoardCountDiagonal, 2);
        }

        public int GetNumberOfCells()
        {
            return this.m_NumberFullCells;
        }

        public int Size
        {
            get { return this.r_Size; }
        }

        public bool IsFull()
        {
            return this.r_Size * this.r_Size == this.m_NumberFullCells;
        }

        public void SetCell(CellPosition i_Position, eCellValue i_CellValue)
        {
            this.r_Cells[i_Position.X, i_Position.Y] = i_CellValue;

            if (this.CellUpdated != null)
			{
                this.CellUpdated.Invoke(this, i_Position, i_CellValue);
			}

            if (i_CellValue != eCellValue.None)
            {
                if (i_Position.X == i_Position.Y)
                {
                    this.r_BoardCountDiagonal[0].AddPlayerCount(i_CellValue);
                }

                if (i_Position.X + i_Position.Y + 1 == this.r_Size)
                {
                    this.r_BoardCountDiagonal[1].AddPlayerCount(i_CellValue);
                }

                this.r_BoardCountRow[i_Position.Y].AddPlayerCount(i_CellValue);
                this.r_BoardCountColumn[i_Position.X].AddPlayerCount(i_CellValue);
                ++this.m_NumberFullCells;
            }
        }

        public eCellValue GetCell(CellPosition i_Position)
        {
            return this.r_Cells[i_Position.X, i_Position.Y];
        }

        public bool IsCellObstructed(CellPosition i_Position)
        {
            return this.GetCell(i_Position) != eCellValue.None;
        }

        // Returns the first sequence found, or None if there is none currently
        public eCellSequenceStatus GetCellSequence()
        {
            eCellSequenceStatus status = eCellSequenceStatus.None;

            foreach (BoardCount count in this.r_BoardCountRow)
            {
                if (status != eCellSequenceStatus.None)
                {
                    break;
                }

                status = count.GetSequenceStatus(this.r_Size);
            }

            foreach (BoardCount count in this.r_BoardCountColumn)
            {
                if (status != eCellSequenceStatus.None)
                {
                    break;
                }

                status = count.GetSequenceStatus(this.r_Size);
            }

            foreach (BoardCount count in this.r_BoardCountDiagonal)
            {
                if (status != eCellSequenceStatus.None)
                {
                    break;
                }

                status = count.GetSequenceStatus(this.r_Size);
            }

            if (status == eCellSequenceStatus.None && this.IsFull())
            {
                status = eCellSequenceStatus.Tie;
            }

            return status;
        }

        public Board Clone()
        {
            Board copy = new Board(this.Size);

            for (int x = 0; x < this.Size; ++x)
			{
                for (int y = 0; y < this.Size; ++y)
				{
                    CellPosition pos = new CellPosition(x, y);
                    copy.SetCell(pos, this.GetCell(pos));
                }
			}

            return copy;
        }

        public string HashString()
        {
            string hashString = string.Empty;
            CellPosition pos;
            for (int x = 0; x < this.Size; ++x)
            {
                for (int y = 0; y < this.Size; ++y)
                {
                    pos = new CellPosition(x, y);
                    hashString += this.GetCell(pos);
                }
            }

            return hashString;
        }

        public override int GetHashCode()
        {
            return -1701819646 + EqualityComparer<eCellValue[,]>.Default.GetHashCode(this.r_Cells);
        }
    }
}