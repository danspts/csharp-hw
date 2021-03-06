using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using GarageLogic;
using GarageLogic.Garage;
using GarageLogic.Vehicle;
using GarageLogic.Vehicle.Requirements;

namespace ConsoleUI
{
    public class ConsoleUI
    {
        public enum eGarageOptions
        {
            ClearInterface = 0,
            InsertNewVehicle = 1,
            DisplayCarList = 2,
            ModifyStatus = 3,
            InflateTires = 4,
            RefuelCar = 5,
            ChargeCar = 6,
            DisplayCarInformation = 7,
            QuitCommand = 8,
        }

        private static readonly string sr_Line = new string('-', 85);

        private bool m_Continue = true;
        private Garage m_Garage;
        private VehicleFactory m_VehicleFactory;

        public ConsoleUI(Garage i_Garage)
        {
            this.m_Garage = i_Garage;
            this.m_VehicleFactory = new VehicleFactory();
        }

        private VehicleFactory VehicleFactory
        {
            get { return this.m_VehicleFactory; }
            set { this.m_VehicleFactory = value; }
        }

        private Garage Garage
        {
            get { return this.m_Garage; }
            set { this.m_Garage = value; }
        }

        public void Start()
        {
            Console.Write("Welcome to the garage Interface!\n\n");

            while (this.m_Continue)
            {
                try
                {
                    eGarageOptions commandChoice = (eGarageOptions)this.promptChooseCommand();
                    Console.Clear();
                    this.chooseCommand(commandChoice);
                }
                catch (Exception e) when (e is ValueOutOfRangeException || e is FormatException ||
                                          e is KeyNotFoundException || e is ArgumentException)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendLine("\n" + sr_Line);
                    builder.Append("/!\\ ERROR : ");
                    builder.Append(e.Message);
                    builder.AppendLine("  /!\\");
                    builder.AppendLine(sr_Line);
                    Console.WriteLine(builder.ToString());
                }
            }
        }

        private void chooseCommand(eGarageOptions i_Command)
        {
            switch (i_Command)
            {
                case eGarageOptions.ClearInterface:
                    Console.Clear();
                    break;
                case eGarageOptions.InsertNewVehicle:
                    this.insertNewVehicleCommand();
                    break;
                case eGarageOptions.DisplayCarList:
                    this.displayCarListCommand();
                    break;
                case eGarageOptions.ModifyStatus:
                    this.modifyStatusCommand();
                    break;
                case eGarageOptions.InflateTires:
                    this.inflateTiresCommand();
                    break;
                case eGarageOptions.RefuelCar:
                    this.refuelCarCommand();
                    break;
                case eGarageOptions.ChargeCar:
                    this.chargeCarCommand();
                    break;
                case eGarageOptions.DisplayCarInformation:
                    this.displayCarInformationCommand();
                    break;
                case eGarageOptions.QuitCommand:
                    this.m_Continue = false;
                    break;
            }
        }

        private int promptChooseCommand()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);
            builder.AppendLine("\t\t\t\tChoose a command: ");
            builder.AppendLine(sr_Line);
            builder.AppendLine("0: Clear the Screen");
            builder.AppendLine("1: Insert a new vehicle");
            builder.AppendLine("2: Display the car list");
            builder.AppendLine("3: Modify the status of a car");
            builder.AppendLine("4: Inflate the tires of a car");
            builder.AppendLine("5: Refuel the gas of a car");
            builder.AppendLine("6: Charge a car");
            builder.AppendLine("7: Display the information of a car");
            builder.AppendLine("8: Quit the interface");
            builder.AppendLine(sr_Line);
            builder.Append("Number:  ");

            Console.Write(builder.ToString());
            string command = Console.ReadLine();
            if (!int.TryParse(command, out int result))
            {
                throw new FormatException("Syntax-invalid: not an integer");
            }
            else if (result < 0 || result > 8)
            {
                throw new ValueOutOfRangeException(0, 8, "Logic-invalid: must be between 0 and 8");
            }

            return result;
        }

        private object promptGetInput(string i_Message, Type i_Type)
        {
            Console.WriteLine(i_Message);
            object outObject;
            if (i_Type.IsEnum)
            {
                StringBuilder builder = new StringBuilder();
                foreach (Enum val in Enum.GetValues(i_Type))
                {
                    builder.AppendLine(string.Format("{0}: {1}", Convert.ChangeType(val, typeof(int)), val));
                }

                builder.AppendLine(sr_Line);
                builder.Append("Number:  ");
                int ordinal = (int)this.promptGetInput(builder.ToString(), typeof(int));
                while (ordinal < 0 || ordinal > Enum.GetValues(i_Type).Length)
				{
                    ordinal = (int)this.promptGetInput("Invalid input, try again", typeof(int));
				}

                outObject = Enum.ToObject(i_Type, ordinal);
            }
            else
            {
                string command = Console.ReadLine();

                TypeConverter converter = TypeDescriptor.GetConverter(i_Type);

                if (converter != null && converter.CanConvertFrom(typeof(string)))
                {
                    if (!converter.IsValid(command))
                    {
                        throw new FormatException(string.Format("Syntax-invalid: not an {0}", i_Type.Name));
                    }

                    try
                    {
                        outObject = converter.ConvertFromString(command);
					}
					catch
                    {
                        throw new FormatException(string.Format("Syntax-invalid: not an {0}", i_Type.Name));
                    }
                }
                else
                {
                    outObject = command;
                }
            }

            return outObject;
        }

        private Owner promptOwner()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);
            builder.AppendLine("\tPlease write {0}: ");
            builder.AppendLine(sr_Line);
            string ownerName = (string)this.promptGetInput(string.Format(builder.ToString(), "the owner's name"), typeof(string));
            string ownerPhone = (string)this.promptGetInput(string.Format(builder.ToString(), "the owner's phone number"), typeof(string));
            return new Owner(ownerName, ownerPhone);
        }

        private Dictionary<string, object> promptPropertiesForVehicleType(VehicleFactory.eVehicleType i_Type)
		{
            Dictionary<string, PropertyRequirement> requirements =
                this.VehicleFactory.GetRequirements(i_Type);

            Dictionary<string, object> properties = new Dictionary<string, object>();

            foreach (KeyValuePair<string, PropertyRequirement> kvp in requirements)
            {
                PropertyRequirement propertyRequirement = kvp.Value;
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("\n" + sr_Line);
                builder.AppendLine(kvp.Key + ": " + propertyRequirement.GetRequirementInformation());
                builder.AppendLine(sr_Line);
                Type type = propertyRequirement.Type;

                object input = this.promptGetInput(builder.ToString(), type);
                while (!propertyRequirement.Verify(input))
                {
                    input = this.promptGetInput("Invalid input, try again", type);
                }

                properties.Add(kvp.Key, input);
            }

            return properties;
        }

        private Vehicle promptVehicle()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);
            builder.AppendLine("\t\t\t\tChoose a vehicle type: ");
            builder.AppendLine(sr_Line);
            VehicleFactory.eVehicleType vehicleType = (VehicleFactory.eVehicleType)this.promptGetInput(builder.ToString(), typeof(VehicleFactory.eVehicleType));
            return this.VehicleFactory.GenerateVehicle((VehicleFactory.eVehicleType)vehicleType, this.promptPropertiesForVehicleType((VehicleFactory.eVehicleType)vehicleType));
        }

        private VehicleRegistration promptGetVehicleFromPlate()
        {
            VehicleRegistration outputVehicle;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);
            builder.AppendLine("\tPlease write the vehicle registration plate: ");
            builder.AppendLine(sr_Line);
            builder.Append("Registration Plate:  ");
            string registrationPlate = (string)this.promptGetInput(builder.ToString(), typeof(string));
            if (this.m_Garage.HasRegistered(registrationPlate))
            {
                outputVehicle = this.m_Garage.GetRegistration(registrationPlate);
            }
            else
            {
                throw new KeyNotFoundException("The vehicle registration plate that you searched isnt registered");
            }

            return outputVehicle;
        }

        private void insertNewVehicleCommand()
        {
            Owner owner = this.promptOwner();
            Vehicle vehicle = this.promptVehicle();
            VehicleRegistration registration = new VehicleRegistration(owner, vehicle);
            if (!this.Garage.HasRegistered(vehicle.LicenseNumber))
            {
                this.Garage.UpsertRegistration(vehicle.LicenseNumber, registration);
            }
            else
            {
                this.Garage.GetRegistration(vehicle.LicenseNumber).Status = VehicleRegistration.eVehicleStatus.InRepair;
            }
        }

        private void displayCarListCommand()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);

            builder.AppendLine("\t\t\t\tChoose a status: ");
            builder.AppendLine(sr_Line);
            VehicleRegistration.eVehicleStatus statusFilter = (VehicleRegistration.eVehicleStatus)this.promptGetInput(builder.ToString(), typeof(VehicleRegistration.eVehicleStatus));

            builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);
            builder.AppendLine("\t\t\t\tList of Vehicles:");
            builder.AppendLine(sr_Line);
            Console.Write(builder.ToString());
            Console.Write(this.Garage.ListVehicles(statusFilter));
        }

        private void modifyStatusCommand()
        {
            VehicleRegistration vehicle = this.promptGetVehicleFromPlate();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);
            builder.AppendLine("\t\t\t\tChoose a status: ");
            builder.AppendLine("\t\t\t\tCan't choose None");
            builder.AppendLine(sr_Line);
            VehicleRegistration.eVehicleStatus vehicleStatus = (VehicleRegistration.eVehicleStatus)this.promptGetInput(builder.ToString(), typeof(VehicleRegistration.eVehicleStatus));

            if (vehicleStatus == VehicleRegistration.eVehicleStatus.None)
			{
                Console.WriteLine("Can't choose None");
			}
			else
			{
                vehicle.Status = vehicleStatus;
            }
        }

        private void inflateTiresCommand()
        {
            VehicleRegistration vehicle = this.promptGetVehicleFromPlate();
            vehicle.Vehicle.InflateAllWheels();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);
            builder.AppendLine("All the wheels of of vehicle " + vehicle.Vehicle.LicenseNumber + " have been inflated");
            builder.AppendLine(sr_Line);
            Console.Write(builder.ToString());
        }

        private void refuelCarCommand()
        {
            VehicleRegistration vehicle = this.promptGetVehicleFromPlate();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);
            builder.AppendLine("\tPlease write how many liter you want to refuel:  ");
            builder.AppendLine(sr_Line);
            int amountRefuel = (int)this.promptGetInput(builder.ToString(), typeof(int));
            Engine engine = vehicle.Vehicle.Engine;
            if (engine.GetType() == typeof(FuelEngine))
            {
                ((FuelEngine)vehicle.Vehicle.Engine).Refuel(amountRefuel);
            }
            else
            {
                throw new ArgumentException("This vehicle doesn't have a fuel tank and therefore cannot be refueled");
            }
        }

        private void chargeCarCommand()
        {
            VehicleRegistration vehicle = this.promptGetVehicleFromPlate();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);
            builder.AppendLine("\tPlease write how much time you want the vehicle to charge:  ");
            builder.AppendLine(sr_Line);
            int timeToCharge = (int)this.promptGetInput(builder.ToString(), typeof(int));
            Engine engine = vehicle.Vehicle.Engine;
            if (engine.GetType() == typeof(ElectricEngine))
            {
                ((ElectricEngine)vehicle.Vehicle.Engine).Recharge(timeToCharge);
            }
            else
            {
                throw new ArgumentException("This vehicle is not electric and therefore cannot be charged");
            }
        }

        private void displayCarInformationCommand()
        {
            VehicleRegistration vehicle = this.promptGetVehicleFromPlate();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);
            builder.AppendLine(vehicle.ToString());
            builder.AppendLine(sr_Line);
            Console.WriteLine(builder.ToString());
        }
    }
}