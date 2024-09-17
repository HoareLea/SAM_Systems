using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public abstract class SystemSetpointController : SystemSensorController
    {
        private ISetpoint setpoint;

        public SystemSetpointController(string name)
            :base(name)
        {

        }

        public SystemSetpointController(string name, string sensorReference)
            : base(name, sensorReference)
        {

        }

        public SystemSetpointController(string name, ISetpoint setpoint)
            : base(name)
        {
            this.setpoint = setpoint == null ? null : Core.Query.Clone(setpoint);
        }

        public SystemSetpointController(string name, string sensorReference, ISetpoint setpoint)
            : base(name, sensorReference)
        {
            this.setpoint = setpoint == null ? null : Core.Query.Clone(setpoint);
        }

        public SystemSetpointController(SystemSetpointController systemSetpointController)
            : base(systemSetpointController)
        {
            if(systemSetpointController != null)
            {
                setpoint = systemSetpointController.setpoint == null ? null : Core.Query.Clone(systemSetpointController.setpoint);
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

            return result;
        }
    }
}
