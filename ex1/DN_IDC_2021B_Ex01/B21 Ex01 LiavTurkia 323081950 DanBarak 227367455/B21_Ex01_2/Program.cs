using System.Text;

namespace B21_Ex01_2
{
	public class Program
	{
		private static void printStars(int i_NumStars, int i_Width)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(' ', (i_Width - i_NumStars) / 2);
			sb.Append('*', i_NumStars);
			sb.Append(' ', (i_Width - i_NumStars) / 2);
			System.Console.WriteLine(sb.ToString());
		}

		private static void recursivelyBuild(int i_NumStars, int i_Height)
		{
			if (i_NumStars > 0)
			{
				printStars(i_NumStars, i_Height);
				recursivelyBuild(i_NumStars - 2, i_Height);
				printStars(i_NumStars, i_Height);
			}
		}

		public static void PrintSandClock(int i_Height)
		{
			if (i_Height % 2 == 0)
			{
				recursivelyBuild(i_Height + 1, i_Height + 1);
			}
			else
			{
				recursivelyBuild(i_Height, i_Height);
			}
		}

		static void Main()
		{
			PrintSandClock(5);
		}
	}
}
