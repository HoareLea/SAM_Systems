using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class AirSystem : FluidSystem
    {
        public AirSystem(AirSystem airSystem) 
            : base(airSystem)
        {
        }

        public AirSystem(System.Guid guid, AirSystem airSystem)
            : base(guid, airSystem)
        {
        }

        public AirSystem(JObject jObject)
            : base(jObject)
        {
        }

        public AirSystem(string name)
            : base(name)
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
            return new AirSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
