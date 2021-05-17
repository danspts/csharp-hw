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

			for (int i = 1; i < i_Numbers.Length; i++)
            {
				maxNumber = Math.Max(i_Numbers[i], maxNumber);
			}

			return maxNumber;
		}

		public static int[] CountNumOfCharacterInStrings(string[] i_Numbers, char i_CharToCount)
        {
			int[] arrayNumOfOnes = new int[3];

			for (int i = 0; i < i_Numbers.Length; i++)
			{
				arrayNumOfOnes[i] = CountNumOfCharacter(i_Numbers[i], i_CharToCount);
			}

			return arrayNumOfOnes;
		}

		public static int CountNumOfCharacter(string i_Digits, char i_CharToCount)
		{
			int count = 0;

			foreach (char character in i_Digits)
			{
				if (character == i_CharToCount)
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
			int numOfOnes;

			foreach (string number in i_Numbers)
            {
				numOfOnes = CountNumOfCharacter(number, '1');
				if (numOfOnes == 1)
                {
					++count;
                }
			}

			return count;
        }

		public static int BinaryStringToInt(string i_String)
        {
			int result = 0;

			foreach (char character in i_String)
            {
				result *= 2;
				if (character == '1')
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
				if (prev <= next)
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
			int numMonotonicInc = 0;

			foreach (int num in i_NumbersInt)
			{
				if (DigitsAreStrictlyMonotonicIncreasing(num))
				{
					numMonotonicInc++;
				}
			}

			return numMonotonicInc;
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
			int[] binaryNumbersAsDecimalArray = new int[i_Numbers.Length];
			float averageNbOfOnes = Average(CountNumOfCharacterInStrings(i_Numbers, '1'));
			float averageNbOfZeros = i_Numbers[0].Length - averageNbOfOnes;
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < i_Numbers.Length; i++)
            {
				binaryNumbersAsDecimalArray[i] = BinaryStringToInt(i_Numbers[i]);
				args[i] = binaryNumbersAsDecimalArray[i];
			}

			args[3] = CountPowersOfTwo(i_Numbers);
			args[4] = CountStrictlyMonotonicIncreasing(binaryNumbersAsDecimalArray);
			args[5] = averageNbOfOnes;
			args[6] = averageNbOfZeros;
			args[7] = MaxNumber(binaryNumbersAsDecimalArray);
			args[8] = MinNumber(binaryNumbersAsDecimalArray);
			sb.AppendLine("Of the numbers {0}, {1}, {2}: ");
			sb.AppendLine("{3} of them is power of 2,");
			sb.AppendLine("{4} of them consists of digits which are a strictly monotonically increasing sequence,");
			sb.AppendLine("the average of ones is {5},");
			sb.AppendLine("the average of zeros is {6},");
			sb.AppendLine("the greatest is {7},");
			sb.AppendLine("smallest is {8}.");
			System.Console.WriteLine(string.Format(sb.ToString(), args));
		}

		public static void PromptUserForBits(int i_NbBits, int i_NbStrings)
		{
			string[] inputs = new string[3];
			bool inputValid = true;

			for (int i = 0; i < i_NbStrings; i++)
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

			// If the input was fully valid, then we can analyze
			if (inputValid)
			{
				AnalyzeInputs(inputs);
			}
		}

		static void Main()
		{
			PromptUserForBits(7, 3);
		}
	}
}
