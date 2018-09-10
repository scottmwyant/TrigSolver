using System;

namespace TrigSolverTest
{
    public static class GenerateData
    {

        public static TrigSolver.DataSet[] Array6 ()
        {
            return new TrigSolver.DataSet[]
            {
                CreateDataSet(new double[] { Math.PI / 180 * 90, 0, 0, 12, 10, 0 }),
                CreateDataSet(new double[] { 0, 0, 0, 0, 0, 0 }),
                CreateDataSet(new double[] { 0, 0, 0, 0, 0, 0 }),
                CreateDataSet(new double[] { 0, 0, 0, 0, 0, 0 }),
                CreateDataSet(new double[] { 0, 0, 0, 0, 0, 0 }),
                CreateDataSet(new double[] { 0, 0, 0, 0, 0, 0 })
            };
        }


        private static TrigSolver.DataSet CreateDataSet(double[] data)
        {
            TrigSolver.Data d = new TrigSolver.Data() { AngA = data[0], AngB = data[1], AngC = data[2], LenA = data[3], LenB = data[4], LenC = data[5] };
            return new TrigSolver.DataSet(d);
        }


    }
}
