using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemSensor : SystemObject
    {
        public SystemSensor()
            : base(string.Empty)
        {
        }

        public SystemSensor(string name)
            : base(name)
        {
        }

        public SystemSensor(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemSensor(SystemSensor systemSensor)
            : base(systemSensor)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            return true;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            return result;
        }
    }
}
