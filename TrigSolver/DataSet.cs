
namespace TrigSolver
{
    class DataSet
    {
        public Data Raw { get; }
        public Triple Angles { get; }
        public Triple Lengths { get; } 

        public DataSet(Data data)
        {
            Raw = data;
            Angles = new Triple(new double[]{ data.angA, data.angB, data.angC });
            Lengths = new Triple(new double[]{ data.lenA, data.lenB, data.lenC });
        }




    }

    
}
