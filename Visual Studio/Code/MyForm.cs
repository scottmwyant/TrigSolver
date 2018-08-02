using System;
using System.Windows.Forms;


namespace TrigSolver
{
    public partial class View : Form
    {
        //
        // fields
        //

        private IViewModel vm;
        TextBox[] tbx = new TextBox[6];

        //
        // constructor
        //

        public View(IViewModel viewModel)
        {
            vm = viewModel;
            InitializeComponent();
            ObserveEvents(true);
            tbx = new TextBox[]
            {
                textBox0, textBox1, textBox2, // length a, b, c
                textBox3, textBox4, textBox5  // angle A, B, C
            };
            Sync();
        }

        //
        // event handlers
        //

        private void TextBox_TextChanged(object sender, EventArgs e){ Sync(); }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (sender == textBox0 || sender == textBox3)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
            }
            else if (sender == textBox1 || sender == textBox4)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
            }
            else if (sender == textBox2 || sender == textBox5)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;
            }
        }
        
        //
        // Coarse synchronization of the view and view model
        //

        private void Sync()
        {
            vm.UseDegrees = degreesToolStripMenuItem.Checked;
            vm.Sync(GetText());
            
            ObserveEvents(false);

            ManageTextBox(textBox0, vm.Enabled0);
            ManageTextBox(textBox1, vm.Enabled1);
            ManageTextBox(textBox2, vm.Enabled2);
            ManageTextBox(textBox3, vm.Enabled3);
            ManageTextBox(textBox4, vm.Enabled4);
            ManageTextBox(textBox5, vm.Enabled5);

            textBox0.Text = vm.Text0;
            textBox1.Text = vm.Text1;
            textBox2.Text = vm.Text2;
            textBox3.Text = vm.Text3;
            textBox4.Text = vm.Text4;
            textBox5.Text = vm.Text5;

            toolStripStatusLabel2.Text = vm.StatusText1;
            toolStripStatusLabel3.Text = vm.StatusText2;

            ObserveEvents(true);

        }

        private void ObserveEvents(bool bln)
        {
            if (bln)
            {
                textBox0.TextChanged += new System.EventHandler(TextBox_TextChanged);
                textBox1.TextChanged += new System.EventHandler(TextBox_TextChanged);
                textBox2.TextChanged += new System.EventHandler(TextBox_TextChanged);
                textBox3.TextChanged += new System.EventHandler(TextBox_TextChanged);
                textBox4.TextChanged += new System.EventHandler(TextBox_TextChanged);
                textBox5.TextChanged += new System.EventHandler(TextBox_TextChanged);
            }
            else
            {
                textBox0.TextChanged -= new System.EventHandler(TextBox_TextChanged);
                textBox1.TextChanged -= new System.EventHandler(TextBox_TextChanged);
                textBox2.TextChanged -= new System.EventHandler(TextBox_TextChanged);
                textBox3.TextChanged -= new System.EventHandler(TextBox_TextChanged);
                textBox4.TextChanged -= new System.EventHandler(TextBox_TextChanged);
                textBox5.TextChanged -= new System.EventHandler(TextBox_TextChanged);
            }
        }

        private void ManageTextBox(TextBox tbx, bool state)
        {
            tbx.ReadOnly = !state;
            if (state)
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

        private string[] GetText()
        {
            string[] arr = new string[6];
            for (int i=0; i<=5; i++){ arr[i] = tbx[i].Text; }
            return arr;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UnitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            degreesToolStripMenuItem.Checked = !(degreesToolStripMenuItem.Checked);
            radiansToolStripMenuItem.Checked = !(radiansToolStripMenuItem.Checked);
            Sync();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //AboutBox1 aboutBox = new AboutBox1();
            //aboutBox.Show();
        }
    }
}
