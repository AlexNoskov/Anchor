using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor
{
    public class DetectorEvent
    {
        private Boolean _isOccurred;
        private Object _sender;

        public DetectorEvent()
        {
            _sender = null;
            _isOccurred = false;
        }

        public Boolean IsOccurredBy(Object sender)
        {
            if (_sender != null)
            {
                if (_sender == sender)
                {
                    return _isOccurred;
                }
            }

            return false;
        }

        public Boolean IsOccurred
        {
            get { return _isOccurred; }
        }

        public virtual void Occur(Object sender)
        {
            _isOccurred = true;
            _sender = sender;
        }
    }    
}
