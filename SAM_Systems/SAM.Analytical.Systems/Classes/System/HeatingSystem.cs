using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class HeatingSystem : LiquidSystem
    {
        public HeatingSystem(HeatingSystem heatingSystem) 
            : base(heatingSystem)
        {
        }

        public HeatingSystem(System.Guid guid, HeatingSystem heatingSystem)
            : base(guid, heatingSystem)
        {
        }

        public HeatingSystem(string name)
            : base(name)
        {
        }

        public HeatingSystem(JObject jObject)
            : base(jObject)
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

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new HeatingSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
