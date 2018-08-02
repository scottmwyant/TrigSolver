using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrigSolver
{
    public interface IViewModel
    {
        bool Enabled0 { get; }
        bool Enabled1 { get; }
        bool Enabled2 { get; }
        bool Enabled3 { get; }
        bool Enabled4 { get; }
        bool Enabled5 { get; }
        bool UseDegrees { set; }

        string Text0 { get; }
        string Text1 { get; }
        string Text2 { get; }
        string Text3 { get; }
        string Text4 { get; }
        string Text5 { get; }
        string StatusText1 { get; }
        string StatusText2 { get; }

        void Sync(string[] str);
    }
}
