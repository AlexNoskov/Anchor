using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor.GettingData
{
    public interface IEndPointProtocol<TValue>
    {
        TValue GetCurrentValue();
        TValue GetAmountValue();
    }
}
