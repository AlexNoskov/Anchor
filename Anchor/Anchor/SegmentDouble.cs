using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public class SegmentDouble : Segment<Double, Double>
    {
        protected override double GetEndAtSpan(double span)
        {
            return Start + span;
        }

        protected override bool IsValidSpan(double span)
        {
            return span >= 0.0;
        }
    }
}
