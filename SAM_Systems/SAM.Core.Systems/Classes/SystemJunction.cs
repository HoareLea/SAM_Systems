using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public abstract class SystemJunction : SystemComponent
    {
        public SystemJunction(SystemJunction systemJunction)
            : base(systemJunction)
        {

        }

        public SystemJunction(JObject jObject)
            : base(jObject)
        {

        }

        public SystemJunction(string name)
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
