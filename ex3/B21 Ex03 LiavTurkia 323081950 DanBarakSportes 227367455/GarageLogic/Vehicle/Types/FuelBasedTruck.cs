using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle.Types
{
	public class FuelBasedTruck : TruckBasedType
	{
		public override Engine GenerateEngine()
		{
			return new FuelEngine(FuelEngine.eFuelType.Soler, 120f);
		}
	}
}
