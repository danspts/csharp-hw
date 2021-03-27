namespace B21_Ex01_3
{
	public class Program
	{
		static void Main()
		{
			System.Console.WriteLine("Please insert the height of your desired sand clock:");
			string input = System.Console.ReadLine();
			try
			{
				int height = int.Parse(input);
				// recurseDown handles even case
				B21_Ex01_2.Program.printSandClock(height);
			}
			catch (System.ArgumentException e) {
				System.Console.WriteLine("Invalid input!");
			}
		}
	}
}
