using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public interface ISynchronizedItem<TState>
    {
        TState State { get; }
        Boolean Sync(TState state);
    }
}
