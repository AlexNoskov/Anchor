using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnchorUnitTest.Threading
{
    public class Mock_ProducerConsumer<T>
    {
        public Mock_ProducerConsumer(Int32 bufferCapacity)
        {
            _lock = new Object();
            _bufferCapacity = bufferCapacity;
            _queue = new Queue<T>(_bufferCapacity);
        }

        private Object _lock;
        private Int32 _bufferCapacity;
        private Queue<T> _queue;

        public Int32 Count
        { get { return _queue.Count; } }
        public Int32 BufferCapacity
        { get { return _bufferCapacity; } }

        public void Add(T item)
        {
            Monitor.Enter(_lock);

            while (_queue.Count == _bufferCapacity)
            {
                Monitor.Wait(_lock);
            }

            _queue.Enqueue(item);

            if (_queue.Count == 1)
            {
                Monitor.PulseAll(_lock);
            }

            Monitor.Exit(_lock);
        }

        public T Take()
        {
            Monitor.Enter(_lock);

            while (_queue.Count == 0)
            {
                Monitor.Wait(_lock);
            }

            T result = _queue.Dequeue();

            if (_queue.Count < _bufferCapacity)
            {
                Monitor.PulseAll(_lock);
            }

            Monitor.Exit(_lock);

            return result;
        }
    }
}
