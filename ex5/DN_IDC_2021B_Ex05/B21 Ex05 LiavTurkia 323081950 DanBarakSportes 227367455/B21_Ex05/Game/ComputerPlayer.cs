using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace B21_Ex05.Game
{
    public class ComputerPlayer : Player
    {
        private readonly System.Random m_Random = new System.Random();

        public ComputerPlayer(string i_Name)
            : base(i_Name)
        {
        }

        public override void OnGameJoined(Game i_Game)
        {
            i_Game.BeforeRound += this.Game_BeforeRound;
        }

        private void Game_BeforeRound(Game i_Sender, Player i_Turn)
        {
            // Play our turn
            if (i_Turn == this)
            {
                CellPosition move;
                do
                {
                    move = new CellPosition(
                        (int)this.m_Random.Next(i_Sender.Board.Size),
                        (int)this.m_Random.Next(i_Sender.Board.Size));
                }
                while (i_Sender.Board.IsCellObstructed(move));

                i_Sender.OnMove(move);
            }
        }
    }
}