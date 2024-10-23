using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace libwpfguts.ViewModels
{
    public class SelectableItemsViewModel
    : INotifyPropertyChanged
    {
        private ObservableCollection<SelectableItemViewModel> items;
        public ObservableCollection<SelectableItemViewModel> Items 
        {
            get => items;
            set
            {
                if (items != value)
                {
                    items = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        private void OnNotifyPropertyChanged([CallerMemberName] string name = "ERROR")
        {
            if (PropertyChanged != null && name != "ERROR")
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
