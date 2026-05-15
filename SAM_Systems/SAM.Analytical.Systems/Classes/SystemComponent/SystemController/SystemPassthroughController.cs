using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

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

        public SystemPassthroughController(System.Guid guid, SystemPassthroughController systemPassthroughController)
            : base(guid, systemPassthroughController)
        {
            if (systemPassthroughController != null)
            {
                normalControllerDataType = systemPassthroughController.normalControllerDataType;
            }
        }

        public SystemPassthroughController(JsonObject jObject)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("NormalControllerDataType"))
            {
                Core.Query.TryGetEnum(jObject["NormalControllerDataType"]?.GetValue<string>() ?? null, out normalControllerDataType);
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

            result.Add("NormalControllerDataType", normalControllerDataType.ToString());

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemPassthroughController(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
