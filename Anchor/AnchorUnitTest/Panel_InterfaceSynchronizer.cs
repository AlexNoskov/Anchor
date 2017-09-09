using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    /// <summary>
    /// Панель проверки интерфейса синхронизатора
    /// </summary>    
    public class Panel_InterfaceSynchronizer<TState>
    {
        public static void Synchronizer_StartState(ISynchronizer<TState> syncronizer)
        {
            AssertStartState(syncronizer);
        }
        
        public static void Synchronizer_ItemEnabled(ISynchronizer<TState> syncronizer)
        {
            Mock_SynchronizerItem<TState> item_1 = new Mock_SynchronizerItem<TState>();

            syncronizer.Add(item_1);
            AssertState(syncronizer, 1, 0, false);

            item_1.Enable();
            AssertState(syncronizer, 1, 1, true);
        }
        
        public static void Synchronizer_UnSubscribeAfterRemove(ISynchronizer<TState> syncronizer)
        {
            Assert.Inconclusive();
            Mock_SynchronizerItem<TState> item_1 = new Mock_SynchronizerItem<TState>();

            syncronizer.Add(item_1);
            AssertState(syncronizer, 1, 0, false);

            item_1.Enable();
            AssertState(syncronizer, 1, 1, true);
        }

        public static void Synchronizer_UnSubscribeAfterClear(ISynchronizer<TState> syncronizer)
        {
            Assert.Inconclusive();
            Mock_SynchronizerItem<TState> item_1 = new Mock_SynchronizerItem<TState>();

            syncronizer.Add(item_1);
            AssertState(syncronizer, 1, 0, false);

            item_1.Enable();
            AssertState(syncronizer, 1, 1, true);
        }

        private static void AssertStartState(ISynchronizer<TState> syncronizer)
        {
            AssertState(syncronizer, 0, 0, false);
        }

        private static void AssertState(ISynchronizer<TState> syncronizer, Int32 count, Int32 enabledCount, Boolean isSync)
        {
            Assert.IsTrue(syncronizer.Count == count);
            Assert.IsTrue(syncronizer.EnabledItemCount == enabledCount);
            Assert.IsTrue(syncronizer.Synchronized == isSync);
        }
    }
}
