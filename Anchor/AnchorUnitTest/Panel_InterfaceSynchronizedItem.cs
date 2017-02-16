using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    /// <summary>
    /// Панель проверки интерфейса синхронизируемого элемента
    /// </summary>
    
    public class Panel_InterfaceSynchronizedItem<TState>
    {
        public static void DefaultState(ISynchronizedItem<TState> item)
        {
            Assert.IsTrue(item.State.Equals(default(TState)));
        }

        public static void SyncSuccess(ISynchronizedItem<TState> item, TState validState)
        {
            TState previous = item.State;
            Boolean result = item.Sync(validState);
            Assert.IsTrue(result);
            Assert.IsFalse(previous.Equals(validState));
            Assert.IsTrue(item.State.Equals(validState));
        }

        public static void SyncFail(ISynchronizedItem<TState> item, TState failState)
        {
            TState previous = item.State;
            Boolean result = item.Sync(failState);
            Assert.IsFalse(result);
            Assert.IsFalse(previous.Equals(failState));
            Assert.IsTrue(item.State.Equals(previous));
        }
    }
}
