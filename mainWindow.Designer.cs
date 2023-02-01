
namespace Gravity_Simulator
{
    partial class mainWindow
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
            this.CalculateButton = new System.Windows.Forms.Button();
            this.sunPictureBox = new System.Windows.Forms.PictureBox();
            this.planetPictureBox = new System.Windows.Forms.PictureBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.startingForceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SunY = new System.Windows.Forms.Label();
            this.SunX = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sunPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planetPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(12, 12);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(136, 26);
            this.CalculateButton.TabIndex = 0;
            this.CalculateButton.Text = "Start";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // sunPictureBox
            // 
            this.sunPictureBox.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.sunPictureBox.Location = new System.Drawing.Point(993, 510);
            this.sunPictureBox.Name = "sunPictureBox";
            this.sunPictureBox.Size = new System.Drawing.Size(50, 50);
            this.sunPictureBox.TabIndex = 12;
            this.sunPictureBox.TabStop = false;
            // 
            // planetPictureBox
            // 
            this.planetPictureBox.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.planetPictureBox.Location = new System.Drawing.Point(1086, 417);
            this.planetPictureBox.Name = "planetPictureBox";
            this.planetPictureBox.Size = new System.Drawing.Size(25, 25);
            this.planetPictureBox.TabIndex = 13;
            this.planetPictureBox.TabStop = false;
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.BackColor = System.Drawing.SystemColors.Control;
            this.xLabel.Location = new System.Drawing.Point(607, 21);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(69, 17);
            this.xLabel.TabIndex = 14;
            this.xLabel.Text = "Planet X: ";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.BackColor = System.Drawing.SystemColors.Control;
            this.yLabel.Location = new System.Drawing.Point(607, 48);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(69, 17);
            this.yLabel.TabIndex = 15;
            this.yLabel.Text = "Planet Y: ";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(171, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(136, 26);
            this.stopButton.TabIndex = 16;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // startingForceTextBox
            // 
            this.startingForceTextBox.Location = new System.Drawing.Point(447, 12);
            this.startingForceTextBox.Name = "startingForceTextBox";
            this.startingForceTextBox.Size = new System.Drawing.Size(144, 22);
            this.startingForceTextBox.TabIndex = 17;
            this.startingForceTextBox.Text = "7";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(330, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Starting Force: ";
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.Red;
            this.ExitButton.Location = new System.Drawing.Point(12, 44);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(136, 33);
            this.ExitButton.TabIndex = 19;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(171, 44);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(136, 33);
            this.ResetButton.TabIndex = 20;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // SunY
            // 
            this.SunY.AutoSize = true;
            this.SunY.BackColor = System.Drawing.SystemColors.Control;
            this.SunY.Location = new System.Drawing.Point(830, 48);
            this.SunY.Name = "SunY";
            this.SunY.Size = new System.Drawing.Size(54, 17);
            this.SunY.TabIndex = 22;
            this.SunY.Text = "Sun Y: ";
            // 
            // SunX
            // 
            this.SunX.AutoSize = true;
            this.SunX.BackColor = System.Drawing.SystemColors.Control;
            this.SunX.Location = new System.Drawing.Point(830, 21);
            this.SunX.Name = "SunX";
            this.SunX.Size = new System.Drawing.Size(54, 17);
            this.SunX.TabIndex = 21;
            this.SunX.Text = "Sun X: ";
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1380, 691);
            this.Controls.Add(this.SunY);
            this.Controls.Add(this.SunX);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startingForceTextBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.planetPictureBox);
            this.Controls.Add(this.sunPictureBox);
            this.Controls.Add(this.CalculateButton);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "mainWindow";
            this.Text = "Gravity Simulation";
            ((System.ComponentModel.ISupportInitialize)(this.sunPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planetPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.PictureBox sunPictureBox;
        private System.Windows.Forms.PictureBox planetPictureBox;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox startingForceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label SunY;
        private System.Windows.Forms.Label SunX;
    }
}

