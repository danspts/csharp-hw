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
			r_VehicleTypes.Add(eVehicleType.FuelBasedMotorcycle, new Types.MotorcycleBasedType(new FuelEngine(FuelEngine.eFuelType.Octane98, 6f)));
			r_VehicleTypes.Add(eVehicleType.ElectricMotorcycle, new Types.MotorcycleBasedType(new ElectricEngine(1.8f)));
			r_VehicleTypes.Add(eVehicleType.FuelBasedCar, new Types.CarBasedType(new FuelEngine(FuelEngine.eFuelType.Octane95, 45f)));
			r_VehicleTypes.Add(eVehicleType.ElectricCar, new Types.CarBasedType(new ElectricEngine(3.2f)));
			r_VehicleTypes.Add(eVehicleType.FuelBasedTruck, new Types.TruckBasedType(new FuelEngine(FuelEngine.eFuelType.Soler, 120f)));
		}

		public Vehicle GenerateVehicle(eVehicleType i_Type, Dictionary<string, object> i_Properties)
		{
			if (r_VehicleTypes.TryGetValue(i_Type, out Types.VehicleType type))
			{
				if (i_Properties.TryGetValue("Tire Manufacturer", out object tireManufacturer))
				{
					return new Vehicle(i_Properties, type.GenerateWheels(tireManufacturer.ToString()), type.Engine);
				}
				else
				{
					throw new ArgumentException("Missing property: Tire Manufacturer");
				}
			}
			else
			{
				throw new NotImplementedException(string.Format("Not implemented vehicle type: {0}", i_Type));
			}
		}

		public Dictionary<string, Requirements.PropertyRequirement> GetRequirements(eVehicleType i_Type)
		{
			if (r_VehicleTypes.TryGetValue(i_Type, out Types.VehicleType type))
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
