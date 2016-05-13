using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnchorUnitTest.Threading
{
    public abstract class Adapter_ProducerConsumer<T>
    {
        public Adapter_ProducerConsumer(Int32 bufferCapacity)
        {
            CreateCollection(bufferCapacity);
            _countThread = 0;
            _tableThread = new ConcurrentDictionary<int, bool>();
        }

        public abstract Int32 BufferCapacity
        { get; }
        public abstract Int32 Count
        { get; }

        private Int32 _countThread;
        private ConcurrentDictionary<Int32, Boolean> _tableThread;

        public void Add(T item)
        {
            OnAdd(item);
        }

        public async Task Add_AtTask(T item)
        {
            await Task.Run(
                () =>
                {
                    OnAdd(item);
                }
                );
        }

        public async Task Add_AtThread_2(T item_1, T item_2)
        {
            ResultDouble<T> result = new ResultDouble<T>();

            _countThread++;
            _tableThread.AddOrUpdate(_countThread, true, (i, b) => { return true; });

            Thread threadFirst = new Thread(new ParameterizedThreadStart(AddAction));
            threadFirst.IsBackground = true;
            ItemChangeState<T> parameterFirst = new ItemChangeState<T>()
            {
                KeyThread = _countThread,
                Item = item_1
            };

            _countThread++;
            _tableThread.AddOrUpdate(_countThread, true, (i, b) => { return true; });

            Thread threadSecond = new Thread(new ParameterizedThreadStart(AddAction));
            threadSecond.IsBackground = true;
            ItemChangeState<T> parameterSecond = new ItemChangeState<T>()
            {
                KeyThread = _countThread,
                Item = item_2
            };

            threadFirst.Start(parameterFirst);
            threadSecond.Start(parameterSecond);

            result.Value_1 = await Task<T>.Run(
                () =>
                {
                    while (_tableThread[parameterFirst.KeyThread]) { }
                    return parameterFirst.Item;
                }
                );
            result.Value_2 = await Task.Run(
                () =>
                {
                    while (_tableThread[parameterSecond.KeyThread]) { }
                    return parameterSecond.Item;
                }
                );
        }

        public T Take()
        {
            return OnTake();
        }

        public async Task<T> Take_AtTask()
        {
            T result = await Task.Run(
                () =>
                {
                    return OnTake();
                }
                );
            return result;
        }

        public async Task<ResultDouble<T>> Take_AtThread_2()
        {
            ResultDouble<T> result = new ResultDouble<T>();

            _countThread++;
            _tableThread.AddOrUpdate(_countThread, true, (i, b) => { return true; });

            Thread threadFirst = new Thread(new ParameterizedThreadStart(TakeAction));
            threadFirst.IsBackground = true;
            ItemChangeState<T> parameterFirst = new ItemChangeState<T>()
            {
                KeyThread = _countThread
            };

            _countThread++;
            _tableThread.AddOrUpdate(_countThread, true, (i, b) => { return true; });

            Thread threadSecond = new Thread(new ParameterizedThreadStart(TakeAction));
            threadSecond.IsBackground = true;
            ItemChangeState<T> parameterSecond = new ItemChangeState<T>()
            {
                KeyThread = _countThread
            };

            threadFirst.Start(parameterFirst);
            threadSecond.Start(parameterSecond);

            result.Value_1 = await Task<T>.Run(
                () =>
                {
                    while (_tableThread[parameterFirst.KeyThread]) { }
                    return parameterFirst.Item;
                }
                );
            result.Value_2 = await Task.Run(
                () =>
                {
                    while (_tableThread[parameterSecond.KeyThread]) { }
                    return parameterSecond.Item;
                }
                );

            return result;
        }

        protected abstract void CreateCollection(Int32 bufferCapacity);
        protected abstract void OnAdd(T item);
        protected abstract T OnTake();

        private void AddAction(Object obj)
        {
            ItemChangeState<T> parameter = obj as ItemChangeState<T>;
            if (parameter != null)
            {
                OnAdd(parameter.Item);
                _tableThread.AddOrUpdate(parameter.KeyThread, false, (i, b) => { return false; });
            }
        }
        private void TakeAction(Object obj)
        {
            ItemChangeState<T> parameter = obj as ItemChangeState<T>;
            if (parameter != null)
            {
                parameter.Item = OnTake();
                _tableThread.AddOrUpdate(parameter.KeyThread, false, (i, b) => { return false; });
            }
        }
    }

    public class ItemChangeState<T>
    {
        public T Item;
        public Int32 KeyThread;
    }

    public class ResultDouble<T>
    {
        public T Value_1;
        public T Value_2;
    }
}
 