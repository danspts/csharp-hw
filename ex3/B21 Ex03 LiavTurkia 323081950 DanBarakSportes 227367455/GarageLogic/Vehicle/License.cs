using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	class License
	{
		private readonly string r_LicenseNumber;

		public License(string i_LicenseNumber)
		{
			this.r_LicenseNumber = i_LicenseNumber;
		}

		public string Number
		{
			get { return this.r_LicenseNumber; }
		}
	}
}
