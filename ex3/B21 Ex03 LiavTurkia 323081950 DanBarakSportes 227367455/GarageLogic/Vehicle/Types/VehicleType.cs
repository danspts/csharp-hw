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

		public abstract Wheel[] GenerateWheels(string i_ManufacturerName);

		public abstract Dictionary<string, Requirements.PropertyRequirement> GetRequirements();
	}
}
