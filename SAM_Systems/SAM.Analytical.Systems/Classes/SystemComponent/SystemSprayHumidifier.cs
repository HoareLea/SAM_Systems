using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class SystemSprayHumidifier : SystemHumidifier
    {
        public SystemSprayHumidifier(string name)
            : base(name)
        {

        }

        public SystemSprayHumidifier(SystemSprayHumidifier systemSprayHumidifier)
            : base(systemSprayHumidifier)
        {

        }

        public SystemSprayHumidifier(JObject jObject)
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
