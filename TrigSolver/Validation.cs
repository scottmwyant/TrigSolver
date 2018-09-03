using System;

namespace TrigSolver
{
    class Validation
    {
        public string ErrorMessage;
        private bool error = new bool();
        private DataSet ds;

        public void Test(DataSet ds)
        {
            this.ds = ds;
            Eval(new Spec_ThreeInputs());

            
        }

        private void Eval(Specification spec)
        {

            if (!this.error)
            {
                if (!spec.IsSatisfiedBy(this.ds))
                {
                    this.error = true;
                    this.ErrorMessage = spec.ErrorMessage;
                }
            }
            
        }
    }

    
}
