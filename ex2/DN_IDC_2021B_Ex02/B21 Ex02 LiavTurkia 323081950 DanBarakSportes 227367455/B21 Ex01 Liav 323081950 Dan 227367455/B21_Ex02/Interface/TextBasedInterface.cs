using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02.Interface
{
	abstract class TextBasedInterface : UI
	{
		// Subclasses should override this functions to create a Text-Based game
		protected abstract string ReadLine();

		protected abstract void WriteLine(string i_Line);

		protected char getSymbolForCell(Game.Board.eCellValue i_CellValue) {
			char result = ' ';
			if (i_CellValue == Game.Board.eCellValue.Player1)
			{
				result = 'X';
			}
			else if (i_CellValue == Game.Board.eCellValue.Player2)
			{
				result = 'O';
			}

			return result;
		}

		private void printBoard(Game.Board i_Board) {
			StringBuilder builder = new StringBuilder();

			// Build X axis at the top
			builder.Append("   ");
			for (int x = 0; x < i_Board.Size; ++x)
			{
				builder.Append(x.ToString());
				builder.Append("   ");
			}
			
			builder.Append("\n");

			for (int x = 0; x < i_Board.Size; ++x)
			{
				// Y axis on the left
				builder.Append((char)('A' + x));
				builder.Append("|");

				for (int y = 0; y < i_Board.Size; ++y)
				{
					builder.Append(" ");
					builder.Append(this.getSymbolForCell(i_Board.GetCell(new Game.CellPosition(x, y))));
					builder.Append(" |");
				}

				builder.AppendLine();

				// Line seperator
				builder.Append(" ");
				builder.Append('=', 1 + (4 * i_Board.Size));
				builder.AppendLine();
			}

			this.WriteLine(builder.ToString());
		}

		public override Game.Player PlayGame(Game.Game i_Game)
		{
			Game.Player winner;
			while (!i_Game.IsGameOver(out winner))
			{
				this.printBoard(i_Game.Board);
				i_Game.PlayRound();
			}

			this.printBoard(i_Game.Board);

			if (winner == null)
			{
				this.WriteLine("TIE");
			}

			return winner;
		}

		public override int PromptForBoardSize()
		{
			this.WriteLine("Please insert the dimensions of the board (3-9)");
			int result = -1;
			do
			{
				if (!int.TryParse(this.ReadLine(), out result))
				{
					this.WriteLine("Syntax-invalid: not an integer");
				}
				else if (result < 3 || result > 9)
				{
					this.WriteLine("Logic-invalid: must be between 3 and 9");
				}
				else
				{
					return result;
				}
			}
			while (true);
		}

		public override Game.CellPosition PromptForMove(Game.Board i_Board)
		{
			this.WriteLine("What is your move? Letter followed by number indicating cell position");

			while (true)
			{
				string input = this.ReadLine();
				if (input.Length != 2)
				{
					this.WriteLine("Syntax-invalid: must be 2 characters");
				}

				// Check if first character is a letter
				else if (!char.IsLetter(input[0]))
				{
					this.WriteLine("Syntax-invalid: first character must be a letter");
				}
				else
				{
					int x = (int)(char.ToUpper(input[0]) - 'A');
					int y;

					// Check if second character is a number
					if (!int.TryParse(input[1].ToString(), out y))
					{
						this.WriteLine("Syntax-invalid: first character must be a digit");
					}

					// At this point, the syntax is valid. We now check the logic
					else if (x < 0 || y < 0 || x >= i_Board.Size || y >= i_Board.Size)
					{
						this.WriteLine("Logic-invalid: chosen coordinate is out of bounds");
					}
					else
					{
						Game.CellPosition choice = new Game.CellPosition(x, y);
						if (i_Board.IsCellObstructed(choice))
						{
							this.WriteLine("Logic-invalid: chosen coordinate already has a coin");
						}
						else
						{
							return choice;
						}
					}
				}
			}
		}

		public override Game.Player PromptForOpponent()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("Select your opponent:");
			builder.AppendLine("1. Human");
			builder.AppendLine("2. Computer");
			builder.AppendLine("Please write the number indicating your choice.");
			this.WriteLine(builder.ToString());
			int result = -1;
			do
			{
				if (!int.TryParse(this.ReadLine(), out result))
				{
					this.WriteLine("Syntax-invalid: not an integer");
				}
				else if (result < 1 || result > 2)
				{
					this.WriteLine("Logic-invalid: must be 1 or 2");
				}
				else
				{
					break;
				}
			}
			while (true);

			Game.Player outPlayer;
			if (result == 1)
			{
				outPlayer = new Game.HumanPlayer(this);
			}
			else
			{
				outPlayer = new Game.ComputerPlayer();
			}

			return outPlayer;
		}

		public override bool ShouldGameContinue()
		{
			this.WriteLine("Do you want to keep playing? (Y/N)");
			string result = string.Empty;
			while (true) {
				result = this.ReadLine().ToUpper();
				if (result != "Y" && result != "N")
				{
					this.WriteLine("Syntax-invalid: must insert Y or N");
				}
				else {
					break;
				}
			}

			return result == "Y";
		}

		public override void ShowScore(int i_Player1, int i_Player2, int ties)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("Current Score:");
			builder.AppendLine(string.Format("You: {0}", i_Player1));
			builder.AppendLine(string.Format("Opponent: {0}", i_Player2));
			builder.AppendLine(string.Format("Ties: {0}", ties));
			this.WriteLine(builder.ToString());
		}
	}
}
