using System.Text;

namespace B21_Ex01_1
{
    class Program
    {

		static int minNumber(int[] numbers)
        {
			int minNumber = -1;

			return minNumber;
        }

		static int maxNumber(int[] numbers)
		{
			int maxNumber = -1;

			return maxNumber;

		}

		static int countNbOfOnes(string i_Digits)
		{
			int count = 0;
			foreach (char c in i_Digits)
			{
				if (c == '1')
				{
					count++;
				}
			}
			return count;
		}

		static float average(int[] numbers)
        {
			float total = 0;
			foreach (int number in numbers)
            {
				total += number;
            }
			float average = total / numbers.Length;

			return average;
		}

		static int countPowersOfTwo(string[] numbers)
        {
			int count = 0;
			foreach(string number in numbers)
            {
				int nbOfOnes = countNbOfOnes(number);
				if (nbOfOnes < 2)
                {
					count++;
                }
			}
			return count;
        }

		static void analyzeInput(string[] numbers)
		{
			object[] args = new object[9];

			args[0] = numbers[0];
			args[1] = numbers[1];
			args[2] = numbers[2];

			int nbPowersOfTwo = countPowersOfTwo(numbers);

			args[3] = nbPowersOfTwo;

			int[] array_nbOfOnes = new int[3];

			for (int i = 0; i < numbers.Length; i++)
            {
				array_nbOfOnes[i] = countNbOfOnes(numbers[i]);

			}

			float averageNbOfOnes = average(array_nbOfOnes);
			float averageNbOfZeros = 7 - averageNbOfOnes;

			args[5] = averageNbOfOnes;
			args[6] = averageNbOfZeros;

			StringBuilder sb = new StringBuilder();

			sb.Append("The numbers are {0}, {1}, {2} - ");
			sb.Append("{3} of them is power of 2, ");
			sb.Append("{4} of them consists of digits which are a strictly monotonically increasing sequence (i.e. 123), ");
			sb.Append("the average of ones is {5}, ");
			sb.Append("the average of zeros is {6}, ");
			sb.Append("the greatest is {7}, ");
			sb.Append("smallest is {8}. ");

			System.Console.WriteLine(string.Format(sb.ToString(), args));

		}

		static void Main()
		{
			string[] inputs = new string[3];

			for (int i = 0; i < 3; i++)
			{
				System.Console.WriteLine("Please insert 7 bits:\n");

				string input = System.Console.ReadLine();
				if (input.Length != 7)
				{
					System.Console.WriteLine("Illegal input: Must have 6 characters");
					return;
				}
				foreach (char c in input)
				{
					if (c != '0' && c != '1')
					{
						System.Console.WriteLine("Illegal input: Must use only binary bits");
						return;
					}
				}
				inputs[i] = input;
			}
			analyzeInput(inputs);
		}
	}
}
