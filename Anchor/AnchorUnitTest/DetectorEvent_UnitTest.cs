using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    [TestClass]
    public class DetectorEvent_UnitTest
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
            DetectorEvent_Panel.StartState(_detectorEvent);
        }

        [TestMethod]
        public void DetectorEvent_Occur_Sender1()
        {
            DetectorEvent_Panel.Occur_Sender1(_detectorEvent);
        }

        [TestMethod]
        public void DetectorEvent_Occur_Null()
        {
            DetectorEvent_Panel.Occur_Null(_detectorEvent);
        }        
    }
}
