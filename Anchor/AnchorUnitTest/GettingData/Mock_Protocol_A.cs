﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anchor.GettingData;

namespace AnchorUnitTest.GettingData
{
    public class Mock_Protocol_A : EndPointAmount<String, Double?>
    {
        protected override string GetCurrentKey()
        {
            return Mock_SourceValues.Key_Operative;
        }
        protected override string GetAmountKey()
        {
            return Mock_SourceValues.Key_Sum;
        }
    }
}
