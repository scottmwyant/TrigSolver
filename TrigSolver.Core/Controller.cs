using TrigSolver.Core.Model;

namespace TrigSolver.Core
{
    internal class Controller : IController
    {
        private int precision = 6;

        private class ControllerResponse
        {
            public Data Solution { get; set; }
            public string Text { get; set; }
            public bool Error { get; set; }
            public string Profile { get; set; }
        }

        private IViewMain view;


        // CONSTRUCTOR
        // The controller is handed a view when it is instantiated.
        // There is an interface defined for the view, so the controller
        // can pass a reference to itself into the view.  This is how the
        // defers to controller methods when events fire.
        internal Controller(IViewMain view)
        {
            this.view = view;
            this.view.SetController(this);
            this.view.SetStatusText("Waiting for input", null);
        }

        public void SwitchUnits()
        {

            double k;
            if (view.Degrees) { k = 180 / System.Math.PI; } else { k = System.Math.PI / 180; }

            double ans;

            ans = ParseInputText(view.AngleA);
            if (ans > 0) { view.AngleA = System.Math.Round(ans * k, precision).ToString(); } else { view.AngleA = null; }

            ans = ParseInputText(view.AngleB);
            if (ans > 0) { view.AngleB = System.Math.Round(ans * k, precision).ToString(); } else { view.AngleB = null; }

            ans = ParseInputText(view.AngleC);
            if (ans > 0) { view.AngleC = System.Math.Round(ans * k, precision).ToString(); } else { view.AngleC = null; }
        }

        public void Solve()
        {
            // This method is called by an event handler in the view.
            // This method could be implemented as an event handler itself
            // because the controller holds a reference to the view (remember the
            // view also holds reference to the controller, the controller "injects" itself)
            // there could be an event defined in the view's interface.


            // Create the data object
            Data input = ReadInputFromView();

            // The line above should be capturing a validation response.
            DataSet ds = new DataSet(input);
            ValidationResponse rsp = Validation.Test(ds);
            
            // Handle the controller's response
            if (rsp.Error)
            {
                view.SetStatusText("Error", rsp.Text);

                // Clear boxes that are disabled
                if (!view.AngleAEnabled) { view.AngleA = null; }
                if (!view.AngleBEnabled) { view.AngleB = null; }
                if (!view.AngleCEnabled) { view.AngleC = null; }
                if( !view.LengthAEnabled) { view.LengthA = null; }
                if (!view.LengthBEnabled) { view.LengthB = null; }
                if (!view.LengthCEnabled) { view.LengthC = null; }

                // Enable all textboxes
                view.AngleAEnabled = true;
                view.AngleBEnabled = true;
                view.AngleCEnabled = true;
                view.LengthAEnabled = true;
                view.LengthBEnabled = true;
                view.LengthCEnabled = true;
            }
            else
            {
                Data solution = ds.Solve();

                view.SetStatusText("Solved", "");

                double k;
                if (view.Degrees) { k = 180 / System.Math.PI; } else { k = 1; }

                if (ds.Profile.Substring(0, 1) == "0") { view.AngleA = System.Math.Round(solution.AngA * k, precision).ToString(); }
                if (ds.Profile.Substring(1, 1) == "0") { view.AngleB = System.Math.Round(solution.AngB * k, precision).ToString(); }
                if (ds.Profile.Substring(2, 1) == "0") { view.AngleC = System.Math.Round(solution.AngC * k, precision).ToString(); }
                if (ds.Profile.Substring(3, 1) == "0") { view.LengthA = System.Math.Round(solution.LenA, precision).ToString(); }
                if (ds.Profile.Substring(4, 1) == "0") { view.LengthB = System.Math.Round(solution.LenB, precision).ToString(); }
                if (ds.Profile.Substring(5, 1) == "0") { view.LengthC = System.Math.Round(solution.LenC, precision).ToString(); }

                // Disable calculated textboxes
                view.AngleAEnabled = (ds.Profile.Substring(0, 1) == "1");
                view.AngleBEnabled = (ds.Profile.Substring(1, 1) == "1");
                view.AngleCEnabled = (ds.Profile.Substring(2, 1) == "1");
                view.LengthAEnabled = (ds.Profile.Substring(3, 1) == "1");
                view.LengthBEnabled = (ds.Profile.Substring(4, 1) == "1");
                view.LengthCEnabled = (ds.Profile.Substring(5, 1) == "1");
            }
        }

        private Data ReadInputFromView()
        {
            double k;
            if (view.Degrees) { k = System.Math.PI/180; } else { k = 1; }
            Data data = new Data()
            {
                AngA = ParseInputText(view.AngleA) * k * System.Convert.ToInt16(view.AngleAEnabled),
                AngB = ParseInputText(view.AngleB) * k * System.Convert.ToInt16(view.AngleBEnabled),
                AngC = ParseInputText(view.AngleC) * k * System.Convert.ToInt16(view.AngleCEnabled),
                LenA = ParseInputText(view.LengthA) * System.Convert.ToInt16(view.LengthAEnabled),
                LenB = ParseInputText(view.LengthB) * System.Convert.ToInt16(view.LengthBEnabled),
                LenC = ParseInputText(view.LengthC) * System.Convert.ToInt16(view.LengthCEnabled),
            };
            return data;
        }

        private static double ParseInputText(string str)
        {
            double ans = new double();
            double.TryParse(str, out ans);
            if (double.IsNaN(ans)) { ans = 0; }
            if (ans < 0) { ans = 0; }
            return ans;
        }
    }
}
