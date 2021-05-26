using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle.Types
{
	public abstract class TruckBasedType : VehicleType
	{
		public override Wheel[] GenerateWheels()
		{
			Wheel[] wheels = new Wheel[16];
			for (int i = 0; i < wheels.Length; ++i)
			{
				wheels[i] = new Wheel("TODO", 28);
			}

			return wheels;
		}

		public override Dictionary<string, Requirements.PropertyRequirement> GetRequirements()
		{
			return Truck.GetRequirements();
		}
	}
}
