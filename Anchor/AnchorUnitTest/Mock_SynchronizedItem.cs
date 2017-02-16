using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anchor;

namespace AnchorUnitTest
{
    public abstract class Mock_SyncItem<TState> : ISynchronizedItem<TState>
    {
        public TState State
        {
            get; 
            protected set;
        }

        public abstract bool Sync(TState state);
    }

    public class Mock_SyncItemSuccess<TState> : Mock_SyncItem<TState>
    {
        public override bool Sync(TState state)
        {
            State = state;
            return true;
        }
    }

    public class Mock_SyncItemFail<TState> : Mock_SyncItem<TState>
    {
        public override bool Sync(TState state)
        {   
            return false;
        }
    }
}
