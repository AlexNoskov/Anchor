using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public abstract class Synchronizer<TState> : ISynchronizer<TState>
    {
        protected Synchronizer()
        {
            _set = new HashSet<ISyncItem<TState>>();
        }

        public int EnabledItemCount
        {
            get
            {
                return 0;
            }
        }

        public bool Synchronized
        {
            get
            {
                return false;
            }
        }

        public int Count
        {
            get
            {
                return _set.Count;
            }
        }


        private HashSet<ISyncItem<TState>> _set;

        public bool Add(ISyncItem<TState> item)
        {
            var addItem = item;
            if (_set.Add(item))
            {
                addItem.Enabled += AddItem_Enabled;
                return true;
            }

            return false;
        }
        
        public void Clear()
        {
            _set.Clear();
        }

        public bool Contains(ISyncItem<TState> item)
        {
            return _set.Contains(item);
        }

        public bool Remove(ISyncItem<TState> item)
        {
            return _set.Remove(item);
        }

        private void AddItem_Enabled(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
