using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace B21_Ex02.Game
{
    class ComputerPlayer : Player
    {
        private readonly Hashtable r_TranspositionTable = new Hashtable();

        private int min(ref Board i_CurrentBoard, out CellPosition o_BestChoice, int i_Alpha, int i_Beta)
        {
            int bestValue = int.MaxValue;
            o_BestChoice = null;
            for (int x = 0; x < i_CurrentBoard.Size; x++)
            {
                for (int y = 0; y < i_CurrentBoard.Size; y++)
                {
                    Board boardCopy = i_CurrentBoard.Clone();
                    CellPosition move = new CellPosition(x, y);
                    if (boardCopy.IsCellObstructed(move))
                    {
                        continue;
                    }

                    int value;
                    boardCopy.SetCell(move, Board.eCellValue.Player2);
                    int boardHash = boardCopy.GetHashCode();
                    if (!this.r_TranspositionTable.Contains(boardHash))
                    {
                        value = this.minimax(ref boardCopy, Game.ePlayer.Player1, out CellPosition temp, i_Alpha, i_Beta);
                        this.r_TranspositionTable[boardHash] = value;
                    }
                    else
                    {
                        value = (int)this.r_TranspositionTable[boardHash];
                    }

                    if (value < bestValue)
                    {
                        bestValue = value;
                        o_BestChoice = move;
                    }

                    i_Beta = Math.Max(i_Beta, value);
                    if (i_Beta <= i_Alpha)
                    {
                        break;
                    }
                }
            }

            return bestValue;
        }

        private int max(ref Board i_CurrentBoard, out CellPosition o_BestChoice, int i_Alpha, int i_Beta)
        {
            int bestValue = int.MinValue;
            o_BestChoice = null;
            for (int x = 0; x < i_CurrentBoard.Size; x++)
            {
                for (int y = 0; y < i_CurrentBoard.Size; y++)
                {
                    Board boardCopy = i_CurrentBoard.Clone();
                    CellPosition move = new CellPosition(x, y);
                    if (boardCopy.IsCellObstructed(move))
                    {
                        continue;
                    }

                    int value;
                    boardCopy.SetCell(move, Board.eCellValue.Player1);
                    int boardHash = boardCopy.GetHashCode();
                    if (!this.r_TranspositionTable.Contains(boardHash))
                    {
                        value = this.minimax(ref boardCopy, Game.ePlayer.Player2, out CellPosition temp, i_Alpha, i_Beta);
                        this.r_TranspositionTable[boardHash] = value;
                    }
                    else
                    {
                        value = (int)this.r_TranspositionTable[boardHash];
                    }

                    if (value > bestValue)
                    {
                        bestValue = value;
                        o_BestChoice = move;
                    }

                    i_Alpha = Math.Max(i_Alpha, value);
                    if (i_Beta <= i_Alpha)
                    {
                        break;
                    }
                }
            }

            return bestValue;
        }

        private int minimax(ref Board i_CurrentBoard, Game.ePlayer i_Player, out CellPosition o_Choice, int i_Alpha, int i_Beta)
        {
            o_Choice = null;
            int returnValue;

            Board.eCellSequenceStatus looser = i_CurrentBoard.GetCellSequence();
            switch (looser)
            {
                case Board.eCellSequenceStatus.Player1:
                    returnValue = -1;
                    break;
                case Board.eCellSequenceStatus.Player2:
                    returnValue = 1;
                    break;
                case Board.eCellSequenceStatus.Tie:
                    returnValue = 0;
                    break;
                default:
                    switch (i_Player)
                    {
                        case Game.ePlayer.Player1:
                            returnValue = this.max(ref i_CurrentBoard, out o_Choice, i_Alpha, i_Beta);
                            break;
                        case Game.ePlayer.Player2:
                            returnValue = this.min(ref i_CurrentBoard, out o_Choice, i_Alpha, i_Beta);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(i_Player), i_Player, null);
                    }

                    break;
            }

            return returnValue;
        }

        public override CellPosition Play(Board i_CurrentBoard)
        {

            this.min(ref i_CurrentBoard, out CellPosition move, int.MaxValue, int.MinValue);
            return move;
        }
    }
}