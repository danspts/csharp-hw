using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle.Types
{
	public class CarBasedType : VehicleType
	{
		public CarBasedType(Engine i_Engine)
			: base(i_Engine)
		{
		}

		protected override Wheel[] GenerateWheels(string i_ManufacturerName)
		{
			Wheel[] wheels = new Wheel[4];
			for (int i = 0; i < wheels.Length; ++i)
			{
				wheels[i] = new Wheel(i_ManufacturerName, 32);
			}

			return wheels;
		}

		public override Dictionary<string, Requirements.PropertyRequirement> GetRequirements()
		{
			return Car.GetRequirements();
		}

		protected override Vehicle GenerateVehicleFromComponents(Dictionary<string, object> i_Properties, Wheel[] i_Wheels, Engine i_Engine)
		{
			return new Car(i_Properties, i_Wheels, i_Engine);
		}
	}
}
