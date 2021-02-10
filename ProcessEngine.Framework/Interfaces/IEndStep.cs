namespace ProcessEngine.Framework.Interfaces
{
    public interface IEndStep<D> : IStep
    {
        void ExecuteStep(IToken<D> token);

        IToken<D> FinalToken
        {
            get;
        }
    }
}
