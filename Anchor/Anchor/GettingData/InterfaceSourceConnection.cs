using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor.GettingData
{/// <summary>
/// Интерфейс контейнера конечных точек.
/// </summary>
/// <typeparam name="TEndPointId"></typeparam>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
    public interface ISourceConnection<TEndPointId, TRequest, TResponse> 
        : IConnector<TEndPointId>, IRequestor<TRequest, TResponse>
    { }
}
