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

    public class Mock_SynchronizerItem<TState> : ISyncItem<TState>
    {
        public event EventHandler Disabled;
        public event EventHandler Enabled;

        public bool IsEnabled
        {
            get; private set;
        }

        public TState State
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        
        public bool Sync(TState state)
        {
            throw new NotImplementedException();
        }

        public void Enable()
        {
            IsEnabled = true;
            NotifyEnabled();
        }
        public void Disable()
        {
            IsEnabled = false;
            NotifyDisabled();
        }

        private void NotifyEnabled()
        {
            Enabled?.Invoke(this, new EventArgs());
        }
        private void NotifyDisabled()
        {
            Disabled?.Invoke(this, new EventArgs());
        }
    }
}
