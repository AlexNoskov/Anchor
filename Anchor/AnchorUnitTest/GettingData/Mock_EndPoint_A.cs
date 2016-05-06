using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorUnitTest.GettingData
{
    public abstract class Mock_EndPoint_A : Mock_EndPoint
    {
        public Mock_EndPoint_A(Int32 id)
            : base(id)
        { }

        public Double Operating
        {
            get { return _valueDictionary[Mock_SourceValues.Key_Operative]; }
        }
        public Double Sum
        {
            get { return _valueDictionary[Mock_SourceValues.Key_Sum]; }
        }

        protected abstract Double OperatingValue { get; }
        protected abstract Double SumValue { get; }

        protected override void Fill()
        {
            _valueDictionary.Add(Mock_SourceValues.Key_Operative, OperatingValue);
            _valueDictionary.Add(Mock_SourceValues.Key_Sum, SumValue);
        }
    }

    public class Mock_EndPoint_A100 : Mock_EndPoint_A
    {
        public Mock_EndPoint_A100(Int32 id)
            : base(id)
        { }

        protected override double OperatingValue
        {
            get { return Mock_SourceValues.Value_1; }
        }
        protected override double SumValue
        {
            get { return Mock_SourceValues.Value_100; }
        }
    }

    public class Mock_EndPoint_A300 : Mock_EndPoint_A
    {
        public Mock_EndPoint_A300(Int32 id)
            : base(id)
        { }

        protected override double OperatingValue
        {
            get { return Mock_SourceValues.Value_3; }
        }
        protected override double SumValue
        {
            get { return Mock_SourceValues.Value_300; }
        }
    }
}
