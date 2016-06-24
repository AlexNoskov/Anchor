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
        private Rounder_Double _rounder;
        private SegmentDouble _segmentOriginal;
        private SegmentRoundDouble _segmentRound;

        [TestInitialize]
        public void Init()
        {
            _rounder = new Rounder_Double(2, MidpointRounding.AwayFromZero);
            _segmentOriginal = new SegmentDouble();
            _segmentRound = new SegmentRoundDouble(_segmentOriginal, _rounder);
        }

        [TestMethod]
        public void SegmentDoubleRound_StartState_null()
        {
            SegmentRoundDouble segmentRound = new SegmentRoundDouble(null, null);            
            Panel_SegmentDouble.StartState(segmentRound);

            segmentRound = new SegmentRoundDouble(_segmentOriginal, null);            
            Panel_SegmentDouble.StartState(segmentRound);

            segmentRound = new SegmentRoundDouble(null, _rounder);            
            Panel_SegmentDouble.StartState(segmentRound);
        }

        [TestMethod]
        public void SegmentDoubleRound_StartState_Empty()
        {
            Panel_SegmentDouble.StartState(_segmentRound);
        }

        [TestMethod]
        public void SegmentDoubleRound_SetReverseLabel()
        {
            Panel_SegmentDouble.SetReverseLabel(_segmentRound);
        }

        [TestMethod]
        public void SegmentDoubleRound_SetSegment()
        {
            Panel_SegmentDouble.SetSegment(_segmentRound);
        }

        [TestMethod]
        public void SegmentDoubleRound_IsPoint()
        {
            Panel_SegmentDouble.IsPoint(_segmentRound);
        }

        [TestMethod]
        public void SegmentDoubleRound_SetSpan()
        {
            Panel_SegmentDouble.SetSpan(_segmentRound);
        }

        [TestMethod]
        public void SegmentDoubleRound_SetSpan_Max()
        {
            Panel_SegmentDouble.SetSpan_Max(_segmentRound);
        }

        [TestMethod]
        public void SegmentDoubleRound_SetSpan_EndMoreMax()
        {
            Panel_SegmentDouble.SetSpan_EndMoreMax(_segmentRound);
        }
    }
}
