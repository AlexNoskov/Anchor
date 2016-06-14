using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor
{
    public abstract class Segment<TLabel, TSpan> : ISegment<TLabel, TSpan>
        where TLabel : IComparable<TLabel>
    {
        public TLabel Start
        {
            get
            {
                return _start;
            }
        }
        public TLabel End
        {
            get
            {
                return _end;
            }
        }
        public TSpan Span
        {
            get
            {
                return _span;
            }
        }
        public bool IsPoint
        {
            get
            {
                return _start.CompareTo(_end) == 0;
            }
        }

        private TLabel _start;
        private TLabel _end;
        private TSpan _span;

        public void SetSegment(TLabel start, TLabel end)
        {
            _start = start;
            if (start.CompareTo(end) == -1)
            {
                _end = end;
            }
            else
            { _end = _start; }
        }
        public void SetSpan(TSpan span)
        {
            if (IsValidSpan(span))
            {
                TLabel nextEnd = GetEndAtSpan(span);
                this.SetSegment(_start, nextEnd);
            }
        }
        
        protected abstract Boolean IsValidSpan(TSpan span);
        protected abstract TLabel GetEndAtSpan(TSpan span);
    }
}
