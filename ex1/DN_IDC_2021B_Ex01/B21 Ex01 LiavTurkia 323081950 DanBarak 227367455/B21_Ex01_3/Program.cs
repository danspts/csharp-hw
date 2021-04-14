namespace B21_Ex01_3
{
	public class Program
	{
		public static void Main()
		{
			System.Console.WriteLine("Please insert the height of your desired sand clock:");
			string input = System.Console.ReadLine();

			if (!int.TryParse(input, out int height))
			{
				System.Console.WriteLine("Illegal input: must be an integer number");
			}
			else if (height <= 0)
			{
				System.Console.WriteLine("Illegal input: must be a positive number");
			}
			else
			{
				B21_Ex01_2.Program.PrintSandClock(height);
			}
		}
	}
}
