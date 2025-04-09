using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class DomesticHotWaterSystem : LiquidSystem
    {
        public DomesticHotWaterSystem(Guid guid, DomesticHotWaterSystem domesticHotWaterSystem)
            : base(guid, domesticHotWaterSystem)
        {
        }

        public DomesticHotWaterSystem(DomesticHotWaterSystem domesticHotWaterSystem) 
            : base(domesticHotWaterSystem)
        {
        }

        public DomesticHotWaterSystem(string name)
            : base(name)
        {
        }

        public DomesticHotWaterSystem(JObject jObject)
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
            return new DomesticHotWaterSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
