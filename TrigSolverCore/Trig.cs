using System;
namespace TrigSolver.Core
{
    internal static class Trig
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
    }
}