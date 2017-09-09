using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor;

namespace AnchorUnitTest
{
    /// <summary>
    /// Панель тестирования сущности, поддерживающей клонирование.
    /// </summary>    
    public class Panel_Cloneable
    {
        public static void Clone<T>(ICloneable<T> obj)
        {
            T clone = obj.Clone();

            Assert.IsFalse(Object.ReferenceEquals(obj, clone));

            IEquatable<T> objEq = obj as IEquatable<T>;
            if (objEq == null)
                Assert.Inconclusive("Невозможно произвести проверку эвивалентности клона и оригинала");

            Assert.IsTrue(objEq.Equals(clone));
        }
    }
}
