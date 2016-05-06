using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor.GettingData
{
    public abstract class ProtocolEndPoint<TRequest, TResponse> : IEndPointProtocol<TResponse>
    {
        public IRequestor<TRequest, TResponse> Sender
        { get; set; }

        public TResponse GetCurrentValue()
        {
            if (Sender != null)
            {
                return Sender.Send(GetCurrentKey());
            }

            return default(TResponse);
        }

        public TResponse GetAmountValue()
        {
            if (Sender != null)
            {
                return Sender.Send(GetAmountKey());
            }

            return default(TResponse);
        }

        protected abstract TRequest GetCurrentKey();
        protected abstract TRequest GetAmountKey();
    }
}
