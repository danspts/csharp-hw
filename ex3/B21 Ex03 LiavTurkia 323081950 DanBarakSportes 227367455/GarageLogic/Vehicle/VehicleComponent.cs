using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	public abstract class VehicleComponent<T>
	{
		public static Dictionary<string, Requirements.PropertyRequirement> GetRequirements() {
			throw new NotImplementedException("GetRequirements is not implemented for this class!");
		}

		public static T Generate(Dictionary<string, object> i_Requirements)
		{
			throw new NotImplementedException("Generate is not implemented for this class!");
		}
	}
}
