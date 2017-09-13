namespace ProjectEuler
{

    internal interface IProjectEulerProblem
    {
        void Solve();
    }

    internal interface IProjectEulerProblem<T> : IProjectEulerProblem
    {
        void ParseInput(T data);
    }

}