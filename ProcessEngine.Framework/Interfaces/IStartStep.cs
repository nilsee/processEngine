namespace ProcessEngine.Framework.Interfaces
{
    public interface IStartStep<D> : IStep
    {
        IToken<D> ExecuteStep();
    }
}
