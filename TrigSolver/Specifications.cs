using System;
using System.Collections.Generic;
using System.Text;

namespace TrigSolver
{
    //interface ISpecification
    //{
    //    bool IsSatisfiedBy(DataSet ds);
    //    string ErrorMessage { get;}
    //}

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
            if (itsNecessary(ds))
            {
                if (ds.Lengths.Max < (ds.Lengths.Sum - ds.Lengths.Max)) {return true; }
                else
                {
                    double gap; // calculate the gap here to feed a metric into the error message
                    errorText = "The three side lengths given cannot form a triangle.  Either make the biggest length smaller by X or one of the other ones longer by X.";
                    return false;
                }
                
            }
            else { return true; }


        }
        private bool itsNecessary(DataSet ds)
        {
            return ((Helper.CountNonZeros(ds.ArrayAll) == 3) && (Helper.CountNonZeros(ds.ArrayLen) == 3));
        }

        private bool TestLengths(DataSet ds)
        {
            return (ds.Lengths.Max < (ds.Lengths.Sum - ds.Lengths.Max));
        }
    }




    static class Helper
    {
        public static int CountNonZeros(double[] arr)
        {
            int count = new int();
            foreach (double d in arr) { if (d > 0) { count++; } }
            return count;
        }
    }

}
