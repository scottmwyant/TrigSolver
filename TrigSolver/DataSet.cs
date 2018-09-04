
namespace TrigSolver
{
    public class DataSet
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
                return new double[] {Data.angA, Data.angB, Data.angC, Data.lenA, Data.lenB, Data.lenC };
            }
        }
        public double[] ArrayLen
        {
            get
            {
                return new double[] { Data.lenA, Data.lenB, Data.lenC };
            }
        }
        public double[] ArrayAng
        {
            get
            {
                return new double[] { Data.angA, Data.angB, Data.angC };
            }
        }

        public string Profile { get; private set; }
        public string Algorithm { get; private set; }

        public DataSet(Data data) // Constructor
        {
            this.Data = data;
            Angles = new Triple(new double[] { data.angA, data.angB, data.angC });
            Lengths = new Triple(new double[] { data.lenA, data.lenB, data.lenC });
            CountAng = CountNonZeros(Angles.Arr);
            CountLen= CountNonZeros(Lengths.Arr);

            // The data set should be able to fully profile the data
            Profile = SetProfile(ArrayAll);
            Algorithm = SetAlgorithm(Profile);
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
        private static string SetAlgorithm(string profile)
        {
            string ans="";
            switch (profile)
            {
                case "123456": ans="ASA"; break;
                // so on and so on ...
            }
            return ans;
        }
    }

    
}
