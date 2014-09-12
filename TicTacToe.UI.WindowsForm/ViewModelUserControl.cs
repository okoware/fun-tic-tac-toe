using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace TicTacToe.UI.WindowsForm
{
    public class ViewModelUserControl<TViewModel> : UserControl where TViewModel : INotifyPropertyChanged
    {
        private readonly object SyncRoot = new object();
        private TViewModel viewModel;

        [Browsable(false)]
        public TViewModel ViewModel
        {
            get
            {
                return this.viewModel;
            }

            set
            {
                if ((value != null) && (this.viewModel == null))
                {
                    lock (SyncRoot)
                    {
                        if (this.viewModel == null)
                        {
                            this.viewModel = value;
                            this.WireViewModel();
                        }
                    }
                }
            }
        }

        private void WireViewModel()
        {
            INotifyPropertyChanged m = this.ViewModel;
            m.PropertyChanged += new PropertyChangedEventHandler(model_PropertyChanged);
            this.OnWireViewModel();
        }

        protected virtual void OnWireViewModel() { }
        protected virtual void OnModelPropertyChanged(string propertyName) { }

        private void model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.OnModelPropertyChanged(e.PropertyName);
        }
    }
}
