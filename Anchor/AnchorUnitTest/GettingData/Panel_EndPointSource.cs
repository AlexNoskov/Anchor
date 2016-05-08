using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anchor.GettingData;
using AnchorUnitTest;

namespace AnchorUnitTest.GettingData
{   /// <summary>
/// Панель тестирования контейнера конечных точек.
/// </summary>
/// <typeparam name="TEndPointId"></typeparam>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TValue"></typeparam>
    public class Panel_EndPointSource<TEndPointId, TKey, TValue>
    {
        public static void StartState(EndPointSource<TEndPointId, TKey, TValue> source)
        {
            Assert.IsTrue(source.EndPointCount == 2);
            Assert.IsNull(source.ConnectedPoint);
        }

        public static void Connect(EndPointSource<TEndPointId, TKey, TValue> source, TEndPointId startId, TEndPointId nextId)
        {
            Assert.IsNull(source.ConnectedPoint);

            Assert.IsTrue(source.Connect(startId));
            Assert.IsTrue(source.ConnectedPoint.Id.Equals(startId));

            Assert.IsTrue(source.Connect(startId));
            Assert.IsTrue(source.ConnectedPoint.Id.Equals(startId));

            Assert.IsTrue(source.Connect(nextId));
            Assert.IsTrue(source.ConnectedPoint.Id.Equals(nextId));
        }

        public static void Connect_Absent(EndPointSource<TEndPointId, TKey, TValue> source, TEndPointId wrongId)
        {
            Assert.IsFalse(source.Connect(wrongId));
            Panel_DefaultValue<EndPoint<TEndPointId, TKey, TValue>>.IsDefault(source.ConnectedPoint);
        }

        public static void Disconnect(EndPointSource<TEndPointId, TKey, TValue> source, TEndPointId validId)
        {
            Panel_DefaultValue<EndPoint<TEndPointId, TKey, TValue>>.IsDefault(source.ConnectedPoint);
            source.Disconnect();
            Panel_DefaultValue<EndPoint<TEndPointId, TKey, TValue>>.IsDefault(source.ConnectedPoint);
            source.Connect(validId);
            Panel_DefaultValue<EndPoint<TEndPointId, TKey, TValue>>.IsNotDefault(source.ConnectedPoint);
            source.Disconnect();
            Panel_DefaultValue<EndPoint<TEndPointId, TKey, TValue>>.IsDefault(source.ConnectedPoint);
        }

        public static void Send(EndPointSource<TEndPointId, TKey, TValue> source, TEndPointId validId, TKey validKey, TKey wrongKey)
        {
            Panel_DefaultValue<EndPoint<TEndPointId, TKey, TValue>>.IsDefault(source.ConnectedPoint);
            TValue receiveValue = source.Send(validKey);
            Panel_DefaultValue<TValue>.IsDefault(receiveValue);

            source.Connect(validId);
            Panel_DefaultValue<EndPoint<TEndPointId, TKey, TValue>>.IsNotDefault(source.ConnectedPoint);

            receiveValue = source.Send(wrongKey);
            Panel_DefaultValue<TValue>.IsDefault(receiveValue);

            receiveValue = source.Send(validKey);
            Panel_DefaultValue<TValue>.IsNotDefault(receiveValue);
        }
    }
}
