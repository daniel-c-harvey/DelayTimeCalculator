using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace libwpfguts
{
    public static class VisualTreeHelperHelper
    {
        public static IEnumerable<T> GetChildrenRecursive<T>(DependencyObject parent)
        {
            LinkedList<T> elements = new();

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var element = VisualTreeHelper.GetChild(parent, i);
                if (element is T typedChild)
                {
                    elements.AddLast(typedChild);
                }

                if (!elements.Any())
                {

                }
            }

            return elements;
        }
    }
}
