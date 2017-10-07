using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    [TestClass]
    public class UnitTest_SegmentTime
    {
        private DateTime _label_1;
        private DateTime _label_2;
        private TimeSpan _spanTickNegate;
        private TimeSpan _spanTick;

        [TestInitialize]
        public void Init()
        {
            _label_1 = DataTest_Axis_Time.Label_1;
            _label_2 = DataTest_Axis_Time.Label_2;
            _spanTick = DataTest_Axis_Time.Span_Tick;
            _spanTickNegate = DataTest_Axis_Time.Span_TickNegate;
        }

        [TestMethod]
        public void SegmentTime_StartState()
        {
            SegmentTime segmentTime = new SegmentTime();
            Panel_InterfaceSegment<DateTime, TimeSpan>.StartState_Empty(segmentTime);
        }

        [TestMethod]
        public void SegmentTime_SetReverseLabel()
        {
            SegmentTime segmentInt = new SegmentTime();
            Panel_InterfaceSegment<DateTime, TimeSpan>.SetSegment_ReverseLabel(segmentInt, _label_2, _label_1);
        }

        [TestMethod]
        public void SegmentTime_SetSegment()
        {
            SegmentTime segment = new SegmentTime();
            Panel_InterfaceSegment<DateTime, TimeSpan>.SetSegment(segment, _label_1, _label_2);
        }

        [TestMethod]
        public void SegmentTime_GetSpanAfterSetSegment()
        {
            SegmentTime segment = new SegmentTime();
            Panel_InterfaceSegment<DateTime, TimeSpan>.GetSpanAfterSetSegment(segment, _label_1, _label_1, TimeSpan.Zero);
            DateTime startDay = new DateTime(2016, 1, 1);
            DateTime startNextDay = new DateTime(2016, 1, 2);
            TimeSpan spanDay = new TimeSpan(1, 0, 0, 0);
            Panel_InterfaceSegment<DateTime, TimeSpan>.GetSpanAfterSetSegment(segment, startDay, startNextDay, spanDay);
        }

        [TestMethod]
        public void SegmentTime_IsPoint()
        {
            SegmentTime segmentInt = new SegmentTime();
            Panel_InterfaceSegment<DateTime, TimeSpan>.IsPoint(segmentInt, _label_1, _label_2);
        }

        [TestMethod]
        public void SegmentTime_SetSpan_Negate()
        {
            SegmentTime segmentTime = new SegmentTime();
            segmentTime.SetSegment(_label_1, _label_2);
            Panel_InterfaceSegment<DateTime, TimeSpan>.SetSpan(segmentTime, _spanTickNegate, _label_2);
        }

        [TestMethod]
        public void SegmentTime_SetSpan_Max()
        {
            _label_1 = DateTime.MaxValue - _spanTick;
            SegmentTime segmentTime = new  SegmentTime();
            segmentTime.SetSegment(_label_1, _label_1);
            Panel_InterfaceSegment<DateTime, TimeSpan>.SetSpan(segmentTime, _spanTick, DateTime.MaxValue);
        }

        [TestMethod]
        public void SegmentTime_SetSpan_EndMoreMax()
        {
            SegmentTime segmentTime = new SegmentTime();
            segmentTime.SetSegment(DateTime.MaxValue, DateTime.MaxValue);
            Panel_InterfaceSegment<DateTime, TimeSpan>.SetSpan(segmentTime, TimeSpan.MaxValue, DateTime.MaxValue);
        }

        [TestMethod]
        public void SegmentTime_CreateMonth()
        {
            SegmentTime january2017 = SegmentTime.CreateMonth(2017, 1);
            Assert.IsTrue(january2017.Start == new DateTime(2017, 1, 1));
            Assert.IsTrue(january2017.End == new DateTime(2017, 2, 1));

            SegmentTime february2017 = SegmentTime.CreateMonth(2017, 2);
            Assert.IsTrue(february2017.Start == new DateTime(2017, 2, 1));
            Assert.IsTrue(february2017.End == new DateTime(2017, 3, 1));

            SegmentTime february2016 = SegmentTime.CreateMonth(2016, 2);
            Assert.IsTrue(february2016.Start == new DateTime(2016, 2, 1));
            Assert.IsTrue(february2016.End == new DateTime(2016, 3, 1));

            SegmentTime june2017 = SegmentTime.CreateMonth(2017, 6);
            Assert.IsTrue(june2017.Start == new DateTime(2017, 6, 1));
            Assert.IsTrue(june2017.End == new DateTime(2017, 7, 1));
        }

        [TestMethod]
        public void SegmentTime_CreateMax()
        {
            SegmentTime sg = SegmentTime.CreateMax();
            Assert.IsTrue(sg.Start == DateTime.MinValue);
            Assert.IsTrue(sg.End == DateTime.MaxValue);
        }

        [TestMethod]
        public void SegmentTime_Shift()
        {
            TimeSpan one = new TimeSpan(1);
            TimeSpan two = new TimeSpan(2);
            SegmentTime segmentMax = new SegmentTime(DateTime.MinValue, DateTime.MaxValue);
            Panel_InterfaceSegment<DateTime, TimeSpan>.ShiftMax(segmentMax, one);
            Panel_InterfaceSegment<DateTime, TimeSpan>.ShiftMax(segmentMax, one.Negate());

            SegmentTime segmentLeftMin = new SegmentTime(DateTime.MinValue, DateTime.MaxValue - one);
            SegmentTime segmentRightMax = new SegmentTime(DateTime.MinValue + one, DateTime.MaxValue);
            Panel_InterfaceSegment<DateTime, TimeSpan>.Shift(segmentLeftMin, one, segmentRightMax);
            Panel_InterfaceSegment<DateTime, TimeSpan>.Shift(segmentRightMax, two.Negate(), segmentLeftMin);
        }
    }
}
