using System;
using System.Windows.Forms;

namespace TrigSolver.WinForms
{
    public partial class View : Form
    {

        public string AngA { get { return textBox1.Text; } }
        public string AngB { get { return textBox2.Text; } }
        public string AngC { get { return textBox3.Text; } }

        public string LenA { get { return textBox4.Text; } }
        public string LenB { get { return textBox5.Text; } }
        public string LenC { get { return textBox6.Text; } }

        public View()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = (Math.PI / 180 * 90).ToString();
            textBox2.Text = (0).ToString();
            textBox3.Text = (0).ToString();
            textBox4.Text = (12).ToString();
            textBox5.Text = (10).ToString();
            textBox6.Text = (0).ToString();

            // Create the data object
            TrigSolver.Core.Data data = new Core.Data()
            {
                AngA = Parse(this.AngA),
                AngB = Parse(this.AngB),
                AngC = Parse(this.AngC),
                LenA = Parse(this.LenA),
                LenB = Parse(this.LenB),
                LenC = Parse(this.LenC),
            };

            // Pass the data object into the app core
            Core.Controller.Execute(data);
            MessageBox.Show("Valid = " + Core.Controller.Valid.ToString());

            textBox1.Text = Core.Controller.Response.AngA.ToString();
            textBox2.Text = Core.Controller.Response.AngB.ToString();
            textBox3.Text = Core.Controller.Response.AngC.ToString();
            textBox4.Text = Core.Controller.Response.LenA.ToString();
            textBox5.Text = Core.Controller.Response.LenB.ToString();
            textBox6.Text = Core.Controller.Response.LenC.ToString();
        }

        private static double Parse(string str)
        {
            double ans = new double();
            double.TryParse(str, out ans);
            if (ans < 0) { ans = 0; }
            return ans;
        }
    }
}
