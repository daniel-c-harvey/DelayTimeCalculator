using core;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

using libwpfguts.Core;

namespace libwpfguts.Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:libwpfguts"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:libwpfguts;assembly=libwpfguts"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:RadioGroupBox/>
    ///
    /// </summary>
    public class RadioGroupBox : Control
    {
        static RadioGroupBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RadioGroupBox), new FrameworkPropertyMetadata(typeof(RadioGroupBox)));
            ItemsSourceProperty.OverrideMetadata(typeof(RadioGroupBox), new FrameworkPropertyMetadata(OnItemsSourceChanged));
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
            DependencyProperty.Register(nameof(SelectedValue), typeof(object), typeof(RadioGroupBox), new PropertyMetadata(OnSelectedValueChanged));

        private static void OnSelectedValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selectedRadio = ((RadioGroupBox)d).ItemsView.OfType<ISelectable>().FirstOrDefault(s => s.Item == e.NewValue);
            if (selectedRadio != null)
            {
                selectedRadio.IsSelected = true;
            }
        }

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
    }
}
