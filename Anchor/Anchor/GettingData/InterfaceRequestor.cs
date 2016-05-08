using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor.GettingData
{
    /// <summary>
    /// Модель "запрос-ответ".
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface IRequestor<TRequest, TResponse>
    {
        TResponse Send(TRequest request);
    }
}
