using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class SystemIndoorController : SystemSetpointController
    {
        private IndoorControllerDataType indoorControllerDataType;

        public SystemIndoorController(string name, IndoorControllerDataType indoorControllerDataType, ISetpoint setpoint)
            : base(name, setpoint)
        {
            this.indoorControllerDataType = indoorControllerDataType;
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

            return result;
        }
    }
}
