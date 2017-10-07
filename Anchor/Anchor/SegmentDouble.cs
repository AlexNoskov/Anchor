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

        protected override double GetActualSpan()
        {
            return _end - _start;
        }

        protected override bool IsValidSpan(double span)
        {
            return span >= 0.0;
        }

        public override ISegment<double, double> Clone()
        {
            return new SegmentDouble(this.Start, this.End);
        }

        protected override double ShiftLabelCycle(double label, double shift)
        {
            return label + shift;
        }

        protected override bool IsNegate(double span)
        {
            return span < 0.0;
        }

        protected override bool IsZero(double span)
        {
            return span == 0.0;
        }
    }
}
