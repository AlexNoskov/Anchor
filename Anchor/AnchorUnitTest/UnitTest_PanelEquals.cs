using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnchorUnitTest
{
    [TestClass]
    public class UnitTest_PanelEquals
    {
        [TestMethod]
        public void PanelEquals_null()
        {
            Panel_Equals.Check_null(new object());
        }

        [TestMethod]
        public void PanelEquals_himself()
        {
            Panel_Equals.Himself(new object());
            Panel_Equals.Himself<Mock_Equatable>(new Mock_Equatable());
        }

        [TestMethod]
        public void PanelEquals_similar()
        {
            Mock_Similar similar = new Mock_Similar();
            Panel_Equals.Similar(new object(), similar);

            Mock_Similar<Int32> similarEquatable = new Mock_Similar<int>();
            Panel_Equals.Similar<Int32>(similarEquatable, 0);
        }

        [TestMethod]
        public void PanelEquals_another()
        {
            Panel_Equals.Another(new object(), new object());
            Mock_Another<Int32> another = new Mock_Another<int>();
            Panel_Equals.Another<Int32>(another, 0);
        }
    }
}
