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
        private Double _label_1;
        private Double _label_2;
        private Double _label_Result_1;
        private Double _label_Result_2;
        private Double _label_Result_3;

        [TestInitialize]
        public void Init()
        {
            _rounder = new Rounder_Double(2, MidpointRounding.AwayFromZero);
            _segmentOriginal = new SegmentDouble();
            _segmentRound = new SegmentRoundDouble(_segmentOriginal, _rounder);

            _label_1 = 0.494;
            _label_2 = 0.495;
            _label_Result_1 = _label_1 + _label_1;
            _label_Result_2 = _label_1 + _label_2;
            _label_Result_3 = _label_2 + _label_2;
        }

        [TestMethod]
        public void SegmentDoubleRound_StartState_null()
        {
            SegmentRoundDouble segmentRound = new SegmentRoundDouble(null, null);            
            Panel_SegmentDouble.StartState_Empty(segmentRound);

            segmentRound = new SegmentRoundDouble(_segmentOriginal, null);            
            Panel_SegmentDouble.StartState_Empty(segmentRound);

            segmentRound = new SegmentRoundDouble(null, _rounder);            
            Panel_SegmentDouble.StartState_Empty(segmentRound);
        }

        [TestMethod]
        public void SegmentDoubleRound_StartState_Empty()
        {
            Panel_SegmentDouble.StartState_Empty(_segmentRound);
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

        [TestMethod]
        public void SegmentDoubleRound_SetSegment_Round()
        {
            _segmentRound.SetSegment(_label_1, _label_2);
            Panel_InterfaceSegment<Double, Double>.SetSegment(_segmentRound, _label_1, _label_2);
            Double etalonStartRound = _rounder.Round(_label_1);
            Double etalonEndRound = _rounder.Round(_label_2);
            Assert.IsTrue(_segmentRound.StartRoundValue == etalonStartRound);
            Assert.IsTrue(_segmentRound.EndRoundValue == etalonEndRound);
        }

        [TestMethod]
        public void SegmentDoubleRound_SetSegment_Round_RounderNull()
        {
            SegmentRoundDouble segmentRound = new SegmentRoundDouble(_segmentOriginal, null);
            segmentRound.SetSegment(_label_1, _label_2);
            Panel_InterfaceSegment<Double, Double>.SetSegment(segmentRound, _label_1, _label_2);
            
            Assert.IsTrue(segmentRound.StartRoundValue == _label_1);
            Assert.IsTrue(segmentRound.EndRoundValue == _label_2);
        }

        [TestMethod]
        public void SegmentDoubleRound_SetSpan_Round()
        {
            _segmentRound.SetSegment(_label_1, _label_1);
            _segmentRound.SetSpan(_label_1);

            Double etalonStartRound = _rounder.Round(_label_1);
            Double etalonEndRound = _rounder.Round(_label_Result_1);
            
            AssertSegmentState(etalonStartRound, etalonEndRound);

            _segmentRound.SetSpan(_label_2);

            etalonStartRound = _rounder.Round(_label_1);
            etalonEndRound = _rounder.Round(_label_Result_2);

            AssertSegmentState(etalonStartRound, etalonEndRound);

            _segmentRound.SetSegment(_label_2, _label_2);
            _segmentRound.SetSpan(_label_2);

            etalonStartRound = _rounder.Round(_label_2);
            etalonEndRound = _rounder.Round(_label_Result_3);
            
            AssertSegmentState(etalonStartRound, etalonEndRound);
        }

        private void AssertSegmentState(double etalonStartRound, double etalonEndRound)
        {
            Assert.IsTrue(_segmentRound.StartRoundValue == etalonStartRound);
            Assert.IsTrue(_segmentRound.EndRoundValue == etalonEndRound);
        }
    }
}
