using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemNotLogicalController : SystemLogicalController
    {
        public override LogicalControllerType LogicalControllerType => LogicalControllerType.Not;

        public SystemNotLogicalController(string name)
            :base(name)
        {

        }

        public SystemNotLogicalController(SystemNotLogicalController systemNotLogicalController)
            : base(systemNotLogicalController)
        {
            if(systemNotLogicalController != null)
            {

            }
        }

        public SystemNotLogicalController(System.Guid guid, SystemNotLogicalController systemNotLogicalController)
            : base(guid, systemNotLogicalController)
        {
            if (systemNotLogicalController != null)
            {

            }
        }

        public SystemNotLogicalController(JObject jObject)
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
            return new SystemNotLogicalController(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
