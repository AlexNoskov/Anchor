﻿using System;
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
            SegmentTime segmentInt = new SegmentTime();
            Panel_InterfaceSegment<DateTime, TimeSpan>.SetSegment(segmentInt, _label_1, _label_2);
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
    }
}