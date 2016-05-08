using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor.GettingData
{
    public abstract class EndPointAmountConnector<TEndPointId, TRequest, TResponse> : IConnector<TEndPointId>, IEndPointAmount<TResponse>
    {
        protected EndPointAmountConnector(EndPointSource<TEndPointId, TRequest, TResponse> source, EndPointAmount<TRequest, TResponse> protocol)
        {
            _source = source;
            _protocol = protocol;
            _protocol.Sender = _source;
        }

        private EndPointSource<TEndPointId, TRequest, TResponse> _source;
        private EndPointAmount<TRequest, TResponse> _protocol;

        public bool Connect(TEndPointId endPoint_Id)
        {
            return _source.Connect(endPoint_Id);
        }

        public void Disconnect()
        {
            _source.Disconnect();
        }

        public TResponse GetCurrentValue()
        {
            return _protocol.GetCurrentValue();
        }
        public TResponse GetAmountValue()
        {
            return _protocol.GetAmountValue();
        }
    }
}
