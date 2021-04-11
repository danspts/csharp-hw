using System.Text;


namespace B21_Ex01_5
{
    class Program
    {
		static char minDigit(string i_Digits)
		{
			char min = '\0';

			foreach (char c in i_Digits)
			{
				if (min == '\0' || min > c)
				{
					min = c;
				}
			}
			return min;
		}

		static char maxDigit(string i_Digits)
		{
			char max = '\0';

			foreach (char c in i_Digits)
			{
				if (max == '\0' || max < c)
				{
					max = c;
				}
			}
			return max;

		}

		static int countMultOfThree(string i_Digits)
		{
			int count = 0;
			foreach (char c in i_Digits)
			{
				if ((c - '0') % 3 == 0)
				{
					count++;
				}
			}
			return count;
		}

		static int nbDigitsBiggerThanUnit(string i_Digits)
        {
			int count = 0;
			for(int i = 0; i < 4; i++)
			{
				if (i_Digits[i] != '0')
				{
					count++;
				}
			}
			return count;
		}

		static void analyzeInput(string i_Digits)
        {
			object[] args = new object[4];
			args[0] = maxDigit(i_Digits);
			args[1] = minDigit(i_Digits);
			args[2] = countMultOfThree(i_Digits);
			args[3] = nbDigitsBiggerThanUnit(i_Digits);

			StringBuilder sb = new StringBuilder();
			sb.AppendLine("The largest digit is: {0}");
			sb.AppendLine("The smallest digit is: {1}");
			sb.AppendLine("How many digits are multiplication of 3: {2}");
			sb.AppendLine("The number of digits that are bigger than the units digit is: {3}");

			System.Console.WriteLine(string.Format(sb.ToString(), args));

		}

		static void Main()
		{
			System.Console.WriteLine("Please insert 6 digits:\n");

			string input = System.Console.ReadLine();
			if (input.Length != 6)
			{
				System.Console.WriteLine("Illegal input: Must have 6 characters");
				foreach (char c in input)
				{
					if(c < '0' || c > '9')
                    {
						System.Console.WriteLine("Illegal input: Must use only digits");
						break;
					}
				}
			}
			else
			{
				analyzeInput(input);
			}
		}
	}
}
