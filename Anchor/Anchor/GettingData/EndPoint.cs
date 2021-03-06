﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor.GettingData
{
    public abstract class EndPoint<TEndPointId, TKey, TValue>
    {
        protected EndPoint(TEndPointId id)
        {
            Id = id;
        }

        public TEndPointId Id
        { get; protected set; }

        public abstract TValue GetValue(TKey key);
    }
}
