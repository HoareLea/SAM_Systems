using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public abstract class SystemChiller : SystemComponent
    {
        public SystemChiller(string name)
            : base(name)
        {

        }

        public SystemChiller(SystemChiller systemChiller)
            : base(systemChiller)
        {

        }

        public SystemChiller(JObject jObject)
            : base(jObject)
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

