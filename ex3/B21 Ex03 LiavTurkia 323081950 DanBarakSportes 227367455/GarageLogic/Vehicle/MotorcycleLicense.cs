using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	class MotorcycleLicense : License
	{
		public enum eMotorcycleLicenseType
		{
			A,
			B1,
			AA,
			BB,
		}

		private readonly eMotorcycleLicenseType r_Type;

		public MotorcycleLicense(string i_Number, eMotorcycleLicenseType i_Type)
			: base(i_Number)
		{
			this.r_Type = i_Type;
		}

		public eMotorcycleLicenseType Type
		{
			get { return this.r_Type; }
		}
	}
}
