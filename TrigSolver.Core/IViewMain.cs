using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrigSolver.Core
{
    public interface IViewMain
    {
        string AngleA { get; set; }
        string AngleB { get; set; }
        string AngleC { get; set; }
        string LengthA { get; set; }
        string LengthB { get; set; }
        string LengthC { get; set; }
        bool Degrees { get; }

        IController Controller { set; }

        void MessageBox(string message);

    }
}
