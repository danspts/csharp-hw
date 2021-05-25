using GarageLogic.Garage;

namespace ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            Garage garage = new Garage();
            UI ui = new UI(garage);
            ui.Start();
        }

    }
}