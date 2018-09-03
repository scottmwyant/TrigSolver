using System;
using System.Collections.Generic;
using System.Text;

namespace TrigSolver
{
    abstract class Specification
    {

        internal string ErrorMessage{ get { return errorText; } }
        protected string errorText ="";
        public abstract bool IsSatisfiedBy(DataSet ds);
    }


    class Spec_ThreeInputs : Specification
    {   
        public override bool IsSatisfiedBy(DataSet ds)
        {
            int count = Helper.CountNonZeros(ds.ArrayAll);
            if (count < 3) { errorText = "Underdefined: There need to be exactly 3 values given."; }
            else if (count > 3) { errorText = "Overdefined: There need to be exactly 3 values given."; }
            return (count==3);
        }
    }
    class Spec_AtLeastOneLength : Specification
    {
        public override bool IsSatisfiedBy(DataSet ds)
        {
            if(Helper.CountNonZeros(ds.ArrayLen) > 0){return true;}
            else
            {
                errorText = "At least one of the given values must be a length.";
                return false;
            }
            

        }
    }
    class Spec_ThreeLengths : Specification
    {
        public override bool IsSatisfiedBy(DataSet ds)
        {
            if (threeLengthsGiven(ds))
            {
                if (ds.Lengths.Max < (ds.Lengths.Sum - ds.Lengths.Max)) {return true; }
                else
                {
                    errorText = setErrorText(ds);
                    return false;
                }
                
            }
            else
            {
                return true;
            }
        }
        private bool threeLengthsGiven(DataSet ds)
        {
            return ((Helper.CountNonZeros(ds.ArrayAll) == 3) && (Helper.CountNonZeros(ds.ArrayLen) == 3));
        }
        private string setErrorText(DataSet ds)
        {
            double gap; // calculate the gap here to feed a metric into the error message
            return "The three side lengths given cannot form a triangle.  Either make the biggest length smaller by X or one of the other ones longer by X.";
        }
    }
    class Spec_SumOfAngles : Specification
    {
        public override bool IsSatisfiedBy(DataSet ds)
        {
            if(ds.Angles.Sum < Math.Pi){return true;}
            else
            {
                errorText = "The sum of the given angles cannot be more than 180 degrees.";
                return false;
            }
        }
    }




    static class Helper
    {
        public static int CountNonZeros(double[] arr)
        {
            int count = new int();
            foreach (double d in arr) { if (d != 0) { count++; } }
            return count;
        }
    }

}
