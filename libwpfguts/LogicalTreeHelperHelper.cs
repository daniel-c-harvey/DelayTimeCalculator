using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace libwpfguts
{
    public static class LogicalTreeHelperHelper
    {
        public static IEnumerable<T> GetChildrenRecursive<T>(FrameworkElement element)
        {
            IEnumerable children = LogicalTreeHelper.GetChildren(element);
            IEnumerable<T> elements = children.OfType<T>();
            if (elements.Any())
            {
                return elements;
            }
            else 
            {
                foreach (FrameworkElement child in children)
                {
                    // repeat down a level breadth first until the desired type is found or we run out of elements
                    return GetChildrenRecursive<T>(child);
                }    
            }

            return Array.Empty<T>();
        }
    }
}
