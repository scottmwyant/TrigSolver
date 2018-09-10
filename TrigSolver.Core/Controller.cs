using System;
using System.Collections.Generic;
using System.Text;

namespace TrigSolver.Core
{
    public static class Controller
    {
        public static IResponse Invoke(Core.Data data)
        {
            DataSet ds = new DataSet(data);

            ControllerResponse response = new ControllerResponse();

            if(Validation.Test(ds).Error)
            {
                response.Error = true;
                response.Solution = new Data();
                response.Text = Validation.ErrorMessage;
                
            }
            else
            {
                response.Error = false;
                response.Solution = ds.Solve();
                response.Text = "Solved";
            }
            

            return response;
        }
    }
}
