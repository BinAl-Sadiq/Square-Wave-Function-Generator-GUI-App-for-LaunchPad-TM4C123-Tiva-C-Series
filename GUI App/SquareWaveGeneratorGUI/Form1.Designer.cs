namespace SquareWaveGeneratorGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SignalDuration = new System.Windows.Forms.NumericUpDown();
            this.DutyRatio = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Submit = new System.Windows.Forms.Button();
            this.PortsList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SignalDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DutyRatio)).BeginInit();
            this.SuspendLayout();
            // 
            // SignalDuration
            // 
            this.SignalDuration.AccessibleName = "SignalDuration";
            this.SignalDuration.Location = new System.Drawing.Point(129, 51);
            this.SignalDuration.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.SignalDuration.Name = "SignalDuration";
            this.SignalDuration.Size = new System.Drawing.Size(120, 20);
            this.SignalDuration.TabIndex = 0;
            this.SignalDuration.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // DutyRatio
            // 
            this.DutyRatio.AccessibleName = "DutyRatio";
            this.DutyRatio.Location = new System.Drawing.Point(129, 103);
            this.DutyRatio.Name = "DutyRatio";
            this.DutyRatio.Size = new System.Drawing.Size(120, 20);
            this.DutyRatio.TabIndex = 1;
            this.DutyRatio.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Signal Duration(μs)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Duty Ratio";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Submit
            // 
            this.Submit.AccessibleDescription = "SubmitButton";
            this.Submit.Location = new System.Drawing.Point(86, 160);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 4;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // PortsList
            // 
            this.PortsList.AccessibleName = "PortsList";
            this.PortsList.FormattingEnabled = true;
            this.PortsList.Location = new System.Drawing.Point(128, 12);
            this.PortsList.Name = "PortsList";
            this.PortsList.Size = new System.Drawing.Size(121, 21);
            this.PortsList.TabIndex = 5;
            this.PortsList.Text = "Select the port...";
            this.PortsList.SelectedIndexChanged += new System.EventHandler(this.PortsList_SelectedIndexChanged);
            this.PortsList.Click += new System.EventHandler(this.PortsList_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Connect To Port";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 212);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PortsList);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DutyRatio);
            this.Controls.Add(this.SignalDuration);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Square Wave Generator";
            ((System.ComponentModel.ISupportInitialize)(this.SignalDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DutyRatio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown SignalDuration;
        private System.Windows.Forms.NumericUpDown DutyRatio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.ComboBox PortsList;
        private System.Windows.Forms.Label label3;
    }
}

