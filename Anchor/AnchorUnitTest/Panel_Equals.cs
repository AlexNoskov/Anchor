using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnchorUnitTest
{
    /// <summary>
    /// Панель тестирования на эквивалентность
    /// </summary>    
    public static class Panel_Equals
    {
        public static void Check_null(Object obj)
        {
            Assert.IsFalse(obj.Equals(null));
        }

        public static void Himself(Object obj)
        {   
            Assert.IsTrue(obj.Equals(obj));
        }

        public static void Similar(Object obj, Object similar)
        {
            Assert.IsNotNull(similar);
            Assert.IsFalse(Object.ReferenceEquals(obj, similar));
            Assert.IsTrue(obj.Equals(obj));
        }

        public static void Another(Object obj, Object another)
        {
            Assert.IsNotNull(another);
            Assert.IsFalse(Object.ReferenceEquals(obj, another));
            Assert.IsFalse(obj.Equals(another));
        }

        public static void Himself<T>(IEquatable<T> objEquatable)
        {
            Assert.IsTrue(objEquatable.Equals((T)objEquatable));
        }

        public static void Similar<T>(IEquatable<T> objEquatable, T similar)
        {
            Assert.IsNotNull(similar);
            Assert.IsFalse(Object.ReferenceEquals(objEquatable, similar));
            Assert.IsTrue(objEquatable.Equals(similar));
        }

        public static void Another<T>(IEquatable<T> objEquatable, T another)
        {
            Assert.IsNotNull(another);
            Assert.IsFalse(Object.ReferenceEquals(objEquatable, another));
            Assert.IsFalse(objEquatable.Equals(another));
        }
    }
}
