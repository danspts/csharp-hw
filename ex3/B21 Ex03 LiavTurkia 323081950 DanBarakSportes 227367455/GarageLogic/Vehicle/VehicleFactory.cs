using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	public class VehicleFactory
	{
		public enum eVehicleType {
			// Add vehicle type names to here, and then add relevant code to (1) and (2)
			FuelBasedMotorcycle = 0,
			ElectricMotorcycle = 1,
			FuelBasedCar = 2,
			ElectricCar = 3,
			FuelBasedTruck = 4,
		}

		private static readonly Dictionary<eVehicleType, Types.VehicleType> r_VehicleTypes;

		static VehicleFactory()
		{
			r_VehicleTypes = new Dictionary<eVehicleType, Types.VehicleType>();

			// For adding new vehicle types, add them to here:
			r_VehicleTypes.Add(eVehicleType.FuelBasedMotorcycle, new Types.FuelBasedMotorcycle());
			r_VehicleTypes.Add(eVehicleType.ElectricMotorcycle, new Types.ElectricMotorcycle());
			r_VehicleTypes.Add(eVehicleType.FuelBasedCar, new Types.FuelBasedCar());
			r_VehicleTypes.Add(eVehicleType.ElectricCar, new Types.ElectricCar());
			r_VehicleTypes.Add(eVehicleType.FuelBasedTruck, new Types.FuelBasedTruck());
		}

		public Vehicle GenerateVehicle(eVehicleType i_Type, Dictionary<string, object> i_Properties)
		{
			if (r_VehicleTypes.TryGetValue(i_Type, out Types.VehicleType type))
			{
				return new Vehicle(i_Properties, type.GenerateWheels(), type.GenerateEngine());
			}
			else
			{
				throw new NotImplementedException(String.Format("Not implemented vehicle type: {0}", i_Type));
			}
		}

		public Dictionary<string, Requirements.PropertyRequirement> GetRequirements(eVehicleType i_Type)
		{
			if (r_VehicleTypes.TryGetValue(i_Type, out Types.VehicleType type))
			{
				return type.GetRequirements();
			}
			else
			{
				throw new NotImplementedException(string.Format("Not implemented vehicle type: {0}", i_Type));
			}
		}
	}
}
