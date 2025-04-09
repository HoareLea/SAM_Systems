using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemSigLogicalController : SystemLogicalController
    {
        public override LogicalControllerType LogicalControllerType => LogicalControllerType.Sig;

        public SystemSigLogicalController(string name)
            :base(name)
        {

        }

        public SystemSigLogicalController(SystemSigLogicalController systemSigLogicalController)
            : base(systemSigLogicalController)
        {
            if(systemSigLogicalController != null)
            {

            }
        }

        public SystemSigLogicalController(System.Guid guid, SystemSigLogicalController systemSigLogicalController)
            : base(guid, systemSigLogicalController)
        {
            if (systemSigLogicalController != null)
            {

            }
        }

        public SystemSigLogicalController(JObject jObject)
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
            return new SystemSigLogicalController(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
