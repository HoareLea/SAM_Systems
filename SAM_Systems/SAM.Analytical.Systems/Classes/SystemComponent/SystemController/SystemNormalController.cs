using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemNormalController : SystemSetpointController
    {
        private NormalControllerDataType normalControllerDataType;
        private NormalControllerLimit normalControllerLimit;

        public SystemNormalController(string name, NormalControllerDataType normalControllerDataType, ISetpoint setpoint, ISetback setback, NormalControllerLimit normalControllerLimit)
            : base(name, setpoint, setback)
        {
            this.normalControllerDataType = normalControllerDataType;
            this.normalControllerLimit = normalControllerLimit; 
        }

        public SystemNormalController(string name, string sensorReference, NormalControllerDataType normalControllerDataType, ISetpoint setpoint, ISetback setback, NormalControllerLimit normalControllerLimit)
            : base(name, sensorReference, setpoint, setback)
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

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<IControlSystem>(Core.Direction.In),
                    Core.Systems.Create.SystemConnector<IControlSystem>(Core.Direction.Out)
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

            result.Add("NormalControllerLimit", normalControllerLimit.ToString());

            return result;
        }
    }
}
