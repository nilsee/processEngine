using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessEngine.Test.Mocks
{
    public class ConcreteTestProcess : Framework.Process<TestData>
    {
        public override void RetryOrSuspend()
        {
            throw new NotImplementedException();
        }

        public override void Setup()
        {
            throw new NotImplementedException();
        }
    }
}
