using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor
{
    /// <summary>
    /// Детектор события.
    /// </summary>
    public class DetectorEvent
    {
        private Boolean _isOccurred;
        private Object _sender;

        public DetectorEvent()
        {
            _sender = null;
            _isOccurred = false;
        }
        /// <summary>
        /// Метод, результат которого показывает факт события от конкретного источника.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Свойство, показывающее факт события.
        /// </summary>
        public Boolean IsOccurred
        {
            get { return _isOccurred; }
        }
        /// <summary>
        /// Метод уведомления о факте события.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        public virtual void Occur(Object sender)
        {
            _isOccurred = true;
            _sender = sender;
        }
    }    
}
