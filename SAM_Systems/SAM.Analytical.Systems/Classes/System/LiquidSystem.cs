using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class LiquidSystem : FluidSystem
    {
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
    }
}
