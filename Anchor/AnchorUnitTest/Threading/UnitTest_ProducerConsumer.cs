using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnchorUnitTest.Threading
{
    [TestClass]
    public class UnitTest_ProducerConsumer
    {
        private HashSet<Int32> _values;
        private Adapter_BlockingCollection<Int32> _adapterBlockingCollection;
        private Adapter_Mock_ProducerConsumer<Int32> _adapterMockProducerConsumer;

        [TestInitialize]
        public void Init()
        {
            InitValues();
            _adapterBlockingCollection = new Adapter_BlockingCollection<int>(Mock_SourceValues_ProducerConsumer.BufferCapacity);
            _adapterMockProducerConsumer = new Adapter_Mock_ProducerConsumer<int>(Mock_SourceValues_ProducerConsumer.BufferCapacity);
        }

        [TestMethod]
        public void ProducerConsumer_Blocking_StartState()
        {
            Panel_ProducerConsumer<Int32>.StartState(_adapterBlockingCollection, Mock_SourceValues_ProducerConsumer.BufferCapacity);
        }

        [TestMethod]
        public void ProducerConsumer_Blocking_WithinBoundSync()
        {
            Panel_ProducerConsumer<Int32>.WithinBound_Sync(_adapterBlockingCollection, _values);
        }

        [Timeout(Mock_SourceValues_ProducerConsumer.DelayFail)]
        [TestMethod]
        public async Task ProducerConsumer_Blocking_AddOverUpperBound()
        {
            await Panel_ProducerConsumer<Int32>.Add_OverUpperBound(_adapterBlockingCollection, _values);
        }

        [Timeout(Mock_SourceValues_ProducerConsumer.DelayFail)]
        [TestMethod]
        public async Task ProducerConsumer_Blocking_AddAtThread_2()
        {
            await Panel_ProducerConsumer<Int32>.Add_AtThread_2(_adapterBlockingCollection, _values);
        }

        [Timeout(Mock_SourceValues_ProducerConsumer.DelayFail)]
        [TestMethod]
        public async Task ProducerConsumer_Blocking_TakeLessDownBound()
        {
            await Panel_ProducerConsumer<Int32>.Take_LessDownBound(_adapterBlockingCollection, _values);
        }

        [Timeout(Mock_SourceValues_ProducerConsumer.DelayFail)]
        [TestMethod]
        public async Task ProducerConsumer_Blocking_TakeAtThread_2()
        {
            await Panel_ProducerConsumer<Int32>.Take_AtThread_2(_adapterBlockingCollection, _values);
        }


        [TestMethod]
        public void ProducerConsumer_Mock_StartState()
        {
            Panel_ProducerConsumer<Int32>.StartState(_adapterMockProducerConsumer, Mock_SourceValues_ProducerConsumer.BufferCapacity);
        }

        [TestMethod]
        public void ProducerConsumer_Mock_WithinBoundSync()
        {
            Panel_ProducerConsumer<Int32>.WithinBound_Sync(_adapterMockProducerConsumer, _values);
        }

        [Timeout(Mock_SourceValues_ProducerConsumer.DelayFail)]
        [TestMethod]
        public async Task ProducerConsumer_Mock_AddOverUpperBound()
        {
            await Panel_ProducerConsumer<Int32>.Add_OverUpperBound(_adapterMockProducerConsumer, _values);
        }

        [Timeout(Mock_SourceValues_ProducerConsumer.DelayFail)]
        [TestMethod]
        public async Task ProducerConsumer_Mock_AddAtThread_2()
        {
            await Panel_ProducerConsumer<Int32>.Add_AtThread_2(_adapterMockProducerConsumer, _values);
        }

        [Timeout(Mock_SourceValues_ProducerConsumer.DelayFail)]
        [TestMethod]
        public async Task ProducerConsumer_Mock_TakeLessDownBound()
        {
            await Panel_ProducerConsumer<Int32>.Take_LessDownBound(_adapterMockProducerConsumer, _values);
        }

        [Timeout(Mock_SourceValues_ProducerConsumer.DelayFail)]
        [TestMethod]
        public async Task ProducerConsumer_Mock_TakeAtThread_2()
        {
            await Panel_ProducerConsumer<Int32>.Take_AtThread_2(_adapterMockProducerConsumer, _values);
        }

        private void InitValues()
        {
            _values = new HashSet<int>();
            for (Int32 i = 1; i <= Mock_SourceValues_ProducerConsumer.OverCapacity; i++)
            {
                _values.Add(i);
            }
        }
    }
}
