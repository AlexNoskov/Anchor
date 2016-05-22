using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public class Rounder_Double : Rounder<Double, Int32, MidpointRounding>
    {
        public Rounder_Double(Int32 precision, MidpointRounding midpointRounding)
            : base(precision, midpointRounding)
        { }

        public override Double Round(Double value)
        {
            return Math.Round(value, Precision, MidLabelPolicy);
        }
    }
}
