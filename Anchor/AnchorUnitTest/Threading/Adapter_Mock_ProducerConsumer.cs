using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorUnitTest.Threading
{
    public class Adapter_Mock_ProducerConsumer<T> : Adapter_ProducerConsumer<T>
    {
        public Adapter_Mock_ProducerConsumer(Int32 bufferCapacity)
            : base(bufferCapacity)
        { }
        private Mock_ProducerConsumer<T> _collection;

        public override int BufferCapacity
        {
            get
            { return _collection.BufferCapacity; }
        }

        public override int Count
        {
            get
            { return _collection.Count; }
        }

        protected override void CreateCollection(int bufferCapacity)
        {
            _collection = new Mock_ProducerConsumer<T>(bufferCapacity);
        }

        protected override void OnAdd(T item)
        {
            _collection.Add(item);
        }

        protected override T OnTake()
        {
            return _collection.Take();
        }
    }
}
