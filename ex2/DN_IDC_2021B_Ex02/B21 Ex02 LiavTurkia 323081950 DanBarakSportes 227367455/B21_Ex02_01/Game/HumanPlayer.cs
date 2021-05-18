using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02.Game
{
	class HumanPlayer : Player
	{
		private readonly Interface.UI r_UserInterface;

		public HumanPlayer(Interface.UI i_UserInterface)
		{
			this.r_UserInterface = i_UserInterface;
		}

		public override CellPosition Play(Board i_CurrentBoard)
		{
			return this.r_UserInterface.PromptForMove(i_CurrentBoard);
		}
	}
}
