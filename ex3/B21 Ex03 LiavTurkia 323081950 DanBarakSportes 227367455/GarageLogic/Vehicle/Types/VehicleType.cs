using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle.Types
{
	public abstract class VehicleType
	{
		public abstract Engine GenerateEngine();

		public abstract Wheel[] GenerateWheels();

		public abstract Dictionary<string, Requirements.PropertyRequirement> GetRequirements();
	}
}
