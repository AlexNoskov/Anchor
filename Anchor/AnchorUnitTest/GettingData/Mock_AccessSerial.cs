using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anchor.GettingData;

namespace AnchorUnitTest.GettingData
{
    public class Mock_Source_SerialAccess : Mock_SourceEndPoint
    {
        protected override void CreateEndPoints()
        {
            Mock_EndPoint_A100 endPoint_Key_1 = new Mock_EndPoint_A100(Mock_SourceValues.Id_1);
            _endPointDictionary.Add(endPoint_Key_1.Id, endPoint_Key_1);

            Mock_EndPoint_B200 endPoint_Parameter_2 = new Mock_EndPoint_B200(Mock_SourceValues.Id_2);
            _endPointDictionary.Add(endPoint_Parameter_2.Id, endPoint_Parameter_2);
        }

        protected override bool TryConnect(int endPoint_Id, out EndPoint<Int32, String, Double?> connected)
        {
            foreach (var pair in _endPointDictionary)
            {
                if (pair.Key == endPoint_Id)
                {
                    connected = pair.Value;
                    return true;
                }
            }

            connected = null;
            return false;
        }
    }
}
