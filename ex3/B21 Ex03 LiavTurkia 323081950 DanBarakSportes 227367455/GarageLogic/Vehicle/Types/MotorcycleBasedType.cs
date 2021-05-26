using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle.Types
{
	public abstract class MotorcycleBasedType : VehicleType
	{
		public override Wheel[] GenerateWheels()
		{
			Wheel[] wheels = new Wheel[2];
			for (int i = 0; i < wheels.Length; ++i)
			{
				wheels[i] = new Wheel("TODO", 30);
			}

			return wheels;
		}

		public override Dictionary<string, Requirements.PropertyRequirement> GetRequirements()
		{
			return Motorcycle.GetRequirements();
		}
	}
}
