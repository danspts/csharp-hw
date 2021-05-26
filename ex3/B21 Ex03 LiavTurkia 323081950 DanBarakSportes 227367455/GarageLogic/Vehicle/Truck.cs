using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	public class Truck : Vehicle
	{
		private readonly float r_MaxCargoWeight;
		private readonly bool r_ContainsDangerousMaterials;

		public static new Dictionary<string, Requirements.PropertyRequirement> GetRequirements()
		{
			Dictionary<string, Requirements.PropertyRequirement> requirements = Vehicle.GetRequirements();
			requirements.Add("Max Cargo Weight", new Requirements.MinimumRequirement<float>(0));
			requirements.Add("Contains Dangerous Materials", new Requirements.TypeRequirement(typeof(bool)));
			return requirements;
		}

		public Truck(Dictionary<string, object> i_Properties, Wheel[] i_Wheels, Engine i_Engine)
			: base(i_Properties, i_Wheels, i_Engine)
		{
			this.applyProperty<float>(i_Properties, "Max Cargo Weight", out this.r_MaxCargoWeight);
			this.applyProperty<bool>(i_Properties, "Contains Dangerous Materials", out this.r_ContainsDangerousMaterials);
		}
	}
}
