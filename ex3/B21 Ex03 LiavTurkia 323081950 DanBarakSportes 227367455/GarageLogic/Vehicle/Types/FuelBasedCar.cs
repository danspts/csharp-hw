using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle.Types
{
	public class FuelBasedCar : CarBasedType
	{
		public override Engine GenerateEngine()
		{
			return new FuelEngine(FuelEngine.eFuelType.Octane95, 45f);
		}
	}
}
