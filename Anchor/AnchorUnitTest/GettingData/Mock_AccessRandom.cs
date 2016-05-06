using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anchor.GettingData;

namespace AnchorUnitTest.GettingData
{
    public class Mock_Source_RandomAccess : Mock_SourceEndPoint
    {
        protected override void CreateEndPoints()
        {
            Mock_EndPoint_A300 endPoint_Key_1 = new Mock_EndPoint_A300(Mock_SourceValues.Id_1);
            _endPointDictionary.Add(endPoint_Key_1.Id, endPoint_Key_1);

            Mock_EndPoint_B400 endPoint_Parameter_2 = new Mock_EndPoint_B400(Mock_SourceValues.Id_2);
            _endPointDictionary.Add(endPoint_Parameter_2.Id, endPoint_Parameter_2);
        }

        protected override bool TryConnect(int endPoint_Id, out EndPoint<Int32, String, Double?> connected)
        {
            if (_endPointDictionary.ContainsKey(endPoint_Id))
            {
                connected = _endPointDictionary[endPoint_Id];
                return true;
            }

            connected = null;
            return false;
        }
    }
}
