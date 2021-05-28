using System;
using System.Collections.Generic;
using System.Text;
using GarageLogic;
using GarageLogic.Garage;
using GarageLogic.Vehicle;

namespace ConsoleUI
{
    public enum GarageOptions
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

    public class UI
    {
        private static readonly string r_Line =
            "-------------------------------------------------------------------------------------";

        private bool m_Continue = true;
        private Garage m_garage;

        public UI(Garage i_Garage)
        {
            this.m_garage = i_Garage;
        }

        public Garage Garage
        {
            get { return this.m_garage; }
        }

        public void Start()
        {
            Console.Write("Welcome to the garage Interface!\n\n");

            while (this.m_Continue)
            {
                try
                {
                    GarageOptions commandChoice = (GarageOptions) this.PromptChooseCommand();
                    this.chooseCommand(commandChoice);
                }
                catch (Exception e) when (e is ValueOutOfRangeException || e is FormatException ||
                                          e is KeyNotFoundException || e is ArgumentException)
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

        private Owner promptOwner()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + r_Line);
            builder.AppendLine("\tPlease write {0}: ");
            builder.AppendLine(r_Line);
            Console.WriteLine(String.Format(builder.ToString(), "the owner's name"));
            string ownerName = Console.ReadLine();
            Console.WriteLine(String.Format(builder.ToString(), "the owner's phone number"));
            string ownerPhone = Console.ReadLine();
            return new Owner(ownerName, ownerPhone);
        }

        private Vehicle promptVehicle()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            Wheel[] wheel = new Wheel[0];
            Engine engine = new FuelEngine(FuelEngine.eFuelType.Octane95, 10);

            return new Vehicle(dic, wheel, engine);
        }

        private VehicleRegistration promptGetVehicleFromPlate()
        {
            VehicleRegistration outputVehicle;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + r_Line);
            builder.AppendLine("\tPlease write the vehicle registration plate: ");
            builder.AppendLine(r_Line);
            builder.Append("Registration Plate:  ");
            Console.Write(builder.ToString());
            string registrationPlate = Console.ReadLine();
            if (this.m_garage.HasRegistered(registrationPlate))
            {
                outputVehicle = this.m_garage.GetRegistration(registrationPlate);
            }
            else
            {
                throw new KeyNotFoundException("The vehicle registration plate that you searched isnt registered");
            }

            return outputVehicle;
        }

        private void chooseCommand(GarageOptions i_Command)
        {
            switch (i_Command)
            {
                case GarageOptions.ClearInterface:
                    Console.Clear();
                    break;
                case GarageOptions.InsertNewVehicle:
                    this.insertNewVehicleCommand();
                    break;
                case GarageOptions.DisplayCarList:
                    this.displayCarListCommand();
                    break;
                case GarageOptions.ModifyStatus:
                    this.modifyStatusCommand();
                    break;
                case GarageOptions.InflateTires:
                    this.inflateTiresCommand();
                    break;
                case GarageOptions.RefuelCar:
                    this.refuelCarCommand();
                    break;
                case GarageOptions.ChargeCar:
                    this.chargeCarCommand();
                    break;
                case GarageOptions.DisplayCarInformation:
                    this.displayCarInformationCommand();
                    break;
                case GarageOptions.QuitCommand:
                    this.m_Continue = false;
                    break;
            }
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
                throw new ArgumentException("Item already exists and this command will overwrite it");
            }
        }

        public void displayCarListCommand()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + r_Line);
            builder.AppendLine("\t\t\t\tList of Vehicles:");
            builder.AppendLine(r_Line);
            Console.Write(builder.ToString());
            Console.Write(this.Garage.ListVehicles(default));
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
            Console.WriteLine(builder.ToString());
            string command = Console.ReadLine();
            if (!int.TryParse(command, out int result))
            {
                throw new FormatException("Syntax-invalid: not an integer");
            }
            else if (result < 1 || result > 3)
            {
                throw new ValueOutOfRangeException(0, 8, "Logic-invalid: must be between 1 and 3");
            }

            vehicle.Status = (VehicleRegistration.eVehicleStatus) result;
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
            Console.Write(builder.ToString());
            string command = Console.ReadLine();
            if (!int.TryParse(command, out int o_timeToCharge))
            {
                throw new FormatException("Syntax-invalid: not an integer");
            }
            else if (o_timeToCharge < 0)
            {
                throw new ValueOutOfRangeException(0, float.MaxValue, "Logic-invalid: must be positive");
            }

            Engine engine = vehicle.Vehicle.Engine;

            if (engine.GetType() == typeof(FuelEngine))
            {
                ((FuelEngine) vehicle.Vehicle.Engine).Refuel(o_timeToCharge);
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
            Console.Write(builder.ToString());
            string command = Console.ReadLine();
            if (!int.TryParse(command, out int o_timeToCharge))
            {
                throw new FormatException("Syntax-invalid: not an integer");
            }
            else if (o_timeToCharge < 0)
            {
                throw new ValueOutOfRangeException(0, float.MaxValue, "Logic-invalid: must be positive");
            }

            Engine engine = vehicle.Vehicle.Engine;

            if (engine.GetType() == typeof(ElectricEngine))
            {
                ((ElectricEngine) vehicle.Vehicle.Engine).Recharge(o_timeToCharge);
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