using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorUnitTest.Threading
{
    public class Adapter_BlockingCollection<T> : Adapter_ProducerConsumer<T>
    {
        public Adapter_BlockingCollection(Int32 bufferCapacity)
            : base(bufferCapacity)
        { }

        private BlockingCollection<T> _blockingCollection;

        public override int BufferCapacity
        {
            get
            {
                return _blockingCollection.BoundedCapacity;
            }
        }
        public override int Count
        {
            get
            {
                return _blockingCollection.Count;
            }
        }

        protected override void CreateCollection(int bufferCapacity)
        {
            _blockingCollection = new BlockingCollection<T>(bufferCapacity);
        }

        protected override void OnAdd(T item)
        {
            _blockingCollection.Add(item);
        }

        protected override T OnTake()
        {
            return _blockingCollection.Take();
        }
    }
}
