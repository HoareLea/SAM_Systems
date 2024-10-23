using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class CoolingSystemGroup : SystemGroup<CoolingSystem>
    {
        public CoolingSystemGroup()
            : base()
        {
        }

        public CoolingSystemGroup(string name)
            : base(name)
        {
        }

        public CoolingSystemGroup(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public CoolingSystemGroup(CoolingSystemGroup coolingSystemGroup)
            : base(coolingSystemGroup)
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
