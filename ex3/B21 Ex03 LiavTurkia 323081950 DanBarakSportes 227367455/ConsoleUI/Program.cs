using GarageLogic.Garage;

namespace ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            ConsoleUI ui = new ConsoleUI(new Garage());
            ui.Start();
        }
    }
}