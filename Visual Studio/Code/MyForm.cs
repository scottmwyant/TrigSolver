// References
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrigSolver
{ 
    public partial class MyForm : Form
    {
        // Constants
        private const byte displayPrecisionAngles = 3;
        private const byte displayPrecisionLengths = 3;
        private const string statusWaiting = "Waiting for inputs...";

        // Fields

        private bool solved = new bool();
        private bool allInputsValid = new bool();
        private double toRadians = new double();
        private double toDisplayedUnits = new double();

        private string inputs = new string(' ', 3);
        private string units = new string(' ', 3);

        
        private MyTextBox[] textBoxes = new MyTextBox[6];
        private float[] inputValues = new float[3];

        private PointF[] points = new PointF[3];

        // Properties
        public string Inputs { get; }
        public string Units { get; }

        // Constructor
        public MyForm()
        {
            InitializeComponent();
            
            textBoxes[0] = textBox0;    // Alpha
            textBoxes[1] = textBox1;    // Beta
            textBoxes[2] = textBox2;    // Gamma
            textBoxes[3] = textBox3;    // Side a
            textBoxes[4] = textBox4;    // Side b
            textBoxes[5] = textBox5;    // Side c

            StatusUpdate(2, statusWaiting);


            // This section will be temporary until the SETTINGS are plumbed in
            degToolStripMenuItem.Checked = true;
            units = "Degrees";

            aasToolStripMenuItem.Checked = true;
            inputs = "AAS";

            ManageTextBoxes(inputs);

            ManageEventHandlers(true);

            SetUnitConversionFactors();
        }

        // ================================================================================================================

        #region EVENTS

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            MyTextBox tbx = (MyTextBox)sender;

            ValidateInput(tbx);

            if (allInputsValid)
            {
                Triangle MyTriangle = DefineTriangle();
                PresentSolution(MyTriangle);
                StatusUpdate(2, "Area: " + Math.Round(MyTriangle.Area, 3).ToString() + " sq. units");
                solved = true;
            }
            else if (solved)
            {
                ClearSolution();
                solved = false;
            }
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            if (!item.Checked)
            {
                foreach (ToolStripMenuItem choice in ((ToolStripDropDownItem)item.OwnerItem).DropDownItems) { choice.Checked = false; }

                item.Checked = true;

                if (((ToolStripMenuItem)item.OwnerItem).Text == "Inputs")
                {
                    inputs = item.Text;
                    ClearSolution();
                    ManageEventHandlers(false);
                    ManageTextBoxes(item.Text);
                    ManageEventHandlers(true);
                    StatusUpdate(1, item.Text.Substring(0, 3).ToUpper());
                }
                else if (((ToolStripMenuItem)item.OwnerItem).Text == "Units")
                {
                    units = item.Text;
                    ConvertDisplayedUnits();
                    SetUnitConversionFactors();
                    StatusUpdate(0, item.Text.Substring(0, 3).ToUpper());
                }


            }
        }

        #endregion

        // ================================================================================================================

        #region METHODS
        
        // Methods managing form controls

        private void ManageTextBoxes(string config)
        {
            foreach (MyTextBox tbx in textBoxes)
            {
                if (tbx.Enabled)

                {
                    tbx.Text = null;
                    tbx.Enabled = false;
                }
            }

            switch (config.Substring(0, 3))
            {
                case "AAS":
                    textBoxes[0].Enabled = true;
                    textBoxes[1].Enabled = true;
                    textBoxes[3].Enabled = true;
                    break;

                case "ASA":
                    textBoxes[0].Enabled = true;
                    textBoxes[1].Enabled = true;
                    textBoxes[5].Enabled = true;
                    break;

                case "SAS":
                    textBoxes[2].Enabled = true;
                    textBoxes[3].Enabled = true;
                    textBoxes[4].Enabled = true;
                    break;

                case "SSA":
                    textBoxes[0].Enabled = true;
                    textBoxes[3].Enabled = true;
                    textBoxes[4].Enabled = true;
                    break;

                case "SSS":
                    textBoxes[3].Enabled = true;
                    textBoxes[4].Enabled = true;
                    textBoxes[5].Enabled = true;
                    break;
            }
        }

        private void ManageEventHandlers(bool bln)
        {
            foreach (MyTextBox tbx in textBoxes)
            {
                if (tbx.Enabled)
                {
                    if (bln)
                    {
                        tbx.TextChanged += TextBox_TextChanged;
                    }
                    else
                    {
                        tbx.TextChanged -= TextBox_TextChanged;
                    }
                }
            }
        }

        // Methods performing calculations

        private void SetUnitConversionFactors()
        {
            if (units == "Degrees")
            {
                toDisplayedUnits = 180 / Math.PI;
                toRadians = (Math.PI / 180);
            }
            else if (units == "Radians")
            {
                toDisplayedUnits = 1d;
                toRadians = 1d;
            }
        }

        private double GetValue(MyTextBox tbx)
        {
            var ans = new double();
            Double.TryParse(tbx.Text, out ans);
            return ans;
        }


        private Triangle DefineTriangle()
        {
            Triangle t = new Triangle();

            switch (inputs.Substring(0, 3))
            {
                case "AAS":

                    // Given values
                    t.Alpha = GetValue(textBoxes[0]) * toRadians;
                    t.Beta = GetValue(textBoxes[1]) * toRadians;
                    t.SideA = GetValue(textBoxes[3]);

                    // Subtract angles from pi to get last angle.
                    t.Gamma = Math.PI - t.Alpha - t.Beta;

                    // Law-Of-Sines to get side B.
                    t.SideB = (t.SideA / Math.Sin(t.Alpha)) * Math.Sin(t.Beta);

                    // Law-Of-Sines to get side C.
                    t.SideC = (t.SideA / Math.Sin(t.Alpha)) * Math.Sin(t.Gamma);

                    break;

                case "ASA":

                    // Given values
                    t.Alpha = GetValue(textBoxes[0]) * toRadians;
                    t.SideC = GetValue(textBoxes[5]);
                    t.Beta = GetValue(textBoxes[1]) * toRadians;

                    // Subtract angles from pi to get last angle.
                    t.Gamma = Math.PI - t.Alpha - t.Beta;

                    // Law-Of-Sines to get side A.
                    t.SideA = (t.SideC / Math.Sin(t.Gamma)) * Math.Sin(t.Alpha);

                    // Law-Of-Sines to get side B.
                    t.SideB = (t.SideC / Math.Sin(t.Gamma)) * Math.Sin(t.Beta);

                    break;

                case "SAS":

                    // Given values
                    t.SideA = GetValue(textBoxes[3]);
                    t.Gamma = GetValue(textBoxes[2]) * toRadians;
                    t.SideB = GetValue(textBoxes[4]);

                    // Law-Of-Cosines to get side C.
                    t.SideC = Math.Sqrt((Math.Pow(t.SideA, 2) + Math.Pow(t.SideB, 2)) - (2 * t.SideA * t.SideB * Math.Cos(t.Gamma)));

                    // Law-Of-Sines to get Alpha.
                    t.Alpha = Math.Asin((Math.Sin(t.Gamma) / t.SideC) * t.SideA);

                    // Subtract angles from pi to get last angle.
                    t.Beta = Math.PI - t.Alpha - t.Gamma;

                    break;

                case "SSA":

                    // Given values
                    t.SideA = GetValue(textBoxes[3]);
                    t.SideB = GetValue(textBoxes[4]);
                    t.Alpha = GetValue(textBoxes[0]) * toRadians;

                    // Law-of-Sines to get Beta.
                    t.Beta = Math.Asin((Math.Sin(t.Alpha) / t.SideA) * t.SideB);

                    // Subtract angles from pi to get last angle.
                    t.Gamma = Math.PI - t.Alpha - t.Beta;

                    // Law-of-Sines to get side C.
                    t.SideC = (t.SideA / Math.Sin(t.Alpha)) * Math.Sin(t.Gamma);

                    break;

                case "SSS":

                    // Given values
                    t.SideA = GetValue(textBoxes[3]);
                    t.SideB = GetValue(textBoxes[4]);
                    t.SideC = GetValue(textBoxes[5]);

                    // Law-Of-Cosines to get Alpha.
                    t.Alpha = (Math.Acos((Math.Pow(t.SideA, 2) - Math.Pow(t.SideB, 2) - Math.Pow(t.SideC, 2)) / (-2 * t.SideB * t.SideC)));

                    // Law-Of-Cosines to get Beta.
                    t.Beta = (Math.Acos((Math.Pow(t.SideB, 2) - Math.Pow(t.SideA, 2) - Math.Pow(t.SideC, 2)) / (-2 * t.SideA * t.SideC)));

                    // Subtract angles from pi to get last angle.
                    t.Gamma = Math.PI - t.Alpha - t.Beta;

                    break;
            }

            t.CalculateProperties();

            return t;
        }
        
        // Methods supporting data validation

        private bool ValidateInput(MyTextBox tbx)
        {
            var ans = new bool();
            var validInputs = new byte();

            allInputsValid = false;

            if (textBoxes[3].Enabled && textBoxes[4].Enabled && textBoxes[5].Enabled)
            {
                // Test the current textbox
                SetValidity(tbx, (GetValue(tbx) > 0));
                ans = tbx.Valid;

                // Special validation test for Side-Side-Side input configuration
                if ((GetValue(textBoxes[3]) * GetValue(textBoxes[4]) * GetValue(textBoxes[5]))>0)
                {
                    ans = ValidationTest2();
                    SetValidity(textBoxes[3], ans);
                    SetValidity(textBoxes[4], ans);
                    SetValidity(textBoxes[5], ans);
                }

            }
            else
            { 
                if (tbx.Name == textBoxes[0].Name || tbx.Name == textBoxes[1].Name || tbx.Name == textBoxes[2].Name)
                {
                    // Assumptions:
                    // When an angle is given it is always either alpha or beta. *NOT A VALID ASSUMPTION!
                    // When only one angle is given it is always alpha, beta is the optional second angle.
                    // When a textbox is disabled (calculated), it's valid state is false.

                    // When alpha and beta are both enabled, validate them both
                    if (textBoxes[0].Enabled && textBoxes[1].Enabled)
                    {
                        SetValidity(textBoxes[0], ValidationTest1((GetValue(textBoxes[0]) * toRadians), Math.PI));
                        ans = (ans && textBoxes[0].Valid);

                        SetValidity(textBoxes[1], ValidationTest1((GetValue(textBoxes[1]) * toRadians), Math.PI));
                        ans = (ans && textBoxes[1].Valid);
                    
                        // Move to advanced validation only when the two individual components are valid
                        if (ans)
                        {
                            ans = ValidationTest1(((GetValue(textBoxes[0]) + GetValue(textBoxes[1])) * toRadians), Math.PI);
                            SetValidity(textBoxes[0], ans);
                            SetValidity(textBoxes[1], ans);
                        }
                    }
                    else
                    {
                        // Validate current textbox
                        SetValidity(tbx, ValidationTest1((GetValue(tbx) * toRadians), Math.PI));
                        ans = tbx.Valid;
                    }
                }
                else if (tbx.Name == textBoxes[3].Name || tbx.Name == textBoxes[4].Name || tbx.Name == textBoxes[5].Name)
                {
                    SetValidity(tbx, ValidationTest1(GetValue(tbx), 0));
                    ans = tbx.Valid;
                }
            }

            foreach (MyTextBox temp in textBoxes)
            {
                if(temp.Enabled && temp.Valid) { validInputs++; }
            }

            if (validInputs == 3) { allInputsValid = true; }

            return ans;
        }

        private bool ValidationTest1(double val, double max)
        {
            bool ans = (val > 0);
            if ((ans) && (max > 0)) { ans = (val < max); }
            return ans;
        }

        private bool ValidationTest2()
        {
            var max = new double();
            var sum = new double();
            max = Math.Max(GetValue(textBoxes[3]), Math.Max(GetValue(textBoxes[4]), GetValue(textBoxes[5])));
            sum = GetValue(textBoxes[3]) + GetValue(textBoxes[4]) + GetValue(textBoxes[5]);
            return (max < (sum - max));
        }

        private void SetValidity(MyTextBox tbx, bool bln)
        {
            tbx.Valid = bln;
            if (bln) { tbx.ForeColor = Color.Black; } else { tbx.ForeColor = Color.Red; }
        }

        // Methods supporting presentation

        private void ConvertDisplayedUnits()
        {
            var k = new double();
            var i = new byte();

            // Disconnect events
            ManageEventHandlers(false);

            // Set the proper conversion factor
            if (toDisplayedUnits == 1) { k = 180 / Math.PI; } else { k = Math.PI / 180; }

            for (i = 0; i < 3; i++)
            {
                if (GetValue(textBoxes[i]) > 0)
                {
                    textBoxes[i].Text = Math.Round(GetValue(textBoxes[i]) * k, displayPrecisionAngles).ToString();
                }
            }

            // Update the class level conversion factors
            SetUnitConversionFactors();

            // Reconnect events
            ManageEventHandlers(true);
        }

        private void StatusUpdate(byte i, string status)
        {
            if (i == 0) { toolStripStatusLabel0.Text = status; }
            else if (i == 1) { toolStripStatusLabel1.Text = status; }
            else if (i == 2) { toolStripStatusLabel2.Text = status; }
        }

        private void PresentSolution(Triangle t)
        {
            // Angles
            if (!textBoxes[0].Enabled) { textBoxes[0].Text = Math.Round(t.Alpha * toDisplayedUnits, displayPrecisionAngles).ToString(); }
            if (!textBoxes[1].Enabled) { textBoxes[1].Text = Math.Round(t.Beta * toDisplayedUnits, displayPrecisionAngles).ToString(); }
            if (!textBoxes[2].Enabled) { textBoxes[2].Text = Math.Round(t.Gamma * toDisplayedUnits, displayPrecisionAngles).ToString(); }

            // Sides
            if (!textBoxes[3].Enabled) { textBoxes[3].Text = Math.Round(t.SideA, displayPrecisionLengths).ToString(); }
            if (!textBoxes[4].Enabled) { textBoxes[4].Text = Math.Round(t.SideB, displayPrecisionLengths).ToString(); }
            if (!textBoxes[5].Enabled) { textBoxes[5].Text = Math.Round(t.SideC, displayPrecisionLengths).ToString(); }

            Plot(t);
        }

        private void ClearSolution()
        {
            foreach (MyTextBox tbx in textBoxes)
            {
                if (!tbx.Enabled) { tbx.Text = null; }
            }

            StatusUpdate(2, statusWaiting);
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(this.BackColor);
            g.Dispose();
        }

        private void Plot(Triangle tri)
        {
            // Scale calculated points to the drawing area
            float k = 0.8f;
            k = k * (float)(Math.Min(pictureBox1.Height / tri.Height, pictureBox1.Width / tri.Width));

            PointF[] points = new PointF[3];
            points[0] = new PointF(tri.PointA.X * k, tri.PointA.Y * k);
            points[1] = new PointF(tri.PointB.X * k, tri.PointB.Y * k);
            points[2] = new PointF(tri.PointC.X * k, tri.PointC.Y * k);

            // Create drawing objects
            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Gray, 5.0f);
            SolidBrush brush = new SolidBrush(Color.LightGray);
            
            //Font font = new Font("Arial", 8.0f);

            //SizeF[] size = new SizeF[3];

            //// Define location of point labels
            //size[0] = g.MeasureString("A", font, 100);
            //size[1] = g.MeasureString("B", font, 100);
            //size[2] = g.MeasureString("C", font, 100);

            //PointF[] labelPoints = new PointF[3];
            //labelPoints[0] = new PointF(points[0].X - size[0].Width - 4, points[0].Y + 4);
            //labelPoints[1] = new PointF(points[1].X + 4, points[1].Y + 4);
            //labelPoints[2] = new PointF(points[2].X - size[2].Width * 0.5f, points[2].Y - size[2].Height - 4);

            //// Define location of side labels
            //size[0] = g.MeasureString("a", font, 100);
            //size[1] = g.MeasureString("b", font, 100);
            //size[2] = g.MeasureString("c", font, 100);

            //PointF[] labelSides = new PointF[3];
            //labelSides[0] = new PointF(((points[1].X + points[2].X) / 2) + (size[0].Width/2), (points[1].Y + points[2].Y) / 2);
            //labelSides[1] = new PointF(((points[0].X + points[2].X) / 2) - (size[1].Width), ((points[0].Y + points[2].Y) / 2) - (size[1].Height));
            //labelSides[2] = new PointF(((points[0].X + points[1].X) / 2), (points[0].Y + points[1].Y) / 2);
            
            // Create and configure a graphics object
            g.Clear(this.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TranslateTransform(5 + Math.Abs(Math.Min(points[0].X, points[2].X)), (pictureBox1.Height - 5));
            //g.ScaleTransform(k,k);

            // Draw triangle
            g.DrawPolygon(pen, points);
            g.FillPolygon(brush, points);

            //// Draw point labels
            //brush.Color = Color.Black;
            //g.DrawString("A", font, brush, labelPoints[0]);
            //g.DrawString("B", font, brush, labelPoints[1]);
            //g.DrawString("C", font, brush, labelPoints[2]);

            //// Draw side labels
            //g.DrawString("a", font, brush, labelSides[0]);
            //g.DrawString("b", font, brush, labelSides[1]);
            //g.DrawString("c", font, brush, labelSides[2]);

            // Release system graphics resources
            //font.Dispose();
            pen.Dispose();
            brush.Dispose();
            g.Dispose();
        }

        #endregion
    }
}