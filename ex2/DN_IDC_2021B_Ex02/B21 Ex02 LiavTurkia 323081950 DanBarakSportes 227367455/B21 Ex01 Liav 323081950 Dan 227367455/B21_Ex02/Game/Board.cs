using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02.Game
{
    class Board
    {
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

        private readonly int m_Size;

        private readonly eCellValue[,] m_Cells;

        private readonly BoardCount[] boardCountRow;
        private readonly BoardCount[] boardCountColumn;
        private readonly BoardCount[] boardCountDiagonal;

        private int m_NumberFullCells = 0;

        public Board(int i_Size)
        {
            this.m_Size = i_Size;
            this.m_Cells = new eCellValue[i_Size, i_Size];
            BoardCount.initBoardCounts(ref this.boardCountRow, i_Size);
            BoardCount.initBoardCounts(ref this.boardCountColumn, i_Size);
            BoardCount.initBoardCounts(ref this.boardCountDiagonal, 2);
        }

        public int getNBOfCells()
        {
            return this.m_NumberFullCells;
        }

        public int Size
        {
            get { return this.m_Size; }
        }

        internal bool isFull()
        {
            return this.m_Size * this.m_Size == this.m_NumberFullCells;
        }

        public void SetCell(CellPosition i_Position, eCellValue i_CellValue)
        {
            this.m_Cells[i_Position.X, i_Position.Y] = i_CellValue;

            if (i_CellValue != eCellValue.None)
            {
                if (i_Position.X == i_Position.Y)
                {
                    this.boardCountDiagonal[0].addPlayerCount(i_CellValue);
                }

                if (i_Position.X + i_Position.Y + 1 == this.m_Size)
                {
                    this.boardCountDiagonal[1].addPlayerCount(i_CellValue);
                }

                this.boardCountRow[i_Position.Y].addPlayerCount(i_CellValue);
                this.boardCountColumn[i_Position.X].addPlayerCount(i_CellValue);
                ++this.m_NumberFullCells;
            }
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
            eCellSequenceStatus status = eCellSequenceStatus.None;

            foreach (BoardCount count in this.boardCountRow)
            {
                if (status != eCellSequenceStatus.None)
                {
                    break;
                }

                status = count.getSequenceStatus(this.m_Size);
            }

            foreach (BoardCount count in this.boardCountColumn)
            {
                if (status != eCellSequenceStatus.None)
                {
                    break;
                }

                status = count.getSequenceStatus(this.m_Size);
            }

            foreach (BoardCount count in this.boardCountDiagonal)
            {
                if (status != eCellSequenceStatus.None)
                {
                    break;
                }

                status = count.getSequenceStatus(this.m_Size);
            }

            if (status == eCellSequenceStatus.None && this.isFull())
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
            return -1701819646 + EqualityComparer<eCellValue[,]>.Default.GetHashCode(this.m_Cells);
        }
    }
}