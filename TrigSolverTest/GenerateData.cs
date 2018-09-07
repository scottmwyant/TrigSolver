using System;
using System.Collections.Generic;
using System.Text;

namespace TrigSolverTest
{
    public static class GenerateData
    {

        public static TrigSolver.DataSet SingleDataSet()
        {
            TrigSolver.Data d = new TrigSolver.Data()
            {
                angA = Math.PI / 180 * 90,
                angB = 0,
                angC = 0,
                lenA = 12,
                lenB = 10,
                lenC = 0
            };

            return new TrigSolver.DataSet(d);
        }
        
    }
}
