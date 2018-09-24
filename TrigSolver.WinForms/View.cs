using System;
using System.Windows.Forms;
using TrigSolver.Core;

namespace TrigSolver.WinForms
{
    internal partial class View : Form, TrigSolver.Core.IViewMain
    {
        //
        // properties
        //
        public string AngleA { get { return textBox1.Text; } set { SetTextBoxText(textBox1, value); } }
        public string AngleB { get { return textBox2.Text; } set { SetTextBoxText(textBox2, value); } }
        public string AngleC { get { return textBox3.Text; } set { SetTextBoxText(textBox3, value); } }
        public string LengthA { get { return textBox4.Text; } set { SetTextBoxText(textBox4, value); } }
        public string LengthB { get { return textBox5.Text; } set { SetTextBoxText(textBox5, value); } }
        public string LengthC { get { return textBox6.Text; } set { SetTextBoxText(textBox6, value); } }
        public bool AngleAEnabled { get { return !textBox1.ReadOnly; } set { SetTextBoxState(textBox1, value); } }
        public bool AngleBEnabled { get { return !textBox2.ReadOnly; } set { SetTextBoxState(textBox2, value); } }
        public bool AngleCEnabled { get { return !textBox3.ReadOnly; } set { SetTextBoxState(textBox3, value); } }
        public bool LengthAEnabled { get { return !textBox4.ReadOnly; } set { SetTextBoxState(textBox4, value); } }
        public bool LengthBEnabled { get { return !textBox5.ReadOnly; } set { SetTextBoxState(textBox5, value); } }
        public bool LengthCEnabled { get { return !textBox6.ReadOnly; } set { SetTextBoxState(textBox6, value); } }
        public bool Solved { get; set; }
        public bool Degrees { get; private set; }

        //
        // fields
        //
        private IController controller;
        

        //
        // public methods
        //
        public void SetController(IController controller)
        {
            this.controller = controller;
        }
        public void MessageBox(string message)
        {
            System.Windows.Forms.MessageBox.Show(message);
        }
        public void SetStatusText(string shortText, string longText)
        {
            textBox7.Text = shortText;
            textBox8.Text = longText;
        }
        //
        // private methods
        //
        private void button1_Click(object sender, EventArgs e)
        {
            // This method is an event handler.  The handler will simply defer
            // to a particular method on teh controller.  The methods that the controller
            // must support are defined in the IController interface in the Core namespace.
            controller.Solve();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // ** Artificially populate the textboxes on the form
            textBox1.Text = (Math.PI / 180 * 90).ToString();
            textBox2.Text = (0).ToString();
            textBox3.Text = (0).ToString();
            textBox4.Text = (12).ToString();
            textBox5.Text = (10).ToString();
            textBox6.Text = (0).ToString();
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            controller.Solve();

        }
        private void SetTextBoxText(TextBox tbx, string str)
        {

            tbx.TextChanged -= TextBox_TextChanged;
            tbx.Text = str;
            tbx.TextChanged += TextBox_TextChanged;
        }
        private void SetTextBoxState(TextBox tbx, bool enabled)
        {
            tbx.ReadOnly = !enabled;
            if (enabled)
            {
                tbx.BackColor = System.Drawing.Color.White;
                tbx.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                tbx.BackColor = System.Drawing.Color.LightGray;
                tbx.ForeColor = System.Drawing.Color.Gray;
            }

        }



        private void UnitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            degreesToolStripMenuItem.Checked = !degreesToolStripMenuItem.Checked;
            radiansToolStripMenuItem.Checked = !radiansToolStripMenuItem.Checked;
            Degrees = !Degrees;
            controller.SwitchUnits();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
