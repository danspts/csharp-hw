namespace B21_Ex01_2
{
	public class Program
	{
		static void printStars(int n, int width) {
			System.Console.Write(new System.String(' ', (width - n) / 2));
			System.Console.Write(new System.String('*', n));
			System.Console.WriteLine(new System.String(' ', (width - n) / 2));
		}

		static void recurseDown(int n, int height) {
			if (n == 1)
			{
				recurseUp(1, height);
			}
			else
			{
				printStars(n, height);
				recurseDown(n - 2, height);
			}
		}

		static void recurseUp(int n, int height) {
			printStars(n, height);
			if (n < height) {
				recurseUp(n + 2, height);
			}
		}

		public static void printSandClock(int height) {
			if (height % 2 == 0)
			{
				recurseDown(height + 1, height + 1);
			}
			else {
				recurseDown(height, height);
			}
		}

		static void Main()
		{
			printSandClock(5);
		}
	}
}
