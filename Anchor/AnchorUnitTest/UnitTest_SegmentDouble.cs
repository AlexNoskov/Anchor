using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    [TestClass]
    public class UnitTest_SegmentDouble
    {
        private SegmentDouble segmentDouble;

        [TestInitialize]
        public void Init()
        {
            segmentDouble = new SegmentDouble();
        }

        [TestMethod]
        public void SegmentDouble_StartState()
        {
            Panel_SegmentDouble.StartState_Empty(segmentDouble);               
        }

        [TestMethod]
        public void SegmentDouble_StartState_Direct()
        {
            SegmentDouble segmentDirect = new SegmentDouble(
                Panel_SegmentDouble.Label_1, Panel_SegmentDouble.Label_2);
            Panel_InterfaceSegment<Double, Double>.AssertState(segmentDirect, Panel_SegmentDouble.Label_1, Panel_SegmentDouble.Label_2);            
        }

        [TestMethod]
        public void SegmentDouble_StartState_Reverse()
        {
            SegmentDouble segmentDirect = new SegmentDouble(
                Panel_SegmentDouble.Label_2, Panel_SegmentDouble.Label_1);
            Panel_InterfaceSegment<Double, Double>.AssertState(segmentDirect, Panel_SegmentDouble.Label_2, Panel_SegmentDouble.Label_2);
        }

        [TestMethod]
        public void SegmentDouble_SetReverseLabel()
        {
            Panel_SegmentDouble.SetReverseLabel(segmentDouble);
        }

        [TestMethod]
        public void SegmentDouble_SetSegment()
        {
            Panel_SegmentDouble.SetSegment(segmentDouble);
        }

        [TestMethod]
        public void SegmentDouble_IsPoint()
        {
            Panel_SegmentDouble.IsPoint(segmentDouble);
        }

        [TestMethod]
        public void SegmentDouble_SetSpan()
        {
            Panel_SegmentDouble.SetSpan(segmentDouble);
        }

        [TestMethod]
        public void SegmentDouble_SetSpan_Max()
        {
            Panel_SegmentDouble.SetSpan_Max(segmentDouble);
        }

        [TestMethod]
        public void SegmentDouble_SetSpan_EndMoreMax()
        {
            Panel_SegmentDouble.SetSpan_EndMoreMax(segmentDouble);
        }

        [TestMethod]
        public void SegmentDouble_Shift()
        {
            SegmentDouble segmentMax = new SegmentDouble(double.MinValue, double.MaxValue);
            Panel_InterfaceSegment<double, double>.ShiftMax(segmentMax, 1.0);
            Panel_InterfaceSegment<double, double>.ShiftMax(segmentMax, -1.0);

            SegmentDouble segmentLeftMin = new SegmentDouble(double.MinValue, double.MaxValue - 1.0);
            SegmentDouble segmentRightMax = new SegmentDouble(double.MinValue + 1.0, double.MaxValue);
            Panel_InterfaceSegment<double, double>.Shift(segmentLeftMin, 1.0, segmentRightMax);
            Panel_InterfaceSegment<double, double>.Shift(segmentRightMax, -2.0, segmentLeftMin);

        }
    }
}
