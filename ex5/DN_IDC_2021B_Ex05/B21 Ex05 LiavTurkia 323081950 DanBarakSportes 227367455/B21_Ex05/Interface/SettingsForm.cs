using System;
using System.Windows.Forms;
using B21_Ex05.Game;

namespace B21_Ex05.Interface
{
	public class SettingsForm : Form
	{
		private NumericUpDown m_NumericUpDownCols;
		private NumericUpDown m_NumericUpDownRows;

		private CheckBox m_IsNotComputerCheckbox;

		private Label m_PlayersLabel;
		private Label m_Player1Label;
		private Label m_ColsLabel;
		private Label m_SizeLabel;

		private TextBox m_Player1Text;
		private TextBox m_Player2Text;

		private Button m_StartButton;

		private GameSettings m_GameSettings = null;

		public SettingsForm()
		{
			this.InitializeComponent();
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			this.m_StartButton = new System.Windows.Forms.Button();
			this.m_Player1Text = new System.Windows.Forms.TextBox();
			this.m_Player2Text = new System.Windows.Forms.TextBox();
			this.m_PlayersLabel = new System.Windows.Forms.Label();
			this.m_Player1Label = new System.Windows.Forms.Label();
			this.m_IsNotComputerCheckbox = new System.Windows.Forms.CheckBox();
			this.m_NumericUpDownCols = new System.Windows.Forms.NumericUpDown();
			this.m_NumericUpDownRows = new System.Windows.Forms.NumericUpDown();
			this.m_ColsLabel = new System.Windows.Forms.Label();
			this.m_ColsLabel = new System.Windows.Forms.Label();
			this.m_SizeLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)this.m_NumericUpDownCols).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.m_NumericUpDownRows).BeginInit();
			this.SuspendLayout();

			resources.ApplyResources(this.m_StartButton, "startButton");
			this.m_StartButton.Text = "Start!";
			this.m_StartButton.Name = "startButton";
			this.m_StartButton.UseVisualStyleBackColor = true;
			this.m_StartButton.Click += new System.EventHandler(this.startButton_Click);

			resources.ApplyResources(this.m_Player1Text, "playerText1");
			this.m_Player1Text.Name = "playerText1";

			resources.ApplyResources(this.m_Player2Text, "playerText2");
			this.m_Player2Text.Name = "playerText2";

			resources.ApplyResources(this.m_PlayersLabel, "label1");
			this.m_PlayersLabel.Name = "label1";

			resources.ApplyResources(this.m_Player1Label, "label2");
			this.m_Player1Label.Name = "label2";

			resources.ApplyResources(this.m_IsNotComputerCheckbox, "isNotComputerCheckbox");
			this.m_IsNotComputerCheckbox.Name = "isNotComputerCheckbox";
			this.m_IsNotComputerCheckbox.UseVisualStyleBackColor = true;
			this.m_IsNotComputerCheckbox.CheckedChanged += new System.EventHandler(this.isNotComputerCheckbox_CheckedChanged);

			resources.ApplyResources(this.m_NumericUpDownCols, "numericUpDownCols");
			this.m_NumericUpDownCols.Maximum = new decimal(new int[]
			{
			9,
			0,
			0,
			0,
			});
			this.m_NumericUpDownCols.Minimum = new decimal(new int[]
			{
			3,
			0,
			0,
			0,
			});
			this.m_NumericUpDownCols.Name = "numericUpDownCols";
			this.m_NumericUpDownCols.Value = new decimal(new int[]
			{
			3,
			0,
			0,
			0,
			});
			resources.ApplyResources(this.m_NumericUpDownRows, "numericUpDownRows");
			this.m_NumericUpDownRows.Maximum = new decimal(new int[]
			{
			9,
			0,
			0,
			0,
			});
			this.m_NumericUpDownRows.Minimum = new decimal(new int[]
			{
			3,
			0,
			0,
			0,
			});
			this.m_NumericUpDownRows.Name = "numericUpDownRows";
			this.m_NumericUpDownRows.Value = new decimal(new int[]
			{
			3,
			0,
			0,
			0,
			});

			resources.ApplyResources(this.m_ColsLabel, "label3");
			this.m_ColsLabel.Name = "label3";

			resources.ApplyResources(this.m_ColsLabel, "label4");
			this.m_ColsLabel.Name = "label4";

			resources.ApplyResources(this.m_SizeLabel, "label5");
			this.m_SizeLabel.Name = "label5";

			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.m_SizeLabel);
			this.Controls.Add(this.m_ColsLabel);
			this.Controls.Add(this.m_ColsLabel);
			this.Controls.Add(this.m_NumericUpDownRows);
			this.Controls.Add(this.m_NumericUpDownCols);
			this.Controls.Add(this.m_IsNotComputerCheckbox);
			this.Controls.Add(this.m_Player1Label);
			this.Controls.Add(this.m_PlayersLabel);
			this.Controls.Add(this.m_Player2Text);
			this.Controls.Add(this.m_Player1Text);
			this.Controls.Add(this.m_StartButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.ShowIcon = false;
			((System.ComponentModel.ISupportInitialize)this.m_NumericUpDownCols).EndInit();
			((System.ComponentModel.ISupportInitialize)this.m_NumericUpDownRows).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		public GameSettings GameSettings
		{
			get { return this.m_GameSettings; }
			set { this.m_GameSettings = value; }
		}

		private void isNotComputerCheckbox_CheckedChanged(object i_Sender, EventArgs i_Args)
		{
			if ((i_Sender as CheckBox).Checked)
			{
				this.m_Player2Text.ReadOnly = false;
				this.m_Player2Text.Text = string.Empty;
			}
			else
			{
				this.m_Player2Text.ReadOnly = true;
				this.m_Player2Text.Text = "[Computer]";
			}
		}

		private void startButton_Click(object i_Sender, EventArgs i_Args)
		{
			if (this.m_NumericUpDownRows.Value == this.m_NumericUpDownCols.Value)
			{
				if (this.m_Player2Text.Text != this.m_Player1Text.Text && this.m_Player2Text.Text != string.Empty && this.m_Player1Text.Text != string.Empty)
				{
					if (this.m_IsNotComputerCheckbox.Checked)
					{
						this.GameSettings = new GameSettings((int)this.m_NumericUpDownCols.Value, new HumanPlayer(this.m_Player1Text.Text), new HumanPlayer(this.m_Player2Text.Text));
					}
					else
					{
						this.GameSettings = new GameSettings((int)this.m_NumericUpDownCols.Value, new HumanPlayer(this.m_Player1Text.Text), new ComputerPlayer("Computer"));
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