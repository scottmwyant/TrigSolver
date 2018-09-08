using System;

namespace TrigSolverTest
{
    public static class GenerateData
    {

        public static TrigSolver.DataSet SingleDataSet()
        {
            TrigSolver.Data d = new TrigSolver.Data()
            {
                AngA = Math.PI / 180 * 90,
                AngB = 0,
                AngC = 0,
                LenA = 12,
                LenB = 10,
                LenC = 0
            };

            return new TrigSolver.DataSet(d);
        }
        
    }
}
