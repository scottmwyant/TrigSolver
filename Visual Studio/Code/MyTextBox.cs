// References
using System;
using System.Windows.Forms;

namespace TrigSolver
{
    public class MyTextBox : TextBox
    {
        // Fields
        private double myValue = new double();
        
        // Properties
        public double Value { get { return myValue; } set { myValue = value; } }
        public string FeatureType { get; set; }
        public bool Valid { get; set; }
        public bool Input { get; set; }

        // Methods
        public void UpdateNumericValue()
        {
            double temp = new double();
            double.TryParse(this.Text, out temp);
            myValue = temp;
        }

        public void UpdateText(byte precision)
        {
            this.Text = Convert.ToString(Math.Round(this.Value, precision));
        }
    }
}