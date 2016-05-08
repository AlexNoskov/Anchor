using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    /// <summary>
    /// Панель тестирования детектора фокусирования.
    /// </summary>
    
    public class Panel_DetectorFocus
    {
        private IDetectorFocus _detectorFocus;
        private DetectorEventCounter _eventFocusCurrent;
        private DetectorEventCounter _eventUnfocusPrevious;

        public void Init(IDetectorFocus detectorFocus)
        {
            Clean();

            _eventFocusCurrent = new DetectorEventCounter();
            _eventUnfocusPrevious = new DetectorEventCounter();

            Assert.IsNotNull(detectorFocus);            
            _detectorFocus = detectorFocus;
            _detectorFocus.FocusCurrentItem += DetectorFocus_FocusCurrentItem;
            _detectorFocus.UnfocusPreviosItem += DetectorFocus_UnfocusPreviosItem;
        }
        public void Clean()
        {
            if (_detectorFocus != null)
            {
                _detectorFocus.FocusCurrentItem -= DetectorFocus_FocusCurrentItem;
                _detectorFocus.UnfocusPreviosItem -= DetectorFocus_UnfocusPreviosItem;
            }
        }

        public void DownOnEqual_NotEvent()
        {
            _detectorFocus.DownOnEqual();
            AssertNotOccurEvents();
        }

        public void DownOut_NotEvent()
        {
            _detectorFocus.DownOut();
            AssertNotOccurEvents();
        }
        public void DownOut_Unfocus()
        {
            _detectorFocus.DownOut();
            AssertOccurUnfocus();
        }

        public void DownOnAnother_Focus()
        {
            _detectorFocus.DownOnAnother();
            AssertOccurFocus();
        }
        public void DownOnAnother_ChangeFocus()
        {
            _detectorFocus.DownOnAnother();
            AssertChangeFocus();
        }
        

        private void DetectorFocus_UnfocusPreviosItem(object sender, EventArgs e)
        {
            _eventUnfocusPrevious.Occur(sender);
        }
        private void DetectorFocus_FocusCurrentItem(object sender, EventArgs e)
        {
            _eventFocusCurrent.Occur(sender);
        }

        private void AssertChangeFocus()
        {
            Assert.IsTrue(_eventFocusCurrent.IsOccurredBy(_detectorFocus));
            Assert.IsTrue(_eventFocusCurrent.Count == 1);
            Assert.IsTrue(_eventUnfocusPrevious.IsOccurredBy(_detectorFocus));
            Assert.IsTrue(_eventUnfocusPrevious.Count == 1);
        }
        private void AssertOccurFocus()
        {
            Assert.IsTrue(_eventFocusCurrent.IsOccurredBy(_detectorFocus));
            Assert.IsTrue(_eventFocusCurrent.Count == 1);
            Assert.IsFalse(_eventUnfocusPrevious.IsOccurred);
        }
        private void AssertOccurUnfocus()
        {
            Assert.IsTrue(_eventUnfocusPrevious.IsOccurredBy(_detectorFocus));
            Assert.IsTrue(_eventUnfocusPrevious.Count == 1);
            Assert.IsFalse(_eventFocusCurrent.IsOccurred);
        }
        private void AssertNotOccurEvents()
        {
            Assert.IsFalse(_eventFocusCurrent.IsOccurred);
            Assert.IsFalse(_eventUnfocusPrevious.IsOccurred);
        }
    }
}
