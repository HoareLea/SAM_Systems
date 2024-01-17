using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class SystemDesiccantWheel : SystemExchanger
    {
        public SystemDesiccantWheel(string name)
            : base(name)
        {

        }

        public SystemDesiccantWheel(SystemDesiccantWheel systemDesiccantWheel)
            : base(systemDesiccantWheel)
        {

        }

        public SystemDesiccantWheel(JObject jObject)
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
