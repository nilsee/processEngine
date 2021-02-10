using ProcessEngine.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniProc.Framework.Steps.Branching
{
    public abstract class ForkedSubProcess<D> : Process<D>
    {
        public new ForkStep<D> StartStep { get; set; }

        public new JoinStep<D> EndStep { get; set; }


    }
}
