using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorUnitTest
{
    public static class DataTest_Axis_Int
    {
        public static readonly Int32 Label_1 = 1;
        public static readonly Int32 Label_2 = 2;
        public static readonly Int32 Label_3 = 3;
        public static readonly Int32 Label_4 = 4;
    }

    public static class DataTest_Axis_Double
    {
        public static readonly Double Range_ZeroToOne_1 = 0.1;
        public static readonly Double Range_ZeroToOne_2 = 0.7;
        public static readonly Double ThreeAfterPoint_Less = 0.494;
        public static readonly Double ThreeAfterPoint_Middle = 0.495;
        public static readonly Double ThreeAfterPoint_TwiceLess = 2 * ThreeAfterPoint_Less;
        public static readonly Double ThreeAfterPoint_LessMiddle = ThreeAfterPoint_Less + ThreeAfterPoint_Middle;
        public static readonly Double ThreeAfterPoint_TwiceMiddle = 2 * ThreeAfterPoint_Middle;
    }

    public static class DataTest_Axis_Time
    {
        public static readonly DateTime Label_1 = new DateTime(2016, 1, 1);
        public static readonly DateTime Label_2 = new DateTime(2016, 1, 2);
        public static readonly DateTime Label_3 = new DateTime(2016, 1, 3);
        public static readonly DateTime Label_4 = new DateTime(2016, 1, 4);
        public static readonly TimeSpan Span_Tick = new TimeSpan(1);
        public static readonly TimeSpan Span_TickNegate = Span_Tick.Negate();
    }
}
