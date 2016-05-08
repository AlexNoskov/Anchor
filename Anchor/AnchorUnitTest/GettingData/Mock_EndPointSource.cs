using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anchor.GettingData;

namespace AnchorUnitTest.GettingData
{
    public abstract class Mock_EndPointSource : EndPointSource<Int32, String, Double?>
    {
        protected Mock_EndPointSource()
            : base()
        {
            _endPointDictionary = new Dictionary<int, EndPoint<Int32, String, Double?>>();
            CreateEndPoints();
        }

        public override int EndPointCount
        {
            get { return _endPointDictionary.Count; }
        }

        protected Dictionary<Int32, EndPoint<Int32, String, Double?>> _endPointDictionary;

        protected abstract void CreateEndPoints();
        protected override void OnDisconnect()
        { }
    }
}
