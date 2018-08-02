using System;

namespace TrigSolver
{


    class Controller1 : IController
    {
        static class Trig
        {
            public static double AnglesSumToPi(double angle1, double angle2)
            {
                return (Math.PI - angle1 - angle2);
            }

            public static double LawOfCosines_SolveForAngle(double length1, double length2, double length3)
            {
                return (Math.Acos((Math.Pow(length2, 2) - Math.Pow(length1, 2) - Math.Pow(length3, 2)) / (-2 * length1 * length3)));
            }

            public static double LawOfSines_SolveForAngle(double angle1, double length1, double length2)
            {
                return Math.Asin((Math.Sin(angle1) / length1) * length2);
            }

            public static double LawOfSines_SolveForLength(double length1, double angle1, double angle2)
            {
                return (length1 / Math.Sin(angle1)) * Math.Sin(angle2);
            }

            public static double LawOfCosines_SolveForLength(double length1, double length2, double angle3)
            {
                return Math.Sqrt((Math.Pow(length1, 2) + Math.Pow(length2, 2)) - (2 * length1 * length2 * Math.Cos(angle3)));
            }

            public static void Solve(string algorithm, double[] input, out double[] output)
            {
                output = new double[3];
                

                switch (algorithm)
                {
                    case "SSS":
                        output[0] = LawOfCosines_SolveForAngle(input[0], input[1], input[2]);
                        output[1] = LawOfCosines_SolveForAngle(input[1], input[0], input[2]);
                        output[2] = AnglesSumToPi(output[0], output[1]);
                        break;

                    case "SAS":
                        output[0] = LawOfCosines_SolveForLength(input[0], input[2], input[1]);
                        output[1] = LawOfSines_SolveForAngle(input[1], output[0], input[0]);
                        output[2] = AnglesSumToPi(input[1], output[1]);
                        break;

                    case "ASA":
                        output[0] = AnglesSumToPi(input[0], input[2]);
                        output[1] = LawOfSines_SolveForLength(input[1], output[0], input[0]);
                        output[2] = LawOfSines_SolveForLength(input[1], output[0], input[2]);
                        break;

                    case "AAS":
                        output[0] = AnglesSumToPi(input[0], input[1]);
                        output[1] = LawOfSines_SolveForLength(input[2], input[1], input[0]);
                        output[2] = LawOfSines_SolveForLength(input[2], input[1], output[0]);
                        break;

                    case "SSA":
                        output[0] = LawOfSines_SolveForAngle(input[2], input[1], input[0]);
                        output[1] = AnglesSumToPi(input[2], output[0]);
                        output[2] = LawOfSines_SolveForLength(input[1], input[2], output[1]);
                        break;
                }
            }
        }

        //
        // Properties
        //
        public bool Error { get { return !(string.IsNullOrWhiteSpace(errorTextShort)); } }
        public int CaseId { get { return caseId; } }
        public string ErrorText1 { get { return errorTextShort; } }
        public string ErrorText2 { get { return errorTextLong; } }
        public double[] Data { get { return arr1; ; } }


        //
        // Fields
        //
        private double[] arr0;
        private double[] arr1;
        private double[] i = new double[3];
        private double[] o = new double[3];

        private int caseId;
        private int[] variable = new int[] { 0, 0, 0, 0, 0, 0 };
        
        private string algorithm;
        private string errorTextShort;
        private string errorTextLong;


        //
        // Methods
        //
        public void Test(double[] data)
        {
            arr0 = data;
            arr1 = data;

            // reset the error data
            errorTextShort = "";
            errorTextLong = "";

            // count given angles, lengths
            int nAng = CountValues(new double[] { arr0[3], arr0[4], arr0[5] });
            int nLen = CountValues(new double[] { arr0[0], arr0[1], arr0[2] });

            if ((nAng + nLen) < 3)
            {
                errorTextShort = "Waiting for inputs";
                errorTextLong = "A total of 3 inputs are needed, at least one must be a side length.";
            }
            else if ((nAng + nLen) > 3)
            {
                errorTextShort = "Overdefined";
                errorTextLong = "A total of 3 inputs are needed, at least one must be a side length.";
            }
            else
            {
                if (nAng == 3)
                {
                    errorTextShort = "Side length violation";
                    errorTextLong = "At least one of the three given values must be a side length.";
                }
                else if ((nLen == 3) && (TestLengths() == false))
                {
                    errorTextShort = "Side length violation";
                    errorTextLong = "The three side lengths cannot form a triangle.";
                }
                else if (TestAngles() == false)
                {
                    errorTextShort = "Sum of angles violation";
                    errorTextLong = "The sum of the given angles must be less than 180° (or pi radians)";
                }
                else
                {
                    //
                    // Advanced validation - At this point we won't know if advanced validation is required
                    // until we determine the caseId since only certain cases require advanced validation.
                    // 

                    caseId = GetCaseId();
                    algorithm = GetAlgorithm();

                    MapValues(false);

                    if (algorithm == "SSA")
                    {

                        double minLength = AdvancedValidationSSA(i[0], i[1], i[2]);
                        double minGiven = Math.Min(i[0], i[1]);

                        if (minGiven < minLength)
                        {
                            errorTextShort = "Side length violation";
                            errorTextLong = "The shorter side has to be at least " + Math.Round(minLength, 5).ToString() + " to form a triangle.";
                        }
                    }

                }
            }

            if (!Error)
            {
                Trig.Solve(algorithm, i, out o);
                MapValues(true);
            }

        }

        private int CountValues(double[] arr)
        {
            int ans = new int();
            foreach(double d in arr)
            {
                if (d > 0) { ans++; }
            }
            return ans;
        }

        private bool TestAngles()
        {
            return ((arr0[3] + arr0[4] + arr0[5]) < Math.PI);
        }

        private bool TestLengths()
        {
            double max = Math.Max(arr0[0], Math.Max(arr0[1], arr0[2]));
            double sum = arr0[0] + arr0[1] + arr0[2];
            return (max < (sum - max));
        }

        private double AdvancedValidationSSA(double length1, double length2, double angle1)
        {
            return Trig.LawOfSines_SolveForLength(Math.Max(length1, length2), (Math.PI / 2), angle1);
        }

        private string GetAlgorithm()
        {
            if (caseId == 1) { return "AAA"; }
            else if (caseId == 2) { return "SSS"; }
            else if (caseId <= 5) { return "SAS"; }
            else if (caseId <= 8) { return "ASA"; }
            else if (caseId <= 14) { return "AAS"; }
            else if (caseId <= 20) { return "SSA"; }
            else return "";
        }

        private int GetCaseId()
        {

            if ((arr0[3] * arr0[4] * arr0[5]) > 0) { return 1; }       // AAA 1 of 1
            else if ((arr0[0] * arr0[1] * arr0[2]) > 0) { return 2; } // SSS 1 of 1
            else if ((arr0[0] * arr0[5] * arr0[1]) > 0) { return 3; } // SAS 1 of 3
            else if ((arr0[0] * arr0[4] * arr0[2]) > 0) { return 4; } // SAS 2 of 3
            else if ((arr0[1] * arr0[3] * arr0[2]) > 0) { return 5; } // SAS 3 of 3
            else if ((arr0[3] * arr0[2] * arr0[4]) > 0) { return 6; } // ASA 1 of 3
            else if ((arr0[4] * arr0[0] * arr0[5]) > 0) { return 7; } // ASA 2 of 3
            else if ((arr0[5] * arr0[1] * arr0[3]) > 0) { return 8; } // ASA 3 of 3
            else if ((arr0[4] * arr0[3] * arr0[0]) > 0) { return 9; } // AAS 1 of 6
            else if ((arr0[5] * arr0[3] * arr0[0]) > 0) { return 10; } // AAS 2 of 6
            else if ((arr0[3] * arr0[4] * arr0[1]) > 0) { return 11; } // AAS 3 of 6
            else if ((arr0[5] * arr0[4] * arr0[1]) > 0) { return 12; } // AAS 4 of 6
            else if ((arr0[3] * arr0[5] * arr0[2]) > 0) { return 13; } // AAS 5 of 6
            else if ((arr0[4] * arr0[5] * arr0[2]) > 0) { return 14; } // AAS 6 of 6
            else if ((arr0[1] * arr0[0] * arr0[3]) > 0) { return 15; } // SSA 1 of 6
            else if ((arr0[2] * arr0[0] * arr0[3]) > 0) { return 16; } // SSA 2 of 6
            else if ((arr0[0] * arr0[1] * arr0[4]) > 0) { return 17; } // SSA 3 of 6
            else if ((arr0[2] * arr0[1] * arr0[4]) > 0) { return 18; } // SSA 4 of 6
            else if ((arr0[0] * arr0[2] * arr0[5]) > 0) { return 19; } // SSA 5 of 6
            else if ((arr0[1] * arr0[2] * arr0[5]) > 0) { return 20; } // SSA 6 of 6
            else { return 0; }
        }

        private void MapValues(bool output)
        {
            if (!output)
            {
                switch (caseId)
                {
                    case 1: break;                                                  // AAA 1 of 1
                    case 2: i[0] = arr0[0]; i[1] = arr0[1]; i[2] = arr0[2];  break; // SSS 1 of 1
                    case 3: i[0] = arr0[0]; i[1] = arr0[5]; i[2] = arr0[1];  break; // SAS 1 of 3
                    case 4: i[0] = arr0[0]; i[1] = arr0[4]; i[2] = arr0[5];  break; // SAS 2 of 3
                    case 5: i[0] = arr0[1]; i[1] = arr0[3]; i[2] = arr0[2];  break; // SAS 3 of 3
                    case 6: i[0] = arr0[3]; i[1] = arr0[2]; i[2] = arr0[4];  break; // ASA 1 of 3
                    case 7: i[0] = arr0[4]; i[1] = arr0[0]; i[2] = arr0[5];  break; // ASA 2 of 3
                    case 8: i[0] = arr0[5]; i[1] = arr0[1]; i[2] = arr0[3];  break; // ASA 3 of 3
                    case 9: i[0] = arr0[4]; i[1] = arr0[3]; i[2] = arr0[0];  break; // AAS 1 of 6
                    case 10: i[0] = arr0[5]; i[1] = arr0[3]; i[2] = arr0[0];  break; // AAS 2 of 6
                    case 11: i[0] = arr0[3]; i[1] = arr0[4]; i[2] = arr0[1];  break; // AAS 3 of 6
                    case 12: i[0] = arr0[5]; i[1] = arr0[4]; i[2] = arr0[1];  break; // AAS 4 of 6
                    case 13: i[0] = arr0[3]; i[1] = arr0[5]; i[2] = arr0[2];  break; // AAS 5 of 6
                    case 14: i[0] = arr0[4]; i[1] = arr0[5]; i[2] = arr0[2];  break; // AAS 6 of 6
                    case 15: i[0] = arr0[1]; i[1] = arr0[0]; i[2] = arr0[3];  break; // SSA 1 of 6
                    case 16: i[0] = arr0[2]; i[1] = arr0[0]; i[2] = arr0[3];  break; // SSA 2 of 6
                    case 17: i[0] = arr0[0]; i[1] = arr0[1]; i[2] = arr0[4];  break; // SSA 3 of 6
                    case 18: i[0] = arr0[2]; i[1] = arr0[1]; i[2] = arr0[4];  break; // SSA 4 of 6
                    case 19: i[0] = arr0[0]; i[1] = arr0[2]; i[2] = arr0[5];  break; // SSA 5 of 6
                    case 20: i[0] = arr0[1]; i[1] = arr0[2]; i[2] = arr0[5];  break; // SSA 6 of 6

                }
            }
            else
            {
                switch (caseId)
                {
                    case 1: break;                                                 // AAA 1 of 1
                    case 2: arr1[3] = o[0]; arr1[4] = o[1]; arr1[5] = o[2]; break; // SSS 1 of 1
                    case 3: arr1[2] = o[0]; arr1[3] = o[1]; arr1[4] = o[2]; break; // SAS 1 of 3
                    case 4: arr1[1] = o[0]; arr1[3] = o[1]; arr1[5] = o[2]; break; // SAS 2 of 3
                    case 5: arr1[0] = o[0]; arr1[4] = o[1]; arr1[5] = o[2]; break; // SAS 3 of 3
                    case 6: arr1[5] = o[0]; arr1[0] = o[1]; arr1[1] = o[2]; break; // ASA 1 of 3
                    case 7: arr1[3] = o[0]; arr1[1] = o[1]; arr1[2] = o[2]; break; // ASA 2 of 3
                    case 8: arr1[4] = o[0]; arr1[0] = o[1]; arr1[2] = o[2]; break; // ASA 3 of 3
                    case 9: arr1[5] = o[0]; arr1[1] = o[1]; arr1[2] = o[2]; break; // AAS 1 of 6
                    case 10: arr1[4] = o[0]; arr1[2] = o[1]; arr1[1] = o[2]; break; // AAS 2 of 6
                    case 11: arr1[5] = o[0]; arr1[0] = o[1]; arr1[2] = o[2]; break; // AAS 3 of 6
                    case 12: arr1[3] = o[0]; arr1[1] = o[1]; arr1[2] = o[2]; break; // AAS 4 of 6
                    case 13: arr1[4] = o[0]; arr1[0] = o[1]; arr1[1] = o[2]; break; // AAS 5 of 6
                    case 14: arr1[3] = o[0]; arr1[1] = o[1]; arr1[2] = o[2]; break; // AAS 6 of 6
                    case 15: arr1[4] = o[0]; arr1[5] = o[1]; arr1[2] = o[2]; break; // SSA 1 of 6
                    case 16: arr1[5] = o[0]; arr1[4] = o[1]; arr1[1] = o[2]; break; // SSA 2 of 6
                    case 17: arr1[3] = o[0]; arr1[5] = o[1]; arr1[2] = o[2]; break; // SSA 3 of 6
                    case 18: arr1[5] = o[0]; arr1[3] = o[1]; arr1[0] = o[2]; break; // SSA 4 of 6
                    case 19: arr1[3] = o[0]; arr1[4] = o[1]; arr1[1] = o[2]; break; // SSA 5 of 6
                    case 20: arr1[4] = o[0]; arr1[3] = o[1]; arr1[0] = o[2]; break; // SSA 6 of 6

                }
            }
            


        }

    }
}