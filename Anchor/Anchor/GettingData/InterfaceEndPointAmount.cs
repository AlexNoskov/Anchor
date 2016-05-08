using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor.GettingData
{
    /// <summary>
    /// Конечный источник данных, имеющий значения: текущее, мгновенное; накопительное, итоговое.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public interface IEndPointAmount<TValue>
    {
        TValue GetCurrentValue();
        TValue GetAmountValue();
    }
}
