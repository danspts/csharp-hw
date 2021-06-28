using B21_Ex05.Game;
using System;
using System.Text;
using System.Windows.Forms;

namespace B21_Ex05.Interface
{
	public class WinFormsUI : UI
	{

		public WinFormsUI()
		{
			// attach delegates here
		}

		protected override GameSettings PromptForGameSettings()
		{
			Interface.SettingsForm settings = new Interface.SettingsForm();
			settings.ShowDialog();
			return settings.GameSettings;
		}

		protected override bool ShouldGameContinue(Player i_Winner)
		{
			string caption;
			StringBuilder builder = new StringBuilder();
			if (i_Winner != null)
			{
				caption = "A Win!";
				builder.AppendLine(string.Format("The winner is {0}!", i_Winner.Name));
			}
			else
			{
				caption = "A Tie!";
				builder.AppendLine("Tie!");
			}
			builder.AppendLine("Would you like to play another round?");

			// TODO once we have a window class, pass it in to this
			DialogResult answer = MessageBox.Show(builder.ToString(), caption, MessageBoxButtons.YesNo);
			return answer == DialogResult.Yes;
		}
	}
}
