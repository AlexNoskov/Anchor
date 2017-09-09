using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor
{
    public abstract class Segment<TLabel, TSpan> : 
        ISegment<TLabel, TSpan>, IIntersected<TLabel, TSpan>
        where TLabel : IComparable<TLabel>
    {
        protected Segment(TLabel start, TLabel end)
        {
            this.SetSegment(start, end);
        }
        protected Segment()
            : this(default(TLabel), default(TLabel))
        { }

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

        public bool IsIntersected(TLabel label)
        {
            return Range<TLabel>.BelongsDirectOrderBound(label, _start, _end);
        }

        public bool IsIntersected(ISegment<TLabel, TSpan> segment)
        {
            if (segment != null)
            {
                return !(_end.CompareTo(segment.Start) < 0 || _start.CompareTo(segment.End) > 0);
            }
            return false;
        }

        public bool IsPartOf(ISegment<TLabel, TSpan> segment)
        {
            if (segment != null)
            {
                Int32 compareStart = _start.CompareTo(segment.Start);
                Int32 compareEnd = _end.CompareTo(segment.End);

                return (compareStart >= 0 && compareEnd <= 0);
            }
            return false;
        }

        public bool Equals(ISegment<TLabel, TSpan> other)
        {
            return this.Start.Equals(other.Start) && this.End.Equals(other.End);
        }

        public abstract ISegment<TLabel, TSpan> Clone();

        public void Shift(TSpan shift)
        {
            if (IsZero(shift))
                return;

            TLabel nextStart = ShiftLabelCycle(Start, shift);
            TLabel nextEnd = ShiftLabelCycle(End, shift);

            if (IsNegate(shift))
            {
                if (nextStart.CompareTo(Start) <= 0)
                {
                    if (nextEnd.CompareTo(End) <= 0)
                    { this.SetSegment(nextStart, nextEnd); }
                }
            }

            if (nextStart.CompareTo(Start) >= 0)
            {
                if (nextEnd.CompareTo(End) >= 0)
                { this.SetSegment(nextStart, nextEnd); }
            }
        }

        protected abstract TLabel ShiftLabelCycle(TLabel label, TSpan shift);
        protected abstract bool IsNegate(TSpan span);
        protected abstract bool IsZero(TSpan span);
    }
}
