using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrigSolver.Core.Model;

namespace TrigSolver.Test
{
    [TestClass]
    public class MyTest
    {

        [TestMethod]
        public void TestMethod1()
        {
            var ds = (DataSet)Setup.GetFakeDataSet();
            Debug.WriteLine(ds.Profile);
            Debug.WriteLine(Convert.ToInt16(ds.Profile,2));
        }
    }

    public static class Setup
    {
        public static Object GetFakeDataSet()
        {
            var d = new Data();
            d.AngA = (Math.PI / 180) * 90;
            d.LenA = 1;
            d.LenC = 4;
            return new DataSet(d);
        }
    }

}
