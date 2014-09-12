using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TicTacToe.Engine;

namespace TicTacToe.UI.WindowsForm
{
    public partial class PlayerInformationPanel : DesignablePlayerInformationPanel
    {
        public PlayerInformationPanel()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [Category("Tic Tac Toe")]
        public Piece Player
        {
            get
            { 
                Piece piece;
                return Enum.TryParse<Piece>(this.playerLabel.Text, true, out piece) ? piece : Piece.E; 
            }
            set { this.playerLabel.Text = value != Piece.E ? value.ToString() : string.Empty; }
        }

        protected override void OnWireViewModel()
        {
        }

        protected override void OnModelPropertyChanged(string propertyName)
        {
            switch (propertyName)
            {
                case ViewModelProperties.PlayerViewModel.WinCount:
                    this.winCountValueLabel.SetText(this.ViewModel.WinCount.ToString());
                    break;
                case ViewModelProperties.PlayerViewModel.RemainingMoveTime:
                    TimeSpan remainingTime = this.ViewModel.RemainingMoveTime;
                    this.remainingTimeValueLabel.SetText(remainingTime != TimeSpan.Zero ? remainingTime.TotalSeconds.ToString() : string.Empty);
                    break;
            }
        }
    }

    public class DesignablePlayerInformationPanel : ViewModelUserControl<PlayerViewModel> { }
}
