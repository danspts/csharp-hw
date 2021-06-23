using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex05.Game
{
	public class CellPosition
	{
		private readonly int r_X;
		private readonly int r_Y;

		public CellPosition(int i_X, int i_Y)
		{
			this.r_X = i_X;
			this.r_Y = i_Y;
		}

		public int X
		{
			get { return this.r_X; }
		}

		public int Y
		{
			get { return this.r_Y; }
		}

		public override bool Equals(object i_Obj)
		{
			return i_Obj is CellPosition position &&
				   this.X == position.X &&
				   this.Y == position.Y;
		}

		public override int GetHashCode()
		{
			int hashCode = 1861411795;
			hashCode = (hashCode * -1521134295) + this.X.GetHashCode();
			hashCode = (hashCode * -1521134295) + this.Y.GetHashCode();
			return hashCode;
		}
	}
}
