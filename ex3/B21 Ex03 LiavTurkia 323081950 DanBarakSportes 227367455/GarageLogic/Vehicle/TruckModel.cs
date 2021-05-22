using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	public class TruckModel : Model
	{
		private readonly float r_MaxCargoWeight;
		private bool m_ContainsDangerousMaterials;

		public TruckModel(string i_ModelName, bool i_ContainsDangerousMaterials, float i_MaxCargoWeight)
			: base(i_ModelName)
		{
			this.m_ContainsDangerousMaterials = i_ContainsDangerousMaterials;
			this.r_MaxCargoWeight = i_MaxCargoWeight;
		}

		public bool ContainsDangerousMaterials
		{
			get { return this.m_ContainsDangerousMaterials; }
			set { this.m_ContainsDangerousMaterials = value; }
		}

		public float MaxCargoWeight
		{
			get { return this.r_MaxCargoWeight; }
		}
	}
}
