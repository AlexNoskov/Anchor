using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    public class Panel_Range<TLabel>
        where TLabel : IComparable<TLabel>
    {
        private TLabel _label_1;
        private TLabel _label_2;
        private TLabel _label_3;

        public void SetLabels(TLabel label_1, TLabel label_2, TLabel label_3)
        {
            _label_1 = label_1;
            _label_2 = label_2;
            _label_3 = label_3;
        }

        public void GetIn(Func<TLabel, TLabel, TLabel, TLabel> getInRange)
        {
            AssertLabelAscend();

            TLabel result = getInRange(_label_2, _label_1, _label_3);
            AssertCompareEqual(result, _label_2);

            result = getInRange(_label_2, _label_2, _label_3);
            AssertCompareEqual(result, _label_2);

            result = getInRange(_label_3, _label_2, _label_3);
            AssertCompareEqual(result, _label_3);

            result = getInRange(_label_1, _label_2, _label_3);
            AssertCompareEqual(result, _label_2);

            result = getInRange(_label_3, _label_1, _label_2);
            AssertCompareEqual(result, _label_2);
        }

        public void Belongs(Func<TLabel, TLabel, TLabel, Boolean> belongsRange)
        {
            AssertLabelAscend();
            AssertBelongsDirectOrderBounds(belongsRange);

            Assert.IsTrue(belongsRange(_label_1, _label_3, _label_1));
            Assert.IsTrue(belongsRange(_label_2, _label_3, _label_1));
            Assert.IsTrue(belongsRange(_label_3, _label_3, _label_1));

            Assert.IsFalse(belongsRange(_label_1, _label_3, _label_2));
            Assert.IsFalse(belongsRange(_label_3, _label_2, _label_1));
        }
        
        public void BelongsDirectOrder(Func<TLabel, TLabel, TLabel, Boolean> belongsRange)
        {
            AssertLabelAscend();
            AssertBelongsDirectOrderBounds(belongsRange);
            Assert.IsTrue(belongsRange(_label_1, _label_3, _label_1));
            Assert.IsFalse(belongsRange(_label_2, _label_3, _label_1));
            Assert.IsTrue(belongsRange(_label_3, _label_3, _label_1));

            Assert.IsFalse(belongsRange(_label_1, _label_3, _label_2));
            Assert.IsFalse(belongsRange(_label_3, _label_2, _label_1));
        }

        public static void AssertCompareEqual(TLabel testee, TLabel etalon)
        {
            Assert.IsTrue(testee.CompareTo(etalon) == 0);
        }

        private void AssertBelongsDirectOrderBounds(Func<TLabel, TLabel, TLabel, bool> belongsRange)
        {
            Assert.IsTrue(belongsRange(_label_1, _label_1, _label_3));
            Assert.IsTrue(belongsRange(_label_2, _label_1, _label_3));
            Assert.IsTrue(belongsRange(_label_3, _label_1, _label_3));

            Assert.IsFalse(belongsRange(_label_1, _label_2, _label_3));
            Assert.IsFalse(belongsRange(_label_3, _label_1, _label_2));
        }
        private void AssertLabelAscend()
        {
            Assert.IsTrue(_label_1.CompareTo(_label_2) < 0);
            Assert.IsTrue(_label_2.CompareTo(_label_3) < 0);
        }
    }
}
