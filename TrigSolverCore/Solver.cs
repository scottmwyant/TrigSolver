
namespace TrigSolver.Core
{
    public interface ISolver
    {
        Data Solve(Data data);
    }

    #region Solvers
    public class Solver : ISolver
    {
        public Data Solve(Data data)
        {
            return data.Copy();
        }
    }

    public class SSS0 : ISolver
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

    
    public class SAS0 : ISolver
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
    public class SAS1 : ISolver
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
    public class SAS2 : ISolver
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
    public class ASA0 : ISolver
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
    public class ASA1 : ISolver
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
    public class ASA2 : ISolver
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
    public class AAS0 : ISolver
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
    public class AAS1 : ISolver
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
    public class AAS2 : ISolver
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
    public class AAS3 : ISolver
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
    public class AAS4 : ISolver
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
    public class AAS5 : ISolver
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
    public class SSA0 : ISolver
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
    public class SSA1 : ISolver
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
    public class SSA2 : ISolver
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
    public class SSA3 : ISolver
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
    public class SSA4 : ISolver
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
    public class SSA5 : ISolver
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

    public static class Factory
    {
        public static ISolver GetSolver(string profileId)
        {
            ISolver solver = new Solver();
            switch (profileId)
            {
                // Side-Side-Side
                case "111000": solver = new SSS0(); break;

                // Side-Angle-Side
                case "001110": solver = new SAS0(); break;
                case "010101": solver = new SAS1(); break;
                case "100011": solver = new SAS2(); break;

                // Angle-Side-Angle
                case "110001": solver = new ASA0(); break;
                case "011100": solver = new ASA1(); break;
                case "101010": solver = new ASA2(); break;

                // Angle-Angle-Side
                case "110100": solver = new AAS0(); break;
                case "101100": solver = new AAS1(); break;
                case "110010": solver = new AAS2(); break;
                case "011010": solver = new AAS3(); break;
                case "101001": solver = new AAS4(); break;
                case "011001": solver = new AAS5(); break;

                // Side-Side-Angle
                case "100110": solver = new SSA0(); break;
                case "100101": solver = new SSA1(); break;
                case "010110": solver = new SSA2(); break;
                case "010011": solver = new SSA3(); break;
                case "001101": solver = new SSA4(); break;
                case "001011": solver = new SSA5(); break;

                case "000111": break; // AAA 1 of 1
            }
            return solver;
            
        }
    }
}
