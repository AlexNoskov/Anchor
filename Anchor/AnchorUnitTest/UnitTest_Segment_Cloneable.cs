using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    [TestClass]
    public class UnitTest_Segment_Cloneable
    {
        [TestMethod]
        public void SegmentInt_Cloneable()
        {
            SegmentInt segment = new SegmentInt(1, 2);
            Panel_Cloneable.Clone(segment);
        }

        [TestMethod]
        public void SegmentDouble_Cloneable()
        {
            SegmentDouble segment = new SegmentDouble(17.0, 21.0);
            Panel_Cloneable.Clone(segment);
        }

        [TestMethod]
        public void SegmentTime_Cloneable()
        {
            DateTime now = DateTime.Now;
            SegmentTime segment = new SegmentTime(now, now.AddDays(3.1));
            Panel_Cloneable.Clone(segment);
        }
    }
}
