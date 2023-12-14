using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public abstract class SystemCircuit : SystemObject
    {
        public SystemCircuit(SystemCircuit systemCircuit)
            : base(systemCircuit)
        {

        }

        public SystemCircuit(JObject jObject)
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
