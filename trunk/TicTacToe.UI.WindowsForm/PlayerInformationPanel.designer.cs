namespace TicTacToe.UI.WindowsForm
{
    partial class PlayerInformationPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playerLabel = new System.Windows.Forms.Label();
            this.remainingTimeLabel = new System.Windows.Forms.Label();
            this.remainingTimeValueLabel = new System.Windows.Forms.Label();
            this.winCountValueLabel = new System.Windows.Forms.Label();
            this.winCountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // playerLabel
            // 
            this.playerLabel.AutoSize = true;
            this.playerLabel.Font = new System.Drawing.Font("Rockwell Extra Bold", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.playerLabel.Location = new System.Drawing.Point(18, 0);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(97, 76);
            this.playerLabel.TabIndex = 0;
            this.playerLabel.Text = "X";
            this.playerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // remainingTimeLabel
            // 
            this.remainingTimeLabel.AutoSize = true;
            this.remainingTimeLabel.Font = new System.Drawing.Font("Rockwell Extra Bold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainingTimeLabel.ForeColor = System.Drawing.Color.White;
            this.remainingTimeLabel.Location = new System.Drawing.Point(4, 82);
            this.remainingTimeLabel.Name = "remainingTimeLabel";
            this.remainingTimeLabel.Size = new System.Drawing.Size(124, 41);
            this.remainingTimeLabel.TabIndex = 1;
            this.remainingTimeLabel.Text = "Time";
            this.remainingTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // remainingTimeValueLabel
            // 
            this.remainingTimeValueLabel.AutoSize = true;
            this.remainingTimeValueLabel.Font = new System.Drawing.Font("Rockwell Extra Bold", 26.25F, System.Drawing.FontStyle.Bold);
            this.remainingTimeValueLabel.ForeColor = System.Drawing.Color.Yellow;
            this.remainingTimeValueLabel.Location = new System.Drawing.Point(45, 124);
            this.remainingTimeValueLabel.Name = "remainingTimeValueLabel";
            this.remainingTimeValueLabel.Size = new System.Drawing.Size(42, 41);
            this.remainingTimeValueLabel.TabIndex = 2;
            this.remainingTimeValueLabel.Text = "0";
            this.remainingTimeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // winCountValueLabel
            // 
            this.winCountValueLabel.AutoSize = true;
            this.winCountValueLabel.Font = new System.Drawing.Font("Rockwell Extra Bold", 26.25F, System.Drawing.FontStyle.Bold);
            this.winCountValueLabel.ForeColor = System.Drawing.Color.White;
            this.winCountValueLabel.Location = new System.Drawing.Point(45, 220);
            this.winCountValueLabel.Name = "winCountValueLabel";
            this.winCountValueLabel.Size = new System.Drawing.Size(42, 41);
            this.winCountValueLabel.TabIndex = 4;
            this.winCountValueLabel.Text = "0";
            this.winCountValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // winCountLabel
            // 
            this.winCountLabel.AutoSize = true;
            this.winCountLabel.Font = new System.Drawing.Font("Rockwell Extra Bold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winCountLabel.ForeColor = System.Drawing.Color.White;
            this.winCountLabel.Location = new System.Drawing.Point(6, 178);
            this.winCountLabel.Name = "winCountLabel";
            this.winCountLabel.Size = new System.Drawing.Size(121, 41);
            this.winCountLabel.TabIndex = 3;
            this.winCountLabel.Text = "Wins";
            this.winCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerInformationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.Controls.Add(this.winCountValueLabel);
            this.Controls.Add(this.winCountLabel);
            this.Controls.Add(this.remainingTimeValueLabel);
            this.Controls.Add(this.remainingTimeLabel);
            this.Controls.Add(this.playerLabel);
            this.Name = "PlayerInformationPanel";
            this.Size = new System.Drawing.Size(127, 301);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.Label remainingTimeLabel;
        private System.Windows.Forms.Label remainingTimeValueLabel;
        private System.Windows.Forms.Label winCountValueLabel;
        private System.Windows.Forms.Label winCountLabel;
    }
}
