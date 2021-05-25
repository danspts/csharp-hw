using GarageLogic.Garage;
using GarageLogic;

namespace ConsoleUI
{
    public enum GarageOptions
    {
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
        private bool m_Continue = true;
        private Garage m_garage;

        public UI(Garage i_Garage)
        {
            this.m_garage = i_Garage;
        }

        public void Start()
        {
            while (this.m_Continue)
            {
                GarageOptions commandChoice = this.PromptChooseCommand();
                this.chooseCommand(commandChoice);
            }
        }

        public GarageOptions PromptChooseCommand()
        {
            // todo
            return GarageOptions.QuitCommand;
        }

        private void chooseCommand(GarageOptions i_Command)
        {
            switch (i_Command)
            {
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
            // todo
        }

        public void displayCarListCommand()
        {
            // todo
        }

        public void modifyStatusCommand()
        {
            // todo
        }

        public void inflateTiresCommand()
        {
            // todo
        }

        public void refuelCarCommand()
        {
            // todo
        }

        public void chargeCarCommand()
        {
            // todo
        }

        public void displayCarInformationCommand()
        {
            // todo
        }
    }
}