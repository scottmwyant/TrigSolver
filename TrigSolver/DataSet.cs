
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

        public string ProfileId { get; private set; }
        public string Algorithm { get; private set; }

        private double[] inputSet;
        private double[] outputSet;

        public DataSet(Data data) // Constructor
        {
            this.Data = data;
            Angles = new Triple(new double[] { data.angA, data.angB, data.angC });
            Lengths = new Triple(new double[] { data.lenA, data.lenB, data.lenC });
            CountAng = CountNonZeros(Angles.Arr);
            CountLen= CountNonZeros(Lengths.Arr);

            Profile();
        }
        
        private static int CountNonZeros(double[] arr)
        {
            int ans = new int();
            foreach (double d in arr){if (d != 0) { ans++; }}
            return ans;

        }


        private void Profile()
        {
            ProfileId = SetProfileId(ArrayAll);
            switch (ProfileId)
            {
                // Side-Side-Side
                case "000111":
                    Algorithm = "SSS";
                    inputSet = new double[] { 3, 4, 5 };
                    outputSet = new double[] { 0, 1, 2 };
                    break; 
                
                //Side-Angle-Side
                case "001110":
                    Algorithm = "SAS";
                    inputSet = new double[] { 3, 2, 4 };
                    outputSet = new double[] { 5, 0, 1 };
                    break;
                case "010101":
                    Algorithm = "SAS";
                    inputSet = new double[] { 3, 1, 2 };
                    outputSet = new double[] { 4, 0, 2 };
                    break;
                case "100011":
                    Algorithm = "SAS";
                    inputSet = new double[] { 4, 0, 5 };
                    outputSet = new double[] { 3, 1, 2 };
                    break;
                
                // Angle-Side-Angle
                case "110001":
                    Algorithm = "ASA";
                    inputSet = new double[] { 0, 5, 1 };
                    outputSet = new double[] { 2, 3, 4 };
                    break;
                case "011100":
                    Algorithm = "ASA";
                    inputSet = new double[] { 1, 3, 2 };
                    outputSet = new double[] { 0, 4, 5 };
                    break;
                case "101010":
                    Algorithm = "ASA";
                    inputSet = new double[] { 2, 4, 0 };
                    outputSet = new double[] { 1, 3, 5 };
                    break;
                
                // Angle-Angle-Side
                case "110100":
                    Algorithm = "AAS";
                    inputSet = new double[] { 1, 0, 3 };
                    outputSet = new double[] { 2, 4, 5 };
                    break; 
                case "101100":
                    Algorithm = "AAS";
                    inputSet = new double[] { 2, 0, 3 };
                    outputSet = new double[] { 1, 5, 4 };
                    break; 
                case "110010":
                    Algorithm = "AAS";
                    inputSet = new double[] { 0, 1, 4 };
                    outputSet = new double[] { 2, 3, 5 };
                    break; 
                case "011010":
                    Algorithm = "AAS";
                    inputSet = new double[] { 2, 1, 4 };
                    outputSet = new double[] { 0, 4, 5 };
                    break;
                case "101001":
                    Algorithm = "AAS";
                    inputSet = new double[] { 0, 2, 5 };
                    outputSet = new double[] { 1, 3, 4 };
                    break;
                case "011001":
                    Algorithm = "AAS";
                    inputSet = new double[] { 1, 2, 5 };
                    outputSet = new double[] { 0, 4, 5 };
                    break;
                
                // Side-Side-Angle
                case "100110":
                    Algorithm = "SSA";
                    inputSet = new double[] { 4, 3, 0 };
                    outputSet = new double[] { 1, 2, 5 };
                    break;
                case "100101":
                    Algorithm = "SSA";
                    inputSet = new double[] { 5, 3, 0 };
                    outputSet = new double[] { 2, 1, 4 };
                    break;
                case "010110":
                    Algorithm = "SSA";
                    inputSet = new double[] { 3, 4, 1 };
                    outputSet = new double[] { 0, 2, 5 };
                    break;
                case "010011":
                    Algorithm = "SSA";
                    inputSet = new double[] { 5, 4, 1 };
                    outputSet = new double[] { 2, 0, 3 };
                    break;
                case "001101":
                    Algorithm = "SSA";
                    inputSet = new double[] { 3, 5, 2 };
                    outputSet = new double[] { 0, 1, 4 };
                    break;
                case "001011":
                    Algorithm = "SSA";
                    inputSet = new double[] { 4, 5, 2 };
                    outputSet = new double[] { 1, 0, 3 };
                    break;
                
                // Angle-Angle-Angle
                case "111000":
                    Algorithm = "AAA";
                    inputSet = new double[] { 0, 1, 2 };
                    outputSet = new double[] { 3, 4, 5 };
                    break; // AAA 1 of 1

            }
            
        }

        private static string SetProfileId(double[] arr)
        {
            string ans = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0) { ans = ans + "1"; } else { ans = ans + "0"; }
            }
            return ans;
        }

    }

    public class DataSet_SAS1 : DataSet
    {
        public double Input1 { get { return Data.lenA; } }
        public double Input2 { get { return Data.angC; } }
        public double Input3 { get { return Data.lenB; } }

        public void Calc1(double val) { Data.lenC = val; }
        public void Calc2(double val) { Data.angA = val; }
        public void Calc3(double val) { Data.angB = val; }

        public DataSet_SAS1(Data data) : base(data) { }
    }


}
