using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    [TestClass]
    public class UT_Segment_Equatable
    {
        [TestMethod]
        public void Segment_Equatable_null()
        {
            SegmentInt segment = new SegmentInt(DataTest_Axis_Int.Label_1, DataTest_Axis_Int.Label_2);
            Panel_Equals.Check_null(segment);
        }

        [TestMethod]
        public void Segment_Equatable_Himself()
        {
            SegmentInt segment = new SegmentInt(DataTest_Axis_Int.Label_1, DataTest_Axis_Int.Label_2);
            Panel_Equals.Himself(segment);            
        }

        [TestMethod]
        public void Segment_Equatable_Similar()
        {
            SegmentInt segment = new SegmentInt(DataTest_Axis_Int.Label_1, DataTest_Axis_Int.Label_2);
            SegmentInt similar = new SegmentInt(DataTest_Axis_Int.Label_1, DataTest_Axis_Int.Label_2);
            Panel_Equals.Similar(segment, similar);
        }

        [TestMethod]
        public void Segment_Equatable_Another()
        {
            SegmentInt segment = new SegmentInt(DataTest_Axis_Int.Label_1, DataTest_Axis_Int.Label_2);
            SegmentInt similar = new SegmentInt(DataTest_Axis_Int.Label_1, DataTest_Axis_Int.Label_3);
            Panel_Equals.Another(segment, similar);
        }
    }
}
