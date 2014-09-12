namespace TicTacToe.UI.WindowsForm
{
    partial class TicTacToeBoard
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
            this.positionButtonsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.position8Button = new System.Windows.Forms.Button();
            this.position7Button = new System.Windows.Forms.Button();
            this.position1Button = new System.Windows.Forms.Button();
            this.position0Button = new System.Windows.Forms.Button();
            this.position2Button = new System.Windows.Forms.Button();
            this.position3Button = new System.Windows.Forms.Button();
            this.position4Button = new System.Windows.Forms.Button();
            this.position5Button = new System.Windows.Forms.Button();
            this.position6Button = new System.Windows.Forms.Button();
            this.positionButtonsLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // positionButtonsLayoutPanel
            // 
            this.positionButtonsLayoutPanel.ColumnCount = 3;
            this.positionButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.positionButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.positionButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.positionButtonsLayoutPanel.Controls.Add(this.position8Button, 0, 2);
            this.positionButtonsLayoutPanel.Controls.Add(this.position7Button, 0, 2);
            this.positionButtonsLayoutPanel.Controls.Add(this.position1Button, 1, 0);
            this.positionButtonsLayoutPanel.Controls.Add(this.position0Button, 0, 0);
            this.positionButtonsLayoutPanel.Controls.Add(this.position2Button, 2, 0);
            this.positionButtonsLayoutPanel.Controls.Add(this.position3Button, 0, 1);
            this.positionButtonsLayoutPanel.Controls.Add(this.position4Button, 1, 1);
            this.positionButtonsLayoutPanel.Controls.Add(this.position5Button, 2, 1);
            this.positionButtonsLayoutPanel.Controls.Add(this.position6Button, 0, 2);
            this.positionButtonsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionButtonsLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.positionButtonsLayoutPanel.Name = "positionButtonsLayoutPanel";
            this.positionButtonsLayoutPanel.RowCount = 3;
            this.positionButtonsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.positionButtonsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.positionButtonsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.positionButtonsLayoutPanel.Size = new System.Drawing.Size(269, 235);
            this.positionButtonsLayoutPanel.TabIndex = 0;
            // 
            // position8Button
            // 
            this.position8Button.BackColor = System.Drawing.Color.White;
            this.position8Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.position8Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.position8Button.Font = new System.Drawing.Font("Comic Sans MS", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.position8Button.Location = new System.Drawing.Point(181, 159);
            this.position8Button.Name = "position8Button";
            this.position8Button.Size = new System.Drawing.Size(85, 73);
            this.position8Button.TabIndex = 9;
            this.position8Button.Tag = "position";
            this.position8Button.UseVisualStyleBackColor = false;
            // 
            // position7Button
            // 
            this.position7Button.BackColor = System.Drawing.Color.White;
            this.position7Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.position7Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.position7Button.Font = new System.Drawing.Font("Comic Sans MS", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.position7Button.Location = new System.Drawing.Point(92, 159);
            this.position7Button.Name = "position7Button";
            this.position7Button.Size = new System.Drawing.Size(83, 73);
            this.position7Button.TabIndex = 8;
            this.position7Button.Tag = "position";
            this.position7Button.UseVisualStyleBackColor = false;
            // 
            // position1Button
            // 
            this.position1Button.BackColor = System.Drawing.Color.White;
            this.position1Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.position1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.position1Button.Font = new System.Drawing.Font("Comic Sans MS", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.position1Button.Location = new System.Drawing.Point(92, 3);
            this.position1Button.Name = "position1Button";
            this.position1Button.Size = new System.Drawing.Size(83, 72);
            this.position1Button.TabIndex = 2;
            this.position1Button.Tag = "position";
            this.position1Button.UseVisualStyleBackColor = false;
            // 
            // position0Button
            // 
            this.position0Button.BackColor = System.Drawing.Color.White;
            this.position0Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.position0Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.position0Button.Font = new System.Drawing.Font("Comic Sans MS", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.position0Button.Location = new System.Drawing.Point(3, 3);
            this.position0Button.Name = "position0Button";
            this.position0Button.Size = new System.Drawing.Size(83, 72);
            this.position0Button.TabIndex = 1;
            this.position0Button.Tag = "position";
            this.position0Button.UseVisualStyleBackColor = false;
            // 
            // position2Button
            // 
            this.position2Button.BackColor = System.Drawing.Color.White;
            this.position2Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.position2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.position2Button.Font = new System.Drawing.Font("Comic Sans MS", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.position2Button.Location = new System.Drawing.Point(181, 3);
            this.position2Button.Name = "position2Button";
            this.position2Button.Size = new System.Drawing.Size(85, 72);
            this.position2Button.TabIndex = 3;
            this.position2Button.Tag = "position";
            this.position2Button.UseVisualStyleBackColor = false;
            // 
            // position3Button
            // 
            this.position3Button.BackColor = System.Drawing.Color.White;
            this.position3Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.position3Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.position3Button.Font = new System.Drawing.Font("Comic Sans MS", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.position3Button.Location = new System.Drawing.Point(3, 81);
            this.position3Button.Name = "position3Button";
            this.position3Button.Size = new System.Drawing.Size(83, 72);
            this.position3Button.TabIndex = 4;
            this.position3Button.Tag = "position";
            this.position3Button.UseVisualStyleBackColor = false;
            // 
            // position4Button
            // 
            this.position4Button.BackColor = System.Drawing.Color.White;
            this.position4Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.position4Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.position4Button.Font = new System.Drawing.Font("Comic Sans MS", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.position4Button.Location = new System.Drawing.Point(92, 81);
            this.position4Button.Name = "position4Button";
            this.position4Button.Size = new System.Drawing.Size(83, 72);
            this.position4Button.TabIndex = 5;
            this.position4Button.Tag = "position";
            this.position4Button.UseVisualStyleBackColor = false;
            // 
            // position5Button
            // 
            this.position5Button.BackColor = System.Drawing.Color.White;
            this.position5Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.position5Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.position5Button.Font = new System.Drawing.Font("Comic Sans MS", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.position5Button.Location = new System.Drawing.Point(181, 81);
            this.position5Button.Name = "position5Button";
            this.position5Button.Size = new System.Drawing.Size(85, 72);
            this.position5Button.TabIndex = 6;
            this.position5Button.Tag = "position";
            this.position5Button.UseVisualStyleBackColor = false;
            // 
            // position6Button
            // 
            this.position6Button.BackColor = System.Drawing.Color.White;
            this.position6Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.position6Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.position6Button.Font = new System.Drawing.Font("Comic Sans MS", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.position6Button.Location = new System.Drawing.Point(3, 159);
            this.position6Button.Name = "position6Button";
            this.position6Button.Size = new System.Drawing.Size(83, 73);
            this.position6Button.TabIndex = 7;
            this.position6Button.Tag = "position";
            this.position6Button.UseVisualStyleBackColor = false;
            // 
            // TicTacToeBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.positionButtonsLayoutPanel);
            this.Name = "TicTacToeBoard";
            this.Size = new System.Drawing.Size(269, 235);
            this.positionButtonsLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel positionButtonsLayoutPanel;
        private System.Windows.Forms.Button position0Button;
        private System.Windows.Forms.Button position1Button;
        private System.Windows.Forms.Button position2Button;
        private System.Windows.Forms.Button position3Button;
        private System.Windows.Forms.Button position4Button;
        private System.Windows.Forms.Button position5Button;
        private System.Windows.Forms.Button position6Button;
        private System.Windows.Forms.Button position7Button;
        private System.Windows.Forms.Button position8Button;
    }
}
