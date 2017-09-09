using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    [TestClass]
    public class UnitTest_Synchronizer
    {
        [TestMethod]
        public void Synchronizer_StartState()
        {
            SynchronizerPeer<Int32> s = new SynchronizerPeer<int>();
            Panel_InterfaceSynchronizer<int>.Synchronizer_StartState(s);
        }

        [TestMethod]
        public void Synchronizer_NotifyItemEnabled()
        {
            SynchronizerPeer<Int32> s = new SynchronizerPeer<int>();
            Panel_InterfaceSynchronizer<int>.Synchronizer_ItemEnabled(s);
        }

        [TestMethod]
        public void Synchronizer_NotifyItemDisabled()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void Synchronizer_FirstItemEnabled()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void Synchronizer_SecondItemEnabled()
        {
            Assert.Inconclusive();
        }
    }
}
