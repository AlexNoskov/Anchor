using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnchorUnitTest.Threading
{
    /// <summary>
    /// Панель тестирования типов, реализущих модель "Производитель - Потребитель".
    /// </summary>   
    public class Panel_ProducerConsumer<TItem> : Mock_SourceValues_ProducerConsumer
    {
        public static void StartState(Adapter_ProducerConsumer<TItem> buffer, Int32 etalonBufferCapacity)
        {
            Assert.IsTrue(buffer.BufferCapacity == etalonBufferCapacity);
            Assert.IsTrue(buffer.Count == 0);
        }

        public static void WithinBound_Sync(Adapter_ProducerConsumer<TItem> buffer, HashSet<TItem> addSerial)
        {
            BufferFiller<TItem> valueSerial = new BufferFiller<TItem>(buffer);
            valueSerial.FillAt(addSerial);

            Assert.IsTrue(buffer.Count == valueSerial.CountInclusive);

            foreach (TItem item in valueSerial.Inclusive)
            {
                TItem itemTaked = buffer.Take();
                Assert.IsTrue(itemTaked.Equals(item));
            }

            Assert.IsTrue(buffer.Count == 0);
        }

        public static async Task Add_OverUpperBound(Adapter_ProducerConsumer<TItem> buffer, HashSet<TItem> addSerial)
        {
            BufferFiller<TItem> valueSerial = new BufferFiller<TItem>(buffer);
            valueSerial.FillAt(addSerial);

            Assert.IsTrue(valueSerial.CountExclusive > 0);

            Timer timerReaction = new Timer(TimeOut_TakeAction, buffer, DelayWait, Timeout.Infinite);

            await buffer.Add_AtTask(valueSerial.FirstExclusive);

            Assert.IsTrue(buffer.Count == buffer.BufferCapacity);

            TItem itemTaked = default(TItem);

            for (int i = 0; i < buffer.BufferCapacity; i++)
            {
                itemTaked = buffer.Take();
            }

            Assert.IsTrue(buffer.Count == 0);
            Assert.IsTrue(itemTaked.Equals(valueSerial.FirstExclusive));
        }

        public static async Task Take_LessDownBound(Adapter_ProducerConsumer<TItem> buffer, HashSet<TItem> addSerial)
        {
            Assert.IsTrue(buffer.Count == 0);

            TItem first = addSerial.First();

            AddState<TItem> addState = new AddState<TItem>(buffer, first);

            Timer timerReactionNormal = new Timer(TimeOut_AddAction, addState, DelayWait, Timeout.Infinite);
            TItem taked = await buffer.Take_AtTask();

            Assert.IsTrue(buffer.Count == 0);
            Assert.IsTrue(taked.Equals(first));
        }

        public static async Task Take_AtThread_2(Adapter_ProducerConsumer<TItem> buffer, HashSet<TItem> addSerial)
        {
            Assert.IsTrue(buffer.Count == 0);

            TItem first = addSerial.ElementAt(0);
            TItem second = addSerial.ElementAt(1);

            AddState<TItem> addState_First = new AddState<TItem>(buffer, first);
            AddState<TItem> addState_Second = new AddState<TItem>(buffer, second);

            Timer timerReaction_First = new Timer(TimeOut_AddAction, addState_First, DelayWait, Timeout.Infinite);
            Timer timerReaction_Second = new Timer(TimeOut_AddAction, addState_Second, DelayWaitDouble, Timeout.Infinite);

            ResultDouble<TItem> result = await buffer.Take_AtThread_2();

            Assert.IsTrue(buffer.Count == 0);

            if (result.Value_1.Equals(first))
            {
                Assert.IsTrue(result.Value_2.Equals(second));
            }
            else
            {
                Assert.IsTrue(result.Value_1.Equals(second));
                Assert.IsTrue(result.Value_2.Equals(first));
            }
        }

        public static async Task Add_AtThread_2(Adapter_ProducerConsumer<TItem> buffer, HashSet<TItem> addSerial)
        {
            BufferFiller<TItem> valueSerial = new BufferFiller<TItem>(buffer);
            valueSerial.FillAt(addSerial);

            Assert.IsTrue(valueSerial.CountExclusive > 1);

            Timer timerReaction_First = new Timer(TimeOut_TakeAction, buffer, DelayWait, Timeout.Infinite);
            Timer timerReaction_Second = new Timer(TimeOut_TakeAction, buffer, DelayWaitDouble, Timeout.Infinite);

            await buffer.Add_AtThread_2(valueSerial.FirstExclusive, valueSerial.SecondExclusive);

            Assert.IsTrue(buffer.Count == buffer.BufferCapacity);

            TItem itemTaked = default(TItem);

            for (int i = 0; i < buffer.BufferCapacity - 1; i++)
            {
                itemTaked = buffer.Take();
            }

            Assert.IsTrue(buffer.Count == 1);

            if (itemTaked.Equals(valueSerial.FirstExclusive))
            {
                itemTaked = buffer.Take();
                Assert.IsTrue(itemTaked.Equals(valueSerial.SecondExclusive));
            }
            else
            {
                Assert.IsTrue(itemTaked.Equals(valueSerial.SecondExclusive));
                itemTaked = buffer.Take();
                Assert.IsTrue(itemTaked.Equals(valueSerial.FirstExclusive));
            }

            Assert.IsTrue(buffer.Count == 0);
        }

        private static void TimeOut_TakeAction(Object state)
        {
            Adapter_ProducerConsumer<TItem> buffer = state as Adapter_ProducerConsumer<TItem>;
            TItem value = buffer.Take();
        }

        private static void TimeOut_AddAction(Object state)
        {
            AddState<TItem> addState = state as AddState<TItem>;
            addState.Add();
        }

        private class BufferFiller<T>
        {
            public BufferFiller(Adapter_ProducerConsumer<T> producerConsumer)
            {
                _producerConsumer = producerConsumer;
                _inclusiveItemList = new List<T>();
                _exclusiveItemList = new List<T>();
            }

            public IEnumerable<T> Inclusive
            {
                get { return _inclusiveItemList; }
            }
            public IEnumerable<T> Exclusive
            {
                get { return _exclusiveItemList; }
            }

            public Int32 CountInclusive
            {
                get { return _inclusiveItemList.Count; }
            }
            public Int32 CountExclusive
            {
                get { return _exclusiveItemList.Count; }
            }

            public T FirstExclusive
            {
                get { return _exclusiveItemList.FirstOrDefault(); }
            }
            public T SecondExclusive
            {
                get { return _exclusiveItemList[1]; }
            }

            private List<T> _inclusiveItemList;
            private List<T> _exclusiveItemList;
            private Adapter_ProducerConsumer<T> _producerConsumer;

            public void FillAt(HashSet<T> addSerial)
            {
                Assert.IsTrue(addSerial.Count >= _producerConsumer.BufferCapacity);

                foreach (T item in addSerial)
                {
                    if (_inclusiveItemList.Count >= _producerConsumer.BufferCapacity)
                    {
                        _exclusiveItemList.Add(item);
                    }
                    else
                    {
                        _producerConsumer.Add(item);
                        _inclusiveItemList.Add(item);
                    }
                }
            }
        }

        private class AddState<T>
        {
            public AddState(Adapter_ProducerConsumer<T> producerConsumer, T item)
            {
                _producerConsumer = producerConsumer;
                _itemForAdd = item;
            }
            private Adapter_ProducerConsumer<T> _producerConsumer;
            private T _itemForAdd;
            public void Add()
            {
                _producerConsumer.Add(_itemForAdd);
            }
        }
    }
}
