using Newtonsoft.Json.Linq;
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

        public SystemOutdoorController(JObject jObject)
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

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("OutdoorControllerDataType"))
            {
                Core.Query.TryGetEnum(jObject.Value<string>("OutdoorControllerDataType"), out outdoorControllerDataType);
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

            result.Add("OutdoorControllerDataType", outdoorControllerDataType.ToString());

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemOutdoorController(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
