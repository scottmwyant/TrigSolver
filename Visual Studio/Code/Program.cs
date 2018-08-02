using System;

namespace TrigSolver
{
    public static class Program
    {
        // Class attributes
        [STAThread]

        // Entry point
        static void Main()
        {
            //
            // Create an object that implements the 'IController' interface.
            // This layer has the core logic and math functions for the app.
            //

            Controller1 c = new Controller1();

            //
            // Pass the controller into an object that models what is displayed
            // on the screen.  The view model assumes the controller has certain
            // properties & methods.  The IController interface defines these
            // assumptions.
            //

            ViewModel vm = new ViewModel(c);

            View mainForm = new View(vm);

            System.Windows.Forms.Application.Run(mainForm);
        }
    }
}