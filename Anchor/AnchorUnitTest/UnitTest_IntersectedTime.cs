using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    [TestClass]
    public class UnitTest_IntersectedTime
    {
        private DateTime _label_1;
        private DateTime _label_2;
        private DateTime _label_3;
        private DateTime _label_4;

        [TestInitialize]
        public void Init()
        {
            _label_1 = DataTest_Axis_Time.Label_1;
            _label_2 = DataTest_Axis_Time.Label_2;
            _label_3 = DataTest_Axis_Time.Label_3;
            _label_4 = DataTest_Axis_Time.Label_4;
        }

        [TestMethod]
        public void IntersectedTime_LabelOut()
        {
            SegmentTime segment = new SegmentTime(_label_2, _label_3);
            Panel_InterfaceIntersected<DateTime, TimeSpan>.LabelOut(segment, _label_1);
            Panel_InterfaceIntersected<DateTime, TimeSpan>.LabelOut(segment, _label_4);
        }

        [TestMethod]
        public void IntersectedTime_LabelOn()
        {
            SegmentTime segment = new SegmentTime(_label_2, _label_3);
            Panel_InterfaceIntersected<DateTime, TimeSpan>.LabelOn(segment, _label_2);
            Panel_InterfaceIntersected<DateTime, TimeSpan>.LabelOn(segment, _label_3);
        }

        [TestMethod]
        public void IntersectedTime_SegmentNull()
        {
            SegmentTime segment = new SegmentTime(_label_1, _label_2);
            Panel_InterfaceIntersected<DateTime, TimeSpan>.SegmentNull_Intersected_PartOf(segment);
        }

        [TestMethod]
        public void IntersectedTime_SegmentOut()
        {
            SegmentTime segmentLeft = new SegmentTime(_label_1, _label_2);
            SegmentTime segmentRight = new SegmentTime(_label_3, _label_4);

            Panel_InterfaceIntersected<DateTime, TimeSpan>.SegmentOut(segmentLeft, segmentRight);
            Panel_InterfaceIntersected<DateTime, TimeSpan>.SegmentOut(segmentRight, segmentLeft);
        }

        [TestMethod]
        public void IntersecteTimet_SegmentIn()
        {
            SegmentTime segmentLeft = new SegmentTime(_label_1, _label_3);
            SegmentTime segmentRight = new SegmentTime(_label_2, _label_4);

            Panel_InterfaceIntersected<DateTime, TimeSpan>.SegmentIn(segmentLeft, segmentRight);
            Panel_InterfaceIntersected<DateTime, TimeSpan>.SegmentIn(segmentRight, segmentLeft);
        }

        [TestMethod]
        public void IntersectedTime_PartOf()
        {
            SegmentTime segment = new SegmentTime(_label_2, _label_3);
            SegmentTime segmentClone = new SegmentTime(_label_2, _label_3);

            Panel_InterfaceIntersected<DateTime, TimeSpan>.PartOf(segment, segmentClone);
        }

        [TestMethod]
        public void IntersectedTime_NotPartOf()
        {
            SegmentTime segmentLeft = new SegmentTime(_label_1, _label_3);
            SegmentTime segmentRight = new SegmentTime(_label_2, _label_4);

            Panel_InterfaceIntersected<DateTime, TimeSpan>.NotPartOf(segmentLeft, segmentRight);
            Panel_InterfaceIntersected<DateTime, TimeSpan>.NotPartOf(segmentRight, segmentLeft);
        }
    }
}
