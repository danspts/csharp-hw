using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02.Game
{
    class BoardCount
    {
        private int playerCountX;
        private int playerCountO;

        BoardCount()
        {
            this.playerCountX = 0;
            this.playerCountO = 0;
        }

        public static void initBoardCounts(ref BoardCount[] i_BoardCounts, int i_Size)
        {
            i_BoardCounts = new BoardCount[i_Size];
            for (int i = 0; i < i_BoardCounts.Length; i++)
            {
                i_BoardCounts[i] = new BoardCount();
            }
        }

        public void addPlayerCount(Board.eCellValue player)
        {
            if (player == Board.eCellValue.Player1)
            {
                ++this.playerCountX;
            }
            else
            {
                ++this.playerCountO;
            }
        }

        private int getTotal()
        {
            return this.playerCountX + this.playerCountO;
        }

        public Board.eCellSequenceStatus getSequenceStatus(int boardSize)
        {
            Board.eCellSequenceStatus status = Board.eCellSequenceStatus.None;

            if (this.getTotal() == boardSize)
            {
                if (this.playerCountX == boardSize)
                {
                    status = Board.eCellSequenceStatus.Player1;
                }
                else if (this.playerCountO == boardSize)
                {
                    status = Board.eCellSequenceStatus.Player2;
                }
            }

            return status;
        }
    }

    class Board
    {
        public enum eCellSequenceStatus
        {
            None,
            Player1,
            Player2,
            Tie
        }

        public enum eCellValue
        {
            None,
            Player1,
            Player2
        }


        private readonly int m_Size;

        private eCellValue[,] m_Cells;
        private int m_NumberFullCells = 0;

        private BoardCount[] boardCountRow;
        private BoardCount[] boardCountColumn;
        private BoardCount[] boardCountDiagonal;

        public Board(int i_Size)
        {
            this.m_Size = i_Size;
            this.m_Cells = new eCellValue[i_Size, i_Size];
            BoardCount.initBoardCounts(ref this.boardCountRow, i_Size);
            BoardCount.initBoardCounts(ref this.boardCountColumn, i_Size);
            BoardCount.initBoardCounts(ref this.boardCountDiagonal, 2);
        }

        public int Size
        {
            get { return this.m_Size; }
        }

        private bool isFull()
        {
            return this.m_Size * this.m_Size == this.m_NumberFullCells;
        }

        public void SetCell(CellPosition i_Position, eCellValue i_CellValue)
        {
            this.m_Cells[i_Position.X, i_Position.Y] = i_CellValue;

            if (i_Position.X == i_Position.Y)
            {
                this.boardCountDiagonal[0].addPlayerCount(i_CellValue);
            }

            if (i_Position.X + i_Position.Y + 1 == this.m_Size)
            {
                Console.WriteLine("HELLLLOOOOOOO DIAGONAL");
                this.boardCountDiagonal[1].addPlayerCount(i_CellValue);
            }

            this.boardCountRow[i_Position.Y].addPlayerCount(i_CellValue);
            this.boardCountColumn[i_Position.X].addPlayerCount(i_CellValue);
            ++this.m_NumberFullCells;
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
    }
}