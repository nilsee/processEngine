using ProcessEngine.Framework.Interfaces;
using ProcessEngine.Framework.Steps;
using System;

namespace ProcessEngine.Framework.Steps.Branching
{
    public class ForkStep<D> : StartStep<D>
    {

        protected ForkedSubProcess<D> _left;

        protected ForkedSubProcess<D> _right;

        public ForkStep() { }

        protected ForkStep(ForkedSubProcess<D> left, ForkedSubProcess<D> right, JoinStep<D> join)
        {
            _left = left;
            _left.StartStep = this;

            _right = right;

        }

        public static void Build<D>(ForkedSubProcess<D> left, ForkedSubProcess<D> right, JoinStep<D> join)
        {
             new ForkStep<D>(left, right, join);
        }


        protected override IToken<D> DoStep()
        {
            throw new NotImplementedException();
        }
    }
}
