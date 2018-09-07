using System;
namespace TrigSolver
{
    public static class Trig
    {

        public static double AnglesSumToPi_SolveForAngle3(double angle1, double angle2)
        { return (Math.PI - angle1 - angle2); }

        public static double LawOfCosines_SolveForAngle1(double length1, double length2, double length3)
        { return (Math.Acos((Math.Pow(length1, 2) - Math.Pow(length2, 2) - Math.Pow(length3, 2)) / (-2 * length2 * length3))); }

        public static double LawOfCosines_SolveForLength3(double length1, double length2, double angle3)
        { return Math.Sqrt((Math.Pow(length1, 2) + Math.Pow(length2, 2)) - (2 * length1 * length2 * Math.Cos(angle3))); }

        public static double LawOfSines_SolveForAngle2(double length1, double angle1, double length2)
        { return Math.Asin((Math.Sin(angle1) / length1) * length2); }

        public static double LawOfSines_SolveForLength2(double angle1, double length1, double angle2)
        { return (length1 / Math.Sin(angle1)) * Math.Sin(angle2); }



        public static Data Solve(DataSet ds)
        {
            Data d = ds.Data.Copy();

            switch (ds.ProfileId)
            {
                // Side-Side-Side
                case "111000": // SSS 1 of 1
                    d.angA = LawOfCosines_SolveForAngle1(d.lenA, d.lenB, d.lenC);
                    d.angB = LawOfCosines_SolveForAngle1(d.lenB, d.lenA, d.lenC);
                    d.angC = AnglesSumToPi_SolveForAngle3(d.angA, d.angB);
                    break;
                
                 // Side-Angle-Side
                case "001110": // SAS 1 of 3
                    d.lenC = LawOfCosines_SolveForLength3(d.lenA, d.lenB, d.angC);
                    d.angB = LawOfSines_SolveForAngle2(d.lenC, d.angC, d.lenB);
                    d.angA = AnglesSumToPi_SolveForAngle3(d.angB, d.angC);
                    break;
                case "010101": // SAS 2 of 3
                    d.lenB = LawOfCosines_SolveForLength3(d.lenA, d.lenC, d.angB);
                    d.angC = LawOfSines_SolveForAngle2(d.lenB, d.angB, d.lenC);
                    d.angA = AnglesSumToPi_SolveForAngle3(d.angB, d.angC);
                    break;
                case "100011": // SAS 3 of 3
                    d.lenA = LawOfCosines_SolveForLength3(d.lenB, d.lenC, d.angA);
                    d.angB = LawOfSines_SolveForAngle2(d.lenA, d.angA, d.lenB);
                    d.angC = AnglesSumToPi_SolveForAngle3(d.angA, d.angB);
                    break;

                // Angle-Side-Angle
                case "110001":  // ASA 1 of 3
                    d.angC = AnglesSumToPi_SolveForAngle3(d.angA, d.angB);
                    d.lenA = LawOfSines_SolveForLength2(d.angC, d.lenC, d.angA);
                    d.lenB = LawOfSines_SolveForLength2(d.angC, d.lenC, d.angB);
                    break;
                case "011100":  // ASA 2 of 3
                    d.angA = AnglesSumToPi_SolveForAngle3(d.angB, d.angC);
                    d.lenB = LawOfSines_SolveForLength2(d.angA, d.lenA, d.angB);
                    d.lenC = LawOfSines_SolveForLength2(d.angA, d.lenA, d.angC);
                    break;
                case "101010":  // ASA 3 of 3
                    d.angB = AnglesSumToPi_SolveForAngle3(d.angA, d.angC);
                    d.lenA = LawOfSines_SolveForLength2(d.angB, d.lenB, d.angA);
                    d.lenC = LawOfSines_SolveForLength2(d.angB, d.lenB, d.angC);
                    break;

                // Angle-Angle-Side
                case "110100":  // AAS 1 of 6
                    d.angC = AnglesSumToPi_SolveForAngle3(d.angA, d.angB);
                    d.lenB = LawOfSines_SolveForLength2(d.angA, d.lenA, d.angB);
                    d.lenC = LawOfSines_SolveForLength2(d.angA, d.lenA, d.angC);
                    break;
                case "101100": // AAS 2 of 6
                    d.angB = AnglesSumToPi_SolveForAngle3(d.angA, d.angC);
                    d.lenB = LawOfSines_SolveForLength2(d.angA, d.lenA, d.angB);
                    d.lenC = LawOfSines_SolveForLength2(d.angA, d.lenA, d.angC);
                    break;
                case "110010":  // AAS 3 of 6
                    d.angC = AnglesSumToPi_SolveForAngle3(d.angA, d.angB);
                    d.lenA = LawOfSines_SolveForLength2(d.angB, d.lenB, d.angC);
                    d.lenC = LawOfSines_SolveForLength2(d.angB, d.lenB, d.angA);
                    break;
                case "011010": // AAS 4 of 6
                    d.angA = AnglesSumToPi_SolveForAngle3(d.angB, d.angC);
                    d.lenA = LawOfSines_SolveForLength2(d.angB, d.lenB, d.angA);
                    d.lenC = LawOfSines_SolveForLength2(d.angB, d.lenB, d.angA);
                    break;
                case "101001": // AAS 5 of 6
                    d.angB = AnglesSumToPi_SolveForAngle3(d.angA, d.angC);
                    d.lenB = LawOfSines_SolveForLength2(d.angC, d.lenC, d.angB);
                    d.lenA = LawOfSines_SolveForLength2(d.angC, d.lenC, d.angA);
                    break;
                case "011001": // AAS 6 of 6
                    d.angA = AnglesSumToPi_SolveForAngle3(d.angB, d.angC);
                    d.lenB = LawOfSines_SolveForLength2(d.angC, d.lenC, d.angB);
                    d.lenA = LawOfSines_SolveForLength2(d.angC, d.lenC, d.angA);
                    break;

                // Side-Side-Angle
                case "100110": // SSA 1 of 6
                    d.angB = LawOfSines_SolveForAngle2(d.lenA, d.angA, d.lenB);
                    d.angC = AnglesSumToPi_SolveForAngle3(d.angA, d.angB);
                    d.lenC = LawOfSines_SolveForLength2(d.angA, d.lenA, d.angC);
                    break;
                case "100101": // SSA 2 of 6
                    d.angC = LawOfSines_SolveForAngle2(d.lenA, d.angA, d.lenC);
                    d.angB = AnglesSumToPi_SolveForAngle3(d.angA, d.angC);
                    d.lenB = LawOfSines_SolveForLength2(d.angA, d.lenA, d.angB);
                    break;
                case "010110": // SSA 3 of 6
                    d.angA = LawOfSines_SolveForAngle2(d.lenB, d.angB, d.lenA);
                    d.angC = AnglesSumToPi_SolveForAngle3(d.angB, d.angA);
                    d.lenC = LawOfSines_SolveForLength2(d.angB, d.lenB, d.angC);
                    break;
                case "010011": // SSA 4 of 6
                    d.angC = LawOfSines_SolveForAngle2(d.lenB, d.angB, d.lenC);
                    d.angA = AnglesSumToPi_SolveForAngle3(d.angB, d.angC);
                    d.lenA = LawOfSines_SolveForLength2(d.angB, d.lenB, d.angA);
                    break;
                case "001101": // SSA 5 of 6
                    d.angA = LawOfSines_SolveForAngle2(d.lenC, d.angC, d.lenA);
                    d.angB = AnglesSumToPi_SolveForAngle3(d.angA, d.angC);
                    d.lenB = LawOfSines_SolveForLength2(d.angC, d.lenC, d.angB);
                    break;
                case "001011": // SSA 6 of 6
                    d.angB = LawOfSines_SolveForAngle2(d.lenC, d.angC, d.lenB);
                    d.angA = AnglesSumToPi_SolveForAngle3(d.angB, d.angC);
                    d.lenA = LawOfSines_SolveForLength2(d.angC, d.lenC, d.angA);
                    break;

                case "000111": // AAA 1 of 1
                    break;
            }
            return d;
        }
    }

}