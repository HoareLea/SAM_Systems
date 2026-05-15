using System.Text.Json.Nodes;
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

        public SystemAirJunction(JsonObject jObject)
            : base(jObject)
        {

        }

        public SystemAirJunction(string name)
            : base(name)
        {

        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            return base.FromJsonObject(jObject);
        }

        public override JsonObject ToJsonObject()
        {
            return base.ToJsonObject();
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemAirJunction(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
