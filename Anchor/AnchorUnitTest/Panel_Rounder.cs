using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    /// <summary>
    /// Панель тестирования сервиса, определяющего округленное значение.
    /// </summary>    
    public class Panel_Rounder<TValue, TPrecision, TMidLabelPolicy>
    {
        public static void StartState(Rounder<TValue, TPrecision, TMidLabelPolicy> rounder, TPrecision etalonPrecision, TMidLabelPolicy etalonMidLabelPolicy)
        {
            Assert.AreEqual(rounder.Precision, etalonPrecision);
            Assert.AreEqual(rounder.MidLabelPolicy, etalonMidLabelPolicy);            
        }
        public static void Round(IRounder<TValue> rounder, TValue value, TValue etalonRoundValue)
        {
            TValue previousValue = value;
            TValue roundValue = rounder.Round(value);
            Assert.AreEqual<TValue>(etalonRoundValue, roundValue);
            Assert.AreEqual<TValue>(previousValue, value);
        }
    }
}
