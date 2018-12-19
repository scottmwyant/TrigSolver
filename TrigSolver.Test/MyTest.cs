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
            var d = (Data)Setup.GetSampleSolution();
            var ds = new DataSet(d);
            Debug.WriteLine("ProfileId: {0}", ds.ProfileId);
            Assert.AreEqual(63, ds.ProfileId);
        }

        internal static class Setup
        {

            internal static readonly int[] CaseIdList_All = { 112, 26, 41, 67, 97, 56, 82, 104, 88, 98, 50, 81, 49, 74, 73, 42, 35, 25, 19, 11 };
            internal static readonly int[] CaseIdList_SAS = { 26, 41, 67 };
            internal static readonly int[] CaseIdList_ASA = { 97, 56, 82 };
            internal static readonly int[] CaseIdList_AAS = { 104, 88, 98, 50, 81, 49 };
            internal static readonly int[] CaseIdList_SSA = { 74, 73, 42, 35, 25, 19 };

            internal static Object GetSampleSolution(int solution = 0)
            {
                var d = new Data();
                switch (solution)
                {
                    default:
                        d.AngA = (Math.PI / 180) * (90);
                        d.AngB = (Math.PI / 180) * (60);
                        d.AngC = (Math.PI / 180) * (30);
                        d.LenA = 4.619;
                        d.LenB = 4;
                        d.LenC = 2.309;
                        break;
                }
                return d;
            }

            internal static Object GetSampleData(Data d0, int caseID)
            {
                var d1 = new Data();

                switch (caseID)
                {
                    case 112: d1.AngA = d0.AngA; d1.AngB = d0.AngB; d1.AngC = d0.AngC; break;
                    case 26: d1.AngC = d0.AngC; d1.LenA = d0.LenA; d1.LenB = d0.LenB; break;
                    case 41: d1.AngB = d0.AngB; d1.LenA = d0.LenA; d1.LenC = d0.LenC; break;
                    case 67: d1.AngA = d0.AngA; d1.LenB = d0.LenB; d1.LenC = d0.LenC; break;
                    case 97: d1.AngA = d0.AngA; d1.AngB = d0.AngB; d1.LenC = d0.LenC; break;
                    case 56: d1.AngB = d0.AngB; d1.AngC = d0.AngC; d1.LenA = d0.LenA; break;
                    case 82: d1.AngA = d0.AngA; d1.AngC = d0.AngC; d1.LenB = d0.LenB; break;
                    case 104: d1.AngA = d0.AngA; d1.AngB = d0.AngB; d1.LenA = d0.LenA; break;
                    case 88: d1.AngA = d0.AngA; d1.AngC = d0.AngC; d1.LenA = d0.LenA; break;
                    case 98: d1.AngA = d0.AngA; d1.AngB = d0.AngB; d1.LenB = d0.LenB; break;
                    case 50: d1.AngB = d0.AngB; d1.AngC = d0.AngC; d1.LenB = d0.LenB; break;
                    case 81: d1.AngA = d0.AngA; d1.AngC = d0.AngC; d1.LenC = d0.LenC; break;
                    case 49: d1.AngB = d0.AngB; d1.AngC = d0.AngC; d1.LenC = d0.LenC; break;
                    case 74: d1.AngA = d0.AngA; d1.LenA = d0.LenA; d1.LenB = d0.LenB; break;
                    case 73: d1.AngA = d0.AngA; d1.LenA = d0.LenA; d1.LenC = d0.LenC; break;
                    case 42: d1.AngB = d0.AngB; d1.LenA = d0.LenA; d1.LenC = d0.LenC; break;
                    case 35: d1.AngB = d0.AngB; d1.LenB = d0.LenB; d1.LenC = d0.LenC; break;
                    case 25: d1.AngC = d0.AngC; d1.LenA = d0.LenA; d1.LenC = d0.LenC; break;
                    case 19: d1.AngC = d0.AngC; d1.LenB = d0.LenB; d1.LenC = d0.LenC; break;
                    case 11: d1.LenA = d0.LenA; d1.LenB = d0.LenB; d1.LenC = d0.LenC; break;
                    default: break;
                }
                return d1;
            }
        }
    }
}