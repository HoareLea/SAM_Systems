using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class Radiator : SAMObject
    {

        public Radiator(Radiator radiator)
            :base(radiator)
        {

        }

        public Radiator(JObject jObject)
            : base(jObject)
        {

        }

        public Radiator(string name)
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
