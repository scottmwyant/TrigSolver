using TrigSolver.Core.Model;

namespace TrigSolver.Core
{ 
    internal class ControllerResponse 
    {
        public Data Solution { get; internal set; }
        public string Text { get; internal set; }
        public bool Error { get; internal set; }
        
    }
}
