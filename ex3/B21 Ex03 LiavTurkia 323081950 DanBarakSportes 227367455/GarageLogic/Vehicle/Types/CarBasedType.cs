using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle.Types
{
	public abstract class CarBasedType : VehicleType
	{
		public override Wheel[] GenerateWheels()
		{
			Wheel[] wheels = new Wheel[4];
			for (int i = 0; i < wheels.Length; ++i)
			{
				wheels[i] = new Wheel("TODO", 32);
			}

			return wheels;
		}

		public override Dictionary<string, Requirements.PropertyRequirement> GetRequirements()
		{
			return Car.GetRequirements();
		}
	}
}
