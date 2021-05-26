using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle.Types
{
	public class ElectricMotorcycle : MotorcycleBasedType
	{
		public override Engine GenerateEngine()
		{
			return new ElectricEngine(1.8f);
		}
	}
}
