using B21_Ex05.Game;

namespace B21_Ex05.Game
{
	public class GameSettings
	{
		private readonly int r_BoardSize;
		private readonly Player r_Player1;
		private readonly Player r_Player2;

		public GameSettings(int i_BoardSize, Player i_Player1, Player i_Player2)
		{
			this.r_BoardSize = i_BoardSize;
			this.r_Player1 = i_Player1;
			this.r_Player2 = i_Player2;
		}

		public int BoardSize
		{
			get { return this.r_BoardSize; }
		}

		public Player Player1
		{
			get { return this.r_Player1; }
		}

		public Player Player2
		{
			get { return this.r_Player2; }
		}
	}
}
