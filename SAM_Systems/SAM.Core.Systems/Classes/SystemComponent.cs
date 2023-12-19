using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public abstract class SystemComponent : SystemObject, ISystemComponent
    {
        public SystemComponent(SystemComponent systemComponent)
            : base(systemComponent)
        {

        }

        public SystemComponent(JObject jObject)
            : base(jObject)
        {

        }

        public SystemComponent(string name)
            : base(name)
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
