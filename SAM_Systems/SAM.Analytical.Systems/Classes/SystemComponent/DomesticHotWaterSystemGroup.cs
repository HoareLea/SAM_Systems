using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class DomesticHotWaterSystemGroup : SystemGroup<DomesticHotWaterSystem>
    {
        public DomesticHotWaterSystemGroup()
            : base()
        {
        }

        public DomesticHotWaterSystemGroup(string name)
            : base(name)
        {
        }

        public DomesticHotWaterSystemGroup(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public DomesticHotWaterSystemGroup(DomesticHotWaterSystemGroup domesticHotWaterSystemGroup)
            : base(domesticHotWaterSystemGroup)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            return true;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            return result;
        }
    }
}
