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

        private static readonly string r_Line = new string('-', 85);

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
        }

        private Garage Garage
        {
            get { return this.m_Garage; }
        }

        public void Start()
        {
            Console.Write("Welcome to the garage Interface!\n\n");

            while (this.m_Continue)
            {
                try
                {
                    eGarageOptions commandChoice = (eGarageOptions) this.PromptChooseCommand();
                    this.chooseCommand(commandChoice);
                }
                catch (Exception e) when (e is ValueOutOfRangeException || e is FormatException ||
                                          e is KeyNotFoundException || e is ArgumentException) // ||
                    //   e is NotImplementedException)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendLine("\n" + r_Line);
                    builder.Append("/!\\ ERROR : ");
                    builder.Append(e.Message);
                    builder.AppendLine("  /!\\");
                    builder.AppendLine(r_Line);
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

        private int PromptChooseCommand()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + r_Line);
            builder.AppendLine("\t\t\t\tChoose a command: ");
            builder.AppendLine(r_Line);
            builder.AppendLine("0: Clear the Screen");
            builder.AppendLine("1: Insert a new vehicle");
            builder.AppendLine("2: Display the car list");
            builder.AppendLine("3: Modify the status of a car");
            builder.AppendLine("4: Inflate the tires of a car");
            builder.AppendLine("5: Refuel the gas of a car");
            builder.AppendLine("6: Charge a car");
            builder.AppendLine("7: Display the information of a car");
            builder.AppendLine("8: Quit the interface");
            builder.AppendLine(r_Line);
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

        private void promptGetInput(out int o_object, string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            string command = Console.ReadLine();
            if (!int.TryParse(command, out o_object))
            {
                throw new FormatException("Syntax-invalid: not an integer");
            }
        }

        private void promptGetInput(out float o_object, string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            string command = Console.ReadLine();
            if (!float.TryParse(command, out o_object))
            {
                throw new FormatException("Syntax-invalid: not an integer");
            }
        }

        private void promptGetInput(out string o_object, string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            o_object = Console.ReadLine();
        }

        private Owner promptOwner()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + r_Line);
            builder.AppendLine("\tPlease write {0}: ");
            builder.AppendLine(r_Line);
            promptGetInput(out string ownerName, String.Format(builder.ToString(), "the owner's name"));
            promptGetInput(out string ownerPhone, String.Format(builder.ToString(), "the owner's phone number"));
            return new Owner(ownerName, ownerPhone);
        }

        private Vehicle promptVehicle()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + r_Line);
            builder.AppendLine("\t\t\t\tChoose a vehicle type: ");
            builder.AppendLine(r_Line);
            builder.AppendLine("0: Fuel based motorcycle");
            builder.AppendLine("1: Electric based motorcycle");
            builder.AppendLine("2: Fuel based car");
            builder.AppendLine("3: Electric based car");
            builder.AppendLine("4: Fuel based truck");
            builder.AppendLine(r_Line);
            builder.Append("Number:  ");
            this.promptGetInput(out int o_VehicleType, builder.ToString());
            if (o_VehicleType < 0 || o_VehicleType > 4)
            {
                throw new ValueOutOfRangeException(0, 4, "Logic-invalid: must be between 0 and 4");
            }

            Dictionary<string, PropertyRequirement> requirements =
                this.VehicleFactory.GetRequirements((VehicleFactory.eVehicleType) o_VehicleType);

            Dictionary<string, object> properties = new Dictionary<string, object>();

            foreach (KeyValuePair<string, PropertyRequirement> kvp in requirements)
            {
                PropertyRequirement propertyRequirement = kvp.Value;
                builder = new StringBuilder();
                builder.AppendLine("\n" + r_Line);
                builder.AppendLine(kvp.Key + ": " + propertyRequirement.GetRequirementInformation());
                builder.AppendLine(r_Line);
                Type type = propertyRequirement.Type;
                switch (true)
                {
                    case bool _ when type == typeof(int):
                        promptGetInput(out int o_ObjectInt, builder.ToString());
                        properties.Add(kvp.Key, o_ObjectInt);
                        break;
                    case bool _ when type == typeof(float):
                        promptGetInput(out float o_ObjectFloat, builder.ToString());
                        properties.Add(kvp.Key, o_ObjectFloat);
                        break;
                    case bool _ when type == typeof(string):
                        promptGetInput(out string o_ObjectString, builder.ToString());
                        properties.Add(kvp.Key, o_ObjectString);
                        break;
                    case bool _ when type.IsEnum:
                        foreach (Enum val in Enum.GetValues(type))
                        {
                            builder.AppendLine(String.Format("{0}: {1}", Convert.ChangeType(val, typeof(int)), val));
                        }

                        builder.AppendLine(r_Line);
                        builder.Append("Number:  ");
                        promptGetInput(out int o_ObjectEnum, builder.ToString());
                        if (type != null)
                            properties.Add(kvp.Key, Enum.ToObject(type, o_ObjectEnum));
                        break;
                    default:
                        throw new NotImplementedException(string.Format("{0} object has not been handled", type.Name));
                }
			}

            return VehicleFactory.GenerateVehicle((VehicleFactory.eVehicleType)o_VehicleType, properties);
        }

        private VehicleRegistration promptGetVehicleFromPlate()
        {
            VehicleRegistration outputVehicle;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + r_Line);
            builder.AppendLine("\tPlease write the vehicle registration plate: ");
            builder.AppendLine(r_Line);
            builder.Append("Registration Plate:  ");
            this.promptGetInput(out string registrationPlate, builder.ToString());
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


        public void insertNewVehicleCommand()
        {
            Owner owner = promptOwner();
            Vehicle vehicle = promptVehicle();
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

        public void displayCarListCommand()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + r_Line);

            builder.AppendLine("\t\t\t\tChoose a status: ");
            builder.AppendLine(r_Line);
            builder.AppendLine("0: No Filter");
            builder.AppendLine("1: In Repair");
            builder.AppendLine("2: Repaired");
            builder.AppendLine("3: Payed for");
            builder.AppendLine(r_Line);
            this.promptGetInput(out int o_StatusFiler, builder.ToString());
            if (o_StatusFiler < 0 || o_StatusFiler > 3)
            {
                throw new ValueOutOfRangeException(0, 3, "Logic-invalid: must be between 0 and 3");
            }

            builder = new StringBuilder();
            builder.AppendLine("\n" + r_Line);
            builder.AppendLine("\t\t\t\tList of Vehicles:");
            builder.AppendLine(r_Line);
            Console.Write(builder.ToString());
            Console.Write(this.Garage.ListVehicles((VehicleRegistration.eVehicleStatus) o_StatusFiler));
        }

        public void modifyStatusCommand()
        {
            VehicleRegistration vehicle = promptGetVehicleFromPlate();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + r_Line);
            builder.AppendLine("\t\t\t\tChoose a status: ");
            builder.AppendLine(r_Line);
            builder.AppendLine("1: In Repair");
            builder.AppendLine("2: Repaired");
            builder.AppendLine("3: Payed for");
            this.promptGetInput(out int o_Status, builder.ToString());
            if (o_Status < 1 || o_Status > 3)
            {
                throw new ValueOutOfRangeException(1, 3, "Logic-invalid: must be between 1 and 3");
            }

            vehicle.Status = (VehicleRegistration.eVehicleStatus) o_Status;
        }

        public void inflateTiresCommand()
        {
            VehicleRegistration vehicle = promptGetVehicleFromPlate();
            vehicle.Vehicle.InflateAllWheels();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + r_Line);
            builder.AppendLine("All the wheels of of vehicle " + vehicle.Vehicle.LicenseNumber + " have been inflated");
            builder.AppendLine(r_Line);
            Console.Write(builder.ToString());
        }

        public void refuelCarCommand()
        {
            VehicleRegistration vehicle = promptGetVehicleFromPlate();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + r_Line);
            builder.AppendLine("\tPlease write how much time you want the vehicle to charge:  ");
            builder.AppendLine(r_Line);
            promptGetInput(out int o_AmountRefuel, builder.ToString());
            Engine engine = vehicle.Vehicle.Engine;
            if (engine.GetType() == typeof(FuelEngine))
            {
                ((FuelEngine) vehicle.Vehicle.Engine).Refuel(o_AmountRefuel);
            }
            else
            {
                throw new ArgumentException("This vehicle doesn't have a fuel tank and therefore cannot be refueled");
            }
        }

        public void chargeCarCommand()
        {
            VehicleRegistration vehicle = promptGetVehicleFromPlate();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + r_Line);
            builder.AppendLine("\tPlease write how much time you want the vehicle to charge:  ");
            builder.AppendLine(r_Line);
            promptGetInput(out int o_TimeToCharge, builder.ToString());
            Engine engine = vehicle.Vehicle.Engine;
            if (engine.GetType() == typeof(ElectricEngine))
            {
                ((ElectricEngine) vehicle.Vehicle.Engine).Recharge(o_TimeToCharge);
            }
            else
            {
                throw new ArgumentException("This vehicle is not electric and therefore cannot be charged");
            }
        }

        public void displayCarInformationCommand()
        {
            VehicleRegistration vehicle = promptGetVehicleFromPlate();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + r_Line);
            builder.AppendLine(vehicle.ToString());
            builder.AppendLine(r_Line);
            Console.WriteLine(builder.ToString());
        }
    }
}