using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02.Game
{
	abstract class Player
	{
		public abstract CellPosition Play(Board i_CurrentBoard);
	}
}
