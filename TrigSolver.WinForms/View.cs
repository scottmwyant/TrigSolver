using System;
using System.Windows.Forms;

namespace TrigSolver.WinForms
{
    internal partial class View : Form, TrigSolver.Core.IViewMain
    {
        // Properties
        public string AngleA { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public string AngleB { get { return textBox2.Text; } set { textBox2.Text = value; } }
        public string AngleC { get { return textBox3.Text; } set { textBox3.Text = value; } }
        public string LengthA { get { return textBox4.Text; } set { textBox4.Text = value; } }
        public string LengthB { get { return textBox5.Text; } set { textBox5.Text = value; } }
        public string LengthC { get { return textBox6.Text; } set { textBox6.Text = value; } }
        public bool Degrees { get; }

        public TrigSolver.Core.IController Controller { get;  set; }

        public void MessageBox(string message)
        {
            System.Windows.Forms.MessageBox.Show(message);
        }
        
        // Constructor
        internal View()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // This method is an event handler.  The handler will simply defer
            // to a particular method on teh controller.  The methods that the controller
            // must support are defined in the IController interface in the Core namespace.
            Controller.ButtonClickRun();
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

    }
}
