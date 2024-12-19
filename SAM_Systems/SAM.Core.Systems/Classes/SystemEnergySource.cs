using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class SystemEnergySource : SystemObject
    {
        public SystemEnergySource(SystemEnergySource systemEnergySource)
            : base(systemEnergySource)
        {

        }

        public SystemEnergySource(JObject jObject)
            : base(jObject)
        {

        }

        public SystemEnergySource(string name)
            : base(name)
        {

        }

        public SystemEnergySource(System.Guid guid, string name)
            : base(guid, name)
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
