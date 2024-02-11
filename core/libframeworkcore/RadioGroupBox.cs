using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using core;


namespace CustomControls
{
    /// <summary>
    /// This control provides an extension of the radio button behavior of group boxes, and adds support for databinding on the Tag value of the selected radio button.
    /// The databinding should be set to use property change notifications on the data source and control end.
    /// </summary>
    public class RadioGroupBox : GroupBox, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string sPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sPropertyName));
        }

        /// <summary>
        /// This property translates between the selected radio button and the integer code associated with it (presumably from an enumerator).
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedRadioValue
        {
            get
            {
                return (int)Controls.OfType<RadioButton>().Where(opt => opt.Checked).First().Tag;
            }
            set
            {
                {
                    RadioButton button = Controls.OfType<RadioButton>().Where(opt => (int)opt.Tag == value).FirstOrDefault();

                    if (button is null) throw new ArgumentException($"This control does not contain a radio button control that matches the supplied value: {value}");

                    // Select me
                    button.Checked = true;
                    NotifyPropertyChanged(nameof(SelectedRadioValue));
                }
            }
        }

        private void _ControlAdded(object sender, ControlEventArgs e)
        {
            RadioButton optNew = e.Control as RadioButton;

            if (optNew != null)
            {
                // Pass the CheckedChanged event of this radio button to provide notification of when the selected value has changed
                optNew.CheckedChanged += RadioButtonsCheckedChanged;
            }
        }

        private void RadioButtonsCheckedChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged(nameof(SelectedRadioValue));
        }
    }

    /// <summary>
    /// A specialization of a Radio Button which supports assigning strong-typed values.
    /// Inherit to specify the type parameter values at the definition of the sub class.
    /// </summary>
    public abstract class EnumeratedRadioButton<TEnum> : RadioButton where TEnum : Enumeration<TEnum>
    {
        private TEnum _value;
        public TEnum Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }

    /// <summary>
    /// A specialization of the RadioGroupBox to work with Enumeration classes.
    /// Inherit in such a way to explicitly specify the super type parameters at the definition of the sub class.
    /// For example see QtyUMRadioGroupBox class declared at the top of Maintenance.SellingMatrix.Designer.vb
    /// </summary>
    /// <typeparam name="TEnum">The Enumeration type to expose through SelectedRadioValue.</typeparam>
    public abstract class EnumeratedRadioGroupBox<TEnum> : RadioGroupBox where TEnum : Enumeration<TEnum>
    {
        protected IEnumerable<EnumeratedRadioButton<TEnum>> qRadios
        {
            get
            {
                return Controls.OfType<EnumeratedRadioButton<TEnum>>();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new TEnum SelectedRadioValue
        {
            get
            {
                EnumeratedRadioButton<TEnum> rb = qRadios.Where(opt => opt.Checked).FirstOrDefault();

                return rb?.Value;
            }
            set
            {
                {
                    var radio = qRadios.Where(opt => opt.Value == value).FirstOrDefault();
                    if (radio != null)
                    {
                        radio.Checked = true;
                        NotifyPropertyChanged(nameof(SelectedRadioValue));
                    }
                }
            }
        }

        ///// <summary>
        ///// Use this method to automatically assign the correct Enumerator value to the radio button value.
        ///// This attempts to match the Text label property of the radio button with the Name of the correct Enum member.
        ///// </summary>
        //public void BindValuesToEnum(Func<string> )
        //{
        //    IEnumerable<TEnum> enumerations = Enumeration<TEnum>.GetAll();
        //    foreach (EnumeratedRadioButton<TEnum> radio in qRadios)
        //    {
        //        TEnum value = enumerations.FirstOrDefault(enumeration => radio.Text == enumeration.Name);

        //        if (value != null)
        //            radio.Value = value;
        //    }
        //}
    }

}
