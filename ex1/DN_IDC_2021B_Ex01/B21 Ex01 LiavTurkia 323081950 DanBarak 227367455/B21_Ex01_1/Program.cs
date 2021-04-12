using System.Text;
using System;

namespace B21_Ex01_1
{
    class Program
    {

		public static int MinNumber(int[] i_Numbers)
        {
			int minNumber = i_Numbers[0];
			for (int i = 1; i < i_Numbers.Length; i++)
			{
				minNumber = Math.Min(i_Numbers[i], minNumber);
			}
			return minNumber;
        }

		public static int MaxNumber(int[] i_Numbers)
		{
			int maxNumber = i_Numbers[0];
			for(int i = 1; i < i_Numbers.Length; i++)
            {
				maxNumber = Math.Max(i_Numbers[i], maxNumber);
			}
			return maxNumber;
		}

		public static int[] CountNbOfOnes(string[] i_Numbers)
        {
			int[] array_nbOfOnes = new int[3];
			for (int i = 0; i < i_Numbers.Length; i++)
			{
				array_nbOfOnes[i] = CountNbOfOnes(i_Numbers[i]);
			}
			return array_nbOfOnes;
		}


		public static int CountNbOfOnes(string i_Digits)
		{
			int count = 0;
			foreach (char c in i_Digits)
			{
				if (c == '1')
				{
					++count;
				}
			}
			return count;
		}

		public static float Average(int[] i_Numbers)
        {
			float total = 0;
			foreach (int number in i_Numbers)
            {
				total += number;
            }
			return total / i_Numbers.Length;
		}

		public static int CountPowersOfTwo(string[] i_Numbers)
        {
			int count = 0;
			int nbOfOnes;
			foreach (string number in i_Numbers)
            {
				nbOfOnes = CountNbOfOnes(number);
				if (nbOfOnes == 1)
                {
					++count;
                }
			}
			return count;
        }

		public static int BinaryStringToInt(string i_String)
        {
			int result = 0;
			foreach(char c in i_String)
            {
				result *= 2;
				if(c == '1')
                {
					++result;
                }
            }
			return result;
        }

		public static bool DigitsAreStrictlyMonotonicIncreasing(int i_Number)
        {
			int prev = -1;
			int next;

			while (i_Number > 0)
            {
				next = i_Number % 10;
				if (prev >= next)
                {
					break;
                }
				i_Number /= 10;
				prev = next;
            }
			// If the loop breaks early, the i_Number won't be <= 0 (as we didn't reach terminating condition)
			return i_Number <= 0;
        }

		public static int CountStrictlyMonotonicIncreasing(int[] i_NumbersInt)
		{
			int nbMonotonicInc = 0;
			foreach (int num in i_NumbersInt)
			{
				if (DigitsAreStrictlyMonotonicIncreasing(num))
				{
					nbMonotonicInc++;
				}
			}
			return nbMonotonicInc;
		}

		public static bool IsBinaryString(string i_String)
		{
			bool result = true;
			foreach (char c in i_String)
			{
				if (c != '0' && c != '1')
				{
					System.Console.WriteLine("Illegal input: Must use only binary bits");
					result = false;
					break;
				}
			}
			return result;
		}

		public static void AnalyzeInputs(string[] i_Numbers)
		{
			object[] args = new object[9];

			int[] numbersInt = new int[i_Numbers.Length];

			for(int i = 0; i < i_Numbers.Length; i++)
            {
				numbersInt[i] = BinaryStringToInt(i_Numbers[i]);
				args[i] = numbersInt[i];
			}

			int nbPowersOfTwo = CountPowersOfTwo(i_Numbers);

			args[3] = nbPowersOfTwo;
			args[4] = CountStrictlyMonotonicIncreasing(numbersInt);

			int[] array_nbOfOnes = new int[3];
			array_nbOfOnes = CountNbOfOnes(i_Numbers);
			
			float averageNbOfOnes = Average(array_nbOfOnes);
			float averageNbOfZeros = 7 - averageNbOfOnes;

			args[5] = averageNbOfOnes;
			args[6] = averageNbOfZeros;
			args[7] = MaxNumber(numbersInt);
			args[8] = MinNumber(numbersInt);

			StringBuilder sb = new StringBuilder();

			sb.AppendLine("Of the numbers {0}, {1}, {2}: ");
			sb.AppendLine("{3} of them is power of 2,");
			sb.AppendLine("{4} of them consists of digits which are a strictly monotonically increasing sequence,");
			sb.AppendLine("the average of ones is {5},");
			sb.AppendLine("the average of zeros is {6},");
			sb.AppendLine("the greatest is {7},");
			sb.AppendLine("smallest is {8}.");

			System.Console.WriteLine(string.Format(sb.ToString(), args));
		}

		public static void PromptUserForBits(int i_NbBits)
		{
			string[] inputs = new string[3];
			bool inputValid = true;
			for (int i = 0; i < 3; i++)
			{
				System.Console.WriteLine(string.Format("Please insert {0} bits:", i_NbBits));

				string input = System.Console.ReadLine();
				if (input.Length != i_NbBits)
				{
					System.Console.WriteLine(string.Format("Illegal input: Must have {0} characters", i_NbBits));
					inputValid = false;
					break;
				}
				else if (!IsBinaryString(input))
				{

					System.Console.WriteLine("Illegal input: Must be a binary string");
					inputValid = false;
					break;
				}
				
				inputs[i] = input;
			}
			if(inputValid)
			{
				AnalyzeInputs(inputs);
			}
		}

		static void Main()
		{
			PromptUserForBits(7);
		}
	}
}
