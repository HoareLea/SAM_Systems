using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemSensor : SystemObject, ISystemSensor
    {       
        public SystemSensor()
            : base(string.Empty)
        {
        }

        public SystemSensor(string name)
            : base(name)
        {
        }

        public SystemSensor(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemSensor(SystemSensor systemSensor)
            : base(systemSensor)
        {

        }
        public SystemSensor(System.Guid guid, SystemSensor systemSensor)
            : base(guid, systemSensor)
        {

        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemSensor(guid == null ? Guid.NewGuid() : guid.Value, this);
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
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

            return result;
        }
    }
}
