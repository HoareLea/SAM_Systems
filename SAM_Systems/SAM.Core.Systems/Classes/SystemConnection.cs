using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public class SystemConnection : SAMObject, ISystemConnection
    {
        private SystemType systemType;
        private Dictionary<Guid, int> dictionary;

        public List<SystemConnector> SystemConnectors
        {
            get
            {
                return new List<SystemConnector>()
                {
                    Create.SystemConnector<IControlSystem>(),
                };
            }
        }

        public SystemConnection(SystemConnection systemConnection)
            : base(systemConnection)
        {

        }

        public SystemConnection(JObject jObject)
            : base(jObject)
        {

        }

        public SystemConnection()
            : base(typeof(SystemConnection).Name)
        {

        }

        public SystemConnection(Guid guid)
            : base(guid, typeof(SystemConnection).Name)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            return base.FromJObject(jObject);
        }

        public override JObject ToJObject()
        {
            return base.ToJObject();
        }
    }
}
