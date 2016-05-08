using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor.GettingData
{
    public abstract class EndPointSource<TEndPointId, TRequest, TResponse> : ISourceConnection<TEndPointId, TRequest, TResponse>
    {
        protected EndPointSource()
        {
            ConnectedPoint = null;
        }

        public EndPoint<TEndPointId, TRequest, TResponse> ConnectedPoint
        { get; private set; }
        public abstract Int32 EndPointCount
        { get; }

        public bool Connect(TEndPointId endPoint_Id)
        {
            EndPoint<TEndPointId, TRequest, TResponse> connected;
            if (TryConnect(endPoint_Id, out connected))
            {
                ConnectedPoint = connected;
                return true;
            }

            ConnectedPoint = null;
            return false;
        }

        public void Disconnect()
        {
            OnDisconnect();
            ConnectedPoint = null;
        }

        public TResponse Send(TRequest key)
        {
            if (ConnectedPoint != null)
            {
                return ConnectedPoint.GetValue(key);
            }
            return default(TResponse);
        }

        protected abstract Boolean TryConnect(TEndPointId endPoint_Id, out EndPoint<TEndPointId, TRequest, TResponse> connected);
        protected abstract void OnDisconnect();
    }
}
