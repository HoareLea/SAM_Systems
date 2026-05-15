using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class CoolingSystem : LiquidSystem
    {
        public CoolingSystem(CoolingSystem coolingSystem) 
            : base(coolingSystem)
        {
        }

        public CoolingSystem(Guid guid, CoolingSystem coolingSystem)
            : base(guid, coolingSystem)
        {
        }

        public CoolingSystem(string name)
            : base(name)
        {
        }

        public CoolingSystem(JsonObject jObject)
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
            return new CoolingSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
