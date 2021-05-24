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
        public UI(Garage i_Garage)
        {
            throw new System.NotImplementedException();
        }
        
        public void start()
        {
            while (m_Continue)
            {
                GarageOptions commandChoice = this.PromptChooseCommand();
                this.chooseCommand(commandChoice);
            }
        }

        public GarageOptions PromptChooseCommand()
        {
            return GarageOptions.QuitCommand;
        }

        private void chooseCommand(GarageOptions i_Command)
        {
            switch (i_Command)
            {
                case GarageOptions.InsertNewVehicle:
                    insertNewVehicleCommand();
                    break;
                case GarageOptions.DisplayCarList:
                    displayCarListCommand();
                    break;
                case GarageOptions.ModifyStatus:
                    modifyStatusCommand();
                    break;
                case GarageOptions.InflateTires:
                    inflateTiresCommand();
                    break;
                case GarageOptions.RefuelCar:
                    refuelCarCommand();
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
        }

        public void displayCarListCommand()
        {
        }

        public void modifyStatusCommand()
        {
        }

        public void inflateTiresCommand()
        {
        }

        public void refuelCarCommand()
        {
        }

        public void chargeCarCommand()
        {
        }

        public void displayCarInformationCommand()
        {
        }


    }
}