using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public abstract class SegmentWithRound<TLabel, TSpan> : ISegment<TLabel, TSpan>, ISegmentWithRound<TLabel, TSpan>
        where TLabel : IComparable<TLabel>
    {
        public SegmentWithRound(ISegment<TLabel, TSpan> segment, IRounder<TLabel> rounder)
        {
            _segmentOriginal = segment;
            Rounder = rounder;
        }

        public TLabel Start
        {
            get
            {
                if (_segmentOriginal != null)
                {
                    return _segmentOriginal.Start;
                }
                return default(TLabel);
            }
        }
        public TLabel End
        {
            get
            {
                if (_segmentOriginal != null)
                {
                    return _segmentOriginal.End;
                }
                return default(TLabel);
            }
        }
        public bool IsPoint
        {
            get
            {
                if (_segmentOriginal != null)
                {
                    return _segmentOriginal.IsPoint;
                }

                return true;
            }
        }
        public TSpan Span
        {
            get
            {
                return _segmentOriginal.Span;
            }
        }

        public IRounder<TLabel> Rounder
        {
            get; set;
        }
        public TLabel StartRoundValue
        {
            get
            {
                return Round(_segmentOriginal.Start);
            }
        }
        public TLabel EndRoundValue
        {
            get
            {
                return Round(_segmentOriginal.End);
            }
        }
        
        private ISegment<TLabel, TSpan> _segmentOriginal;
        
        public void SetSegment(TLabel start, TLabel end)
        {
            if (_segmentOriginal != null)
            { _segmentOriginal.SetSegment(start, end); }
        }
        public void SetSpan(TSpan span)
        {
            if (_segmentOriginal != null)
            { _segmentOriginal.SetSpan(span); }
        }

        protected TLabel Round(TLabel label)
        {
            if (Rounder != null)
            {
                return Rounder.Round(label);
            }

            return label;
        }
    }
}
