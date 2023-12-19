using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class AirSystem : FluidSystem
    {
        public AirSystem(AirSystem airSystem) 
            : base(airSystem)
        {
        }

        public AirSystem(JObject jObject)
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
