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

        // Fields
        private double toDegrees = new double();
        private double toRadians = new double();
        private string inputs = new string(' ', 3);
        private string units = new string(' ', 3);

        private MyTextBox[] textBoxes = new MyTextBox[6];
        private float[] inputValues = new float[3];

        // Properties
        public string Inputs { get; }
        public string Units { get; }

        // Constructor
        public MyForm()
        {
            InitializeComponent();
            
            textBoxes[0] = textBoxAlpha;
            textBoxes[1] = textBoxBeta;
            textBoxes[2] = textBoxGamma;
            textBoxes[3] = textBoxA;
            textBoxes[4] = textBoxB;
            textBoxes[5] = textBoxC;

            // This section will be temporary until the SETTINGS are plumbed in
            degToolStripMenuItem.Checked = true;
            units = "DEG";

            aasToolStripMenuItem.Checked = true;
            inputs = "AAS";
            ConfigureTextBoxes(inputs);

            ManageEventHandlers(true);

            SetUnitConversionFactors();
        }

        // ================================================================================================================

        #region EVENTS

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            MyTextBox tbx = (MyTextBox)sender;

            if (tbx.Input)
            {
                tbx.UpdateNumericValue();

                if ((ValidInput(tbx)) && (CountValidInputs() == 3))
                {
                    Solve();
                }
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
                    ConfigureTextBoxes(item.Text);
                }
                else if (((ToolStripMenuItem)item.OwnerItem).Text == "Units")
                {
                    units = item.Text;
                    ConvertDisplayedUnits();
                }


            }
        }

        #endregion

        // ================================================================================================================

        #region METHODS

        private void ConvertDisplayedUnits()
        {
            float k = new float();
            float value = new float();
            int i = new int();

            if (units == "Degrees") { k = (180 / ((float)Math.PI)); }
            else if (units == "Radians") { k = (((float)Math.PI) / 180); }


            for (i = 0; i < 3; i++)
            {
                if (textBoxes[i].Value > 0)
                {
                    value = (float)Math.Round((k * value), displayPrecisionAngles);
                    textBoxes[i].Text = Convert.ToString(value);
                }
            }

        }

        private bool IsNumericPositive(string text, out float value)
        {
            bool ans = new bool();
            float val = new float();

            if (text.Length > 0)
            {
                if (float.TryParse(text, out val))
                {
                    if (val > 0) { ans = true; }

                }
            }
            if (ans) { value = val; } else { value = 0.0f; }
            return ans;
        }

        private void ConfigureTextBoxes(string config)
        {
            foreach (MyTextBox tbx in textBoxes)
            {
                tbx.Text = null;
                tbx.Tag = 6;
                tbx.Enabled = false;
                tbx.Input = false;
            }

            MyTextBox[] temp = new MyTextBox[3];

            switch (config.Substring(0, 3))
            {
                case "AAS":
                    temp[0] = textBoxAlpha;
                    temp[1] = textBoxBeta;
                    temp[2] = textBoxA;
                    break;

                case "ASA":
                    temp[0] = textBoxAlpha;
                    temp[1] = textBoxC;
                    temp[2] = textBoxBeta;
                    break;

                case "SAS":
                    temp[0] = textBoxA;
                    temp[1] = textBoxGamma;
                    temp[2] = textBoxB;
                    break;

                case "SSS":
                    temp[0] = textBoxA;
                    temp[1] = textBoxB;
                    temp[2] = textBoxC;
                    break;
            }

            for (byte i = 0; i < 3; i++)
            {
                temp[i].Tag = i;
                temp[i].Enabled = true;
                temp[i].Input = true;
            }

        }

        private void ManageEventHandlers(bool bln)
        {
            foreach (MyTextBox tbx in textBoxes)
            {
                if (tbx.Input)
                {
                    if (bln)
                    {
                        //tbx.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
                        tbx.TextChanged += TextBox_TextChanged;
                    }
                    else
                    {
                        //tbx.TextChanged -= new System.EventHandler(this.TextBox_TextChanged);
                        tbx.TextChanged -= TextBox_TextChanged;
                    }
                }
            }
        }

        private void SetUnitConversionFactors()
        {
            if (units == "DEG")
            {
                toDegrees = 1d;
                toRadians = (Math.PI / 180);
            }
            else if (units == "RAD")
            {
                toDegrees = (180 / Math.PI);
                toRadians = 1d;
            }
        }

        private bool ValidInput(MyTextBox tbx)
        {
            if (tbx.Value > 0)
            {
                tbx.Valid = true;
                tbx.ForeColor = Color.Black;
            }
            else
            {
                tbx.Valid = false;
                tbx.ForeColor = Color.Red;
            }
            return tbx.Valid;
        }

        private byte CountValidInputs()
        {
            byte count = new byte();
            foreach (MyTextBox tbx in textBoxes)
            {
                if (tbx.Input && tbx.Valid) { count++; }
            }
            return count;
        }

        private void Solve()
        {
            double k = new double();
            if (toDegrees == 1) { k = (180 / Math.PI);  } else { k = 1d; }

            switch (inputs.Substring(0, 3))
            {
                case "AAS":

                    // Subtract angles from pi to get last angle.
                    textBoxes[2].Value = k * (Math.PI - (textBoxes[0].Value * toRadians) - (textBoxes[1].Value * toRadians));
                    //textBoxes[2].Text = Convert.ToString(Math.Round(textBoxes[2].Value, displayPrecisionAngles));
                    textBoxes[2].UpdateText(displayPrecisionAngles);

                    // Law-Of-Sines to get side B.
                    textBoxes[4].Value = textBoxes[3].Value / Math.Sin((textBoxes[0].Value * toRadians)) * Math.Sin((textBoxes[1].Value * toRadians));
                    //textBoxes[4].Text = Convert.ToString(Math.Round(textBoxes[4].Value, displayPrecisionLengths));
                    textBoxes[4].UpdateText(displayPrecisionLengths);

                    // Law-Of-Sines to get side C.
                    textBoxes[5].Value = textBoxes[3].Value / Math.Sin((textBoxes[0].Value * toRadians)) * Math.Sin((textBoxes[2].Value * toRadians));
                    //textBoxes[5].Text = Convert.ToString(Math.Round(textBoxes[5].Value, displayPrecisionLengths));
                    textBoxes[5].UpdateText(displayPrecisionLengths);
                    break;

                case "ASA":

                    // Subtract angles from pi to get last angle.
                    textBoxes[2].Value = k * (Math.PI - (textBoxes[0].Value * toRadians) - (textBoxes[1].Value * toRadians));
                    //textBoxes[2].Text = Convert.ToString(Math.Round(textBoxes[2].Value, displayPrecisionAngles));
                    textBoxes[2].UpdateText(displayPrecisionAngles);

                    // Law-Of-Sines to get side A.
                    textBoxes[3].Value = textBoxes[5].Value / Math.Sin((textBoxes[2].Value * toRadians)) * Math.Sin((textBoxes[0].Value * toRadians));
                    //textBoxes[3].Text = Convert.ToString(Math.Round(textBoxes[3].Value, displayPrecisionLengths));
                    textBoxes[3].UpdateText(displayPrecisionLengths);

                    // Law-Of-Sines to get side B.
                    textBoxes[4].Value = textBoxes[5].Value / Math.Sin((textBoxes[2].Value) * toRadians) * Math.Sin((textBoxes[1].Value * toRadians));
                    //textBoxes[4].Text = Convert.ToString(Math.Round(textBoxes[4].Value, displayPrecisionLengths));
                    textBoxes[4].UpdateText(displayPrecisionLengths);
                    break;

                case "SAS":

                    // Law-Of-Cosines to get side C.
                    textBoxes[5].Value = Math.Sqrt((Math.Pow(textBoxes[3].Value, 2)) + (Math.Pow(textBoxes[4].Value, 2)) - (2 * textBoxes[3].Value * textBoxes[4].Value * Math.Cos((textBoxes[2].Value * toRadians))));
                    //textBoxes[5].Text = Convert.ToString(Math.Round(calc, displayPrecisionLengths));
                    textBoxes[5].UpdateText(displayPrecisionLengths);

                    // Law-Of-Sines to get Alpha.
                    textBoxes[0].Value = k * (Math.Asin((Math.Sin((textBoxes[2].Value * toRadians)) / textBoxes[5].Value) * textBoxes[3].Value));
                    //textBoxes[0].Text = Convert.ToString(Math.Round(calc, displayPrecisionAngles));
                    textBoxes[0].UpdateText(displayPrecisionAngles);

                    // Law-Of-Sines to get Beta.
                    textBoxes[1].Value = k * (Math.Asin((Math.Sin((textBoxes[2].Value * toRadians)) / textBoxes[5].Value) * textBoxes[4].Value));
                    //textBoxes[1].Text = Convert.ToString(Math.Round(calc, displayPrecisionAngles));
                    textBoxes[1].UpdateText(displayPrecisionAngles);
                    break;

                case "SSS":

                    // Law-Of-Cosines to get Alpha.
                    textBoxes[0].Value = k * (Math.Acos((Math.Pow(textBoxes[3].Value, 2) - Math.Pow(textBoxes[4].Value, 2) - Math.Pow(textBoxes[5].Value, 2)) / (-2 * textBoxes[4].Value * textBoxes[5].Value)));
                    //textBoxes[0].Text = Convert.ToString(Math.Round(calc, displayPrecisionAngles));
                    textBoxes[0].UpdateText(displayPrecisionAngles);

                    // Law-Of-Cosines to get Beta.
                    textBoxes[1].Value = k * (Math.Acos((Math.Pow(textBoxes[4].Value, 2) - Math.Pow(textBoxes[3].Value, 2) - Math.Pow(textBoxes[5].Value, 2)) / (-2 * textBoxes[3].Value * textBoxes[5].Value)));
                    //textBoxes[1].Text = Convert.ToString(Math.Round(calc, displayPrecisionAngles));
                    textBoxes[1].UpdateText(displayPrecisionAngles);

                    // Subtract angles from pi to get last angle.
                    textBoxes[2].Value = k * (Math.PI - (textBoxes[0].Value * toRadians) - (textBoxes[1].Value * toRadians));
                    //textBoxes[2].Text = Convert.ToString(Math.Round(calc, displayPrecisionAngles));
                    textBoxes[2].UpdateText(displayPrecisionAngles);
                    break;
            }
        }

        #endregion

    }
}