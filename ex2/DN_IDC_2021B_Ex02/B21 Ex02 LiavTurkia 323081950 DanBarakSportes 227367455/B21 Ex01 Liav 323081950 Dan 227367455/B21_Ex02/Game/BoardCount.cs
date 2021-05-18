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
}
