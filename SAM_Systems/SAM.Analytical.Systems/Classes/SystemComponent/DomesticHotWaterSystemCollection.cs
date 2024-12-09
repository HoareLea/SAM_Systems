using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class DomesticHotWaterSystemCollection : SystemCollection<DomesticHotWaterSystem>
    {
        public DomesticHotWaterSystemCollection()
            : base()
        {
        }

        public DomesticHotWaterSystemCollection(string name)
            : base(name)
        {
        }

        public DomesticHotWaterSystemCollection(JObject jObject)
            : base(jObject)
        {

        }

        public DomesticHotWaterSystemCollection(DomesticHotWaterSystemCollection domesticHotWaterSystemCollection)
            : base(domesticHotWaterSystemCollection)
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