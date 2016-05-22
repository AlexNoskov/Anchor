using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public abstract class Rounder<TValue, TPrecision, TMidLabelPolicy> : IRounder<TValue>
    {
        public Rounder(TPrecision precision, TMidLabelPolicy midLabelPolicy)
        {
            this.Precision = precision;
            this.MidLabelPolicy = midLabelPolicy;
        }

        public TPrecision Precision
        { get; private set; }
        public TMidLabelPolicy MidLabelPolicy
        { get; private set; }

        public abstract TValue Round(TValue value);
    }
}
