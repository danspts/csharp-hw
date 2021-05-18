using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02.Game
{
	class HumanPlayer : Player
	{
		private readonly Interface.UI m_UserInterface;

		public HumanPlayer(Interface.UI i_UserInterface)
		{
			this.m_UserInterface = i_UserInterface;
		}

		public override CellPosition Play(Board i_CurrentBoard)
		{
			return this.m_UserInterface.PromptForMove(i_CurrentBoard);
		}
	}
}
