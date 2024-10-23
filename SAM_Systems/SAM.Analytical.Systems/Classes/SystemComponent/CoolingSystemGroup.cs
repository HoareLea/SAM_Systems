using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class HeatingSystemGroup : SystemGroup<HeatingSystem>
    {
        public HeatingSystemGroup()
            : base()
        {
        }

        public HeatingSystemGroup(string name)
            : base(name)
        {
        }

        public HeatingSystemGroup(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public HeatingSystemGroup(HeatingSystemGroup heatingSystemGroup)
            : base(heatingSystemGroup)
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
