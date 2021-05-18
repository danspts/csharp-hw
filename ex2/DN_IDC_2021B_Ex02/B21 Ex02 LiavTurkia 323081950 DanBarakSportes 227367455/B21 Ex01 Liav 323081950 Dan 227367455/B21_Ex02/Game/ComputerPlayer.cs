﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace B21_Ex02.Game
{
    class ComputerPlayer : Player
    {
        private readonly System.Random m_Random = new System.Random();
        Hashtable transpositionTable = new Hashtable();


        private int min(ref Board i_CurrentBoard, out CellPosition bestChoice, int alpha, int beta)
        {
            int bestValue = int.MaxValue;
            bestChoice = null;
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
                    if (!this.transpositionTable.Contains(boardHash))
                    {
                        value = minimax(ref boardCopy, Game.ePlayer.Player1, out CellPosition temp, alpha, beta);
                        this.transpositionTable[boardHash] = value;
                    }
                    else
                    {
                        value = (int) this.transpositionTable[boardHash];
                    }

                    if (value < bestValue)
                    {
                        bestValue = value;
                        bestChoice = move;
                    }

                    beta = Math.Max(beta, value);
                    if (beta <= alpha)
                    {
                        break;
                    }
                }
            }

            return bestValue;
        }

        private int max(ref Board i_CurrentBoard, out CellPosition bestChoice, int alpha, int beta)
        {
            int bestValue = int.MinValue;
            bestChoice = null;
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
                    if (!this.transpositionTable.Contains(boardHash))
                    {
                        value = minimax(ref boardCopy, Game.ePlayer.Player2, out CellPosition temp, alpha, beta);
                        this.transpositionTable[boardHash] = value;
                    }
                    else
                    {
                        value = (int) this.transpositionTable[boardHash];
                    }

                    if (value > bestValue)
                    {
                        bestValue = value;
                        bestChoice = move;
                    }

                    alpha = Math.Max(alpha, value);
                    if (beta <= alpha)
                    {
                        break;
                    }
                }
            }

            return bestValue;
        }

        private int minimax(ref Board i_CurrentBoard, Game.ePlayer player, out CellPosition choice, int alpha, int beta)
        {
            choice = null;
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
                    switch (player)
                    {
                        case Game.ePlayer.Player1:
                            returnValue = this.max(ref i_CurrentBoard, out choice, alpha, beta);
                            break;
                        case Game.ePlayer.Player2:
                            returnValue = this.min(ref i_CurrentBoard, out choice, alpha, beta);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(player), player, null);
                    }

                    break;
            }


            return returnValue;
        }

        private CellPosition randomMove(Board i_CurrentBoard)
        {
            CellPosition move;
            do
            {
                move = new CellPosition(
                    this.m_Random.Next(i_CurrentBoard.Size),
                    this.m_Random.Next(i_CurrentBoard.Size));
            } while (i_CurrentBoard.IsCellObstructed(move));

            return move;
        }

        private CellPosition bestMove(Board i_CurrentBoard)
        {
            this.min(ref i_CurrentBoard, out CellPosition move, Int32.MaxValue, Int32.MinValue);
            return move;
        }


        public override CellPosition Play(Board i_CurrentBoard)
        {
            return this.bestMove(i_CurrentBoard);
            if (i_CurrentBoard.Size * i_CurrentBoard.Size - i_CurrentBoard.getNBOfCells() < 16)
            {
                return this.bestMove(i_CurrentBoard);
            }
            else
            {
                return this.randomMove(i_CurrentBoard);
            }
        }
    }
}