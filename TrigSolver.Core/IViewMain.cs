using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrigSolver.Core
{
    public interface IViewMain
    {
        //
        // properties
        //
        string AngleA { get; set; }
        string AngleB { get; set; }
        string AngleC { get; set; }
        string LengthA { get; set; }
        string LengthB { get; set; }
        string LengthC { get; set; }
        bool AngleAEnabled { get; set; }
        bool AngleBEnabled { get; set; }
        bool AngleCEnabled { get; set; }
        bool LengthAEnabled { get; set; }
        bool LengthBEnabled { get; set; }
        bool LengthCEnabled { get; set; }
        bool Solved { get; set; }
        bool Degrees { get; }

        //
        // methods
        //
        void SetController(IController controller);
        void SetStatusText(string shortText, string longText);

    }
}
