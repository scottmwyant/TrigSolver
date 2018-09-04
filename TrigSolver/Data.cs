using System;

namespace TrigSolver
{
    public class Data
    {
        public double angA { get; set; }
        public double angB { get; set; }
        public double angC { get; set; }
        public double lenA { get; set; }
        public double lenB { get; set; }
        public double lenC { get; set; }
        
        public Data Copy()
        {
            Data ans = new Data
            {
                angA =this.angA, angB=this.angB, angC=this.angC,
                lenA =this.lenA, lenB=this.lenB, lenC=this.lenC
            };
            return ans;
        }
    }
}
