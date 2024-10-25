using core;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

using libwpfguts.Core;
using System.Windows.Input;

namespace libwpfguts.Controls
{
    public class RadioGroupBox : Control
    {
        public static RoutedCommand SelectedValueChangedCommand = new RoutedCommand();

        static RadioGroupBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RadioGroupBox), new FrameworkPropertyMetadata(typeof(RadioGroupBox)));
            ItemsSourceProperty.OverrideMetadata(typeof(RadioGroupBox), new FrameworkPropertyMetadata(OnItemsSourceChanged));
        }

        public RadioGroupBox()
        {
            CommandBindings.Add(new CommandBinding(SelectedValueChangedCommand, CheckedItemChanged));
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((RadioGroupBox)d).SetItemView((IEnumerable<object>)e.NewValue);
        }

        private void SetItemView(IEnumerable<object> items)
        {
            ItemsView = new ObservableCollection<SelectedViewModel>(items.Select(i => new SelectedViewModel() { Item = i }));
        }

        public IEnumerable<object> ItemsSource
        {
            get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable<object>), typeof(RadioGroupBox));

        public IEnumerable<object> ItemsView
        {
            get { return (IEnumerable<object>)GetValue(ItemsViewProperty); }
            private set { SetValue(ItemsViewProperty, value); }
        }

        public static readonly DependencyProperty ItemsViewProperty =
            DependencyProperty.Register(nameof(ItemsView), typeof(IEnumerable<object>), typeof(RadioGroupBox));

        public object SelectedValue
        {
            get => GetValue(SelectedValueProperty);
            set => SetValue(SelectedValueProperty, value);
        }

        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.Register(nameof(SelectedValue), typeof(object), typeof(RadioGroupBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedValueChanged));

        private static void OnSelectedValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var rgb = d as RadioGroupBox;
            var selectedRadio = rgb?.ItemsView.OfType<ISelectable>().FirstOrDefault(s => s.Item == e.NewValue);
            if (selectedRadio != null)
            {
                if (!selectedRadio.IsSelected)
                {
                   selectedRadio.IsSelected = true;
                }
                rgb?.SelectedItemChanged?.Invoke(rgb, new SelectedItemChangedEventArgs(e.NewValue, e.OldValue));
            }
        }

        public delegate void SelectedItemChangedEventHandler(object sender, SelectedItemChangedEventArgs args);
        public event SelectedItemChangedEventHandler? SelectedItemChanged;

        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(nameof(Header), typeof(string), typeof(RadioGroupBox));

        public Orientation Orientation
        {
            get => (Orientation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(RadioGroupBox));

        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }

        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register(nameof(DisplayMemberPath), typeof(string), typeof(RadioGroupBox), new PropertyMetadata(OnDisplayMemberPathChanged));

        private static void OnDisplayMemberPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((RadioGroupBox)d).SetItemTemplateSelector((string)e.NewValue);
        }

        private void SetItemTemplateSelector(string displayMemberPath)
        {
            ItemTemplateSelector = new DisplayMemberPathDataTemplateSelector(displayMemberPath);
        }

        public DisplayMemberPathDataTemplateSelector ItemTemplateSelector
        {
            get => (DisplayMemberPathDataTemplateSelector)GetValue(ItemTemplateSelectorProperty);
            set => SetValue(ItemTemplateSelectorProperty, value);
        }

        public static readonly DependencyProperty ItemTemplateSelectorProperty = 
            DependencyProperty.Register(nameof(ItemTemplateSelector), typeof(DisplayMemberPathDataTemplateSelector), typeof(RadioGroupBox), new PropertyMetadata(null));

        private void CheckedItemChanged(object sender, ExecutedRoutedEventArgs e)
        {
            SelectedValue = e.Parameter;
        }
    }
}
