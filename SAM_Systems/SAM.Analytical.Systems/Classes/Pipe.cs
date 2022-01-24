using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class Pipe : SAMObject
    {

        public Pipe(Pump pump)
            :base(pump)
        {

        }

        public Pipe(JObject jObject)
            : base(jObject)
        {

        }

        public Pipe(string name)
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
