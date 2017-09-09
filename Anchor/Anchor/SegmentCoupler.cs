using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public class SegmentCoupler<TLabel, TSpan> : ISegment<TLabel, TSpan>, ISegmentCoupler<TLabel, TSpan>
        where TLabel : IComparable<TLabel>
    {
        public SegmentCoupler(ISegment<TLabel, TSpan> originalSegment, TSpan spanCoupler)
        { }

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

        public TLabel StartCoupler
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public TLabel EndCoupler
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

        public void SetSpanCoupler(TSpan spanCoupler)
        {
            throw new NotImplementedException();
        }

        public void Shift(TSpan shift)
        {
            throw new NotImplementedException();
        }

        public bool Equals(ISegment<TLabel, TSpan> other)
        {
            throw new NotImplementedException();
        }

        public ISegment<TLabel, TSpan> Clone()
        {
            throw new NotImplementedException();
        }
    }
}
