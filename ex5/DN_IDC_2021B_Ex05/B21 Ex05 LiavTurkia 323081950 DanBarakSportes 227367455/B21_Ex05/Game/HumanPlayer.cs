using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex05.Game
{
	class HumanPlayer : Player
	{
		private readonly Interface.UI r_UserInterface;

		public HumanPlayer(string i_Name, Interface.UI i_UserInterface)
			: base(i_Name)
		{
			this.r_UserInterface = i_UserInterface;
		}

		public override CellPosition Play(Board i_CurrentBoard)
		{
			return this.r_UserInterface.PromptForMove(i_CurrentBoard);
		}
	}
}
