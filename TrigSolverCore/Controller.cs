using System;
using System.Collections.Generic;
using System.Text;

namespace TrigSolver.Core
{
    public static class Controller
    {
        public static bool Valid { get; private set; }
        public static Data Response { get; private set; }

        public static void Execute(Core.Data data)
        {
            Core.DataSet ds = new DataSet(data);

            Valid = Core.Validation.Test(ds);

            Response = ds.Solve();

           
        }
    }
}
