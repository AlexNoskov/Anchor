using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor
{
    public interface ISegment<TLabel, TSpan>
    {
        TLabel Start { get; }
        TLabel End { get; }
        TSpan Span { get; }        
        Boolean IsPoint { get; }

        void SetSegment(TLabel start, TLabel end);
        void SetSpan(TSpan span);
    }
}
