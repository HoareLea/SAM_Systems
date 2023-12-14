using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
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
