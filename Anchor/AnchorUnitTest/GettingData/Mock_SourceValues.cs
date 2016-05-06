using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorUnitTest.GettingData
{
    public static class Mock_SourceValues
    {
        static Mock_SourceValues()
        {
            EndPoint_A100 = new Mock_EndPoint_A100(Id_1);
            EndPoint_B200 = new Mock_EndPoint_B200(Id_2);

            EndPoint_A300 = new Mock_EndPoint_A300(Id_1);
            EndPoint_B400 = new Mock_EndPoint_B400(Id_2);
        }

        public static Int32 Id_Absent { get { return 0; } }
        public static Int32 Id_1 { get { return 1; } }
        public static Int32 Id_2 { get { return 2; } }

        public static String Key_Operative { get { return "Operative"; } }
        public static String Key_Sum { get { return "Sum"; } }
        public static String Key_Actual { get { return "Actual"; } }
        public static String Key_Total { get { return "Total"; } }

        public static Double Value_1 { get { return 1.0; } }
        public static Double Value_2 { get { return 2.0; } }
        public static Double Value_3 { get { return 3.0; } }
        public static Double Value_4 { get { return 4.0; } }

        public static Double Value_100 { get { return 100.0; } }
        public static Double Value_200 { get { return 200.0; } }
        public static Double Value_300 { get { return 300.0; } }
        public static Double Value_400 { get { return 400.0; } }

        public static Mock_EndPoint_A100 EndPoint_A100 { get; private set; }
        public static Mock_EndPoint_B200 EndPoint_B200 { get; private set; }
        public static Mock_EndPoint_A300 EndPoint_A300 { get; private set; }
        public static Mock_EndPoint_B400 EndPoint_B400 { get; private set; }
    }
}
