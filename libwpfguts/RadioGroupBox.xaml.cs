using System.Text;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace libwpfguts
{
    public partial class RadioGroupBox : ItemsControl
    {
        static RadioGroupBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RadioGroupBox), new FrameworkPropertyMetadata(typeof(RadioGroupBox)));
        }

        public RadioGroupBox()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(nameof(Header),
                                        typeof(string),
                                        typeof(RadioGroupBox));
        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.Register(nameof(SelectedValue),
                                        typeof(object),
                                        typeof(RadioGroupBox),
                                        new PropertyMetadata(OnSelectedValueChanged));

        private static void OnSelectedValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //var selectedRadio = VisualTreeHelperHelper.GetChildrenRecursive<RadioButton>(d)?.FirstOrDefault(r => r.Content == e.NewValue);
            //var selectedRadio = ((RadioGroupBox)d).Items.OfType<ISelectable>().FirstOrDefault(s => s.IsSelected);
            //if (selectedRadio != null)
            //{
            //    selectedRadio.IsSelected = true;
            //}
        }

        public object SelectedValue
        {
            get => GetValue(SelectedValueProperty);
            set => SetValue(SelectedValueProperty, value);
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register(nameof(Orientation),
                                        typeof(Orientation),
                                        typeof(RadioGroupBox));

        private void CheckedItemChanged(object sender, RoutedEventArgs e)
        {
            SelectedValue = ((ContentControl)sender).Content;
        }

        public Orientation Orientation
        {
            get => (Orientation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        public new static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource),
                                        typeof(IEnumerable),
                                        typeof(RadioGroupBox));

        public new IEnumerable ItemsSource
        {
            get => base.ItemsSource;
            set
            {
                base.ItemsSource = value.OfType<object>().Select(o => new SelectedViewModel(o));
                
            }
        }

    }

    public class SelectedViewModel
        : INotifyPropertyChanged
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

        public SelectedViewModel(object item)
        {
            _item = item;
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
