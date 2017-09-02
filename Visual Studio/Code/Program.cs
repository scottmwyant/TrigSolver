using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TrigSolver
{
    public static class Program
    {
        // Class attributes
        [STAThread]



        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        // Puropose: This method serves as an entry point for the program.
        //
        // Approach: Default entry point.  No command line arguments are used.
        //
        static void Main()
        {
            Form1 myForm = new Form1();
            myForm.ShowDialog();
        }

    }


    public class Triangle
    {

        // Class fields
        private PointF[] points = new PointF[3];
        private float[] sides = new float[3];
        private float[] angles = new float[3];

        // Class properties
        public float AngleA { get { return angles[0]; } }
        public float AngleB { get { return angles[1]; } }
        public float AngleC { get { return angles[2]; } }
        public float SideA { get { return sides[0]; } }
        public float SideB { get { return sides[1]; } }
        public float SideC { get { return sides[2]; } }

        public Triangle(string config, float[] values)
        {
            switch (config.Substring(0, 3))
            {
                case "AAS":

                    // Given values
                    angles[0] = values[0];
                    angles[1] = values[1];
                    sides[0] = values[2];

                    // Subtract angles from pi to get last angle.
                    angles[2] = (float)(Math.PI - angles[0] - angles[1]);

                    // Law-Of-Sines to get side B.
                    sides[1] = (float)(sides[0] / Math.Sin(angles[0]) * Math.Sin(angles[1]));

                    // Law-Of-Sines to get side C.
                    sides[2] = (float)(sides[0] / Math.Sin(angles[0]) * Math.Sin(angles[2]));

                    break;

                case "ASA":

                    // Given values
                    angles[0] = values[0];
                    sides[2] = values[1];
                    angles[1] = values[2];

                    // Subtract angles from pi to get last angle.
                    angles[2] = (float)(Math.PI - angles[0] - angles[1]);

                    // Law-Of-Sines to get side A.
                    sides[0] = (float)((sides[2] / Math.Sin(angles[2])) * Math.Sin(angles[0]));

                    // Law-Of-Sines to get side B.
                    sides[1] = (float)((sides[2] / Math.Sin(angles[2])) * Math.Sin(angles[1]));

                    break;

                case "SAS":

                    // Given values
                    sides[0] = values[0];
                    angles[2] = values[1];
                    sides[1] = values[2];

                    // Law-Of-Cosines to get side C.
                    sides[2] = (float)Math.Sqrt((Math.Pow(sides[0], 2)) + (Math.Pow(sides[1], 2)) - (2 * sides[0] * sides[1] * Math.Cos(angles[2])));

                    // Law-Of-Sines to get Alpha.
                    angles[0] = (float)Math.Asin((Math.Sin(angles[2]) / sides[2]) * sides[0]);

                    // Law-Of-Sines to get Beta.
                    angles[1] = (float)Math.Asin((Math.Sin(angles[2]) / sides[2]) * sides[1]);

                    break;

                case "SSS":

                    // Given values
                    sides[0] = values[0];
                    sides[1] = values[1];
                    sides[2] = values[2];

                    // Law-Of-Cosines to get Alpha.
                    angles[0] = (float)Math.Acos((Math.Pow(sides[0], 2) - Math.Pow(sides[1], 2) - Math.Pow(sides[2], 2)) / (-2 * sides[1] * sides[2]));

                    // Law-Of-Cosines to get Beta.
                    angles[1] = (float)Math.Acos((Math.Pow(sides[1], 2) - Math.Pow(sides[0], 2) - Math.Pow(sides[2], 2)) / (-2 * sides[0] * sides[2]));

                    // Subtract angles from pi to get last angle.
                    angles[2] = (float)(Math.PI - angles[0] - angles[1]);

                    break;
            }
        }
    }



    public class MyTextBox : TextBox
    {
        // Fields

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



    //
    //      DESIGN
    //      
    //      +   6 textboxes displayed on a form
    //      +   When 3 are filled in, the rest calculate
    //      +   Current config determines which boxes are input which are output
    //      +   Display units can be degrees or radians
    //
    // 
    // 
    //     EVENT: textbox change
    //
    //               Validation:
    //                  Valid data is numeric and greater than 0.
    //                  If there are two angles given, the sum must be less than pi.
    //                      Note that there is no case where 3 angles are given.  Also,
    //                      it is programatically determined which textboxes (angles) are
    //                      enabled for a given config.
    //               
    //               When all 3 inputs have valid data, the outputs are calculated.
    //     
    //     EVENT: menu change; config
    //              Clear values from each textbox.  Enable / Disable based on selection.
    //              
    //              
    //     EVENT: menu change; units
    //              Convert values for each angle textbox.
    //              Behind the scenes, convert back to radians before calculating.
    // 
    //
    // 
    // 
 