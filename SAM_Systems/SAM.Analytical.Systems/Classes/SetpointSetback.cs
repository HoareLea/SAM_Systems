using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class SetpointSetback : Setback
    {
        private ISetpoint setpoint;

        public SetpointSetback()
        {

        }

        public SetpointSetback(string scheduleName, ISetpoint setpoint)
            :base(scheduleName)
        {
            this.setpoint = setpoint == null ? null : Core.Query.Clone(setpoint);
        }

        public SetpointSetback(SetpointSetback setpointSetback)
            :base(setpointSetback)
        {
            if(setpointSetback != null)
            {
                setpoint = setpointSetback.setpoint == null ? null : Core.Query.Clone(setpointSetback.setpoint);
            }
        }

        public SetpointSetback(JObject jObject)
            : base(jObject)
        {

        }

        public ISetpoint Setpoint
        {
            get
            {
                return Core.Query.Clone(setpoint);
            }
        }

        public virtual bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                setpoint = Core.Query.IJSAMObject<ISetpoint>(jObject.Value<JObject>("Setpoint"));
            }

            return true;
        }

        public virtual JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            if (setpoint != null)
            {
                result.Add("Setpoint", setpoint.ToJObject());
            }

            return result;
        }
    }
}
