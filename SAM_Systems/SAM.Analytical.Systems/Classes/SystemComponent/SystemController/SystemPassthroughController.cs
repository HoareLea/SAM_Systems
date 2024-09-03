using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class SystemPassthroughController : SystemSensorController
    {
        private NormalControllerDataType normalControllerDataType;

        public SystemPassthroughController(string name)
            :base(name)
        {

        }

        public SystemPassthroughController(string name, NormalControllerDataType normalControllerDataType)
            : base(name)
        {
            this.normalControllerDataType = normalControllerDataType;
        }

        public SystemPassthroughController(SystemPassthroughController systemPassthroughController)
            : base(systemPassthroughController)
        {
            if(systemPassthroughController != null)
            {
                normalControllerDataType = systemPassthroughController.normalControllerDataType;
            }
        }

        public SystemPassthroughController(JObject jObject)
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

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("NormalControllerDataType"))
            {
                Core.Query.TryGetEnum(jObject.Value<string>("NormalControllerDataType"), out normalControllerDataType);
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

            return result;
        }
    }
}
