using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex05.Game
{
    public class BoardCount
    {
        private int m_PlayerCountX;
        private int m_PlayerCountO;

        BoardCount()
        {
            this.m_PlayerCountX = 0;
            this.m_PlayerCountO = 0;
        }

        public static void InitBoardCounts(ref BoardCount[] i_BoardCounts, int i_Size)
        {
            i_BoardCounts = new BoardCount[i_Size];
            for (int i = 0; i < i_BoardCounts.Length; i++)
            {
                i_BoardCounts[i] = new BoardCount();
            }
        }

        public void AddPlayerCount(Board.eCellValue i_Player)
        {
            if (i_Player == Board.eCellValue.Player1)
            {
                ++this.m_PlayerCountX;
            }
            else
            {
                ++this.m_PlayerCountO;
            }
        }

        public int GetTotal()
        {
            return this.m_PlayerCountX + this.m_PlayerCountO;
        }

        public Board.eCellSequenceStatus GetSequenceStatus(int i_BoardSize)
        {
            Board.eCellSequenceStatus status = Board.eCellSequenceStatus.None;

            if (this.GetTotal() == i_BoardSize)
            {
                if (this.m_PlayerCountX == i_BoardSize)
                {
                    status = Board.eCellSequenceStatus.Player1;
                }
                else if (this.m_PlayerCountO == i_BoardSize)
                {
                    status = Board.eCellSequenceStatus.Player2;
                }
            }

            return status;
        }
    }
}
