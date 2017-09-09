using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public interface IEnabledItem
    {
        Boolean IsEnabled { get; }
        event EventHandler Enabled;
        event EventHandler Disabled;
    }
}
