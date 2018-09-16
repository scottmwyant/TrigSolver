using TrigSolver.Core.Model;

namespace TrigSolver.Core
{
    internal class Controller : IController
    {
        private int precision = 4;

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
        }

        public void SwitchUnits()
        {
            double k;
            if (view.Degrees) { k = 180 / System.Math.PI; } else { k = System.Math.PI / 180; }
            view.AngleA = System.Math.Round(ParseInputText(view.AngleA) * k, precision).ToString();
            view.AngleB = System.Math.Round(ParseInputText(view.AngleB) * k, precision).ToString();
            view.AngleC = System.Math.Round(ParseInputText(view.AngleC) * k, precision).ToString();
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

            



            // Pass the data object into the controller
            ControllerResponse response = Evaluate(input);

            // Handle the controller's response
            if (response.Error)
            {
                view.MessageBox(response.Text);

                view.AngleAEnabled = true;
                view.AngleBEnabled = true;
                view.AngleCEnabled = true;
                view.LengthAEnabled = true;
                view.LengthBEnabled = true;
                view.LengthCEnabled = true;
            }
            else
            {
                view.AngleA = System.Math.Round(response.Solution.AngA, precision).ToString();
                view.AngleB = System.Math.Round(response.Solution.AngB, precision).ToString();
                view.AngleC = System.Math.Round(response.Solution.AngC, precision).ToString();
                view.LengthA = System.Math.Round(response.Solution.LenA, precision).ToString();
                view.LengthB = System.Math.Round(response.Solution.LenB, precision).ToString();
                view.LengthC = System.Math.Round(response.Solution.LenC, precision).ToString();

                char[] arr = response.Profile.ToCharArray();
                view.AngleAEnabled = ('1' == arr[0]);
                view.AngleBEnabled = ('1' == arr[1]);
                view.AngleCEnabled = ('1' == arr[2]);
                view.LengthAEnabled = ('1' == arr[3]);
                view.LengthBEnabled = ('1' == arr[4]);
                view.LengthCEnabled = ('1' == arr[5]);
            }
        }

        private Data ReadInputFromView()
        {
            double k;
            if (view.Degrees) { k = System.Math.PI/180; } else { k = 1; }
            Data data = new Data()
            {
                AngA = ParseInputText(view.AngleA) * k * System.Convert.ToInt16(view.AngleAEnabled),
                AngB = ParseInputText(view.AngleB) * k * System.Convert.ToInt16(view.AngleAEnabled),
                AngC = ParseInputText(view.AngleC) * k * System.Convert.ToInt16(view.AngleAEnabled),
                LenA = ParseInputText(view.LengthA) * System.Convert.ToInt16(view.AngleAEnabled),
                LenB = ParseInputText(view.LengthB) * System.Convert.ToInt16(view.AngleAEnabled),
                LenC = ParseInputText(view.LengthC) * System.Convert.ToInt16(view.AngleAEnabled),
            };
            return data;
        }
            
        




        private ControllerResponse Evaluate(Data data)
        {
            DataSet ds = new DataSet(data);

            ControllerResponse response = new ControllerResponse();

            if (Validation.Test(ds).Error)
            {
                response.Error = true;
                response.Solution = new Data();
                response.Text = Validation.ErrorMessage;

            }
            else
            {
                response.Error = false;
                response.Solution = ds.Solve();
                response.Text = "Solved";
                response.Profile = ds.Profile;
            }


            return response;
        }



        private static double ParseInputText(string str)
        {
            double ans = new double();
            double.TryParse(str, out ans);
            if (ans < 0) { ans = 0; }
            return ans;
        }
    }
}
