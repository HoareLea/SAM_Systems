using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class SystemBoiler: SystemComponent
    {
        public SystemBoiler(SystemBoiler systemBoiler)
            : base(systemBoiler)
        {

        }

        public SystemBoiler(JObject jObject)
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
