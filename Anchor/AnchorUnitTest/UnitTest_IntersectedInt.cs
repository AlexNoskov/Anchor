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
        //private Int32 _label_1;
        private Int32 _label_2;
        private Int32 _label_3;
        //private Int32 _label_4;

        [TestInitialize]
        public void Init()
        {
            //_label_1 = 1;
            _label_2 = 2;
            _label_3 = 3;
            //_label_4 = 4;
        }

        [TestMethod]
        public void IntersectedInt_LabelOut()
        {
            Assert.Inconclusive();
            SegmentInt segment = new SegmentInt();
            segment.SetSegment(_label_2, _label_3);
            //Panel_InterfaceIntersected<Int32, Int32>.LabelOut()
        }
    }
}
