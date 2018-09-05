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



        public static Data SolveByProfile(Data data, string profile)
        {
            Data ans = data.Copy();

            switch (profile)
            {
                // Side-Side-Side
                case "111000": // SSS 1 of 1
                    break;
                
                 // Side-Angle-Side
                case "001110": // SAS 1 of 3
                    break;
                case "010101": // SAS 2 of 3
                    break;
                case "100011": // SAS 3 of 3
                    break;

                // Angle-Side-Angle
                case "110001":  // ASA 1 of 3
                    break;
                case "011100":  // ASA 2 of 3
                    break;
                case "101010":  // ASA 3 of 3
                    break;

                // Angle-Angle-Side
                case "110100":  // AAS 1 of 6
                    break;
                case "101100": // AAS 2 of 6
                    break;
                case "110010":  // AAS 3 of 6
                    break;
                case "011010": // AAS 4 of 6
                    break;
                case "101001": // AAS 5 of 6
                    break;
                case "011001": // AAS 6 of 6
                    break;

                // Side-Side-Angle
                case "100110": // SSA 1 of 6
                    break;
                case "100101": // SSA 2 of 6
                    break;
                case "010110": // SSA 3 of 6
                    break;
                case "010011": // SSA 4 of 6
                    break;
                case "001101": // SSA 5 of 6
                    break;
                case "001011": // SSA 6 of 6
                    break;

                case "000111": // AAA 1 of 1
                    break;
            }


            return ans;
        }
    }

}
}