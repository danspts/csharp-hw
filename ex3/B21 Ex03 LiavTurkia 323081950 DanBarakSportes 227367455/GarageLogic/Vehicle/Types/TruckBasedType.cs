using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle.Types
{
	public class TruckBasedType : VehicleType
	{
		public TruckBasedType(Engine i_Engine)
			: base(i_Engine)
		{
		}

		protected override Wheel[] GenerateWheels(string i_ManufacturerName)
		{
			Wheel[] wheels = new Wheel[16];
			for (int i = 0; i < wheels.Length; ++i)
			{
				wheels[i] = new Wheel(i_ManufacturerName, 28);
			}

			return wheels;
		}

		public override Dictionary<string, Requirements.PropertyRequirement> GetRequirements()
		{
			return Truck.GetRequirements();
		}

		protected override Vehicle GenerateVehicleFromComponents(Dictionary<string, object> i_Properties, Wheel[] i_Wheels, Engine i_Engine)
		{
			return new Truck(i_Properties, i_Wheels, i_Engine);
		}
	}
}
