using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor
{/// <summary>
/// Интерфейс сервиса, определяющего факт пересечения.
/// </summary>
/// <typeparam name="TLabel">Тип меток.</typeparam>
/// <typeparam name="TSpan">Тип длительности.</typeparam>
    public interface IIntersected<TLabel, TSpan>
        where TLabel : IComparable<TLabel>
    {
        /// <summary>
        /// Метод, определяющий факт принадлежности метки.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        Boolean IsIntersected(TLabel label);
        /// <summary>
        /// Метод, определяющий факт пересечения с отрезком.
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        Boolean IsIntersected(ISegment<TLabel, TSpan> segment);
        /// <summary>
        /// Метод, определяющий факт принадлежности к отрезку.
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        Boolean IsPartOf(ISegment<TLabel, TSpan> segment);
    }
}
