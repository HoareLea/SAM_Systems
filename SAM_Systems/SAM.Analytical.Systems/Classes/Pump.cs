using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class Pump : SAMObject
    {

        public Pump(Pump pump)
            :base(pump)
        {

        }

        public Pump(JObject jObject)
            : base(jObject)
        {

        }

        public Pump(string name)
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
