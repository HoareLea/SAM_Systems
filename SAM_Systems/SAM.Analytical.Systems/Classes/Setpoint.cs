using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public abstract class Setpoint : ISetpoint
    {
        public Setpoint()
        {

        }

        public Setpoint(Setpoint setpoint)
        {

        }

        public Setpoint(JObject jObject)
        {
            FromJObject(jObject);
        }

        public virtual bool FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            return true;
        }

        public virtual JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            return result;
        }
    }
}
