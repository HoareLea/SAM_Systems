using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class SystemCoolingCoil: SystemComponent
    {
        public SystemCoolingCoil(SystemCoolingCoil systemCoolingCoil)
            : base(systemCoolingCoil)
        {

        }

        public SystemCoolingCoil(JObject jObject)
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
