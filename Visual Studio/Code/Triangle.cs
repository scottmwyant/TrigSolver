using System;
using System.Drawing;


namespace TrigSolver
{
    class Triangle
    {
        // Fields
        private PointF[] points = new PointF[3];
        private double[] sides = new double[3];
        private double[] angles = new double[3];
        private double[] rankedSides = new double[3];
        private double[] rankedAngles = new double[3];
        private double area = new double();
        private double height = new double();
        private double width = new double();
        private string angleClass;
        private string sideClass;

        // Properties (read-write)
        public double Alpha { get { return angles[0]; } set { angles[0] = value; } }
        public double Beta  { get { return angles[1]; } set { angles[1] = value; } }
        public double Gamma { get { return angles[2]; } set { angles[2] = value; } }
        public double SideA { get { return sides[0]; } set { sides[0] = value; } }
        public double SideB { get { return sides[1]; } set { sides[1] = value; } }
        public double SideC { get { return sides[2]; } set { sides[2] = value; } }

        // Properties (read-only)
        public double MinAngle { get { return rankedAngles[0]; } }
        public double MedAngle { get { return rankedAngles[1]; } }
        public double MaxAngle { get { return rankedAngles[2]; } }
        public double MinSide { get { return rankedSides[0]; } }
        public double MedSide { get { return rankedSides[1]; } }
        public double MaxSide { get { return rankedSides[2]; } }
        public PointF PointA { get { return points[0]; } }
        public PointF PointB { get { return points[1]; } }
        public PointF PointC { get { return points[2]; } }
        public PointF[] Points { get { return points; } }
        public double Area { get { return area; } }
        public double Height { get { return height; } }
        public double Width { get { return width; } }

        public string AngleClass { get { return angleClass; } }
        public string SideClass { get { return sideClass; } }

        // Methods

        public void CalculateProperties()
        {
            // Define point A
            points[0].X = 0.0f;
            points[0].Y = 0.0f;

            // Define point B
            points[1].X = (float)sides[2];
            points[1].Y = 0.0f;

            // Define point C
            points[2].X = (float)(sides[1] * Math.Cos(angles[0]));
            points[2].Y = (float)(-1 * sides[1] * Math.Sin(angles[0]));

            // Overall height and width (can be used to scale a plot)
            height = Math.Abs(points[2].Y);
            width = Math.Max(points[0].X, Math.Max(points[1].X, points[2].X)) - Math.Min(points[0].X, Math.Min(points[1].X, points[2].X));

            // Copy angle and side arrays
            angles.CopyTo(rankedAngles,0);
            sides.CopyTo(rankedSides,0);

            // Rank
            Array.Sort(rankedAngles);
            Array.Sort(rankedSides);

            // Acute / Right / Obtuse
            if (rankedAngles[2] < Math.PI / 2) { angleClass = "Acute"; }
            else if (rankedAngles[2] > Math.PI / 2) { angleClass = "Obtuse"; }
            else { angleClass = "Right"; }

            // Equilateral / Isosceles / Scalene
            if ((float)sides[0] == (float)sides[1] && (float)sides[0] == (float)sides[2]) { sideClass = "Equilateral"; }
            else if ((float)sides[0] == (float)sides[1] || (float)sides[0] == (float)sides[2] || (float)sides[1] == (float)sides[2]) { sideClass = "Isosceles"; }
            else { sideClass = "Scalene";}

             area = (((sides[1] * Math.Cos(angles[0])) * (sides[1] * Math.Sin(angles[0]))) + ((sides[1] * Math.Cos(angles[1])) * (sides[0] * Math.Sin(angles[1])))) / 2;

        }

    }
}
