using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex05.Game
{
	class HumanPlayer : Player
	{
		public HumanPlayer(string i_Name)
			: base(i_Name)
		{
		}

		public override void OnGameJoined(Game i_Game)
		{
			// Do nothing, the UI does it for us
		}
	}
}
