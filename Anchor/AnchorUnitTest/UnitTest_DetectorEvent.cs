using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    [TestClass]
    public class UnitTest_DetectorEvent
    {
        private DetectorEvent _detectorEvent;

        [TestInitialize]
        public void Init()
        {
            _detectorEvent = new DetectorEvent();
        }

        [TestMethod]
        public void DetectorEvent_StartState()
        {
            Panel_DetectorEvent.StartState(_detectorEvent);
        }

        [TestMethod]
        public void DetectorEvent_Occur_Sender1()
        {
            Panel_DetectorEvent.Occur_Sender1(_detectorEvent);
        }

        [TestMethod]
        public void DetectorEvent_Occur_Null()
        {
            Panel_DetectorEvent.Occur_Null(_detectorEvent);
        }        
    }
}
