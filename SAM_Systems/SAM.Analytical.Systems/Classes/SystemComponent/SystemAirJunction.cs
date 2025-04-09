using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemAirJunction : SystemJunction<AirSystem>, IAirSystemComponent
    {
        public SystemAirJunction()
            : base()
        {

        }

        public SystemAirJunction(SystemAirJunction systemAirJunction)
            : base(systemAirJunction)
        {

        }

        public SystemAirJunction(System.Guid guid, SystemAirJunction systemAirJunction)
            : base(guid, systemAirJunction)
        {

        }

        public SystemAirJunction(JObject jObject)
            : base(jObject)
        {

        }

        public SystemAirJunction(string name)
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
            return new SystemAirJunction(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
