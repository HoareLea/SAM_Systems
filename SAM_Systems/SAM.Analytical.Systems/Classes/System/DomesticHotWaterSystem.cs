using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class DomesticHotWaterSystem : LiquidSystem
    {
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
    }
}
