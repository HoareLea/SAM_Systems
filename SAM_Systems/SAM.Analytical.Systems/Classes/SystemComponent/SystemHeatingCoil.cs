using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class SystemHeatingCoil : SystemComponent
    {
        public SystemHeatingCoil(SystemHeatingCoil systemHeatingCoil)
            : base(systemHeatingCoil)
        {

        }

        public SystemHeatingCoil(JObject jObject)
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
