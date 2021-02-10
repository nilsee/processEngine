using ProcessEngine.Framework.Interfaces;
using System;

namespace ProcessEngine.Framework.Steps.Branching
{
    public class JoinStep<D> : EndStep<D>
    {
        protected override void DoStep(IToken<D> token)
        {
            throw new NotImplementedException();
        }
    }
}
