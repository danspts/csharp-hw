using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex05.Game
{
	public abstract class Player
	{
		private readonly string r_Name;

		public Player(string i_Name)
		{
			this.r_Name = i_Name;
		}

		public string Name
		{
			get { return this.r_Name; }
		}

		public abstract void OnGameJoined(Game i_Game);
	}
}
