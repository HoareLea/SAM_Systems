using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public abstract class SystemGroup : SystemObject, ISystemGroup
    {
        public SystemGroup(SystemGroup systemGroup)
            : base(systemGroup)
        {

        }

        public SystemGroup(JObject jObject)
            : base(jObject)
        {

        }

        public abstract List<SystemConnector> SystemConnectors { get; }

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
