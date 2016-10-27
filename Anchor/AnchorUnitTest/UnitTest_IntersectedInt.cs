using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    [TestClass]
    public class UnitTest_IntersectedInt
    {
        private Int32 _label_1;
        private Int32 _label_2;
        private Int32 _label_3;
        private Int32 _label_4;

        [TestInitialize]
        public void Init()
        {
            _label_1 = 1;
            _label_2 = 2;
            _label_3 = 3;
            _label_4 = 4;
        }

        [TestMethod]
        public void IntersectedInt_LabelOut()
        {
            SegmentInt segment = new SegmentInt(_label_2, _label_3);
            Panel_InterfaceIntersected<Int32, Int32>.LabelOut(segment, _label_1);
            Panel_InterfaceIntersected<Int32, Int32>.LabelOut(segment, _label_4);
        }

        [TestMethod]
        public void IntersectedInt_LabelOn()
        {
            SegmentInt segment = new SegmentInt(_label_2, _label_3);
            Panel_InterfaceIntersected<Int32, Int32>.LabelOn(segment, _label_2);
            Panel_InterfaceIntersected<Int32, Int32>.LabelOn(segment, _label_3);
        }

        [TestMethod]
        public void IntersectedInt_SegmentOut()
        {
            SegmentInt segmentLeft = new SegmentInt(_label_1, _label_2);
            SegmentInt segmentRight = new SegmentInt(_label_3, _label_4);

            Panel_InterfaceIntersected<Int32, Int32>.SegmentOut(segmentLeft, segmentRight);
            Panel_InterfaceIntersected<Int32, Int32>.SegmentOut(segmentRight, segmentLeft);
        }

        [TestMethod]
        public void IntersectedInt_SegmentIn()
        {
            SegmentInt segmentLeft = new SegmentInt(_label_1, _label_3);
            SegmentInt segmentRight = new SegmentInt(_label_2, _label_4);

            Panel_InterfaceIntersected<Int32, Int32>.SegmentIn(segmentLeft, segmentRight);
            Panel_InterfaceIntersected<Int32, Int32>.SegmentIn(segmentRight, segmentLeft);
        }

        [TestMethod]
        public void IntersectedInt_PartOf()
        {
            SegmentInt segment = new SegmentInt(_label_2, _label_3);
            SegmentInt segmentClone = new SegmentInt(_label_2, _label_3);

            Panel_InterfaceIntersected<Int32, Int32>.PartOf(segment, segmentClone);
        }

        [TestMethod]
        public void IntersectedInt_NotPartOf()
        {
            SegmentInt segmentLeft = new SegmentInt(_label_1, _label_3);
            SegmentInt segmentRight = new SegmentInt(_label_2, _label_4);

            Panel_InterfaceIntersected<Int32, Int32>.NotPartOf(segmentLeft, segmentRight);
            Panel_InterfaceIntersected<Int32, Int32>.NotPartOf(segmentRight, segmentLeft);
        }
    }
}
