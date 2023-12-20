using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class CoolingSystem : LiquidSystem
    {
        public CoolingSystem(CoolingSystem coolingSystem) 
            : base(coolingSystem)
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
    }
}
