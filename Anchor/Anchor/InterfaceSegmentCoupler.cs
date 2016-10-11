using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public interface ISegmentCoupler<TLabel, TSpan>
        where TLabel : IComparable<TLabel>
    {
        TLabel StartCoupler { get; }
        TLabel EndCoupler { get; }

        void SetSpanCoupler(TSpan spanCoupler);
    }
}
