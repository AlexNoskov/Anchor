using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    /// <summary>
    /// Панель тестирования интерфейса, представляющего отрезок вещественных чисел.
    /// </summary>    
    public class Panel_SegmentDouble
    {
        static Panel_SegmentDouble()
        {
            _label_1 = 0.1;
            _label_2 = 0.7;
        }

        public static Double Label_1
        {
            get { return _label_1; }
        }
        public static Double Label_2
        {
            get { return _label_2; }
        }

        private static Double _label_1;
        private static Double _label_2;
        
        
        
        public static void StartState_Empty(ISegment<Double, Double> segmentDouble)
        {
            Panel_InterfaceSegment<Double, Double>.StartState_Empty(segmentDouble);
        }
        
        public static void SetReverseLabel(ISegment<Double, Double> segmentDouble)
        {
            Panel_InterfaceSegment<Double, Double>.SetSegment_ReverseLabel(segmentDouble, _label_2, _label_1);
        }
        
        public static void SetSegment(ISegment<Double, Double> segmentDouble)
        {
            Panel_InterfaceSegment<Double, Double>.SetSegment(segmentDouble, _label_1, _label_2);
        }
        
        public static void IsPoint(ISegment<Double, Double> segmentDouble)
        {
            Panel_InterfaceSegment<Double, Double>.IsPoint(segmentDouble, _label_1, _label_2);
        }
        
        public static void SetSpan(ISegment<Double, Double> segmentDouble)
        {
            Panel_InterfaceSegment<Double, Double>.SetSpan(segmentDouble, _label_1, _label_1);
        }
        
        public static void SetSpan_Max(ISegment<Double, Double> segmentDouble)
        {
            segmentDouble.SetSegment(_label_1, _label_1);
            Panel_InterfaceSegment<Double, Double>.SetSpan(segmentDouble, Double.MaxValue, Double.MaxValue);
        }
        
        public static void SetSpan_EndMoreMax(ISegment<Double, Double> segmentDouble)
        {
            segmentDouble.SetSegment(Double.MaxValue, Double.MaxValue);
            Panel_InterfaceSegment<Double, Double>.SetSpan(segmentDouble, _label_1, Double.MaxValue);
        }
    }
}
