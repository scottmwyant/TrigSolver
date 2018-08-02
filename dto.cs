using System;


namespace AppCore
{

    public class Corner
    {
        private double angle = new double();
        private bool useDegrees = new bool();

        public double Length { get; set; }

        public bool UseDegrees { get; set; }
        public double Angle
        {
            get
            {
                if (useDegrees) { return angle * 180 / Math.PI; }
                else { return angle; }
            }
            set
            {
                if (useDegrees) { angle = value * Math.PI / 180; }
                else { angle = value; }
            }
        }
    }

}
