using System.Windows.Forms;

namespace core.DataBinding
{
    public static class DataBindingExtensions
    {
        /// <summary>
        /// Adds a binding to the Control's collection, after setting the binding to bidirectional.
        /// </summary>
        public static void AddBi(this ControlBindingsCollection bindings, Binding binding)
        {
            binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            binding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            bindings.Add(binding);
        }
    }
}