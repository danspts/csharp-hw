using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle.Types
{
	public abstract class VehicleType
	{
		private readonly Engine r_Engine;

		public VehicleType(Engine i_Engine)
		{
			this.r_Engine = i_Engine;
		}

		public Engine Engine
		{
			get { return this.r_Engine;  }
		}

		protected abstract Wheel[] GenerateWheels(string i_ManufacturerName);

		protected abstract Vehicle GenerateVehicleFromComponents(Dictionary<string, object> i_Properties, Wheel[] i_Wheels, Engine i_Engine);

		public Vehicle GenerateVehicle(Dictionary<string, object> i_Properties)
		{
			if (i_Properties.TryGetValue("Tire Manufacturer", out object tireManufacturer))
			{
				return this.GenerateVehicleFromComponents(i_Properties, this.GenerateWheels(tireManufacturer.ToString()), this.Engine);
			}
			else
			{
				throw new ArgumentException("Missing property: Tire Manufacturer");
			}
		}

		public abstract Dictionary<string, Requirements.PropertyRequirement> GetRequirements();
	}
}
