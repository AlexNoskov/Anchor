using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor.GettingData
{
    public interface IConnector<TEndPointId>
    {
        Boolean Connect(TEndPointId endPoint_Id);
        void Disconnect();
    }
}
