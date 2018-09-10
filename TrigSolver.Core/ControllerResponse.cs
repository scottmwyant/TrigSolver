
namespace TrigSolver.Core
{
    public interface IResponse
    {
        Data Solution { get; }
        string Text { get; }
        bool Error { get; }

    }

    internal class ControllerResponse : IResponse
    {
        public Data Solution { get; internal set; }
        public string Text { get; internal set; }
        public bool Error { get; internal set; }
        
    }
}
