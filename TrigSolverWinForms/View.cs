using System;
using System.Windows.Forms;

namespace TrigSolver.WinForms
{
    internal partial class View : Form
    {
        // Constructor
        internal View()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            // Create the data object
            TrigSolver.Core.Data data = new Core.Data()
            {
                AngA = Parse(this.textBox1.Text),
                AngB = Parse(this.textBox2.Text),
                AngC = Parse(this.textBox3.Text),
                LenA = Parse(this.textBox4.Text),
                LenB = Parse(this.textBox5.Text),
                LenC = Parse(this.textBox6.Text),
            };

            // Pass the data object into the controller
            TrigSolver.Core.IResponse response = TrigSolver.Core.Controller.Invoke(data);

            // Handle the controller's response
            if(response.Error)
            {
                MessageBox.Show(response.Text);
            }
            else
            {
                textBox1.Text = response.Solution.AngA.ToString();
                textBox2.Text = response.Solution.AngB.ToString();
                textBox3.Text = response.Solution.AngC.ToString();
                textBox4.Text = response.Solution.LenA.ToString();
                textBox5.Text = response.Solution.LenB.ToString();
                textBox6.Text = response.Solution.LenC.ToString();
            }
            
        }

        private static double Parse(string str)
        {
            double ans = new double();
            double.TryParse(str, out ans);
            if (ans < 0) { ans = 0; }
            return ans;
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
