using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class ElectricalSystem : SystemObject, ISystem
    {
        public ElectricalSystem(AirSystem airSystem)
            : base(airSystem)
        {
        }

        public ElectricalSystem(JObject jObject)
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
