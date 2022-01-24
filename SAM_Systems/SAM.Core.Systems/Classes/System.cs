using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class System : SAMObject
    {

        public System(System plantRoom)
            :base(plantRoom)
        {

        }

        public System(JObject jObject)
            : base(jObject)
        {

        }

        public System(string name)
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
