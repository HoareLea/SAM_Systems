using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class HeatingSystemCollection : SystemCollection<HeatingSystem>
    {
        public HeatingSystemCollection()
            : base()
        {
        }

        public HeatingSystemCollection(string name)
            : base(name)
        {
        }

        public HeatingSystemCollection(JObject jObject)
            : base(jObject)
        {

        }

        public HeatingSystemCollection(HeatingSystemCollection heatingSystemCollection)
            : base(heatingSystemCollection)
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
