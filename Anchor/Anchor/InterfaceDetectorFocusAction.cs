﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public interface IDetectorFocusAction
    {
        void NotifyFocusCurrentItem();
        void NotifyUnfocusPreviosItem();
    }
}
