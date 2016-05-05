using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    public class DetectorEvent_Panel
    {
        private static Object _sender_1;
        private static Object _sender_2;

        static DetectorEvent_Panel()
        {
            _sender_1 = new Object();
            _sender_2 = new Object();
        }

        public static void StartState(DetectorEvent testeeDetector)
        {
            Assert.IsFalse(testeeDetector.IsOccurred);
            Assert.IsFalse(testeeDetector.IsOccurredBy(null));
            Assert.IsFalse(testeeDetector.IsOccurredBy(_sender_1));
        }

        public static void Occur_Sender1(DetectorEvent testeeDetector)
        {
            testeeDetector.Occur(_sender_1);

            Assert.IsTrue(testeeDetector.IsOccurred);
            Assert.IsTrue(testeeDetector.IsOccurredBy(_sender_1));

            Assert.IsFalse(testeeDetector.IsOccurredBy(null));
            Assert.IsFalse(testeeDetector.IsOccurredBy(_sender_2));
        }

        public static void Occur_Null(DetectorEvent testeeDetector)
        {
            testeeDetector.Occur(null);

            Assert.IsTrue(testeeDetector.IsOccurred);
            Assert.IsFalse(testeeDetector.IsOccurredBy(_sender_1));

            Assert.IsFalse(testeeDetector.IsOccurredBy(null));
            Assert.IsFalse(testeeDetector.IsOccurredBy(_sender_2));
        }
    }
}
