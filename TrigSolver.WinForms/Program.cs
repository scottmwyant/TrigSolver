using System;
using System.Windows.Forms;

namespace TrigSolver.WinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Instantiate the main view defined in this project
            //
            View view = new View();

            // Pass the view to the GetController method on the core factory.  The key here is that the view
            // project is not directly responsible for "newing up" the controller; the view does not need to
            // know the precise type of the controller object.  The view ONLY EVER knows about the controller interface.
            //
            TrigSolver.Core.IController controller = Core.Factory.GetController(view);

            
            // Run the view
            Application.Run(view);

        }
    }
}
