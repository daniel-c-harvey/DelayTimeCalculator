using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace libwpfguts.Converters
{
    [ValueConversion(typeof(IEnumerable<object>), typeof(IEnumerable<SelectedViewModel>))]
    public class SelectableViewModelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Ensure the input value is an ObservableCollection<object>
            if (value is IEnumerable<object> collection)
            {
                // Return the collection cast to IEnumerable
                return collection.OfType<object>().Select(o => new SelectedViewModel() { Item = o });
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable itemsSource)
            {
                return itemsSource.OfType<SelectedViewModel>().Select(i => i.Item);
            }
            return null;
        }
    }
}
