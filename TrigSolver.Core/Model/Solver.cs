
namespace TrigSolver.Core.Model
{
    internal interface ISolver
    {
        Data Solve(Data data);
    }

    #region Solvers
    internal class Solver : ISolver
    {
        public Data Solve(Data data)
        {
            return data.Copy();
        }
    }

    internal class SSS0 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.AngA = Trig.LawOfCosines_SolveForAngle1(d.LenA, d.LenB, d.LenC);
            d.AngB = Trig.LawOfCosines_SolveForAngle1(d.LenB, d.LenA, d.LenC);
            d.AngC = Trig.AnglesSumToPi_SolveForAngle3(d.AngA, d.AngB);
            return d;
        }
    }

    
    internal class SAS0 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.LenC = Trig.LawOfCosines_SolveForLength3(d.LenA, d.LenB, d.AngC);
            d.AngB = Trig.LawOfSines_SolveForAngle2(d.LenC, d.AngC, d.LenB);
            d.AngA = Trig.AnglesSumToPi_SolveForAngle3(d.AngB, d.AngC);
            return d;
        }
    }
    internal class SAS1 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.LenB = Trig.LawOfCosines_SolveForLength3(d.LenA, d.LenC, d.AngB);
            d.AngC = Trig.LawOfSines_SolveForAngle2(d.LenB, d.AngB, d.LenC);
            d.AngA = Trig.AnglesSumToPi_SolveForAngle3(d.AngB, d.AngC);
            return d;
        }
    }
    internal class SAS2 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.LenA = Trig.LawOfCosines_SolveForLength3(d.LenB, d.LenC, d.AngA);
            d.AngB = Trig.LawOfSines_SolveForAngle2(d.LenA, d.AngA, d.LenB);
            d.AngC = Trig.AnglesSumToPi_SolveForAngle3(d.AngA, d.AngB);
            return d;
        }
    }
    internal class ASA0 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.AngC = Trig.AnglesSumToPi_SolveForAngle3(d.AngA, d.AngB);
            d.LenA = Trig.LawOfSines_SolveForLength2(d.AngC, d.LenC, d.AngA);
            d.LenB = Trig.LawOfSines_SolveForLength2(d.AngC, d.LenC, d.AngB);
            return d;
        }
    }
    internal class ASA1 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.AngA = Trig.AnglesSumToPi_SolveForAngle3(d.AngB, d.AngC);
            d.LenB = Trig.LawOfSines_SolveForLength2(d.AngA, d.LenA, d.AngB);
            d.LenC = Trig.LawOfSines_SolveForLength2(d.AngA, d.LenA, d.AngC);
            return d;
        }
    }
    internal class ASA2 : ISolver
    { 
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.AngB = Trig.AnglesSumToPi_SolveForAngle3(d.AngA, d.AngC);
            d.LenA = Trig.LawOfSines_SolveForLength2(d.AngB, d.LenB, d.AngA);
            d.LenC = Trig.LawOfSines_SolveForLength2(d.AngB, d.LenB, d.AngC);
            return d;
        }
    }
    internal class AAS0 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.AngC = Trig.AnglesSumToPi_SolveForAngle3(d.AngA, d.AngB);
            d.LenB = Trig.LawOfSines_SolveForLength2(d.AngA, d.LenA, d.AngB);
            d.LenC = Trig.LawOfSines_SolveForLength2(d.AngA, d.LenA, d.AngC);
            return d;
        }
    }
    internal class AAS1 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.AngB = Trig.AnglesSumToPi_SolveForAngle3(d.AngA, d.AngC);
            d.LenB = Trig.LawOfSines_SolveForLength2(d.AngA, d.LenA, d.AngB);
            d.LenC = Trig.LawOfSines_SolveForLength2(d.AngA, d.LenA, d.AngC);
            return d;
        }
    }
    internal class AAS2 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.AngC = Trig.AnglesSumToPi_SolveForAngle3(d.AngA, d.AngB);
            d.LenA = Trig.LawOfSines_SolveForLength2(d.AngB, d.LenB, d.AngC);
            d.LenC = Trig.LawOfSines_SolveForLength2(d.AngB, d.LenB, d.AngA);
            return d;
        }
    }
    internal class AAS3 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.AngA = Trig.AnglesSumToPi_SolveForAngle3(d.AngB, d.AngC);
            d.LenA = Trig.LawOfSines_SolveForLength2(d.AngB, d.LenB, d.AngA);
            d.LenC = Trig.LawOfSines_SolveForLength2(d.AngB, d.LenB, d.AngA);
            return d;
        }
    }
    internal class AAS4 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.AngB = Trig.AnglesSumToPi_SolveForAngle3(d.AngA, d.AngC);
            d.LenB = Trig.LawOfSines_SolveForLength2(d.AngC, d.LenC, d.AngB);
            d.LenA = Trig.LawOfSines_SolveForLength2(d.AngC, d.LenC, d.AngA);
            return d;
        }
    }
    internal class AAS5 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.AngA = Trig.AnglesSumToPi_SolveForAngle3(d.AngB, d.AngC);
            d.LenB = Trig.LawOfSines_SolveForLength2(d.AngC, d.LenC, d.AngB);
            d.LenA = Trig.LawOfSines_SolveForLength2(d.AngC, d.LenC, d.AngA);
            return d;
        }
    }
    internal class SSA0 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.AngB = Trig.LawOfSines_SolveForAngle2(d.LenA, d.AngA, d.LenB);
            d.AngC = Trig.AnglesSumToPi_SolveForAngle3(d.AngA, d.AngB);
            d.LenC = Trig.LawOfSines_SolveForLength2(d.AngA, d.LenA, d.AngC);
            return d;
        }
    }
    internal class SSA1 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.AngC = Trig.LawOfSines_SolveForAngle2(d.LenA, d.AngA, d.LenC);
            d.AngB = Trig.AnglesSumToPi_SolveForAngle3(d.AngA, d.AngC);
            d.LenB = Trig.LawOfSines_SolveForLength2(d.AngA, d.LenA, d.AngB);
            return d;
        }
    }
    internal class SSA2 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.AngA = Trig.LawOfSines_SolveForAngle2(d.LenB, d.AngB, d.LenA);
            d.AngC = Trig.AnglesSumToPi_SolveForAngle3(d.AngB, d.AngA);
            d.LenC = Trig.LawOfSines_SolveForLength2(d.AngB, d.LenB, d.AngC);
            return d;
        }
    }
    internal class SSA3 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.AngC = Trig.LawOfSines_SolveForAngle2(d.LenB, d.AngB, d.LenC);
            d.AngA = Trig.AnglesSumToPi_SolveForAngle3(d.AngB, d.AngC);
            d.LenA = Trig.LawOfSines_SolveForLength2(d.AngB, d.LenB, d.AngA);
            return d;
        }
    }
    internal class SSA4 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.AngA = Trig.LawOfSines_SolveForAngle2(d.LenC, d.AngC, d.LenA);
            d.AngB = Trig.AnglesSumToPi_SolveForAngle3(d.AngA, d.AngC);
            d.LenB = Trig.LawOfSines_SolveForLength2(d.AngC, d.LenC, d.AngB);
            return d;
        }
    }
    internal class SSA5 : ISolver
    {
        public Data Solve(Data data)
        {
            Data d = data.Copy();
            d.AngB = Trig.LawOfSines_SolveForAngle2(d.LenC, d.AngC, d.LenB);
            d.AngA = Trig.AnglesSumToPi_SolveForAngle3(d.AngB, d.AngC);
            d.LenA = Trig.LawOfSines_SolveForLength2(d.AngC, d.LenC, d.AngA);
            return d;
        }
    }
    #endregion

}
