using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor.GettingData;
using AnchorUnitTest;

namespace AnchorUnitTest.GettingData
{   
    public class Panel_EndPointSource<TEndPointId, TKey, TValue>
    {
        public static void StartState(SourceEndPoint<TEndPointId, TKey, TValue> port)
        {
            Assert.IsTrue(port.EndPointCount == 2);
            Assert.IsNull(port.ConnectedPoint);
        }

        public static void Connect(SourceEndPoint<TEndPointId, TKey, TValue> port, TEndPointId startId, TEndPointId nextId)
        {
            Assert.IsNull(port.ConnectedPoint);

            Assert.IsTrue(port.Connect(startId));
            Assert.IsTrue(port.ConnectedPoint.Id.Equals(startId));

            Assert.IsTrue(port.Connect(startId));
            Assert.IsTrue(port.ConnectedPoint.Id.Equals(startId));

            Assert.IsTrue(port.Connect(nextId));
            Assert.IsTrue(port.ConnectedPoint.Id.Equals(nextId));
        }

        public static void Connect_Absent(SourceEndPoint<TEndPointId, TKey, TValue> port, TEndPointId wrongId)
        {
            Assert.IsFalse(port.Connect(wrongId));
            DefaultValue_Panel<EndPoint<TEndPointId, TKey, TValue>>.IsDefault(port.ConnectedPoint);
        }

        public static void Disconnect(SourceEndPoint<TEndPointId, TKey, TValue> port, TEndPointId validId)
        {
            DefaultValue_Panel<EndPoint<TEndPointId, TKey, TValue>>.IsDefault(port.ConnectedPoint);
            port.Disconnect();
            DefaultValue_Panel<EndPoint<TEndPointId, TKey, TValue>>.IsDefault(port.ConnectedPoint);
            port.Connect(validId);
            DefaultValue_Panel<EndPoint<TEndPointId, TKey, TValue>>.IsNotDefault(port.ConnectedPoint);
            port.Disconnect();
            DefaultValue_Panel<EndPoint<TEndPointId, TKey, TValue>>.IsDefault(port.ConnectedPoint);
        }

        public static void Send(SourceEndPoint<TEndPointId, TKey, TValue> port, TEndPointId validId, TKey validKey, TKey wrongKey)
        {
            DefaultValue_Panel<EndPoint<TEndPointId, TKey, TValue>>.IsDefault(port.ConnectedPoint);
            TValue receiveValue = port.Send(validKey);
            DefaultValue_Panel<TValue>.IsDefault(receiveValue);

            port.Connect(validId);
            DefaultValue_Panel<EndPoint<TEndPointId, TKey, TValue>>.IsNotDefault(port.ConnectedPoint);

            receiveValue = port.Send(wrongKey);
            DefaultValue_Panel<TValue>.IsDefault(receiveValue);

            receiveValue = port.Send(validKey);
            DefaultValue_Panel<TValue>.IsNotDefault(receiveValue);
        }
    }
}
