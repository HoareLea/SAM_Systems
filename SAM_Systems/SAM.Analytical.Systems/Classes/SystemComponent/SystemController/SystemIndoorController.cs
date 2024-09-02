using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class SystemIndoorController : SystemSetpointController
    {
        private IndoorControllerDataType indoorControllerDataType;
        private IndoorControllerLimit indoorControllerLimit;

        public SystemIndoorController(string name, IndoorControllerDataType indoorControllerDataType, ISetpoint setpoint, IndoorControllerLimit indoorControllerLimit)
            : base(name, setpoint)
        {
            this.indoorControllerDataType = indoorControllerDataType;
            this.indoorControllerLimit = indoorControllerLimit; 
        }

        public SystemIndoorController(string name, string sensorReference, IndoorControllerDataType indoorControllerDataType, ISetpoint setpoint, IndoorControllerLimit indoorControllerLimit)
            : base(name, sensorReference, setpoint)
        {
            this.indoorControllerDataType = indoorControllerDataType;
            this.indoorControllerLimit = indoorControllerLimit;
        }

        public SystemIndoorController(string name)
            :base(name)
        {

        }

        public SystemIndoorController(SystemIndoorController systemIndoorController)
            : base(systemIndoorController)
        {
            if(systemIndoorController != null)
            {
                indoorControllerDataType = systemIndoorController.indoorControllerDataType;
                indoorControllerLimit = systemIndoorController.indoorControllerLimit;
            }
        }

        public SystemIndoorController(JObject jObject)
            : base(jObject)
        {

        }

        public IndoorControllerDataType IndoorControllerDataType
        {
            get
            {
                return indoorControllerDataType;
            }
        }

        public IndoorControllerLimit IndoorControllerLimit
        {
            get
            {
                return indoorControllerLimit;
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("IndoorControllerDataType"))
            {
                Core.Query.TryGetEnum(jObject.Value<string>("IndoorControllerDataType"), out indoorControllerDataType);
            }

            if (jObject.ContainsKey("IndoorControllerLimit"))
            {
                Core.Query.TryGetEnum(jObject.Value<string>("IndoorControllerLimit"), out indoorControllerLimit);
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

            result.Add("IndoorControllerDataType", indoorControllerDataType.ToString());

            result.Add("IndoorControllerLimit", indoorControllerDataType.ToString());

            return result;
        }
    }
}
