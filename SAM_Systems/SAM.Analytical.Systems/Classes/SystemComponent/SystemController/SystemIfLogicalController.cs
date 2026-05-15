using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemIfLogicalController : SystemLogicalController
    {
        public override LogicalControllerType LogicalControllerType => LogicalControllerType.If;

        public SystemIfLogicalController(string name)
            :base(name)
        {

        }

        public SystemIfLogicalController(SystemIfLogicalController systemIfLogicalController)
            : base(systemIfLogicalController)
        {
            if(systemIfLogicalController != null)
            {

            }
        }

        public SystemIfLogicalController(System.Guid guid, SystemIfLogicalController systemIfLogicalController)
            : base(guid, systemIfLogicalController)
        {
            if (systemIfLogicalController != null)
            {

            }
        }

        public SystemIfLogicalController(JsonObject jObject)
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
                    Core.Systems.Create.SystemConnector<IControlSystem>(Core.Direction.In),
                    Core.Systems.Create.SystemConnector<IControlSystem>(Core.Direction.In),
                    Core.Systems.Create.SystemConnector<IControlSystem>(Core.Direction.In)
                );
            }
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
            return new SystemIfLogicalController(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
