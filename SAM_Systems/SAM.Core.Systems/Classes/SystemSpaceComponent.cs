using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public abstract class SystemSpaceComponent : SystemComponent, ISystemSpaceComponent
    {
        public SystemSpaceComponent(string name)
            : base(name)
        {
        }

        public SystemSpaceComponent(JObject jObject)
            : base(jObject)
        {

        }

        public SystemSpaceComponent(SystemSpaceComponent systemSpaceComponent)
            : base(systemSpaceComponent)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            return base.FromJObject(jObject);
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            return result;
        }
    }
}
