using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex05.Game
{
    public class Game
    {

        public delegate void RoundEventHandler(Game i_Sender, Player i_Turn);
        public delegate void GameOverHandler(Game i_Sender, Player i_Victor);

        public event RoundEventHandler BeforeRound;
        public event RoundEventHandler AfterRound;
        public event GameOverHandler GameOver;

        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private Player m_CurrentTurn;
        private Board m_Board;

        public Game(Board i_Board, Player i_Player1, Player i_Player2)
        {
            this.m_Board = i_Board;
            this.r_Player1 = i_Player1;
            this.r_Player2 = i_Player2;

            this.m_CurrentTurn = this.Player1;

            this.AfterRound += Game_AfterRound;
        }

        public Game(GameSettings i_Settings)
            : this(new Board(i_Settings.BoardSize), i_Settings.Player1, i_Settings.Player2)
		{
		}

        public Board Board
        {
            get { return this.m_Board; }
            set { this.m_Board = value; }
        }

        public Player Player1
		{
            get { return this.r_Player1; }
		}

        public Player Player2
		{
            get { return this.r_Player2; }
		}

        public Player CurrentTurn
		{
            get { return this.m_CurrentTurn; }
		}
        public void Start()
		{
            this.Player1.OnGameJoined(this);
            this.Player2.OnGameJoined(this);

            if (this.BeforeRound != null)
            {
                this.BeforeRound.Invoke(this, this.m_CurrentTurn);
            }
        }

        // Out variable is null if tie, otherwise it's who won
        private bool isGameOver(out Player o_Victor)
        {
            Board.eCellSequenceStatus sequence = this.Board.GetCellSequence();

            if (sequence == Board.eCellSequenceStatus.Player1)
            {
                o_Victor = this.Player2;
            }
            else if (sequence == Board.eCellSequenceStatus.Player2)
            {
                o_Victor = this.Player1;
            }
            else
            {
                o_Victor = null;
            }

            return sequence != Board.eCellSequenceStatus.None;
        }

        public void OnMove(CellPosition i_Move)
        {
            Board.eCellValue cellValue;
            if(this.m_CurrentTurn == this.Player1)
			{
                cellValue = Board.eCellValue.Player1;
            }
			else if(this.m_CurrentTurn == this.Player2)
            {
                cellValue = Board.eCellValue.Player2;
            }
            else
            {
                // Should never happen
                // But here for safety
                cellValue = Board.eCellValue.None;
            }

            this.Board.SetCell(i_Move, cellValue);

            if (this.AfterRound != null)
			{
                this.AfterRound.Invoke(this, this.m_CurrentTurn);
			}
            
        }

        private void Game_AfterRound(Game i_Sender, Player i_Turn)
        {
            if(this.isGameOver(out Player winner))
			{
                if(this.GameOver != null)
				{
                    this.GameOver.Invoke(this, winner);
				}
			}
			else
            {
                // Switch turn and notify that it's next round
                if (this.m_CurrentTurn == this.Player1)
                {
                    this.m_CurrentTurn = this.Player2;
                }
                else
                {
                    this.m_CurrentTurn = this.Player1;
                }

                if (this.BeforeRound != null)
                {
                    this.BeforeRound.Invoke(this, this.m_CurrentTurn);
                }
            }
        }
    }
}