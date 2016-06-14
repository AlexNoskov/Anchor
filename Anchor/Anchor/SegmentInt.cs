using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public class SegmentInt : Segment<Int32, Int32>
    {
        protected override int GetEndAtSpan(int span)
        {
            return Start + span - 1;
        }

        protected override bool IsValidSpan(int span)
        {
            return span >= 0;
        }
    }
}
