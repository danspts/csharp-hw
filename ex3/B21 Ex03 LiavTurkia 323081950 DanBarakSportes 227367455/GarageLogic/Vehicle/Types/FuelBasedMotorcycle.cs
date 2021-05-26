using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle.Types
{
	public class FuelBasedMotorcycle : MotorcycleBasedType
	{
		public override Engine GenerateEngine()
		{
			return new FuelEngine(FuelEngine.eFuelType.Octane98, 6f);
		}
	}
}
