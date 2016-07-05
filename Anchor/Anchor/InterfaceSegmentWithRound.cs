using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public interface ISegmentWithRound<TLabel, TSpan>
        where TLabel : IComparable<TLabel>
    {
        IRounder<TLabel> Rounder { get; set; }

        TLabel StartRoundValue { get; }
        TLabel EndRoundValue { get; }
    }
}
