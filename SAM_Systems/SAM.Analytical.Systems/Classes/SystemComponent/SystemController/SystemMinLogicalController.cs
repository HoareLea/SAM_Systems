using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemMinLogicalController : SystemLogicalController
    {
        public override LogicalControllerType LogicalControllerType => LogicalControllerType.Min;

        public SystemMinLogicalController(string name)
            :base(name)
        {

        }

        public SystemMinLogicalController(SystemMinLogicalController systemMinLogicalController)
            : base(systemMinLogicalController)
        {
            if(systemMinLogicalController != null)
            {

            }
        }

        public SystemMinLogicalController(System.Guid guid, SystemMinLogicalController systemMinLogicalController)
            : base(guid, systemMinLogicalController)
        {
            if (systemMinLogicalController != null)
            {

            }
        }

        public SystemMinLogicalController(JsonObject jObject)
            : base(jObject)
        {

        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
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

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemMinLogicalController(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
