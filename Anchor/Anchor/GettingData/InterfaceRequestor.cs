using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor.GettingData
{
    public interface IRequestor<TRequest, TResponse>
    {
        TResponse Send(TRequest request);
    }
}
