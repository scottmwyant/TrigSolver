
namespace TrigSolver.Core
{
    public class Data
    {
        public double AngA { get; set; }
        public double AngB { get; set; }
        public double AngC { get; set; }
        public double LenA { get; set; }
        public double LenB { get; set; }
        public double LenC { get; set; }

        public Data Copy()
        {
            Data ans = new Data
            {
                AngA =this.AngA, AngB=this.AngB, AngC=this.AngC,
                LenA =this.LenA, LenB=this.LenB, LenC=this.LenC
            };
            return ans;
        }
    }
}
