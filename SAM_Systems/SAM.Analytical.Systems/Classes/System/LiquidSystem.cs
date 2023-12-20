using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public abstract class LiquidSystem : FluidSystem
    {
        public LiquidSystem(LiquidSystem liquidSystem) 
            : base(liquidSystem)
        {
        }

        public LiquidSystem(JObject jObject)
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
