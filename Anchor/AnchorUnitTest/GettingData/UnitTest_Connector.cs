using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnchorUnitTest.GettingData
{
    /// <summary>
    /// Сводное описание для UnitTest_Connector
    /// </summary>
    [TestClass]
    public class UnitTest_Connector
    {
        private Mock_Source_AccessSerial _accessSerial;
        private Mock_Source_AccessRandom _accessRandom;

        [TestInitialize]
        public void Init()
        {
            _accessSerial = new Mock_Source_AccessSerial();
            _accessRandom = new Mock_Source_AccessRandom();
        }

        [TestMethod]
        public void EndPointSource_Mock_Serial_StartState()
        {
            Panel_EndPointSource<Int32, String, Double?>.StartState(_accessSerial);
        }
        [TestMethod]
        public void EndPointSource_Mock_Random_StartState()
        {
            Panel_EndPointSource<Int32, String, Double?>.StartState(_accessRandom);
        }

        [TestMethod]
        public void EndPointSource_Mock_Serial_Connect()
        {
            Panel_EndPointSource<Int32, String, Double?>.Connect(_accessSerial, Mock_SourceValues.Id_1, Mock_SourceValues.Id_2);
        }
        [TestMethod]
        public void EndPointSource_Mock_Random_Connect()
        {
            Panel_EndPointSource<Int32, String, Double?>.Connect(_accessRandom, Mock_SourceValues.Id_1, Mock_SourceValues.Id_2);
        }

        [TestMethod]
        public void EndPointSource_Mock_Serial_Connect_Absent()
        {
            Panel_EndPointSource<Int32, String, Double?>.Connect_Absent(_accessSerial, Mock_SourceValues.Id_Absent);
        }
        [TestMethod]
        public void EndPointSource_Mock_Random_Connect_Absent()
        {
            Panel_EndPointSource<Int32, String, Double?>.Connect_Absent(_accessRandom, Mock_SourceValues.Id_Absent);
        }

        [TestMethod]
        public void EndPointSource_Mock_Serial_Disconnect()
        {
            Panel_EndPointSource<Int32, String, Double?>.Disconnect(_accessSerial, Mock_SourceValues.Id_1);
        }
        [TestMethod]
        public void EndPointSource_Mock_Random_Disconnect()
        {
            Panel_EndPointSource<Int32, String, Double?>.Disconnect(_accessRandom, Mock_SourceValues.Id_1);
        }

        [TestMethod]
        public void EndPointSource_Mock_Serial_Send()
        {
            Panel_EndPointSource<Int32, String, Double?>.Send(_accessSerial, Mock_SourceValues.Id_1, Mock_SourceValues.Key_Operative, Mock_SourceValues.Key_Actual);
        }
        [TestMethod]
        public void EndPointSource_Mock_Random_Send()
        {
            Panel_EndPointSource<Int32, String, Double?>.Send(_accessRandom, Mock_SourceValues.Id_1, Mock_SourceValues.Key_Operative, Mock_SourceValues.Key_Actual);
        }
    }
}
