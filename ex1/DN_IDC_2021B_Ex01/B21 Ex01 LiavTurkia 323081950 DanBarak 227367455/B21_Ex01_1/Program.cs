using System.Text;

namespace B21_Ex01_1
{
    class Program
    {

		static int minNumber(int[] numbers)
        {
			int minNumber = numbers[0];

			for (int i = 1; i < numbers.Length; i++)
			{
				if (numbers[i] < minNumber)
				{
					minNumber = numbers[i];
				}
			}
			return minNumber;
        }

		static int maxNumber(int[] numbers)
		{
			int maxNumber = numbers[0];

			for(int i = 1; i < numbers.Length; i++)
            {
				if (numbers[i] > maxNumber)
                {
					maxNumber = numbers[i];
				}
			}
			return maxNumber;

		}

		static int[] countNbOfOnes(string[] numbers)
        {
			int[] array_nbOfOnes = new int[3];

			for (int i = 0; i < numbers.Length; i++)
			{
				array_nbOfOnes[i] = countNbOfOnes(numbers[i]);

			}

			return array_nbOfOnes;
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
			int nbOfOnes;
			foreach (string number in numbers)
            {
				nbOfOnes = countNbOfOnes(number);
				if (nbOfOnes == 1)
                {
					count++;
                }
			}
			return count;
        }

		static int stringToInt(string str)
        {
			int result = 0;
			foreach(char c in str)
            {
				result *= 2;
				if(c == '1')
                {
					result++;
                }
            }
			return result;
        }

		static bool strictlyMonotonicIncreasing(int i)
        {
			int prev = -1;
			int next;
			while(i > 0)
            {
				next = i % 10;
				if (prev >= next)
                {
					return false;
                }
				i /= 10;
				prev = next;
            }
			return true;
        }

		static int countStrictlyMonotonicIncreasing(int[] numbersInt)
		{

			int nbMonotonicInc = 0;

			foreach (int num in numbersInt)
			{
				if (strictlyMonotonicIncreasing(num))
				{
					nbMonotonicInc++;
				}
			}

			return nbMonotonicInc;
		}

		static void analyzeInput(string[] numbers)
		{
			object[] args = new object[9];

			int[] numbersInt = new int[numbers.Length];

			for(int i = 0; i < numbers.Length; i++)
            {
				numbersInt[i] = stringToInt(numbers[i]);
				args[i] = numbersInt[i];
			}

			int nbPowersOfTwo = countPowersOfTwo(numbers);

			args[3] = nbPowersOfTwo;
			args[4] = countStrictlyMonotonicIncreasing(numbersInt);

			int[] array_nbOfOnes = new int[3];
			array_nbOfOnes = countNbOfOnes(numbers);
			
			float averageNbOfOnes = average(array_nbOfOnes);
			float averageNbOfZeros = 7 - averageNbOfOnes;

			args[5] = averageNbOfOnes;
			args[6] = averageNbOfZeros;

			args[7] = maxNumber(numbersInt);
			args[8] = minNumber(numbersInt);

			StringBuilder sb = new StringBuilder();

			sb.Append("\nThe numbers are {0}, {1}, {2} - ");
			sb.Append("{3} of them is power of 2, ");
			sb.Append("{4} of them consists of digits which are a strictly monotonically increasing sequence, ");
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
					System.Console.WriteLine("Illegal input: Must have 7 characters");
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
