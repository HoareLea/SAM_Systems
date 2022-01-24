using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class HeatingGroup : SAMObject
    {

        public HeatingGroup(HeatingGroup heatingGroup)
            :base(heatingGroup)
        {

        }

        public HeatingGroup(JObject jObject)
            : base(jObject)
        {

        }

        public HeatingGroup(string name)
            : base(name)
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
