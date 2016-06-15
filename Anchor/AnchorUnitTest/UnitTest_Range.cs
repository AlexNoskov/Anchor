using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    [TestClass]
    public class UnitTest_Range
    {
        private Double _labelDouble_1;
        private Double _labelDouble_2;
        private Double _labelDouble_3;

        private Int32 _labelInt_1;
        private Int32 _labelInt_2;
        private Int32 _labelInt_3;

        private DateTime _labelTime_1;
        private DateTime _labelTime_2;
        private DateTime _labelTime_3;

        private Panel_Range<Double> _panelRangeDouble;
        private Panel_Range<Int32> _panelRangeInt;
        private Panel_Range<DateTime> _panelRangeTime;

        [TestInitialize]
        public void Init()
        {
            _labelDouble_1 = 0.1;
            _labelDouble_2 = 0.5;
            _labelDouble_3 = 0.9;

            _labelInt_1 = 1;
            _labelInt_2 = 2;
            _labelInt_3 = 3;

            _labelTime_1 = new DateTime(2016, 6, 14);
            _labelTime_2 = new DateTime(2016, 6, 15);
            _labelTime_3 = new DateTime(2016, 6, 16);

            _panelRangeDouble = new Panel_Range<Double>();
            _panelRangeDouble.SetLabels(_labelDouble_1, _labelDouble_2, _labelDouble_3);

            _panelRangeInt = new Panel_Range<Int32>();
            _panelRangeInt.SetLabels(_labelInt_1, _labelInt_2, _labelInt_3);

            _panelRangeTime = new Panel_Range<DateTime>();
            _panelRangeTime.SetLabels(_labelTime_1, _labelTime_2, _labelTime_3);
        }

        [TestMethod]
        public void RangeDouble_LeftRight()
        {
            Double left;
            Double right;

            Range<Double>.LeftRight(_labelDouble_1, _labelDouble_1, out left, out right);

            Panel_Range<Double>.AssertCompareEqual(left, _labelDouble_1);
            Panel_Range<Double>.AssertCompareEqual(right, _labelDouble_1);

            Range<Double>.LeftRight(_labelDouble_1, _labelDouble_2, out left, out right);

            Panel_Range<Double>.AssertCompareEqual(left, _labelDouble_1);
            Panel_Range<Double>.AssertCompareEqual(right, _labelDouble_2);

            Range<Double>.LeftRight(_labelDouble_2, _labelDouble_1, out left, out right);

            Panel_Range<Double>.AssertCompareEqual(left, _labelDouble_1);
            Panel_Range<Double>.AssertCompareEqual(right, _labelDouble_2);
        }
        [TestMethod]
        public void RangeDouble_GetIn()
        {
            _panelRangeDouble.GetIn(Range<Double>.GetIn);
        }
        [TestMethod]
        public void RangeDouble_Belongs()
        {
            _panelRangeDouble.Belongs(Range<Double>.Belongs);
        }

        [TestMethod]
        public void RangeInt_LeftRight()
        {
            int left;
            int right;

            Range<int>.LeftRight(_labelInt_1, _labelInt_1, out left, out right);

            Panel_Range<int>.AssertCompareEqual(left, _labelInt_1);
            Panel_Range<int>.AssertCompareEqual(right, _labelInt_1);

            Range<int>.LeftRight(_labelInt_1, _labelInt_2, out left, out right);

            Panel_Range<int>.AssertCompareEqual(left, _labelInt_1);
            Panel_Range<int>.AssertCompareEqual(right, _labelInt_2);

            Range<int>.LeftRight(_labelInt_2, _labelInt_1, out left, out right);

            Panel_Range<int>.AssertCompareEqual(left, _labelInt_1);
            Panel_Range<int>.AssertCompareEqual(right, _labelInt_2);
        }
        [TestMethod]
        public void RangeInt_GetIn()
        {
            _panelRangeInt.GetIn(Range<Int32>.GetIn);
        }
        [TestMethod]
        public void RangeInt_Belongs()
        {
            _panelRangeInt.Belongs(Range<Int32>.Belongs);
        }
        [TestMethod]
        public void RangeTime_LeftRight()
        {
            DateTime left;
            DateTime right;

            Range<DateTime>.LeftRight(_labelTime_1, _labelTime_1, out left, out right);

            Panel_Range<DateTime>.AssertCompareEqual(left, _labelTime_1);
            Panel_Range<DateTime>.AssertCompareEqual(right, _labelTime_1);

            Range<DateTime>.LeftRight(_labelTime_1, _labelTime_2, out left, out right);

            Panel_Range<DateTime>.AssertCompareEqual(left, _labelTime_1);
            Panel_Range<DateTime>.AssertCompareEqual(right, _labelTime_2);

            Range<DateTime>.LeftRight(_labelTime_2, _labelTime_1, out left, out right);

            Panel_Range<DateTime>.AssertCompareEqual(left, _labelTime_1);
            Panel_Range<DateTime>.AssertCompareEqual(right, _labelTime_2);
        }
        [TestMethod]
        public void RangeTime_GetIn()
        {
            _panelRangeTime.GetIn(Range<DateTime>.GetIn);
        }
        [TestMethod]
        public void RangeTime_Belongs()
        {
            _panelRangeTime.Belongs(Range<DateTime>.Belongs);
        }
    }
}
