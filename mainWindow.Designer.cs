
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
            this.stopButton = new System.Windows.Forms.Button();
            this.xforceTextBox = new System.Windows.Forms.TextBox();
            this.xforceLabel = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.yforceLabel = new System.Windows.Forms.Label();
            this.yforceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sunMassTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.planetMassTextBox = new System.Windows.Forms.TextBox();
            this.propertiesPanel = new System.Windows.Forms.Panel();
            this.velShaderCheckBox = new System.Windows.Forms.CheckBox();
            this.debugStats = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.otherMassTextBox = new System.Windows.Forms.TextBox();
            this.simPanel = new System.Windows.Forms.PictureBox();
            this.fpsBar = new System.Windows.Forms.TrackBar();
            this.propertiesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsBar)).BeginInit();
            this.SuspendLayout();
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(4, 0);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(136, 26);
            this.CalculateButton.TabIndex = 0;
            this.CalculateButton.Text = "Start";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(146, 0);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(136, 26);
            this.stopButton.TabIndex = 16;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // xforceTextBox
            // 
            this.xforceTextBox.Location = new System.Drawing.Point(78, 75);
            this.xforceTextBox.Name = "xforceTextBox";
            this.xforceTextBox.Size = new System.Drawing.Size(201, 22);
            this.xforceTextBox.TabIndex = 17;
            this.xforceTextBox.Text = "-1";
            // 
            // xforceLabel
            // 
            this.xforceLabel.AutoSize = true;
            this.xforceLabel.BackColor = System.Drawing.SystemColors.Control;
            this.xforceLabel.Location = new System.Drawing.Point(7, 78);
            this.xforceLabel.Name = "xforceLabel";
            this.xforceLabel.Size = new System.Drawing.Size(65, 17);
            this.xforceLabel.TabIndex = 18;
            this.xforceLabel.Text = "X Force: ";
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(4, 36);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(278, 33);
            this.ResetButton.TabIndex = 20;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // yforceLabel
            // 
            this.yforceLabel.AutoSize = true;
            this.yforceLabel.BackColor = System.Drawing.SystemColors.Control;
            this.yforceLabel.Location = new System.Drawing.Point(7, 106);
            this.yforceLabel.Name = "yforceLabel";
            this.yforceLabel.Size = new System.Drawing.Size(65, 17);
            this.yforceLabel.TabIndex = 26;
            this.yforceLabel.Text = "Y Force: ";
            // 
            // yforceTextBox
            // 
            this.yforceTextBox.Location = new System.Drawing.Point(78, 103);
            this.yforceTextBox.Name = "yforceTextBox";
            this.yforceTextBox.Size = new System.Drawing.Size(201, 22);
            this.yforceTextBox.TabIndex = 25;
            this.yforceTextBox.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(7, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Sun Mass: ";
            // 
            // sunMassTextBox
            // 
            this.sunMassTextBox.Location = new System.Drawing.Point(102, 187);
            this.sunMassTextBox.Name = "sunMassTextBox";
            this.sunMassTextBox.Size = new System.Drawing.Size(177, 22);
            this.sunMassTextBox.TabIndex = 29;
            this.sunMassTextBox.Text = "100000000000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(7, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Planet Mass: ";
            // 
            // planetMassTextBox
            // 
            this.planetMassTextBox.Location = new System.Drawing.Point(102, 131);
            this.planetMassTextBox.Name = "planetMassTextBox";
            this.planetMassTextBox.Size = new System.Drawing.Size(177, 22);
            this.planetMassTextBox.TabIndex = 27;
            this.planetMassTextBox.Text = "1000000000";
            // 
            // propertiesPanel
            // 
            this.propertiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertiesPanel.BackColor = System.Drawing.SystemColors.Control;
            this.propertiesPanel.Controls.Add(this.fpsBar);
            this.propertiesPanel.Controls.Add(this.velShaderCheckBox);
            this.propertiesPanel.Controls.Add(this.debugStats);
            this.propertiesPanel.Controls.Add(this.label3);
            this.propertiesPanel.Controls.Add(this.otherMassTextBox);
            this.propertiesPanel.Controls.Add(this.label1);
            this.propertiesPanel.Controls.Add(this.CalculateButton);
            this.propertiesPanel.Controls.Add(this.sunMassTextBox);
            this.propertiesPanel.Controls.Add(this.label2);
            this.propertiesPanel.Controls.Add(this.planetMassTextBox);
            this.propertiesPanel.Controls.Add(this.stopButton);
            this.propertiesPanel.Controls.Add(this.yforceLabel);
            this.propertiesPanel.Controls.Add(this.xforceTextBox);
            this.propertiesPanel.Controls.Add(this.yforceTextBox);
            this.propertiesPanel.Controls.Add(this.xforceLabel);
            this.propertiesPanel.Controls.Add(this.ResetButton);
            this.propertiesPanel.Location = new System.Drawing.Point(1057, 8);
            this.propertiesPanel.Name = "propertiesPanel";
            this.propertiesPanel.Size = new System.Drawing.Size(284, 700);
            this.propertiesPanel.TabIndex = 31;
            // 
            // velShaderCheckBox
            // 
            this.velShaderCheckBox.AutoSize = true;
            this.velShaderCheckBox.Location = new System.Drawing.Point(10, 259);
            this.velShaderCheckBox.Name = "velShaderCheckBox";
            this.velShaderCheckBox.Size = new System.Drawing.Size(129, 21);
            this.velShaderCheckBox.TabIndex = 34;
            this.velShaderCheckBox.Text = "Velocity Shader";
            this.velShaderCheckBox.UseVisualStyleBackColor = true;
            // 
            // debugStats
            // 
            this.debugStats.AutoSize = true;
            this.debugStats.Location = new System.Drawing.Point(10, 232);
            this.debugStats.Name = "debugStats";
            this.debugStats.Size = new System.Drawing.Size(163, 21);
            this.debugStats.TabIndex = 33;
            this.debugStats.Text = "Show Debug Overlay";
            this.debugStats.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(7, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "Other Mass: ";
            // 
            // otherMassTextBox
            // 
            this.otherMassTextBox.Location = new System.Drawing.Point(102, 159);
            this.otherMassTextBox.Name = "otherMassTextBox";
            this.otherMassTextBox.Size = new System.Drawing.Size(177, 22);
            this.otherMassTextBox.TabIndex = 31;
            this.otherMassTextBox.Text = "1000000000";
            // 
            // simPanel
            // 
            this.simPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simPanel.BackColor = System.Drawing.Color.Black;
            this.simPanel.Location = new System.Drawing.Point(12, 8);
            this.simPanel.Name = "simPanel";
            this.simPanel.Size = new System.Drawing.Size(1028, 700);
            this.simPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.simPanel.TabIndex = 32;
            this.simPanel.TabStop = false;
            this.simPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.simPanel_Paint);
            this.simPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.simPanel_MouseDown);
            this.simPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.simPanel_MouseMove);
            this.simPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.simPanel_MouseUp);
            // 
            // fpsBar
            // 
            this.fpsBar.Location = new System.Drawing.Point(10, 286);
            this.fpsBar.Maximum = 1000;
            this.fpsBar.Minimum = 60;
            this.fpsBar.Name = "fpsBar";
            this.fpsBar.Size = new System.Drawing.Size(269, 56);
            this.fpsBar.TabIndex = 35;
            this.fpsBar.Value = 60;
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1353, 720);
            this.Controls.Add(this.simPanel);
            this.Controls.Add(this.propertiesPanel);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C# Gravity Simulation";
            this.propertiesPanel.ResumeLayout(false);
            this.propertiesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox xforceTextBox;
        private System.Windows.Forms.Label xforceLabel;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label yforceLabel;
        private System.Windows.Forms.TextBox yforceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sunMassTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox planetMassTextBox;
        private System.Windows.Forms.Panel propertiesPanel;
        private System.Windows.Forms.PictureBox simPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox otherMassTextBox;
        private System.Windows.Forms.CheckBox debugStats;
        private System.Windows.Forms.CheckBox velShaderCheckBox;
        private System.Windows.Forms.TrackBar fpsBar;
    }
}

