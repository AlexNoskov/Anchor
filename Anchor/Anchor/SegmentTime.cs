﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public class SegmentTime : Segment<DateTime, TimeSpan>
    {
        public SegmentTime(DateTime start, DateTime end)
            : base(start, end)
        { }
        public SegmentTime()
            : base()
        { }

        public static SegmentTime CreateMax()
        {            
            return new SegmentTime(DateTime.MinValue, DateTime.MaxValue);
        }

        public static SegmentTime CreateMonth(int year, int month)
        {
            DateTime start = new DateTime(year, month, 1);
            DateTime end = start.AddMonths(1);
            
            return new SegmentTime(start, end);
        }

        protected override DateTime GetEndAtSpan(TimeSpan span)
        {
            if (span <= (DateTime.MaxValue - DateTime.MinValue))
            {
                DateTime maxStart = DateTime.MaxValue - span;
                if (Start <= maxStart)
                {
                    return Start.Add(span);
                }
            }

            return DateTime.MaxValue;
        }

        protected override bool IsValidSpan(TimeSpan span)
        {
            return span >= TimeSpan.Zero;            
        }

        public override ISegment<DateTime, TimeSpan> Clone()
        {
            return new SegmentTime(this.Start, this.End);
        }
               
        protected override DateTime ShiftLabelCycle(DateTime label, TimeSpan shift)
        {
            if (IsZero(shift))
                return label;

            if (IsNegate(shift))
            {
                DateTime l = DateTime.MinValue + shift.Negate();
                if (l > label)
                {
                    return DateTime.MaxValue - (l - label);
                }
            }
            if (!IsNegate(shift))
            {
                DateTime l = DateTime.MaxValue + shift.Negate();
                if (l < label)
                {
                    return DateTime.MinValue + (label - l);
                }
            }

            return label + shift;
        }

        protected override bool IsNegate(TimeSpan span)
        {
            return span < TimeSpan.Zero;
        }

        protected override bool IsZero(TimeSpan span)
        {
            return span == TimeSpan.Zero;
        }
    }
}
