using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	public class VehicleFactory
	{
		public enum eVehicleType {
			FuelBasedMotorcycle,
			ElectricMotorcycle,
			FuelBasedCar,
			ElectricCar,
			FuelBasedTruck,
		}

		public Vehicle GenerateVehicle(eVehicleType i_Type, License license,)
		{
			Model model;
			License license;
			Wheel[] wheels;
			Engine engine;
			switch(i_Type)
			{
				case eVehicleType.FuelBasedMotorcycle:

					break;
				default:
					throw new ArgumentException("Unimplemented vehicle type");
			}

			return new Vehicle(model, license, wheels, engine);
		}
	}
}
