using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemPassthroughController : SystemSetpointController
    {
        private NormalControllerDataType normalControllerDataType;

        public SystemPassthroughController(string name)
            :base(name)
        {

        }

        public SystemPassthroughController(string name, string sensorReference, ISetpoint setpoint, ISetback setback, NormalControllerDataType normalControllerDataType)
            : base(name, sensorReference, setpoint, setback)
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

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<IControlSystem>(Core.Direction.Out),
                    Core.Systems.Create.SystemConnector<IControlSystem>(Core.Direction.In)
                );
            }
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
