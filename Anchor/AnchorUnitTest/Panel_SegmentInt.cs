using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    /// <summary>
    /// Панель тестирования интерфейса, представляющего отрезок целых чисел.
    /// </summary>
    
    public static class Panel_SegmentInt
    {
        static Panel_SegmentInt()
        {
            Label_1 = DataTest_Axis_Int.Label_1;
            Label_2 = DataTest_Axis_Int.Label_2;
            Label_3 = DataTest_Axis_Int.Label_3;
            Label_4 = DataTest_Axis_Int.Label_4;
        }

        public static Int32 Label_1
        { get; private set; }
        public static Int32 Label_2
        { get; private set; }
        public static Int32 Label_3
        { get; private set; }
        public static Int32 Label_4
        { get; private set; }
                
        public static void StartState(ISegment<Int32, Int32> segment)
        {
            Panel_InterfaceSegment<Int32, Int32>.StartState_Empty(segment);
        }
        
        public static void SetSegment_ReverseLabel(ISegment<Int32, Int32> segment)
        {
            Panel_InterfaceSegment<Int32, Int32>.SetSegment_ReverseLabel(segment, Label_2, Label_1);
        }
                
        public static void SetSegment(ISegment<Int32, Int32> segment)
        {
            Panel_InterfaceSegment<Int32, Int32>.SetSegment(segment, Label_1, Label_2);
        }
        public static void GetSpanAfterSetSegment(ISegment<Int32, Int32> segment)
        {
            Panel_InterfaceSegment<Int32, Int32>.GetSpanAfterSetSegment(segment, 1, 1, 1);
            Panel_InterfaceSegment<Int32, Int32>.GetSpanAfterSetSegment(segment, 2, 4, 3);
            Panel_InterfaceSegment<Int32, Int32>.GetSpanAfterSetSegment(segment, -1, -1, 1);
            Panel_InterfaceSegment<Int32, Int32>.GetSpanAfterSetSegment(segment,-4, -2, 3);
        }

        /*
        [TestMethod]
        public void SegmentInt_IsPoint()
        {
            SegmentInt segmentInt = new SegmentInt();
            Panel_InterfaceSegment<Int32, Int32>.IsPoint(segmentInt, _label_1, _label_2);
        }

        [TestMethod]
        public void SegmentInt_SetSpan_Empty()
        {
            SegmentInt segmentInt = new SegmentInt();
            Panel_InterfaceSegment<Int32, Int32>.SetSpan(segmentInt, 0, 0);
        }

        [TestMethod]
        public void SegmentInt_SetSpan_One()
        {
            SegmentInt segmentInt = new SegmentInt();
            Panel_InterfaceSegment<Int32, Int32>.SetSpan(segmentInt, _label_1, 0);
        }

        [TestMethod]
        public void SegmentInt_SetSpan_Max()
        {
            SegmentInt segmentInt = new SegmentInt();
            segmentInt.SetSegment(_label_1, _label_1);
            Panel_InterfaceSegment<Int32, Int32>.SetSpan(segmentInt, Int32.MaxValue, Int32.MaxValue);
        }

        [TestMethod]
        public void SegmentInt_SetSpan_EndMoreMax()
        {
            SegmentInt segmentInt = new SegmentInt();
            segmentInt.SetSegment(Int32.MaxValue, Int32.MaxValue);
            Panel_InterfaceSegment<Int32, Int32>.SetSpan(segmentInt, _label_2, Int32.MaxValue);
        }
        */
    }
}
