using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class SystemNormalController : SystemSetpointController
    {
        private NormalControllerDataType normalControllerDataType;
        private NormalControllerLimit normalControllerLimit;

        public SystemNormalController(string name, NormalControllerDataType normalControllerDataType, ISetpoint setpoint, NormalControllerLimit normalControllerLimit)
            : base(name, setpoint)
        {
            this.normalControllerDataType = normalControllerDataType;
            this.normalControllerLimit = normalControllerLimit; 
        }

        public SystemNormalController(string name, string sensorReference, NormalControllerDataType normalControllerDataType, ISetpoint setpoint, NormalControllerLimit normalControllerLimit)
            : base(name, sensorReference, setpoint)
        {
            this.normalControllerDataType = normalControllerDataType;
            this.normalControllerLimit = normalControllerLimit;
        }

        public SystemNormalController(string name)
            :base(name)
        {

        }

        public SystemNormalController(SystemNormalController systemNormalController)
            : base(systemNormalController)
        {
            if(systemNormalController != null)
            {
                normalControllerDataType = systemNormalController.normalControllerDataType;
                normalControllerLimit = systemNormalController.normalControllerLimit;
            }
        }

        public SystemNormalController(JObject jObject)
            : base(jObject)
        {

        }

        public NormalControllerDataType NormalControllerDataType
        {
            get
            {
                return normalControllerDataType;
            }
        }

        public NormalControllerLimit NormalControllerLimit
        {
            get
            {
                return normalControllerLimit;
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("NormalControllerDataType"))
            {
                Core.Query.TryGetEnum(jObject.Value<string>("NormalControllerDataType"), out normalControllerDataType);
            }

            if (jObject.ContainsKey("NormalControllerLimit"))
            {
                Core.Query.TryGetEnum(jObject.Value<string>("NormalControllerLimit"), out normalControllerLimit);
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

            result.Add("NormalControllerDataType", normalControllerDataType.ToString());

            result.Add("NormalControllerLimit", normalControllerDataType.ToString());

            return result;
        }
    }
}
