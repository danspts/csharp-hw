using B21_Ex05.Game;
using System;
using System.Windows.Forms;

namespace B21_Ex05.Interface
{
    public partial class SettingsForm : Form
    {

        public GameSettings m_GameSettings = null;

        public SettingsForm()
        {
            InitializeComponent();
        }
        public GameSettings GameSettings
        {
            get { return this.m_GameSettings;  }
            set { this.m_GameSettings = value; }
        }
        
        private void isNotComputerCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                this.playerText2.ReadOnly = false;
                this.playerText2.Text = "";
            }
            else
            {
                this.playerText2.ReadOnly = true;
                this.playerText2.Text = "[Computer]";
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if(this.numericUpDownRows.Value == this.numericUpDownCols.Value)
            {
                if (this.playerText2.Text != this.playerText1.Text && this.playerText2.Text != "" && this.playerText1.Text != "")
                {
                    if (this.isNotComputerCheckbox.Checked)
                    {
                        this.GameSettings = new GameSettings((int)this.numericUpDownCols.Value, new HumanPlayer(this.playerText1.Text), new HumanPlayer(this.playerText2.Text));
                    }
                    else
                    {
                        this.GameSettings = new GameSettings((int)this.numericUpDownCols.Value, new HumanPlayer(this.playerText1.Text), new ComputerPlayer("Computer"));
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The users must have non-empty distinct names");
                }
            }
            else
            {
                MessageBox.Show("Rows must have the same value as Cols");
            }
        }
    }
}