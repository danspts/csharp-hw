using System.ComponentModel;
using System.Windows.Forms;

namespace B21_Ex05.Interface
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.startButton = new System.Windows.Forms.Button();
            this.playerText1 = new System.Windows.Forms.TextBox();
            this.playerText2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.isNotComputerCheckbox = new System.Windows.Forms.CheckBox();
            this.numericUpDownCols = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            resources.ApplyResources(this.startButton, "startButton");
            this.startButton.Name = "startButton";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // playerText1
            // 
            resources.ApplyResources(this.playerText1, "playerText1");
            this.playerText1.Name = "playerText1";
            // 
            // playerText2
            // 
            resources.ApplyResources(this.playerText2, "playerText2");
            this.playerText2.Name = "playerText2";
            this.playerText2.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // isNotComputerCheckbox
            // 
            resources.ApplyResources(this.isNotComputerCheckbox, "isNotComputerCheckbox");
            this.isNotComputerCheckbox.Name = "isNotComputerCheckbox";
            this.isNotComputerCheckbox.UseVisualStyleBackColor = true;
            this.isNotComputerCheckbox.CheckedChanged += new System.EventHandler(this.isNotComputerCheckbox_CheckedChanged);
            // 
            // numericUpDownCols
            // 
            resources.ApplyResources(this.numericUpDownCols, "numericUpDownCols");
            this.numericUpDownCols.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownCols.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownCols.Name = "numericUpDownCols";
            this.numericUpDownCols.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numericUpDownRows
            // 
            resources.ApplyResources(this.numericUpDownRows, "numericUpDownRows");
            this.numericUpDownRows.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownRows.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownRows);
            this.Controls.Add(this.numericUpDownCols);
            this.Controls.Add(this.isNotComputerCheckbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playerText2);
            this.Controls.Add(this.playerText1);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.NumericUpDown numericUpDownCols;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox isNotComputerCheckbox;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox playerText1;

        private System.Windows.Forms.Button startButton;

        #endregion

        private TextBox playerText2;
        private Label label5;
    }
}