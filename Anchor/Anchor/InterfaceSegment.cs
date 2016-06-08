using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor
{
    /// <summary>
    /// Интерфейс, описывающий отрезок.
    /// </summary>
    /// <typeparam name="TLabel">Тип меток.</typeparam>
    /// <typeparam name="TSpan">Тип длительности.</typeparam>
    public interface ISegment<TLabel, TSpan>
        where TLabel : IComparable<TLabel>
    {
        /// <summary>
        /// Начальная метка.
        /// </summary>
        TLabel Start { get; }
        /// <summary>
        /// Конечная метка.
        /// </summary>
        TLabel End { get; }
        /// <summary>
        /// Длительность.
        /// </summary>
        TSpan Span { get; }        
        /// <summary>
        /// Свойство, определяющее равенство начальной и конечной меток.
        /// </summary>
        Boolean IsPoint { get; }

        /// <summary>
        /// Метод, гарантирующий что после устанавки меток начало будет меньше или равно окончанию. 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        void SetSegment(TLabel start, TLabel end);
        /// <summary>
        /// Метод, устанавливающий длительность изменением окончания.
        /// </summary>
        /// <param name="span"></param>
        void SetSpan(TSpan span);
    }
}
