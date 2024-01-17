using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class SystemDirectEvaporativeCooler : SystemHumidifier
    {
        public SystemDirectEvaporativeCooler(string name)
            : base(name)
        {

        }

        public SystemDirectEvaporativeCooler(SystemDirectEvaporativeCooler systemDirectEvaporativeCooler)
            : base(systemDirectEvaporativeCooler)
        {

        }

        public SystemDirectEvaporativeCooler(JObject jObject)
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
