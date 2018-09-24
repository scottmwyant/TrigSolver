using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrigSolver.Core;

namespace TrigSolver.Test
{
    internal static class Factory
    {
        internal static IViewMain TestData1()
        {
            View v = new View();
            Core.Factory.GetController(v);

            v.AngleA = ((90) * (System.Math.PI / 180)).ToString();
            v.LengthA = "12";
            v.LengthB = "10";

            return v;
        }
    }

    internal class View: IViewMain
    {
        public string AngleA { get; set; }
        public string AngleB { get; set; }
        public string AngleC { get; set; }
        public string LengthA { get; set; }
        public string LengthB { get; set; }
        public string LengthC { get; set; }

        public bool AngleAEnabled { get; set; }
        public bool AngleBEnabled { get; set; }
        public bool AngleCEnabled { get; set; }
        public bool LengthAEnabled { get; set; }
        public bool LengthBEnabled { get; set; }
        public bool LengthCEnabled { get; set; }

        public bool Degrees { get; set; }
        public bool Solved { get; set; }

        private IController controller;
        private string msg;

        public void SetController(IController con)
        {
            con = this.controller;
        }

        public void MessageBox(string message)
        {
            this.msg = message;
        }

        internal View()
        {
            this.AngleAEnabled = true;
            this.AngleBEnabled = true;
            this.AngleCEnabled = true;
            this.LengthAEnabled = true;
            this.LengthBEnabled = true;
            this.LengthCEnabled = true;
        }
    }

    [TestClass]
    internal class FirstTest
    {
        [TestMethod]
        internal void Test()
        {

        }
    }
}
