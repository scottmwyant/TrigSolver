using System;
using System.Linq;

namespace TrigSolver.Core.Model
{
    internal class Triple
    {
        public double Max { get { return Arr.Max(); } }
        public double Mid { get { return Arr.Sum() - Arr.Min() - Arr.Max(); } }
        public double Min { get { return Arr.Min(); } }
        public double Sum { get { return Arr.Sum(); } }
        public double[] Arr { get; }

        public Triple(double[] data){Arr = data;}
    }
}
