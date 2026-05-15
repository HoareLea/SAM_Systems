using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class AirSystemGroup : SystemGroup<AirSystem>
    {
        public AirSystemGroup()
            : base()
        {
        }

        public AirSystemGroup(string name)
            : base(name)
        {
        }

        public AirSystemGroup(JsonObject jObject)
            : base(jObject)
        {

        }

        public AirSystemGroup(AirSystemGroup airSystemGroup)
            : base(airSystemGroup)
        {

        }

        public AirSystemGroup(Guid guid, AirSystemGroup airSystemGroup)
            : base(guid, airSystemGroup)
        {

        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new AirSystemGroup(guid == null ? Guid.NewGuid() : guid.Value, this);
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            return true;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if (result == null)
            {
                return null;
            }

            return result;
        }
    }
}
