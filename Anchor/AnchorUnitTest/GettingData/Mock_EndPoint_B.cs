using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorUnitTest.GettingData
{
    public abstract class Mock_EndPoint_B : Mock_EndPoint
    {
        public Mock_EndPoint_B(Int32 id)
            : base(id)
        { }

        public Double Actual
        {
            get { return _valueDictionary[Mock_SourceValues.Key_Actual]; }
        }
        public Double Total
        {
            get { return _valueDictionary[Mock_SourceValues.Key_Total]; }
        }
        protected abstract Double ActualValue { get; }
        protected abstract Double TotalValue { get; }

        protected override void Fill()
        {
            _valueDictionary.Add(Mock_SourceValues.Key_Actual, ActualValue);
            _valueDictionary.Add(Mock_SourceValues.Key_Total, TotalValue);
        }
    }

    public class Mock_EndPoint_B200 : Mock_EndPoint_B
    {
        public Mock_EndPoint_B200(Int32 id)
            : base(id)
        { }

        protected override double ActualValue
        {
            get { return Mock_SourceValues.Value_2; }
        }

        protected override double TotalValue
        {
            get { return Mock_SourceValues.Value_200; }
        }
    }

    public class Mock_EndPoint_B400 : Mock_EndPoint_B
    {
        public Mock_EndPoint_B400(Int32 id)
            : base(id)
        { }

        protected override double ActualValue
        {
            get { return Mock_SourceValues.Value_4; }
        }

        protected override double TotalValue
        {
            get { return Mock_SourceValues.Value_400; }
        }
    }
}
