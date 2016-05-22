using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    [TestClass]
    public class UnitTest_Rounder_Double
    {
        private Int32 _precision_3;
        private MidpointRounding _afz;
        private Rounder_Double _rounder_3Digit_Afz;
        [TestInitialize]
        public void Init()
        {
            _precision_3 = 3;
            _afz = MidpointRounding.AwayFromZero;
            _rounder_3Digit_Afz = new Rounder_Double(_precision_3, _afz);
        }

        [TestMethod]
        public void Rounder_Double_StartState()
        {
            Panel_Rounder<Double, Int32, MidpointRounding>.StartState(
                _rounder_3Digit_Afz, _precision_3, _afz);
        }

        [TestMethod]
        public void Rounder_Double_Round()
        {
            Panel_Rounder<Double, Int32, MidpointRounding>.Round(
                _rounder_3Digit_Afz, 1.9994, 1.999);

            Panel_Rounder<Double, Int32, MidpointRounding>.Round(
                _rounder_3Digit_Afz, 1.9995, 2.0);
        }
    }
}
