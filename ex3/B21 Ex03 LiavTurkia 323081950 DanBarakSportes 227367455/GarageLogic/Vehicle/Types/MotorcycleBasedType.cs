using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle.Types
{
    public class MotorcycleBasedType : VehicleType
    {
		public MotorcycleBasedType(Engine i_Engine)
            : base(i_Engine)
		{
		}

		public override Wheel[] GenerateWheels(string i_ManufacturerName)
        {
            Wheel[] wheels = new Wheel[2];
            for (int i = 0; i < wheels.Length; ++i)
            {
                wheels[i] = new Wheel(i_ManufacturerName, 30);
            }

            return wheels;
        }

		public override Dictionary<string, Requirements.PropertyRequirement> GetRequirements()
        {
            return Motorcycle.GetRequirements();
        }
    }
}