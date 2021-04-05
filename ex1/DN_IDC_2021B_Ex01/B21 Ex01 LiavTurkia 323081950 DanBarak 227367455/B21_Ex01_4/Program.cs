using System.Text;

namespace B21_Ex01_4
{
	public class Program
	{
		private static bool palindromeRecurse(string i_Input, int i_Offset)
		{
			if (i_Offset >= i_Input.Length / 2)
			{
				return true;
			}

			return i_Input[i_Offset] == i_Input[i_Input.Length - 1 - i_Offset] && palindromeRecurse(i_Input, i_Offset + 1);
		}

		public static bool IsPalindrome(string i_Input)
		{
			return palindromeRecurse(i_Input, 0);
		}

		// Returns whether it is English
		public static bool CountUppercase(string i_Input, out int o_UppercaseLetters)
		{
			o_UppercaseLetters = 0;
			foreach (char c in i_Input)
			{
				if (!char.IsLetter(c))
				{
					return false;
				}
				if (char.IsUpper(c))
				{
					++o_UppercaseLetters;
				}
			}

			return true;
		}

		private static void analyzeInput(string i_Input)
		{
			object[] args = new object[2];
			args[0] = i_Input;

			StringBuilder sb = new StringBuilder();
			sb.AppendLine("For the input string {0}:");
			if (IsPalindrome(i_Input))
			{
				sb.AppendLine("It is a palindrome");
			}
			else
			{
				sb.AppendLine("It is not a palindrome");
			}

			if (int.TryParse(i_Input, out int inputAsInt))
			{
				sb.AppendLine("It is a number");
				if (inputAsInt % 4 == 0)
				{
					sb.AppendLine("It is a multiplication of 4");
				}
			}
			else
			{
				sb.AppendLine("It is not a number");
			}

			System.Console.WriteLine(string.Format(sb.ToString(), args));
		}

		static void Main()
		{
			string input = System.Console.ReadLine();
			if (input.Length != 10)
			{
				System.Console.WriteLine("Illegal input: Must have 10 characters");
			}
			else
			{
				analyzeInput(input);
			}
		}
	}
}
