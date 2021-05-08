using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02.Game
{
	abstract class Player
	{
		private readonly string m_Name;

		public Player(string i_Name)
		{
			this.m_Name = i_Name;
		}

		public string Name
		{
			get { return this.m_Name; }
		}

		public abstract CellPosition Play(Board i_CurrentBoard);
	}
}
