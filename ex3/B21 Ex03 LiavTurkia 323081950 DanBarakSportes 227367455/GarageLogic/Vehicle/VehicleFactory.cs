using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	public class VehicleFactory
	{
		public enum eVehicleType
		{
			// Add vehicle type names to here, and then add relevant code to the static constructor
			FuelBasedMotorcycle = 0,
			ElectricMotorcycle = 1,
			FuelBasedCar = 2,
			ElectricCar = 3,
			FuelBasedTruck = 4,
		}

		private static readonly Dictionary<eVehicleType, Types.VehicleType> sr_VehicleTypes;

		static VehicleFactory()
		{
			sr_VehicleTypes = new Dictionary<eVehicleType, Types.VehicleType>
			{
				// For adding new vehicle types, add them to here:
				{ eVehicleType.FuelBasedMotorcycle, new Types.MotorcycleBasedType(new FuelEngine(FuelEngine.eFuelType.Octane98, 6f)) },
				{ eVehicleType.ElectricMotorcycle, new Types.MotorcycleBasedType(new ElectricEngine(1.8f)) },
				{ eVehicleType.FuelBasedCar, new Types.CarBasedType(new FuelEngine(FuelEngine.eFuelType.Octane95, 45f)) },
				{ eVehicleType.ElectricCar, new Types.CarBasedType(new ElectricEngine(3.2f)) },
				{ eVehicleType.FuelBasedTruck, new Types.TruckBasedType(new FuelEngine(FuelEngine.eFuelType.Soler, 120f)) },
			};
		}

		public Vehicle GenerateVehicle(eVehicleType i_Type, Dictionary<string, object> i_Properties)
		{
			if (sr_VehicleTypes.TryGetValue(i_Type, out Types.VehicleType type))
			{
				return type.GenerateVehicle(i_Properties);
			}
			else
			{
				throw new NotImplementedException(string.Format("Not implemented vehicle type: {0}", i_Type));
			}
		}

		public Dictionary<string, Requirements.PropertyRequirement> GetRequirements(eVehicleType i_Type)
		{
			if (sr_VehicleTypes.TryGetValue(i_Type, out Types.VehicleType type))
			{
				Dictionary<string, Requirements.PropertyRequirement> requirements = type.GetRequirements();
				requirements.Add("Tire Manufacturer", new Requirements.TypeRequirement(typeof(string)));
				return requirements;
			}
			else
			{
				throw new NotImplementedException(string.Format("Not implemented vehicle type: {0}", i_Type));
			}
		}
	}
}
