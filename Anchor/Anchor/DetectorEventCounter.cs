using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    /// <summary>
    /// Детектор события с подсчетом фактов.
    /// </summary>
    public class DetectorEventCounter : DetectorEvent
    {
        private Int32 _count;

        public DetectorEventCounter()
            : base()
        {
            _count = 0;
        }

        public Int32 Count
        {
            get { return _count; }
        }

        public override void Occur(object sender)
        {
            base.Occur(sender);
            _count++;
        }
    }
}
