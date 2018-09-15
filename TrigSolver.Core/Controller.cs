using TrigSolver.Core.Model;

namespace TrigSolver.Core
{
    internal class Controller : IController
    {
        private IViewMain view;


        // CONSTRUCTOR
        // The controller is handed a view when it is instantiated.
        // There is an interface defined for the view, so the controller
        // can pass a reference to itself into the view.  This is how the
        // defers to controller methods when events fire.
        internal Controller(IViewMain view)
        {
            this.view = view;
            this.view.Controller = this;
        }

        public void ButtonClickRun()
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
            }
            else
            {
                view.AngleA = response.Solution.AngA.ToString();
                view.AngleB = response.Solution.AngB.ToString();
                view.AngleC = response.Solution.AngC.ToString();
                view.LengthA = response.Solution.LenA.ToString();
                view.LengthB = response.Solution.LenB.ToString();
                view.LengthC = response.Solution.LenC.ToString();
            }
        }

        private Data ReadInputFromView()
        {
            Data data = new Data()
            {
                AngA = ParseInputText(view.AngleA),
                AngB = ParseInputText(view.AngleB),
                AngC = ParseInputText(view.AngleC),
                LenA = ParseInputText(view.LengthA),
                LenB = ParseInputText(view.LengthB),
                LenC = ParseInputText(view.LengthC),
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
