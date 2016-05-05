using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor
{
    public interface IIntersected<TLabel, TSpan>
    {
        Boolean IsIntersected(TLabel label);
        Boolean IsIntersected(ISegment<TLabel, TSpan> segment);
        Boolean IsPartOf(ISegment<TLabel, TSpan> segment);
    }
}
