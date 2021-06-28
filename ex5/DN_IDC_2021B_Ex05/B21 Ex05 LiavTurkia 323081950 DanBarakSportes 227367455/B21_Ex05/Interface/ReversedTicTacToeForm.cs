using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace B21_Ex05.Interface
{
    public class ReversedTicTacToeForm : Form
    {
        private readonly Button[,] r_ButtonMatrix;
        private readonly TableLayoutPanel r_ButtonLayout;
        private readonly TableLayoutPanel r_OverallLayout;
        private readonly TableLayoutPanel r_LabelLayout;

        private readonly Game.GameSettings r_Settings;

        private readonly Label r_Player1;
        private readonly Label r_Player2;

        // Player1, Player2
        private readonly int[] r_Score;

        private Game.Game m_CurrentGame;

        public ReversedTicTacToeForm(WinFormsUI i_UI, Game.GameSettings i_Settings)
        {
            this.r_ButtonMatrix = new Button[i_Settings.BoardSize, i_Settings.BoardSize];
            this.r_Settings = i_Settings;

            this.Name = "ReversedTicTacToe";
            this.Text = "ReversedTicTacToe";
            this.Load += new System.EventHandler(this.ReversedTicTacToe_Load);
            this.ResumeLayout(false);

            i_UI.BeforeGame += this.UI_BeforeGame;
            i_UI.AfterGame += this.UI_AfterGame;

            this.r_ButtonLayout = new TableLayoutPanel();
            this.r_ButtonLayout.ColumnCount = i_Settings.BoardSize;
            this.r_ButtonLayout.RowCount = i_Settings.BoardSize;
            this.r_ButtonLayout.Anchor = AnchorStyles.Top;
            this.r_ButtonLayout.AutoSize = true;

            this.r_LabelLayout = new TableLayoutPanel();
            this.r_LabelLayout.ColumnCount = 2;
            this.r_LabelLayout.RowCount = 1;

            this.r_OverallLayout = new TableLayoutPanel();
            this.r_OverallLayout.ColumnCount = 1;
            this.r_OverallLayout.RowCount = 2;

            this.r_Player1 = new Label();
            this.r_Player1.Font = new System.Drawing.Font(this.r_Player1.Font, System.Drawing.FontStyle.Bold);
            this.r_Player1.Text = string.Format("{0}: 0", i_Settings.Player1.Name);
            this.r_Player1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.r_Player1.AutoSize = true;
            this.r_Player1.Dock = DockStyle.Fill;
            this.r_LabelLayout.Controls.Add(this.r_Player1, 0, 0);

            this.r_Player2 = new Label();
            this.r_Player2.Text = string.Format("{0}: 0", i_Settings.Player2.Name);
            this.r_Player2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.r_Player2.AutoSize = true;
            this.r_Player2.Dock = DockStyle.Fill;

            this.r_LabelLayout.AutoSize = true;
            this.r_LabelLayout.Anchor = AnchorStyles.Bottom;
            this.r_LabelLayout.Controls.Add(this.r_Player2, 1, 0);

            this.r_OverallLayout.Controls.Add(this.r_ButtonLayout, 0, 0);
            this.r_OverallLayout.Controls.Add(this.r_LabelLayout, 0, 1);

            this.r_OverallLayout.Dock = DockStyle.Fill;
            this.r_OverallLayout.AutoSize = true;

            this.r_Score = new int[2];
            this.r_Score[0] = 0;
            this.r_Score[1] = 0;

            this.AutoSize = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private Game.GameSettings Settings
        {
            get { return this.r_Settings; }
        }

        private void ReversedTicTacToe_Load(object i_Sender, EventArgs i_EventArgs)
        {
            this.r_ButtonLayout.ColumnStyles.Clear();
            this.r_ButtonLayout.RowStyles.Clear();

            // make sure the buttons are evenly spaced
            int percent = 100 / this.Settings.BoardSize;
            for (int i = 0; i < this.Settings.BoardSize; i++)
            {
                this.r_ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, percent));
                this.r_ButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, percent));
            }

            this.r_OverallLayout.ColumnStyles.Clear();
            this.r_OverallLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0f));

            for (int x = 0; x < this.Settings.BoardSize; x++)
            {
                for (int y = 0; y < this.Settings.BoardSize; y++)
                {
                    Button button = new Button();
                    button.Text = string.Empty;
                    button.Name = string.Format("button_{0}.{1}", x, y);
                    button.Dock = DockStyle.Fill;
                    button.ClientSize = new System.Drawing.Size(button.ClientSize.Width, button.ClientSize.Width);
                    button.Tag = new Game.CellPosition(x, y);
                    this.r_ButtonLayout.Controls.Add(button, x, y);
                    this.r_ButtonMatrix[x, y] = button;

                    button.Click += this.button_Click;
                }
            }

            this.Controls.Add(this.r_OverallLayout);
        }

        private void button_Click(object i_Sender, EventArgs i_Args)
        {
            Button button = i_Sender as Button;
            if (button != null)
            {
                TableLayoutPanel table = button.Parent as TableLayoutPanel;
                if (table != null)
                {
                    Game.CellPosition position = button.Tag as Game.CellPosition;

                    if (this.m_CurrentGame != null && position != null && this.m_CurrentGame.CurrentTurn is Game.HumanPlayer)
                    {
                        this.m_CurrentGame.OnMove(position);
                    }
                }
            }
        }

        private void UI_BeforeGame(UI i_Sender, Game.Game i_Game)
        {
            this.m_CurrentGame = i_Game;

            foreach (Button button in this.r_ButtonMatrix)
            {
                if (button != null)
                {
                    button.Text = string.Empty;
                    button.Enabled = true;
                }
            }

            i_Game.Board.CellUpdated += this.Board_CellUpdated;
            i_Game.BeforeRound += this.Game_BeforeRound;
        }

        private void UI_AfterGame(UI i_Sender, Game.Game i_Game, Game.Player i_Winner)
        {
            i_Game.Board.CellUpdated -= this.Board_CellUpdated;
            i_Game.BeforeRound -= this.Game_BeforeRound;

            if (i_Winner == this.r_Settings.Player1)
            {
                this.r_Score[0]++;
            }
            else if (i_Winner == this.r_Settings.Player2)
            {
                this.r_Score[1]++;
            }

            this.r_Player1.Text = string.Format("{0}: {1}", this.r_Settings.Player1.Name, this.r_Score[0]);
            this.r_Player2.Text = string.Format("{0}: {1}", this.r_Settings.Player2.Name, this.r_Score[1]);
        }

        private void Board_CellUpdated(Game.Board i_Sender, Game.CellPosition i_Position, Game.Board.eCellValue i_CellValue)
        {
            string coin;
            switch (i_CellValue)
            {
                case B21_Ex05.Game.Board.eCellValue.Player1:
                    coin = "X";
                    break;
                case B21_Ex05.Game.Board.eCellValue.Player2:
                    coin = "O";
                    break;
                case B21_Ex05.Game.Board.eCellValue.None:
                default:
                    coin = string.Empty;
                    break;
            }

            Button button = this.r_ButtonMatrix[i_Position.X, i_Position.Y];
            button.Enabled = false;
            button.Text = coin;
        }

        private void Game_BeforeRound(Game.Game i_Sender, Game.Player i_Turn)
        {
            if (i_Turn == i_Sender.Player1)
            {
                this.r_Player1.Font = new System.Drawing.Font(this.r_Player1.Font, System.Drawing.FontStyle.Bold);
                this.r_Player2.Font = new System.Drawing.Font(this.r_Player2.Font, System.Drawing.FontStyle.Regular);
            }
            else if (i_Turn == i_Sender.Player2)
            {
                this.r_Player1.Font = new System.Drawing.Font(this.r_Player1.Font, System.Drawing.FontStyle.Regular);
                this.r_Player2.Font = new System.Drawing.Font(this.r_Player2.Font, System.Drawing.FontStyle.Bold);
            }
        }
    }
}