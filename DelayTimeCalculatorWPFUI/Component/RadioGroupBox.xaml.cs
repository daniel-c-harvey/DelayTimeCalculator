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

        public static readonly DependencyProperty HeaderProperty = 
            DependencyProperty.Register(nameof(Header), 
                                        typeof(string), 
                                        typeof(RadioGroupBox));
        public string? Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty SelectedValueProperty = 
            DependencyProperty.Register(nameof(SelectedValue), 
                                        typeof(object), 
                                        typeof(RadioGroupBox),
                                        new PropertyMetadata(Y));

        private static void Y(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
   
        }

        public object? SelectedValue
        {
            get => GetValue(SelectedValueProperty);
            set => SetValue(SelectedValueProperty, value);
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register(nameof(Orientation),
                                        typeof(Orientation),
                                        typeof(RadioGroupBox),
                                        new PropertyMetadata(X));

        private static void X(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void CheckedItemChanged(object sender, RoutedEventArgs e)
        {
            SelectedValue = ((ContentControl)sender).Content;
        }

        public Orientation Orientation
        {
            get => (Orientation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }
    };
}
