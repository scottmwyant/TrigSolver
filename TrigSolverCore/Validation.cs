using System;

namespace TrigSolver.Core
{
    internal static class Validation
    {
        public static string ErrorMessage;
        private static bool error = new bool();
        private static DataSet myDs;

        public static IResponse Test(DataSet ds)
        {
            myDs = ds;
            Eval(new Spec_ThreeInputs());
            Eval(new Spec_AtLeastOneLength());
            
            if(ds.Algorithm=="SSA")
            {
                Eval(new Spec_SideLengthForSSA());
            }

            // Build a response object (with a constructor???)
            Response response = new Response()
            {
                Error = error,
                Text = ErrorMessage
            };

            ErrorMessage = "";
            error = false;

            return response;
        }

        private static void Eval(Specification spec)
        {

            if (!error)
            {
                if (!spec.IsSatisfiedBy(myDs))
                {
                    error = true;
                    ErrorMessage = spec.ErrorMessage;
                }
            }
            
        }





    }

    
}
