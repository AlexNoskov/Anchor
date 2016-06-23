using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    [TestClass]
    public class UnitTest_SegmentDouble_Rounder
    {        
        [TestMethod]
        public void SegmentDoubleRound_StartState_null()
        {
            Rounder_Double rounder = new Rounder_Double(2, MidpointRounding.AwayFromZero);
            SegmentDouble segment = new SegmentDouble();

            SegmentRoundDouble segmentRound = new SegmentRoundDouble(null, null);
            Panel_InterfaceSegment<Double, Double>.StartState_Empty(segmentRound);

            segmentRound = new SegmentRoundDouble(segment, null);
            Panel_InterfaceSegment<Double, Double>.StartState_Empty(segmentRound);

            segmentRound = new SegmentRoundDouble(null, rounder);
            Panel_InterfaceSegment<Double, Double>.StartState_Empty(segmentRound);
        }
    }
}
