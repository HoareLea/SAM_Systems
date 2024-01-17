using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class SystemSteamHumidifier : SystemHumidifier
    {
        public SystemSteamHumidifier(string name)
            : base(name)
        {

        }

        public SystemSteamHumidifier(SystemSteamHumidifier systemSteamHumidifier)
            : base(systemSteamHumidifier)
        {

        }

        public SystemSteamHumidifier(JObject jObject)
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
