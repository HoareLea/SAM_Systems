using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class PlumbingSystem : SystemObject, IMechanicalSystem
    {
        public PlumbingSystem(AirSystem airSystem)
            : base(airSystem)
        {
        }

        public PlumbingSystem(JObject jObject)
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
