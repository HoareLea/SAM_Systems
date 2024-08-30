using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class SystemPassthroughController : SystemSensorController
    {
        private IndoorControllerDataType indoorControllerDataType;

        public SystemPassthroughController(string name)
            :base(name)
        {

        }

        public SystemPassthroughController(string name, IndoorControllerDataType indoorControllerDataType)
            : base(name)
        {
            this.indoorControllerDataType = indoorControllerDataType;
        }

        public SystemPassthroughController(SystemPassthroughController systemPassthroughController)
            : base(systemPassthroughController)
        {
            if(systemPassthroughController != null)
            {
                indoorControllerDataType = systemPassthroughController.indoorControllerDataType;
            }
        }

        public SystemPassthroughController(JObject jObject)
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

            if (jObject.ContainsKey("IndoorControllerDataType"))
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
