using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Garage
{
	public class Owner
	{
		private readonly string r_Name;
		private readonly string r_PhoneNumber;

		public Owner(string i_Name, string i_PhoneNumber)
		{
			this.r_Name = i_Name;
			this.r_PhoneNumber = i_PhoneNumber;
		}

		public string Name
		{
			get { return this.r_Name; }
		}

		public string PhoneNumber
		{
			get { return this.r_PhoneNumber; }
		}

		public override string ToString()
		{
			return r_Name;
		}
	}
}
