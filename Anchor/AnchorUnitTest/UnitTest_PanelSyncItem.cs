using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnchorUnitTest
{
    [TestClass]
    public class UnitTest_PanelSyncItem
    {
        [TestInitialize]
        public void Init()
        {

        }

        [TestMethod]
        public void PanelSyncItem_DefaultState()
        {
            Mock_SyncItemSuccess<Int32> a = new Mock_SyncItemSuccess<int>();            
            Panel_InterfaceSynchronizedItem<Int32>.DefaultState(a);
        }

        [TestMethod]
        public void PanelSyncItem_Sync()
        {
            Mock_SyncItemSuccess<Int32> success = new Mock_SyncItemSuccess<int>();
            Mock_SyncItemFail<Int32> fail = new Mock_SyncItemFail<int>();
            Panel_InterfaceSynchronizedItem<Int32>.SyncSuccess(success, 1);
            Panel_InterfaceSynchronizedItem<Int32>.SyncFail(fail, 1);
        }
    }
}
