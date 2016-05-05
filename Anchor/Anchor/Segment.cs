using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor
{
    public abstract class Segment<TLabel, TSpan> : ISegment<TLabel, TSpan>
    {
        public TLabel Start
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public TLabel End
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public TSpan Span
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public bool IsPoint
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        
        public void SetSegment(TLabel start, TLabel end)
        {
            throw new NotImplementedException();
        }
        public void SetSpan(TSpan span)
        {
            throw new NotImplementedException();
        }
    }
}
