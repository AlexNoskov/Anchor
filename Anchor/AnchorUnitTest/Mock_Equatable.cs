using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorUnitTest
{
    public class Mock_Similar
    {
        public override bool Equals(object obj)
        {
            return true;
        }
        public override int GetHashCode()
        {
            return 0;
        }
    }

    public class Mock_Equatable : IEquatable<Mock_Equatable>
    {
        public bool Equals(Mock_Equatable other)
        {
            return base.Equals(other);
        }
    }

    public class Mock_Another<T> : IEquatable<T>
    {
        public bool Equals(T other)
        {
            return false;
        }
    }

    public class Mock_Similar<T> : IEquatable<T>
    {
        public bool Equals(T other)
        {
            return true;
        }
    }
}
