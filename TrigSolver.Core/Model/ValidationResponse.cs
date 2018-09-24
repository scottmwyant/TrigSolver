
namespace TrigSolver.Core.Model
{
    internal class ValidationResponse
    {
        public Data Solution { get; internal set; }
        public string Text { get; internal set; }
        public bool Error { get; internal set; }

        internal ValidationResponse(bool err, string txt)
        {
            this.Error = err;
            this.Text = txt;
        }
        
    }
}
