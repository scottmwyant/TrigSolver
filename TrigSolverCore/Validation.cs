using System;

namespace TrigSolver.Core
{
    public static class Validation
    {
        public static string ErrorMessage;
        private static bool error = new bool();
        private static DataSet myDs;

        public static bool Test(DataSet ds)
        {
            myDs = ds;
            Eval(new Spec_ThreeInputs());
            Eval(new Spec_AtLeastOneLength());
            
            if(ds.Algorithm=="SSA")
            {
                Eval(new Spec_SideLengthForSSA());
            }

            return !error;
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
