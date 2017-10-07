using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public class SegmentInt : Segment<Int32, Int32>
    {
        public SegmentInt(Int32 start, Int32 end)
            : base(start, end)
        { }
        public SegmentInt()
            : base()
        { }

        protected override int GetEndAtSpan(int span)
        {
            return Start + span - 1;
        }

        protected override int GetActualSpan()
        {
            return _end - _start + 1;
        }

        protected override bool IsValidSpan(int span)
        {
            return span >= 0;
        }

        public override ISegment<int, int> Clone()
        {
            return new SegmentInt(this.Start, this.End);
        }

        protected override int ShiftLabelCycle(int label, int shift)
        {
            return label + shift;
        }

        protected override bool IsNegate(int span)
        {
            return span < 0;
        }

        protected override bool IsZero(int span)
        {
            return span == 0;
        }

        //public override void Shift(int shift)
        //{
        //    int nextStart = Start + shift;
        //    int nextEnd = End + shift;

        //    if (shift > 0)
        //    {
        //        if (nextStart >= Start)
        //        {
        //            if (nextEnd >= End)
        //            { this.SetSegment(nextStart, nextEnd); }
        //        }                
        //    }
        //    if (shift < 0)
        //    {                
        //        if (nextStart <= Start)
        //        {
        //            if (nextEnd <= End)
        //            { this.SetSegment(nextStart, nextEnd); }
        //        }
        //    }            
        //}

    }
}
