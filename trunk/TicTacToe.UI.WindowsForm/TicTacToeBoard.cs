using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using TicTacToe.Engine;

namespace TicTacToe.UI.WindowsForm
{
    public partial class TicTacToeBoard : DesignableTicTacToeBoard
    {
        private readonly List<Button> positionButtons;
        private readonly Color backColor;
        private readonly Color winningCellsBackColor = Color.Yellow;

        public TicTacToeBoard()
        {
            InitializeComponent();
            this.backColor = this.position0Button.BackColor;
            this.positionButtons = CreatePositionButtonList();
        }

        private List<Button> CreatePositionButtonList()
        {
            const string PositionButtonTag = "position";
            return (from button in this.positionButtonsLayoutPanel.Controls.OfType<Button>()
                    where StringComparer.InvariantCulture.Equals(PositionButtonTag, button.Tag)
                    orderby button.Name
                    select button).ToList();
        }

        protected override void OnWireViewModel()
        {            
            for (int i = 0; i < this.positionButtons.Count; i++)
            {
                var positionButton = this.positionButtons[i];
                int selectedPosition = i; // declaring varible here for the closure
                Action<object, EventArgs> boardClickHandler = (sender, e) =>
                {
                    this.ViewModel.SelectedMovePosition = selectedPosition;
                    this.ViewModel.HumanMoveCommand.Execute(null);
                };
                positionButton.Click += new EventHandler(boardClickHandler);
            }
        }

        private void UpdateBoard()
        {
            int positionButtonIndex = 0;

            foreach (var piece in this.ViewModel.Board)
            {
                var positionButton = this.positionButtons[positionButtonIndex];
                string pieceText = (piece != Piece.E) ? piece.ToString() : string.Empty;
                positionButton.SetText(pieceText);
                positionButtonIndex++;
            }
        }

        private void HighlightWinningRows()
        {
            this.ViewModel.WinningRows
                           .SelectMany(position => position)
                           .Distinct().ToList()
                           .ForEach((position) => this.positionButtons[position].BackColor = winningCellsBackColor);
        }

        private void ClearRowHighlight()
        {
            this.positionButtons.ForEach(b => b.BackColor = backColor);
        }

        private void UpdateGameState()
        {
            switch (this.ViewModel.GameState)
            {
                case GameState.GameOver:
                    this.HighlightWinningRows();
                    break;
                case GameState.Started:
                    this.ClearRowHighlight();
                    break;
            }
        }

        protected override void OnModelPropertyChanged(string propertyName)
        {
            switch (propertyName)
            {
                case ViewModelProperties.TicTacToeViewModel.GameState:
                    this.UpdateGameState();
                    break;
                case ViewModelProperties.TicTacToeViewModel.Board:
                    this.UpdateBoard();
                    break;
            }
        }
    }

    public class DesignableTicTacToeBoard : ViewModelUserControl<TicTacToeViewModel> { }
}
