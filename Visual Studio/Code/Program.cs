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

    // Entry point
    static void Main()
    {
        Form1 myForm = new Form1();
        myForm.ShowDialog();
    }

}
}