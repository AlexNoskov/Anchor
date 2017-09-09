using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    [TestClass]
    public class UnitTest_SegmentInt
    {
        private Int32 _label_1;
        private Int32 _label_2;
        private Int32 _label_3;
        private Int32 _label_4;

        [TestInitialize]
        public void Init()
        {
            _label_1 = DataTest_Axis_Int.Label_1;
            _label_2 = DataTest_Axis_Int.Label_2;
            _label_3 = DataTest_Axis_Int.Label_3;
            _label_4 = DataTest_Axis_Int.Label_4;
        }

        [TestMethod]
        public void SegmentInt_StartState()
        {
            SegmentInt segmentInt = new SegmentInt();
            Panel_SegmentInt.StartState(segmentInt);
        }

        [TestMethod]
        public void SegmentInt_StartState_Direct()
        {
            SegmentInt segmentInt = new SegmentInt(Panel_SegmentInt.Label_1, Panel_SegmentInt.Label_2);
            Panel_InterfaceSegment<Int32, Int32>.AssertState(segmentInt, Panel_SegmentInt.Label_1, Panel_SegmentInt.Label_2);
        }

        [TestMethod]
        public void SegmentInt_StartState_Reverse()
        {
            SegmentInt segmentInt = new SegmentInt(Panel_SegmentInt.Label_2, Panel_SegmentInt.Label_1);
            Panel_InterfaceSegment<Int32, Int32>.AssertState(segmentInt, Panel_SegmentInt.Label_2, Panel_SegmentInt.Label_2);
        }

        [TestMethod]
        public void SegmentInt_SetReverseLabel()
        {         
            SegmentInt segmentInt = new SegmentInt();
            Panel_SegmentInt.SetSegment_ReverseLabel(segmentInt);            
        }

        [TestMethod]
        public void SegmentInt_SetSegment()
        {
            SegmentInt segmentInt = new SegmentInt();
            Panel_SegmentInt.SetSegment(segmentInt);            
        }

        [TestMethod]
        public void SegmentInt_IsPoint()
        {
            SegmentInt segmentInt = new SegmentInt();
            Panel_InterfaceSegment<Int32, Int32>.IsPoint(segmentInt, _label_1, _label_2);
        }

        [TestMethod]
        public void SegmentInt_SetSpan_Empty()
        {
            SegmentInt segmentInt = new SegmentInt(_label_1, _label_2);
            Panel_InterfaceSegment<Int32, Int32>.SetSpan(segmentInt, _label_1, _label_1);
        }

        [TestMethod]
        public void SegmentInt_SetSpan_One()
        {
            SegmentInt segmentInt = new SegmentInt(_label_1, _label_2);
            Panel_InterfaceSegment<Int32, Int32>.SetSpan(segmentInt, _label_1, _label_1);
        }

        [TestMethod]
        public void SegmentInt_SetSpan_Max()
        {
            SegmentInt segmentInt = new SegmentInt(_label_1, _label_1);
            Panel_InterfaceSegment<Int32, Int32>.SetSpan(segmentInt, Int32.MaxValue, Int32.MaxValue);
        }

        [TestMethod]
        public void SegmentInt_SetSpan_EndMoreMax()
        {
            SegmentInt segmentInt = new SegmentInt(Int32.MaxValue, Int32.MaxValue);
            Panel_InterfaceSegment<Int32, Int32>.SetSpan(segmentInt, _label_2, Int32.MaxValue);
        }

        [TestMethod]
        public void SegmentInt_Shift()
        {
            SegmentInt segmentMax = new SegmentInt(Int32.MinValue, Int32.MaxValue);
            Panel_InterfaceSegment<Int32, Int32>.ShiftMax(segmentMax, 1);
            Panel_InterfaceSegment<Int32, Int32>.ShiftMax(segmentMax, -1);

            SegmentInt segmentLeftMin = new SegmentInt(Int32.MinValue, Int32.MaxValue-1);
            SegmentInt segmentRightMax = new SegmentInt(Int32.MinValue+1, Int32.MaxValue);
            Panel_InterfaceSegment<Int32, Int32>.Shift(segmentLeftMin, 1, segmentRightMax);
            Panel_InterfaceSegment<Int32, Int32>.Shift(segmentRightMax, -2, segmentLeftMin);
        }
    }
}
