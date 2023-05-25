
namespace Gravity_Simulation_2._0
{
    partial class Window
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
            this.simBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.simBox)).BeginInit();
            this.SuspendLayout();
            // 
            // simBox
            // 
            this.simBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.simBox.Location = new System.Drawing.Point(12, 12);
            this.simBox.Name = "simBox";
            this.simBox.Size = new System.Drawing.Size(1140, 642);
            this.simBox.TabIndex = 0;
            this.simBox.TabStop = false;
            this.simBox.Paint += new System.Windows.Forms.PaintEventHandler(this.simBox_Paint);
            this.simBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.simBox_MouseDown);
            this.simBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.simBox_MouseMove);
            this.simBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.simBox_MouseUp);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 666);
            this.Controls.Add(this.simBox);
            this.Name = "Window";
            this.Text = "Gravity Simulation";
            ((System.ComponentModel.ISupportInitialize)(this.simBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox simBox;
    }
}

