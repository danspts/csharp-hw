using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02.Game
{
	class ComputerPlayer : Player
	{
		private readonly System.Random m_Random = new System.Random();

		public override CellPosition Play(Board i_CurrentBoard)
		{
			// TODO make this smart
			CellPosition move;
			do
			{
				move = new CellPosition(this.m_Random.Next(i_CurrentBoard.Size), this.m_Random.Next(i_CurrentBoard.Size));
			} while (i_CurrentBoard.IsCellObstructed(move));
			return move;
		}
	}
}
