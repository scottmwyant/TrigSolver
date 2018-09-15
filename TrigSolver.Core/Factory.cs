using TrigSolver.Core.Model;

namespace TrigSolver.Core
{
    public static class Factory
    {
        public static IController GetController(IViewMain view)
        {
            return new Controller(view);
        }
        internal static ISolver GetSolver(string profileId)
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
