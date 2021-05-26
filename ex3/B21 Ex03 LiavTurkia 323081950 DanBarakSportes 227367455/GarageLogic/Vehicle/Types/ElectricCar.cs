using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle.Types
{
	public class ElectricCar : CarBasedType
	{
		public override Engine GenerateEngine()
		{
			return new ElectricEngine(3.2f);
		}
	}
}
