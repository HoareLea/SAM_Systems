using System.Text.Json.Nodes;
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

        public HeatingSystem(JsonObject jObject)
            : base(jObject)
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
            return new HeatingSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
