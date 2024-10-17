using core;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace DelayTimeCalculatorWPFUI.Component
{
    public partial class RadioGroupBox : ItemsControl
    {
        static RadioGroupBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RadioGroupBox), new FrameworkPropertyMetadata(typeof(RadioGroupBox)));
        }

        protected IEnumerable<RadioButton> Radios => LogicalTreeHelper.GetChildren(this).OfType<RadioButton>();

        public static readonly DependencyProperty HeaderProperty = 
            DependencyProperty.Register(nameof(Header), 
                                        typeof(string), 
                                        typeof(RadioGroupBox));
        public string? Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        //public delegate void SelectedValueChangedEvent(object value);
        //public event SelectedValueChangedEvent? OnSelectedValueChanged;

        public static readonly DependencyProperty SelectedValueProperty = 
            DependencyProperty.Register(nameof(SelectedValue), 
                                        typeof(object), 
                                        typeof(RadioGroupBox),
                                        new PropertyMetadata(OnSelectedValueChanged));

        private static void OnSelectedValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var radio = ((RadioGroupBox)d).Radios.FirstOrDefault(r => r.Content.Equals(e.NewValue));
            if (radio != null)
            {
                radio.IsChecked = true;
                // notify
            }
        }

        public object? SelectedValue
        {
            get => GetValue(SelectedValueProperty);//Radios.FirstOrDefault(r => r.IsChecked ?? false)?.Content;
            set => SetValue(SelectedValueProperty, value);
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register(nameof(Orientation),
                                        typeof(Orientation),
                                        typeof(RadioGroupBox));
        public Orientation Orientation
        {
            get => (Orientation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }
    };
}
