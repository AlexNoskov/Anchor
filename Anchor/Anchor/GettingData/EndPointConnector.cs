using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor.GettingData
{
    public abstract class ConnectorEndPoint<TEndPointId, TRequest, TResponse> : IConnector<TEndPointId>, IEndPointProtocol<TResponse>
    {
        protected ConnectorEndPoint(SourceEndPoint<TEndPointId, TRequest, TResponse> source, ProtocolEndPoint<TRequest, TResponse> protocol)
        {
            _source = source;
            _protocol = protocol;
            _protocol.Sender = _source;
        }

        private SourceEndPoint<TEndPointId, TRequest, TResponse> _source;
        private ProtocolEndPoint<TRequest, TResponse> _protocol;

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
