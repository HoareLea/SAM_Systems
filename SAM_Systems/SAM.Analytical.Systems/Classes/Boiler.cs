using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class Boiler : SAMObject
    {

        public Boiler(Boiler boiler)
            :base(boiler)
        {

        }

        public Boiler(JObject jObject)
            : base(jObject)
        {

        }

        public Boiler(string name)
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
