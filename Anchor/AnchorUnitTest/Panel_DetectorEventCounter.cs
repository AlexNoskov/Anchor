using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    /// <summary>
    /// Панель тестирования детектора событий со счетчиком.
    /// </summary>   
    public class Panel_DetectorEventCounter
    {
        public static void StartState(DetectorEventCounter testEvent)
        {
            Assert.IsTrue(testEvent.Count == 0);
        }

        public static void Occur_Count(DetectorEventCounter testEvent)
        {
            Int32 etalonCount = testEvent.Count;
            testEvent.Occur(null);
            etalonCount++;
            Assert.IsTrue(testEvent.Count == etalonCount);
        }
    }
}
