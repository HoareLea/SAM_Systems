using Newtonsoft.Json.Linq;
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

        public CoolingSystem(JObject jObject)
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
            return new CoolingSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
