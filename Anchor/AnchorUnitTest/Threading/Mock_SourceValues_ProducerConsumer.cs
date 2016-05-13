using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorUnitTest.Threading
{
    public class Mock_SourceValues_ProducerConsumer
    {
        public const Int32 DelayFail = DelayWait * 4;
        public const Int32 DelayWait = 100;
        public const Int32 DelayWaitDouble = DelayWait * 2;

        public const Int32 BufferCapacity = 2;
        public const Int32 ExcessCapacity = 2;
        public const Int32 OverCapacity = BufferCapacity + ExcessCapacity;
    }
}
