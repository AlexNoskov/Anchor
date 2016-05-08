using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnchorUnitTest
{
    /// <summary>
    /// Панель проверки значения на равенство значению по умолчанию своего типа.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Panel_DefaultValue<T>
    {
        public static void IsDefault(T value)
        {
            if (default(T) == null)
            {
                Assert.IsNull(value);
            }
            else
            {
                Assert.IsTrue(value.Equals(default(T)));
            }
        }
        public static void IsNotDefault(T value)
        {
            if (default(T) == null)
            {
                Assert.IsNotNull(value);
            }
            else
            {
                Assert.IsFalse(value.Equals(default(T)));
            }
        }
    }
}
