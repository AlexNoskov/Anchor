using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public class SegmentRoundDouble : SegmentWithRound<Double, Double>
    {
        public SegmentRoundDouble(ISegment<double, double> segment, IRounder<double> rounder) : base(segment, rounder)
        {
        }
    }
}
