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

        public enum eGameResult
        {
            Player1,
            Player2,
            Tie
        }

        private readonly Player m_Player1;
        private readonly Player m_Player2;
        private ePlayer m_CurrentTurn = ePlayer.Player1;
        private Board m_Board;

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

        // Out variable is null if tie, otherwise it's who won
        public bool IsGameOver(out Player o_Victor)
        {
            Board.eCellSequenceStatus sequence = this.Board.GetCellSequence();

            if (sequence == Board.eCellSequenceStatus.Player1)
            {
                o_Victor = this.m_Player2;
            }
            else if (sequence == Board.eCellSequenceStatus.Player2)
            {
                o_Victor = this.m_Player1;
            }
            else
            {
                o_Victor = null;
            }

            return sequence != Board.eCellSequenceStatus.None;
        }

        public void PlayRound()
        {
            this.PlayMove(this.m_CurrentTurn);
            if (this.m_CurrentTurn == ePlayer.Player1)
            {
                this.m_CurrentTurn = ePlayer.Player2;
            }
            else
            {
                this.m_CurrentTurn = ePlayer.Player1;
            }
        }
    }
}