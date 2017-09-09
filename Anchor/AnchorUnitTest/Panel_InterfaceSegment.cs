using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    /// <summary>
    /// Панель тестирования интерфейса, представляющего отрезок.
    /// </summary>
    public class Panel_InterfaceSegment<TLabel, TSpan>
        where TLabel : IComparable<TLabel>
    {       
        public static void StartState_Empty (ISegment<TLabel, TSpan> segment)
        {
            Panel_DefaultValue<TLabel>.IsDefault(segment.Start);
            Panel_DefaultValue<TLabel>.IsDefault(segment.End);
            Assert.IsTrue(segment.IsPoint);
        }
        
        public static void SetSegment_ReverseLabel(ISegment<TLabel, TSpan> segment, TLabel startMoreEnd, TLabel endLowerStart)
        {
            Assert.IsTrue(startMoreEnd.CompareTo(endLowerStart) == 1);
            segment.SetSegment(startMoreEnd, endLowerStart);            
            /*
            Assert.IsTrue(segment.Start.Equals(startMoreEnd));
            Assert.IsTrue(segment.End.Equals(startMoreEnd));
            */
            AssertState(segment, startMoreEnd, startMoreEnd);
        }

        public static void SetSegment(ISegment<TLabel, TSpan> segment, TLabel start, TLabel end)
        {
            Assert.IsTrue(start.CompareTo(end) == -1);
            segment.SetSegment(start, end);
            /*
            Assert.IsTrue(segment.Start.Equals(start));
            Assert.IsTrue(segment.End.Equals(end));
            */
            AssertState(segment, start, end);
        }

        public static void IsPoint(ISegment<TLabel, TSpan> segment, TLabel start, TLabel end)
        {
            Assert.IsTrue(start.CompareTo(end) == -1);
            segment.SetSegment(start, end);
            Assert.IsFalse(segment.IsPoint);
            segment.SetSegment(start, start);
            Assert.IsTrue(segment.IsPoint);
        }

        public static void SetSpan(ISegment<TLabel, TSpan> segment, TSpan span, TLabel etalonEnd)
        {
            segment.SetSpan(span);
            Assert.IsTrue(segment.End.Equals(etalonEnd));
        }

        public static void AssertState(ISegment<TLabel, TSpan> segment, TLabel etalonStart, TLabel etalonEnd)
        {
            Assert.IsTrue(segment.Start.Equals(etalonStart));
            Assert.IsTrue(segment.End.Equals(etalonEnd));
        }

        public static void ShiftMax(ISegment<TLabel, TSpan> segmentMax, TSpan shift)
        {
            var clone = segmentMax.Clone();
            segmentMax.Shift(shift);
            Assert.IsTrue(segmentMax.Equals(clone));
        }

        public static void Shift(ISegment<TLabel, TSpan> segment, TSpan shift, ISegment<TLabel, TSpan> etalonSegment)
        {
            segment.Shift(shift);
            Assert.IsTrue(segment.Equals(etalonSegment));
        }
    }
}
