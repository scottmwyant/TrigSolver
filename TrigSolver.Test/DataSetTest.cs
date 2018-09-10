using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrigSolverTest
{
    [TestClass]
    public class DataSetTest
    {
        private const double testPrecision = .000001;

        [TestMethod]
        public void Profile()
        {
            TrigSolver.Data data = new TrigSolver.Data
            {
                AngA = 0, AngB = .15, AngC = 0,
                LenA = 0, LenB = 0, LenC = 0
            };

            TrigSolver.DataSet ds = new TrigSolver.DataSet(data);

            Assert.AreEqual(ds.Profile, "010000", false);
        }
        [TestMethod]
        public void Test()
        {
            TrigSolver.DataSet[] ds = GenerateData.Array6();
            Assert.AreEqual(6.63324958, ds[0].Solve().LenC, testPrecision);
            //TrigSolver.DataSet dset = new TrigSolver.DataSet(new TrigSolver.Data());
            //TrigSolver.Data ans = dset.Solve();
        }

    }
}
