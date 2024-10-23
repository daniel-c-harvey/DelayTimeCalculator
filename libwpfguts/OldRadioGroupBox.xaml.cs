using core;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace libwpfguts
{
    public partial class OldRadioGroupBox : ItemsControl
    {
        static OldRadioGroupBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(OldRadioGroupBox), new FrameworkPropertyMetadata(typeof(OldRadioGroupBox)));
            ItemsSourceProperty.OverrideMetadata(typeof(OldRadioGroupBox), new FrameworkPropertyMetadata(null, OnCoerceItemsSource));
        }

        public OldRadioGroupBox()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(nameof(Header),
                                        typeof(string),
                                        typeof(OldRadioGroupBox));
        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.Register(nameof(SelectedValue),
                                        typeof(object),
                                        typeof(OldRadioGroupBox),
                                        new PropertyMetadata(OnSelectedValueChanged));

        private static void OnSelectedValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selectedRadio = ((OldRadioGroupBox)d).Items.OfType<ISelectable>().FirstOrDefault(s => s.Item == e.NewValue);
            if (selectedRadio != null)
            {
                selectedRadio.IsSelected = true;
            }
        }

        public object SelectedValue
        {
            get => GetValue(SelectedValueProperty);
            set => SetValue(SelectedValueProperty, value);
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register(nameof(Orientation),
                                        typeof(Orientation),
                                        typeof(OldRadioGroupBox));

        private void CheckedItemChanged(object sender, RoutedEventArgs e)
        {
            SelectedValue = ((ContentControl)sender).Content;
        }

        public Orientation Orientation
        {
            get => (Orientation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //var control = d as ItemsControl;
            //if (control != null)
            //{
            //    control.ItemsSource = ((IEnumerable)e.NewValue).OfType<object>().Select(o => new SelectedViewModel() { Item = o });
            //}
            //ItemsControl.OnItemSourceChanged(d, e);
        }

        private static object OnCoerceItemsSource(DependencyObject d, object value)
        {
            var itemsSource = value as IEnumerable;
            if (itemsSource != null)
            {
                return new ObservableCollection<object>(itemsSource.OfType<object>().Select(o => new SelectedViewModel() { Item = o }));
            }
            return value;
        }
    }

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
