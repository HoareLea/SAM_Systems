using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class LiquidSystem : FluidSystem
    {
        public LiquidSystem(Guid guid, LiquidSystem liquidSystem)
            : base(guid, liquidSystem)
        {
        }

        public LiquidSystem(LiquidSystem liquidSystem) 
            : base(liquidSystem)
        {
        }

        public LiquidSystem(JsonObject jObject)
            : base(jObject)
        {
        }

        public LiquidSystem(string name)
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
            return new LiquidSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
