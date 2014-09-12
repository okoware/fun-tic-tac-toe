using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;
using TicTacToe.Engine;
using System;
using System.Linq;

namespace TicTacToe.UI.WindowsForm
{
    public partial class TicTacToeForm : Form
    {
        private readonly TicTacToeViewModel viewModel;

        public TicTacToeForm()
        {
            InitializeComponent();
            this.viewModel = new TicTacToeViewModel();
            this.WireViewModel();
            this.BindToViewModel();
            this.ticTacToeBoard.ViewModel = this.viewModel;
            this.playerXInformationPanel.ViewModel = this.viewModel.PlayerXViewModel;
            this.playerOInformationPanel.ViewModel = this.viewModel.PlayerOViewModel;
        }

        private void WireViewModel()
        {
            INotifyPropertyChanged m = this.viewModel;
            m.PropertyChanged += new PropertyChangedEventHandler(model_PropertyChanged);

            this.newGameToolStripMenuItem.Click += (sender, e) =>
            {
                ICommand cmd = this.viewModel.ResetGameCommand;
                cmd.Execute(null);
            };
        }

        // TODO: clean this up
        private void BindToViewModel()
        {
            var timePerMoveDataSource = new[] { 1, 2, 3, 4, 5, 10, 30, 60 }.Select(sec => new ItemValue<TimeSpan>(TimeSpan.FromSeconds(sec), string.Format("{0} second{1}", sec, (sec == 1) ? string.Empty : "s"))).ToArray();
            this.timePerMoveToolStripComboBox.Items.AddRange(timePerMoveDataSource);
            this.timePerMoveToolStripComboBox.SelectedIndexChanged += new EventHandler((sender, e) => this.viewModel.TimePerMove = timePerMoveDataSource[this.timePerMoveToolStripComboBox.SelectedIndex].Value);
            this.viewModel.TimePerMove = timePerMoveDataSource[1].Value;

            var difficultyDataSource = new[] { new ItemValue<ushort>(0, "Child's Play"),
                                               new ItemValue<ushort>(1, "Easy"),
                                               new ItemValue<ushort>(2, "Medium"),
                                               new ItemValue<ushort>(3, "Hard"),
                                               new ItemValue<ushort>(5, "Extreme")};
            var defaultDifficulty = difficultyDataSource[2];
            this.difficultyToolStripComboBox.Items.AddRange(difficultyDataSource);
            this.difficultyToolStripComboBox.SelectedIndexChanged += new EventHandler((sender, e) => this.viewModel.PlayerOViewModel.Ply = difficultyDataSource[this.difficultyToolStripComboBox.SelectedIndex].Value);
            this.difficultyToolStripComboBox.SelectedItem = defaultDifficulty;
            this.viewModel.PlayerOViewModel.Ply = defaultDifficulty.Value;
        }

        protected virtual void OnModelPropertyChanged(string propertyName)
        {
            switch (propertyName)
            {
                case ViewModelProperties.TicTacToeViewModel.StatusMessage:
                    this.toolStripStatusLabel.SetText(this.viewModel.StatusMessage);
                    break;
                case ViewModelProperties.TicTacToeViewModel.TimePerMove:
                    this.timePerMoveToolStripComboBox.SelectedItem = this.timePerMoveToolStripComboBox.Items
                        .Cast<ItemValue<TimeSpan>>()
                        .Where(item => item.Value == this.viewModel.TimePerMove)
                        .FirstOrDefault();
                    break;
            }
        }

        private void model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.OnModelPropertyChanged(e.PropertyName);
        }

        class ItemValue<TValue>
        {
            private readonly TValue value;
            private readonly string text;

            public ItemValue(TValue value, string text)
            {
                this.value = value;
                this.text = text;
            }

            public TValue Value { get { return this.value; } }
            public string Text { get { return this.text; } }

            public override string ToString()
            {
                return this.text;
            }
        }
    }
}
