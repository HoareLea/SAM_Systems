using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class AirSystemGroup : SystemGroup<AirSystem>
    {
        public AirSystemGroup()
            : base()
        {
        }

        public AirSystemGroup(string name)
            : base(name)
        {
        }

        public AirSystemGroup(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public AirSystemGroup(AirSystemGroup airSystemGroup)
            : base(airSystemGroup)
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
