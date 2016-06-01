using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;
namespace AnchorUnitTest
{
    /// <summary>
    /// Панель тестирования интерфейса сервиса, определяющего факт пересечения.
    /// </summary>    
    public class Panel_InterfaceIntersected<TLabel, TSpan>
    {
        public static void LabelLessStart(IIntersected<TLabel, TSpan> intersected, TLabel label)
        {
            Assert.Inconclusive();
        }

        public static void LabelMoreEnd(IIntersected<TLabel, TSpan> intersected, TLabel label)
        {
            Assert.Inconclusive();
        }

        public static void LabelOn(IIntersected<TLabel, TSpan> intersected)
        {
            Assert.Inconclusive();
        }
    }
}
