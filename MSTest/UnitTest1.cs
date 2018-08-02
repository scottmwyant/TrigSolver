using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrigSolver;

namespace MSTest
{
    [TestClass]
    public class Test
    {
        private const double testPrecision = .00001;

        [TestMethod]
        public void AnglesSumToPi_SolveForAngle3_Test()
        { Assert.AreEqual(Math.PI / 3, Trig.AnglesSumToPi_SolveForAngle3(Math.PI / 6, Math.PI / 2), testPrecision); }

        [TestMethod]
        public void LawOfCosines_SolveForAngle1_Test()
        { Assert.AreEqual(1.82347654, Trig.LawOfCosines_SolveForAngle1(4, 3, 2), testPrecision); }

        [TestMethod]
        public void LawOfCosines_SolveForLength3_Test()
        { Assert.AreEqual(3.71794, Trig.LawOfCosines_SolveForLength3(6, 3, Math.PI / 6), testPrecision); }

        [TestMethod]
        public void LawOfSines_SolveForAngle2_Test()
        { Assert.AreEqual((Math.PI / 6), Trig.LawOfSines_SolveForAngle2(6, Math.PI / 2, 3), testPrecision); }

        [TestMethod]
        public void LawOfSines_SolveForLength2_Test()
        { Assert.AreEqual(6, Trig.LawOfSines_SolveForLength2(Math.PI / 6, 3, Math.PI / 2), testPrecision); }

    }
}
