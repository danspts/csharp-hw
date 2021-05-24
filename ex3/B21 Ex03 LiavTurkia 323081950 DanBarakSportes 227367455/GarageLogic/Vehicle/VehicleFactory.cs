using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	public class VehicleFactory
	{
		public enum eVehicleType {
			// Add vehicle type names to here, and then add relevant code to (1) and (2)
			FuelBasedMotorcycle,
			ElectricMotorcycle,
			FuelBasedCar,
			ElectricCar,
			FuelBasedTruck,
		}

		/*
		private TypeConfiguration getTypeConfiguration(eVehicleType i_Type)
		{
			TypeConfiguration config;
			switch (i_Type)
			{
				// (1) When adding new vehicle types, make sure to fill in the proper type names here:
				case eVehicleType.FuelBasedMotorcycle:
					config = new TypeConfiguration(2, typeof(Wheel), typeof(MotorcycleLicense), typeof(FuelEngine), typeof(MotorcycleModel));
					break;
				case eVehicleType.ElectricMotorcycle:
					config = new TypeConfiguration(2, typeof(Wheel), typeof(MotorcycleLicense), typeof(ElectricEngine), typeof(MotorcycleModel));
					break;
				case eVehicleType.FuelBasedCar:
					config = new TypeConfiguration(4, typeof(Wheel), typeof(License), typeof(FuelEngine), typeof(CarModel));
					break;
				case eVehicleType.ElectricCar:
					config = new TypeConfiguration(4, typeof(Wheel), typeof(License), typeof(ElectricEngine), typeof(CarModel));
					break;
				case eVehicleType.FuelBasedTruck:
					config = new TypeConfiguration(16, typeof(Wheel), typeof(License), typeof(FuelEngine), typeof(TruckModel));
					break;
				default:
					throw new ArgumentException("Unimplemented vehicle type");
			}

			return config;
		}*/

		private void fillTypeProperties(eVehicleType i_Type, ref Dictionary<string, object> io_Properties)
		{
			switch (i_Type)
			{
				// (2) When adding new vehicle types, make sure to fill in the proper default values here:
				case eVehicleType.FuelBasedMotorcycle:
					break;
				case eVehicleType.ElectricMotorcycle:
					break;
				case eVehicleType.FuelBasedCar:
					break;
				case eVehicleType.ElectricCar:
					break;
				case eVehicleType.FuelBasedTruck:
					break;
				default:
					throw new ArgumentException("Unimplemented vehicle type");
			}
		}

		public Vehicle GenerateVehicle(eVehicleType i_Type, Dictionary<string, object> i_Properties)
		{
			/*TypeConfiguration configuration = this.getTypeConfiguration(i_Type);

			this.fillTypeProperties(i_Type, ref i_Properties);

			Wheel[] wheels = new Wheel[configuration.NumOfWheels];

			return new Vehicle(model, license, wheels, engine);
			*/
			return null;
		}

		public Dictionary<string, Requirements.PropertyRequirement> GetRequirements(eVehicleType i_Type)
		{
			/*Dictionary<string, Requirements.PropertyRequirement> requirements = new Dictionary<string, Requirements.PropertyRequirement>();

			TypeConfiguration configuration = getTypeConfiguration(i_Type, null);

			return requirements;
			*/
			return null;
		}
	}
}
