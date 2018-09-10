using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrigSolverTest
{
    [TestClass]
    public class ValidationTest
    {
        private const double testprecision = .00001;

        [TestMethod]
        public void Test()
        {
            TrigSolver.DataSet[] ds = GenerateData.Array6();
            bool ans = TrigSolver.Validation.Test(ds[0]);
            Assert.AreEqual(true, ans);
        }

    }
}
