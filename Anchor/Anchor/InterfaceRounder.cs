using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor
{
    public interface IRounder<T>
    {
        T Round(T value);
    }
}
