using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class FluidSystem : SystemObject, IMechanicalSystem
    {
        public FluidSystem(AirSystem airSystem)
            : base(airSystem)
        {
        }

        public FluidSystem(JObject jObject)
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
