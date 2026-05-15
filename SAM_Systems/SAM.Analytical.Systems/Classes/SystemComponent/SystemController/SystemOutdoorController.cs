using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemOutdoorController : SystemSetpointController
    {
        private OutdoorControllerDataType outdoorControllerDataType;

        public SystemOutdoorController(string name, OutdoorControllerDataType outdoorControllerDataType, ISetpoint setpoint, ISetback setback)
            : base(name, setpoint, setback)
        {
            this.outdoorControllerDataType = outdoorControllerDataType;
        }

        public SystemOutdoorController(string name, string sensorReference, OutdoorControllerDataType outdoorControllerDataType, ISetpoint setpoint, ISetback setback)
            : base(name, sensorReference, setpoint, setback)
        {
            this.outdoorControllerDataType = outdoorControllerDataType;
        }

        public SystemOutdoorController(string name)
            :base(name)
        {

        }

        public SystemOutdoorController(SystemOutdoorController systemOutdoorController)
            : base(systemOutdoorController)
        {
            if(systemOutdoorController != null)
            {
                outdoorControllerDataType = systemOutdoorController.outdoorControllerDataType;
            }
        }

        public SystemOutdoorController(System.Guid guid, SystemOutdoorController systemOutdoorController)
            : base(guid, systemOutdoorController)
        {
            if (systemOutdoorController != null)
            {
                outdoorControllerDataType = systemOutdoorController.outdoorControllerDataType;
            }
        }

        public SystemOutdoorController(JsonObject jObject)
            : base(jObject)
        {

        }

        public OutdoorControllerDataType OutdoorControllerDataType
        {
            get
            {
                return outdoorControllerDataType;
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("OutdoorControllerDataType"))
            {
                Core.Query.TryGetEnum(jObject["OutdoorControllerDataType"]?.GetValue<string>() ?? null, out outdoorControllerDataType);
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

            result.Add("OutdoorControllerDataType", outdoorControllerDataType.ToString());

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemOutdoorController(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
