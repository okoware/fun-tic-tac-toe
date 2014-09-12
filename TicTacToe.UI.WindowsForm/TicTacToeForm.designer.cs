namespace TicTacToe.UI.WindowsForm
{
    partial class TicTacToeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicTacToeForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.timePerMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timePerMoveToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.difficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.difficultyToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.ticTacToeBoard = new TicTacToe.UI.WindowsForm.TicTacToeBoard();
            this.playerOInformationPanel = new TicTacToe.UI.WindowsForm.PlayerInformationPanel();
            this.playerXInformationPanel = new TicTacToe.UI.WindowsForm.PlayerInformationPanel();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 294);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(563, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(548, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.Text = "let rec ``fun`` (a:\'tic) (b:\'tac) : \'toe = ``fun`` a b";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(563, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.toolStripSeparator1,
            this.timePerMoveToolStripMenuItem,
            this.difficultyToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // timePerMoveToolStripMenuItem
            // 
            this.timePerMoveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timePerMoveToolStripComboBox});
            this.timePerMoveToolStripMenuItem.Name = "timePerMoveToolStripMenuItem";
            this.timePerMoveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.timePerMoveToolStripMenuItem.Text = "Time Per Move";
            // 
            // timePerMoveToolStripComboBox
            // 
            this.timePerMoveToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timePerMoveToolStripComboBox.Name = "timePerMoveToolStripComboBox";
            this.timePerMoveToolStripComboBox.Size = new System.Drawing.Size(121, 21);
            // 
            // difficultyToolStripMenuItem
            // 
            this.difficultyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.difficultyToolStripComboBox});
            this.difficultyToolStripMenuItem.Name = "difficultyToolStripMenuItem";
            this.difficultyToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.difficultyToolStripMenuItem.Text = "Difficulty";
            // 
            // difficultyToolStripComboBox
            // 
            this.difficultyToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficultyToolStripComboBox.Name = "difficultyToolStripComboBox";
            this.difficultyToolStripComboBox.Size = new System.Drawing.Size(121, 21);
            // 
            // ticTacToeBoard
            // 
            this.ticTacToeBoard.BackColor = System.Drawing.Color.Black;
            this.ticTacToeBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ticTacToeBoard.Location = new System.Drawing.Point(127, 24);
            this.ticTacToeBoard.Name = "ticTacToeBoard";
            this.ticTacToeBoard.Size = new System.Drawing.Size(309, 270);
            this.ticTacToeBoard.TabIndex = 4;
            this.ticTacToeBoard.ViewModel = null;
            // 
            // playerOInformationPanel
            // 
            this.playerOInformationPanel.BackColor = System.Drawing.Color.MidnightBlue;
            this.playerOInformationPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.playerOInformationPanel.Location = new System.Drawing.Point(436, 24);
            this.playerOInformationPanel.Name = "playerOInformationPanel";
            this.playerOInformationPanel.Player = TicTacToe.Engine.Piece.O;
            this.playerOInformationPanel.Size = new System.Drawing.Size(127, 270);
            this.playerOInformationPanel.TabIndex = 3;
            this.playerOInformationPanel.ViewModel = null;
            // 
            // playerXInformationPanel
            // 
            this.playerXInformationPanel.BackColor = System.Drawing.Color.MidnightBlue;
            this.playerXInformationPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.playerXInformationPanel.Location = new System.Drawing.Point(0, 24);
            this.playerXInformationPanel.Name = "playerXInformationPanel";
            this.playerXInformationPanel.Player = TicTacToe.Engine.Piece.X;
            this.playerXInformationPanel.Size = new System.Drawing.Size(127, 270);
            this.playerXInformationPanel.TabIndex = 2;
            this.playerXInformationPanel.ViewModel = null;
            // 
            // TicTacToeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(563, 316);
            this.Controls.Add(this.ticTacToeBoard);
            this.Controls.Add(this.playerOInformationPanel);
            this.Controls.Add(this.playerXInformationPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TicTacToeForm";
            this.Text = "fun : \'tic -> \'tac -> \'toe";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private PlayerInformationPanel playerXInformationPanel;
        private PlayerInformationPanel playerOInformationPanel;
        private TicTacToeBoard ticTacToeBoard;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem timePerMoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox timePerMoveToolStripComboBox;
        private System.Windows.Forms.ToolStripMenuItem difficultyToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox difficultyToolStripComboBox;

    }
}

