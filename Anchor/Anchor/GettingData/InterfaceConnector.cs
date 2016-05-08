using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor.GettingData
{
    /// <summary>
    /// Интерфейс управления подключением.
    /// </summary>
    /// <typeparam name="TEndPointId">Уникальный идентификатор конечного источника данных, к которому осуществляется подключение.</typeparam>
    public interface IConnector<TEndPointId>
    {
        Boolean Connect(TEndPointId endPoint_Id);
        void Disconnect();
    }
}
