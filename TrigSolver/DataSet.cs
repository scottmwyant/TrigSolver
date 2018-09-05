
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
                case "111000": ans = "SSS"; break; // SSS 1 of 1
                //
                case "001110": ans = "SAS"; break; // SAS 1 of 3
                case "010101": ans = "SAS"; break; // SAS 2 of 3
                case "100011": ans = "SAS"; break; // SAS 3 of 3
                //
                case "110001": ans = "ASA"; break; // ASA 1 of 3
                case "011100": ans = "ASA"; break; // ASA 2 of 3
                case "101010": ans = "ASA"; break; // ASA 3 of 3
                //
                case "110100": ans = "AAS"; break; // AAS 1 of 6
                case "101100": ans = "AAS"; break; // AAS 2 of 6
                case "110010": ans = "AAS"; break; // AAS 3 of 6
                case "011010": ans = "AAS"; break; // AAS 4 of 6
                case "101001": ans = "AAS"; break; // AAS 5 of 6
                case "011001": ans = "AAS"; break; // AAS 6 of 6
                //
                case "100110": ans = "SSA"; break; // SSA 1 of 6
                case "100101": ans = "SSA"; break; // SSA 2 of 6
                case "010110": ans = "SSA"; break; // SSA 3 of 6
                case "010011": ans = "SSA"; break; // SSA 4 of 6
                case "001101": ans = "SSA"; break; // SSA 5 of 6
                case "001011": ans = "SSA"; break; // SSA 6 of 6
                //
                case "000111": ans = "AAA"; break; // AAA 1 of 1


            }
            return ans;
        }
    }

    
}
