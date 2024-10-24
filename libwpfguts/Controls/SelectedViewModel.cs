using core;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace libwpfguts
{
    public class SelectedViewModel
        : INotifyPropertyChanged, ISelectable
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        private object _item = default!;
        public object Item
        {
            get => _item;
            set
            {
                if (_item != value)
                {
                    _item = value;
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
