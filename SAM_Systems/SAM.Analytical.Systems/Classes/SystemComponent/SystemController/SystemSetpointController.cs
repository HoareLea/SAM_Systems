using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public abstract class SystemSetpointController : SystemSensorController
    {
        private ISetpoint setpoint;
        private ISetback setback;

        public SystemSetpointController(string name)
            :base(name)
        {

        }

        public SystemSetpointController(string name, string sensorReference)
            : base(name, sensorReference)
        {

        }

        public SystemSetpointController(string name, ISetpoint setpoint, ISetback setback)
            : base(name)
        {
            this.setpoint = setpoint == null ? null : Core.Query.Clone(setpoint);
            this.setback = setback == null ? null : Core.Query.Clone(setback);
        }

        public SystemSetpointController(string name, string sensorReference, ISetpoint setpoint, ISetback setback)
            : base(name, sensorReference)
        {
            this.setpoint = setpoint == null ? null : Core.Query.Clone(setpoint);
            this.setback = setback == null ? null : Core.Query.Clone(setback);
        }

        public SystemSetpointController(SystemSetpointController systemSetpointController)
            : base(systemSetpointController)
        {
            if(systemSetpointController != null)
            {
                setpoint = systemSetpointController.setpoint == null ? null : Core.Query.Clone(systemSetpointController.setpoint);
                setback = systemSetpointController.setback == null ? null : Core.Query.Clone(systemSetpointController.setback);
            }
        }

        public SystemSetpointController(JObject jObject)
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

        public ISetback Setback
        {
            get
            {
                return Core.Query.Clone(setback);
            }
        }

        public override bool FromJObject(JObject jObject)
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

            if (jObject.ContainsKey("Setback"))
            {
                setback = Core.Query.IJSAMObject<ISetback>(jObject.Value<JObject>("Setback"));
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

            if (setpoint != null)
            {
                result.Add("Setpoint", setpoint.ToJObject());
            }

            if (setback != null)
            {
                result.Add("Setback", setback.ToJObject());
            }

            return result;
        }
    }
}
