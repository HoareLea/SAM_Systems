using System.Text.Json.Nodes;
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

        public SystemSetpointController(System.Guid guid, SystemSetpointController systemSetpointController)
            : base(guid, systemSetpointController)
        {
            if (systemSetpointController != null)
            {
                setpoint = systemSetpointController.setpoint == null ? null : Core.Query.Clone(systemSetpointController.setpoint);
                setback = systemSetpointController.setback == null ? null : Core.Query.Clone(systemSetpointController.setback);
            }
        }

        public SystemSetpointController(JsonObject jObject)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                setpoint = Core.Query.IJSAMObject<ISetpoint>(jObject["Setpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("Setback"))
            {
                setback = Core.Query.IJSAMObject<ISetback>(jObject["Setback"] as JsonObject);
            }

            return true;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if (result == null)
            {
                return null;
            }

            if (setpoint != null)
            {
                result.Add("Setpoint", setpoint.ToJsonObject());
            }

            if (setback != null)
            {
                result.Add("Setback", setback.ToJsonObject());
            }

            return result;
        }
    }
}
