using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class AirSystem : SystemObject, IMechanicalSystem
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
