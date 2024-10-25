using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace libwpfguts.Core
{
    public class DisplayMemberPathDataTemplateSelector : DataTemplateSelector
    {
        private string displayMemberPath;
        private DataTemplate? _clrNodeContentTemplate;

        public DisplayMemberPathDataTemplateSelector(string displayMemberPath)
        {
            this.displayMemberPath = displayMemberPath;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            // xml mode is for losers
            {
                if (_clrNodeContentTemplate == null)
                {
                    _clrNodeContentTemplate = new DataTemplate();
                    FrameworkElementFactory text = new FrameworkElementFactory(typeof(TextBlock));
                    Binding binding = new Binding();
                    binding.Path = new PropertyPath(displayMemberPath);
                    //binding.StringFormat = _stringFormat;
                    text.SetBinding(TextBlock.TextProperty, binding);
                    _clrNodeContentTemplate.VisualTree = text;
                    _clrNodeContentTemplate.Seal();
                }
                return _clrNodeContentTemplate;
            }
        }
    }
}
