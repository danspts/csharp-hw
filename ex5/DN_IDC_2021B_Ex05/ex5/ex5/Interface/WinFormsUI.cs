using B21_Ex05.Game;
using System;
using System.Text;
using System.Windows.Forms;

namespace B21_Ex05.Interface
{
	public class WinFormsUI : UI
	{

		protected ReversedTicTacToeForm m_GameForm;

		public WinFormsUI()
		{
			// attach delegates here
		}

		protected override GameSettings PromptForGameSettings()
		{
			Interface.SettingsForm settings = new Interface.SettingsForm();
			settings.ShowDialog();
			this.GameForm = new ReversedTicTacToeForm(this, settings.GameSettings);
			return settings.GameSettings;
		}

		public ReversedTicTacToeForm GameForm
        {
            get { return this.m_GameForm; }
			set {  this.m_GameForm = value; }
        }

		public override void Start()
		{
			base.Start();
			this.GameForm.ShowDialog();
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

			DialogResult answer = MessageBox.Show(builder.ToString(), caption, MessageBoxButtons.YesNo);
			return answer == DialogResult.Yes;
		}
	}
}
