using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	public class CarModel : Model
	{
		public enum eCarColor
		{
			Red,
			Silver,
			White,
			Black,
		}

		private readonly eCarColor r_CarColor;
		private readonly int r_NumberOfDoors;

		public CarModel(string i_ModelName, int i_NumberOfDoors, eCarColor eCarColor)
			: base(i_ModelName)
		{
			if (i_NumberOfDoors < 2 || i_NumberOfDoors > 5)
			{
				throw new ValueOutOfRangeException(2, 5, "Invalid number of doors");
			}

			this.r_NumberOfDoors = i_NumberOfDoors;
			this.r_CarColor = eCarColor;
		}

		public int NumberOfDoors
		{
			get { return this.r_NumberOfDoors; }
		}

		public eCarColor Color
		{
			get { return this.r_CarColor; }
		}
	}
}
