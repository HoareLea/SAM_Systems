using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemLiquidPassthroughController : SystemSensorController
    {
        private LiquidNormalControllerDataType liquidNormalControllerDataType;

        public SystemLiquidPassthroughController(string name)
            :base(name)
        {

        }

        public SystemLiquidPassthroughController(string name, LiquidNormalControllerDataType liquidNormalControllerDataType)
            : base(name)
        {
            this.liquidNormalControllerDataType = liquidNormalControllerDataType;
        }

        public SystemLiquidPassthroughController(SystemLiquidPassthroughController systemLiquidPassthroughController)
            : base(systemLiquidPassthroughController)
        {
            if(systemLiquidPassthroughController != null)
            {
                liquidNormalControllerDataType = systemLiquidPassthroughController.liquidNormalControllerDataType;
            }
        }

        public SystemLiquidPassthroughController(System.Guid guid, SystemLiquidPassthroughController systemLiquidPassthroughController)
            : base(guid, systemLiquidPassthroughController)
        {
            if (systemLiquidPassthroughController != null)
            {
                liquidNormalControllerDataType = systemLiquidPassthroughController.liquidNormalControllerDataType;
            }
        }

        public SystemLiquidPassthroughController(JsonObject jObject)
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

        public LiquidNormalControllerDataType LiquidNormalControllerDataType
        {
            get
            {
                return liquidNormalControllerDataType;
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("LiquidNormalControllerDataType"))
            {
                Core.Query.TryGetEnum(jObject["LiquidNormalControllerDataType"]?.GetValue<string>() ?? null, out liquidNormalControllerDataType);
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

            result.Add("LiquidNormalControllerDataType", liquidNormalControllerDataType.ToString());

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemLiquidPassthroughController(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
