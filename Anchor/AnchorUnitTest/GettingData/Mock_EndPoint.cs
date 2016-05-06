using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anchor.GettingData;

namespace AnchorUnitTest.GettingData
{
    public abstract class Mock_EndPoint : EndPoint<Int32, String, Double?>
    {
        protected Mock_EndPoint(Int32 id)
            : base(id)
        {
            _valueDictionary = new Dictionary<string, double>();
            Fill();
        }

        protected Dictionary<String, Double> _valueDictionary;

        public override double? GetValue(string key)
        {
            if (_valueDictionary.ContainsKey(key))
            {
                return _valueDictionary[key];
            }

            return null;
        }

        protected abstract void Fill();
    }
}
