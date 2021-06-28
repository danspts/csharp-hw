using System.ComponentModel;

namespace B21_Ex02.WinformsInterface
{
    partial class ReversedTicTacToe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        ///
        ///
        /// 
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.tableLayoutPanel1.ColumnCount = this.m_ButtonMatrix.GetLength(0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = this.m_ButtonMatrix.GetLength(1);
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1110, 866);
            this.tableLayoutPanel1.TabIndex = 0;
            this.label1.Location = new System.Drawing.Point(400, 930);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label2.Location = new System.Drawing.Point(592, 937);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 43);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            this.AutoScaleDimensions = new System.Drawing.SizeF(12D, 25D);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 1008);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReversedTicTacToe";
            this.Text = "ReversedTicTacToe";
            this.Load += new System.EventHandler(this.ReversedTicTacToe_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}