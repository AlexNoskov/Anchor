using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;
namespace AnchorUnitTest
{
    /// <summary>
    /// Панель тестирования интерфейса сервиса, определяющего факт пересечения.
    /// </summary>    
    public class Panel_InterfaceIntersected<TLabel, TSpan>
        where TLabel : IComparable<TLabel>
    {
        public static void LabelOut(IIntersected<TLabel, TSpan> intersected, TLabel label)
        {
            Assert.IsFalse(intersected.IsIntersected(label));
        }

        public static void LabelOn(IIntersected<TLabel, TSpan> intersected, TLabel label)
        {
            Assert.IsTrue(intersected.IsIntersected(label));
        }

        public static void SegmentOut(IIntersected<TLabel, TSpan> intersected, ISegment<TLabel, TSpan> segment)
        {
            Assert.IsFalse(intersected.IsIntersected(segment));
        }

        public static void SegmentIn(IIntersected<TLabel, TSpan> intersected, ISegment<TLabel, TSpan> segment)
        {
            Assert.IsTrue(intersected.IsIntersected(segment));
        }

        public static void NotPartOf(IIntersected<TLabel, TSpan> intersected, ISegment<TLabel, TSpan> segment)
        {
            Assert.IsFalse(intersected.IsPartOf(segment));
        }

        public static void PartOf(IIntersected<TLabel, TSpan> intersected, ISegment<TLabel, TSpan> segment)
        {
            Assert.IsTrue(intersected.IsPartOf(segment));
        }
    }
}
