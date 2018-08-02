namespace TrigSolver
{
    public interface IController
    {
        bool Error { get; }
        string ErrorText1 { get; }
        string ErrorText2 { get; }
        double[] Data { get; }
        void Test(double[] data);
        
    }
}
