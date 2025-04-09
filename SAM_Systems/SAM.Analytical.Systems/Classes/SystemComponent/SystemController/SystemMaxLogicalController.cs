using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemMaxLogicalController : SystemLogicalController
    {
        public override LogicalControllerType LogicalControllerType => LogicalControllerType.Max;

        public SystemMaxLogicalController(string name)
            :base(name)
        {

        }

        public SystemMaxLogicalController(SystemMaxLogicalController systemMaxLogicalController)
            : base(systemMaxLogicalController)
        {
            if(systemMaxLogicalController != null)
            {

            }
        }

        public SystemMaxLogicalController(System.Guid guid, SystemMaxLogicalController systemMaxLogicalController)
            : base(guid, systemMaxLogicalController)
        {
            if (systemMaxLogicalController != null)
            {

            }
        }

        public SystemMaxLogicalController(JObject jObject)
            : base(jObject)
        {

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

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemMaxLogicalController(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
