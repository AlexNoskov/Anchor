using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public class SegmentTime : Segment<DateTime, TimeSpan>
    {
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
