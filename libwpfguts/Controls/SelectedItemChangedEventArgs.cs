namespace libwpfguts.Controls
{
    public class SelectedItemChangedEventArgs : EventArgs
    {
        object NewItem { get; set; }
        object OldItem { get; set; }

        public SelectedItemChangedEventArgs(object NewItem, object OldItem)
        {
            this.NewItem = NewItem;
            this.OldItem = OldItem;
        }
    }
}