using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public static class Range<TLabel>
        where TLabel : IComparable<TLabel>
    {
        public static TLabel GetIn(TLabel label, TLabel bound1, TLabel bound2)
        {
            TLabel leftBound;
            TLabel rightBound;

            LeftRight(bound1, bound2, out leftBound, out rightBound);

            if (label.CompareTo(leftBound) < 0) { return leftBound; }
            if (label.CompareTo(rightBound) > 0) { return rightBound; }
            return label;
        }

        public static Boolean Belongs(TLabel label, TLabel bound1, TLabel bound2)
        {
            TLabel leftBound;
            TLabel rightBound;

            LeftRight(bound1, bound2, out leftBound, out rightBound);

            return BelongsDirectOrderBound(label, leftBound, rightBound);
        }

        public static bool BelongsDirectOrderBound(TLabel label, TLabel leftBound, TLabel rightBound)
        {
            if (
                            (label.CompareTo(leftBound) == 0) || (label.CompareTo(rightBound) == 0) ||
                            ((label.CompareTo(leftBound) > 0) && (label.CompareTo(rightBound) < 0))
                            )
            { return true; }

            return false;
        }

        public static void LeftRight(TLabel bound1, TLabel bound2, out TLabel leftBound, out TLabel rightBound)
        {
            int resultCompare = bound1.CompareTo(bound2);
            if (resultCompare > 0)
            {
                leftBound = bound2;
                rightBound = bound1;
            }
            else
            {
                leftBound = bound1;
                rightBound = bound2;
            }
        }
    }
}
