
namespace TrigSolver.Core
{
    internal class DataSet
    {
        public Data Data { get; }
        public Triple Angles { get; }
        public Triple Lengths { get; }

        public int CountAll { get { return CountAng + CountLen; } }
        public int CountAng { get; private set; }
        public int CountLen { get; private set; }

        public double[] ArrayAll
        {
            get
            {
                return new double[] { Data.AngA, Data.AngB, Data.AngC, Data.LenA, Data.LenB, Data.LenC };
            }
        }
        public double[] ArrayLen
        {
            get
            {
                return new double[] { Data.LenA, Data.LenB, Data.LenC };
            }
        }
        public double[] ArrayAng
        {
            get
            {
                return new double[] { Data.AngA, Data.AngB, Data.AngC };
            }
        }

        public string Algorithm { get; private set; }
        public string Profile { get; private set; }

        private ISolver solver;

        public DataSet(Data data) // Constructor
        {
            this.Data = data;
            Angles = new Triple(new double[] { data.AngA, data.AngB, data.AngC });
            Lengths = new Triple(new double[] { data.LenA, data.LenB, data.LenC });
            CountAng = CountNonZeros(Angles.Arr);
            CountLen = CountNonZeros(Lengths.Arr);
            Profile = SetProfile(this.ArrayAll);
            solver = Factory.GetSolver(this.Profile);
            Algorithm = solver.GetType().Name.Substring(0,3);
        }
        public Data Solve()
        {
            return solver.Solve(this.Data);
        }
        private static int CountNonZeros(double[] arr)
        {
            int ans = new int();
            foreach (double d in arr){if (d != 0) { ans++; }}
            return ans;

        }
        private static string SetProfile(double[] arr)
        {
            string ans = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0) { ans = ans + "1"; } else { ans = ans + "0"; }
            }
            return ans;
        }
    }
}
