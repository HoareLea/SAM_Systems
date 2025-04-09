using Newtonsoft.Json.Linq;
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

        public LiquidSystem(JObject jObject)
            : base(jObject)
        {
        }

        public LiquidSystem(string name)
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
            return new LiquidSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
