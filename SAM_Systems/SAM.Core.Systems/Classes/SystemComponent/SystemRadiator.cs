using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class SystemRadiator : SystemComponent, ISystemSpaceComponent
    {
        public SystemRadiator(SystemRadiator systemRadiator)
            : base(systemRadiator)
        {

        }

        public SystemRadiator(JObject jObject)
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
