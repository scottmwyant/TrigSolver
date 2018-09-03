
namespace TrigSolver
{
    class DataSet
    {
        public Data Data { get; }
        public Triple Angles { get; }
        public Triple Lengths { get; }
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
        public DataSet(Data data)
        {
            this.Data = data;
            Angles = new Triple(new double[]{ data.angA, data.angB, data.angC });
            Lengths = new Triple(new double[]{ data.lenA, data.lenB, data.lenC });
        }
    }

    
}
