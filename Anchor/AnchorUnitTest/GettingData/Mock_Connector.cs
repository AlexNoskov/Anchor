using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anchor.GettingData;

namespace AnchorUnitTest.GettingData
{
    public class Mock_Connector_AccessSerial_A : EndPointAmountConnector<Int32, String, Double?>
    {
        public Mock_Connector_AccessSerial_A()
            : base(new Mock_Source_AccessSerial(), new Mock_Protocol_A())
        { }
    }

    public class Mock_Connector_SerialAccess_B : EndPointAmountConnector<Int32, String, Double?>
    {
        public Mock_Connector_SerialAccess_B()
            : base(new Mock_Source_AccessSerial(), new Mock_Protocol_B())
        { }
    }

    public class Mock_Connection_RandomAccess_A : EndPointAmountConnector<Int32, String, Double?>
    {
        public Mock_Connection_RandomAccess_A()
            : base(new Mock_Source_AccessRandom(), new Mock_Protocol_A())
        { }
    }

    public class Mock_Connection_RandomAccess_B : EndPointAmountConnector<Int32, String, Double?>
    {
        public Mock_Connection_RandomAccess_B()
            : base(new Mock_Source_AccessRandom(), new Mock_Protocol_B())
        { }
    }
}
