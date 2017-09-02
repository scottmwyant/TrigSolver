using System;

namespace TrigSolver
{
    public class MyTextBox : TextBox
    {
        // Constructor
        public MyTextBox()
        {

        }

        // Properties
        public string FeatureType { get; set; }
        public bool Valid { get; set; }
        public bool Input { get; set; }

        public double NumericValue
        {
            get
            {
                double val = new double();
                double.TryParse(this.Text, out val);
                return val;
            }
        }
    }
}