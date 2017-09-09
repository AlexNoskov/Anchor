using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public class SegmentDouble : Segment<Double, Double>
    {
        public SegmentDouble(Double start, Double end)
            : base(start, end)
        { }

        public SegmentDouble()
            : base()
        { }

        protected override double GetEndAtSpan(double span)
        {
            return Start + span;
        }

        protected override bool IsValidSpan(double span)
        {
            return span >= 0.0;
        }

        public override ISegment<double, double> Clone()
        {
            return new SegmentDouble(this.Start, this.End);
        }
    }
}
