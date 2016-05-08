using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    [TestClass]
    public class UnitTest_DetectorFocus
    {
        public UnitTest_DetectorFocus()
        {
            _panel = new Panel_DetectorFocus();
            _detectorFocus = new DetectorFocus();
        }

        private Panel_DetectorFocus _panel;
        private DetectorFocus _detectorFocus;

        [TestInitialize]
        public void Init()
        {            
            _panel.Init(_detectorFocus);
        }

        [TestCleanup]
        public void Clean()
        {
            _panel.Clean();
        }

        [TestMethod]
        public void DetectorFocus_StartState()
        {
            AssertOutState();
        }

        [TestMethod]
        public void DetectorFocus_ToState()
        {
            _detectorFocus.ToFirst();
            AssertFirstState();

            _detectorFocus.ToEqual();
            AssertEqualState();

            _detectorFocus.ToChange();
            AssertChangeState();

            _detectorFocus.ToOut();
            AssertOutState();
        }

        [TestMethod]
        public void DetectorFocus_Out_DownOnEqual()
        {
            AssertOutState();
            _panel.DownOnEqual_NotEvent();
            AssertOutState();            
        }

        [TestMethod]
        public void DetectorFocus_Out_DownOut()
        {
            AssertOutState();            
            _panel.DownOut_NotEvent();
            AssertOutState();            
        }

        [TestMethod]
        public void DetectorFocus_Out_DownOnAnother()
        {
            AssertOutState();
            _panel.DownOnAnother_Focus();            
            AssertFirstState();
        }

        [TestMethod]
        public void DetectorFocus_First_DownOnEqual()
        {
            _detectorFocus.ToFirst();

            _panel.DownOnEqual_NotEvent();
            AssertEqualState();
        }

        [TestMethod]
        public void DetectorFocus_First_DownOut()
        {
            _detectorFocus.ToFirst();

            _panel.DownOut_Unfocus();
            AssertOutState();
        }

        [TestMethod]
        public void DetectorFocus_First_DownOnAnother()
        {
            _detectorFocus.ToFirst();
            
            _panel.DownOnAnother_ChangeFocus();            
            AssertChangeState();
        }

        [TestMethod]
        public void DetectorFocus_Equal_DownOnEqual()
        {
            _detectorFocus.ToEqual();

            _panel.DownOnEqual_NotEvent();
            AssertEqualState();
        }

        [TestMethod]
        public void DetectorFocus_Equal_DownOut()
        {
            _detectorFocus.ToEqual();
            
            _panel.DownOut_Unfocus();
            AssertOutState();
        }

        [TestMethod]
        public void DetectorFocus_Equal_DownOnAnother()
        {
            _detectorFocus.ToEqual();

            _panel.DownOnAnother_ChangeFocus();
            AssertChangeState();
        }

        [TestMethod]
        public void DetectorFocus_Change_DownOnEqual()
        {
            _detectorFocus.ToChange();

            _panel.DownOnEqual_NotEvent();
            AssertEqualState();
        }

        [TestMethod]
        public void DetectorFocus_Change_DownOut()
        {
            _detectorFocus.ToChange();
            
            _panel.DownOut_Unfocus();
            AssertOutState();
        }

        [TestMethod]
        public void DetectorFocus_Change_DownOnAnother()
        {
            _detectorFocus.ToChange();

            _panel.DownOnAnother_ChangeFocus();
            AssertChangeState();
        }

        private void AssertOutState()
        {
            Assert.IsTrue(_detectorFocus.IsOutState);
            Assert.IsFalse(_detectorFocus.IsFirstState);
            Assert.IsFalse(_detectorFocus.IsEqualState);
            Assert.IsFalse(_detectorFocus.IsChangeState);
        }

        private void AssertFirstState()
        {
            Assert.IsFalse(_detectorFocus.IsOutState);
            Assert.IsTrue(_detectorFocus.IsFirstState);
            Assert.IsFalse(_detectorFocus.IsEqualState);
            Assert.IsFalse(_detectorFocus.IsChangeState);
        }

        private void AssertEqualState()
        {
            Assert.IsFalse(_detectorFocus.IsOutState);
            Assert.IsFalse(_detectorFocus.IsFirstState);
            Assert.IsTrue(_detectorFocus.IsEqualState);
            Assert.IsFalse(_detectorFocus.IsChangeState);
        }

        private void AssertChangeState()
        {
            Assert.IsFalse(_detectorFocus.IsOutState);
            Assert.IsFalse(_detectorFocus.IsFirstState);
            Assert.IsFalse(_detectorFocus.IsEqualState);
            Assert.IsTrue(_detectorFocus.IsChangeState);
        }
    }
}
