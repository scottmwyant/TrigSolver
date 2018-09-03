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
            Eval(new Spec_AtLeastOneLength());
            Profile();
            // Start building the validation response here
            // Need to include things like which algorithm to use
            // what the "binary" profile looks like, etc.  
            // 
            // After the "binary" profile is known, look that up
            // in a hashtable or dictionary.   The strings (or possibly objects)
            // in the dictionary will contribute to the repsonse back to the validation
            // caller.  Then we should have everyhting we need to get a solution.
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




        private string Profile()
        {
            string ans = "";
            double[] arr = this.ds.ArrAll;
            for(int i=0 to arr.Length; i++)
            {
                if(arr[i]>0){ans=ans+"1";}else{ans=ans+"0";}
            }
            return ans;
            
            // could be returning type System.Collections.BitArray,
            // which would be constructed by passing in a bool[] : 

            // bool[] b = new bool[8];
            // double[] d = ds.ArrAll
            // for(int i=0; i<d.Length; i++){b[i] = (d[i]>0;)}
            // return new System.Collections.BitArray(ans);   
            
        }
    }

    
}
