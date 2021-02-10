namespace ProcessEngine.Framework.Interfaces
{
    public interface IIntermediateStep<D> : IStep
    {
        IToken<D> ExecuteStep(IToken<D> token);
    }
}
