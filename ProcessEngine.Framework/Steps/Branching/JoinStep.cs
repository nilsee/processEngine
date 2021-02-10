using ProcessEngine.Framework.Interfaces;
using ProcessEngine.Framework.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniProc.Framework.Steps.Branching
{
    public class JoinStep<D> : EndStep<D>
    {
        protected override void DoStep(IToken<D> token)
        {
            throw new NotImplementedException();
        }
    }
}
