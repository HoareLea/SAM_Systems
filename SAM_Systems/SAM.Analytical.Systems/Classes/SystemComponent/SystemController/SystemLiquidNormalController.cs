using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemLiquidNormalController : SystemSetpointController
    {
        private LiquidNormalControllerDataType liquidNormalControllerDataType;

        public SystemLiquidNormalController(string name, LiquidNormalControllerDataType liquidNormalControllerDataType, ISetpoint setpoint, ISetback setback)
            : base(name, setpoint, setback)
        {
            this.liquidNormalControllerDataType = liquidNormalControllerDataType;
        }

        public SystemLiquidNormalController(string name, string sensorReference, LiquidNormalControllerDataType liquidNormalControllerDataType, ISetpoint setpoint, ISetback setback)
            : base(name, sensorReference, setpoint, setback)
        {
            this.liquidNormalControllerDataType = liquidNormalControllerDataType;
        }

        public SystemLiquidNormalController(string name)
            :base(name)
        {

        }

        public SystemLiquidNormalController(SystemLiquidNormalController systemLiquidNormalController)
            : base(systemLiquidNormalController)
        {
            if(systemLiquidNormalController != null)
            {
                liquidNormalControllerDataType = systemLiquidNormalController.liquidNormalControllerDataType;
            }
        }

        public SystemLiquidNormalController(JObject jObject)
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

        public LiquidNormalControllerDataType LiquidNormalControllerDataType
        {
            get
            {
                return liquidNormalControllerDataType;
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("LiquidNormalControllerDataType"))
            {
                Core.Query.TryGetEnum(jObject.Value<string>("LiquidNormalControllerDataType"), out liquidNormalControllerDataType);
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

            result.Add("LiquidNormalControllerDataType", liquidNormalControllerDataType.ToString());

            return result;
        }
    }
}
