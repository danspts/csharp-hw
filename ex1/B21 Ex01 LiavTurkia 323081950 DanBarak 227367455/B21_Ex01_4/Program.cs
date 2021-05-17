using System.Text;

namespace B21_Ex01_4
{
	public class Program
	{
		private static bool offsetMatchesInString(string i_Input, int i_Offset)
		{
			return i_Input[i_Offset] == i_Input[i_Input.Length - 1 - i_Offset];
		}

		private static bool palindromeRecurse(string i_Input, int i_Offset)
		{
			return i_Offset >= i_Input.Length / 2
				|| (offsetMatchesInString(i_Input, i_Offset) && palindromeRecurse(i_Input, i_Offset + 1));
		}

		public static bool IsPalindrome(string i_Input)
		{
			return palindromeRecurse(i_Input, 0);
		}

		public static bool IsOnlyDigits(string i_Input)
		{
			bool valid = true;

			foreach (char character in i_Input)
			{
				if (!char.IsDigit(character))
				{
					valid = false;
					break;
				}
			}

			return valid;
		}

		public static bool IsOnlyLetters(string i_Input)
		{
			bool valid = true;

			foreach (char character in i_Input)
			{
				if (!char.IsLetter(character))
				{
					valid = false;
					break;
				}
			}

			return valid;
		}

		public static int CountUppercase(string i_Input)
		{
			int uppercaseLetters = 0;

			foreach (char character in i_Input)
			{
				if (char.IsUpper(character))
				{
					++uppercaseLetters;
				}
			}

			return uppercaseLetters;
		}

		public static bool Divides(long i_Input, int i_Divisor)
		{
			return i_Input % i_Divisor == 0;
		}

		public static void AnalyzeInput(string i_Input)
		{
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

			// We use long as 10 digits overflows an int
			if (long.TryParse(i_Input, out long inputAsNumber))
			{
				sb.AppendLine("It is a number");
				if (Divides(inputAsNumber, 4))
				{
					sb.AppendLine("It is a multiplication of 4");
				}
				else
				{
					sb.AppendLine("But it is not a multiplication of 4");
				}
			}
			else
			{
				sb.AppendLine("It is not a number");
			}

			if (!IsOnlyLetters(i_Input))
			{
				sb.AppendLine("It is not in English");
			}
			else
			{
				sb.AppendLine("It is in English");
				sb.AppendLine(string.Format("It has {0} uppercase letters", CountUppercase(i_Input)));
			}

			System.Console.WriteLine(string.Format(sb.ToString(), i_Input));
		}

		public static void PromptUserForAnalysis(int i_DesiredLength)
		{
			System.Console.WriteLine(string.Format("Please insert a string with {0} characters:", i_DesiredLength));

			string input = System.Console.ReadLine();

			if (input.Length != i_DesiredLength)
			{
				System.Console.WriteLine(string.Format("Illegal input: Must have {0} characters", i_DesiredLength));
			}
			else if (!(IsOnlyLetters(input) || IsOnlyDigits(input)))
			{
				System.Console.WriteLine("Illegal input: Must contain only digits or only letters");
			}
			else
			{
				AnalyzeInput(input);
			}
		}

		static void Main()
		{
			PromptUserForAnalysis(10);
		}
	}
}
