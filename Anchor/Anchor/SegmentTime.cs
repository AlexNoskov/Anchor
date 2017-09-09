using System;
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
    }
}
