using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor
{
    /// <summary>
    /// Интрефейс сервиса, определяющего округленное ("грубое") значение. 
    /// </summary>
    /// <typeparam name="T">Тип округления.</typeparam>
    public interface IRounder<T>
    {
        T Round(T value);
    }
}
