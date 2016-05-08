using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    [TestClass]
    public class UnitTest_DetectorEventCounter
    {
        private DetectorEventCounter _eventCount;
     
        [TestInitialize]
        public void Init()
        {
            _eventCount = new DetectorEventCounter();
        }

        [TestMethod]
        public void DetectorEventCount_StartState()
        {
            Panel_DetectorEvent.StartState(_eventCount);
            Panel_DetectorEventCounter.StartState(_eventCount);            
        }

        [TestMethod]
        public void DetectorEventCount_Occur_Sender1()
        {
            Panel_DetectorEvent.Occur_Sender1(_eventCount);
        }

        [TestMethod]
        public void DetectorEventCount_Occur_Null()
        {
            Panel_DetectorEvent.Occur_Null(_eventCount);
        }

        [TestMethod]
        public void DetectorEventCount_Occur_Count()
        {
            Panel_DetectorEventCounter.Occur_Count(_eventCount);
        }        
    }
}
