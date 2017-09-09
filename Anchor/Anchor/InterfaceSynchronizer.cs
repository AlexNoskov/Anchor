using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public interface ISynchronizer<TState>
    {
        Int32 EnabledItemCount { get; }
        Boolean Synchronized { get; }

        Int32 Count { get; }
        Boolean Add(ISyncItem<TState> item);
        Boolean Remove(ISyncItem<TState> item);
        Boolean Contains(ISyncItem<TState> item);
        void Clear();
    }
}
