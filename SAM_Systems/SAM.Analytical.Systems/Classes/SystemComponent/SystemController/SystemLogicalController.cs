using System.Text.Json.Nodes;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public abstract class SystemLogicalController : SystemController
    {
        public abstract LogicalControllerType LogicalControllerType { get; }

        public SystemLogicalController(string name)
            :base(name)
        {

        }

        public SystemLogicalController(SystemLogicalController systemLogicalController)
            : base(systemLogicalController)
        {
            if(systemLogicalController != null)
            {

            }
        }

        public SystemLogicalController(System.Guid guid, SystemLogicalController systemLogicalController)
            : base(guid, systemLogicalController)
        {
            if (systemLogicalController != null)
            {

            }
        }

        public SystemLogicalController(JsonObject jObject)
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
    }
}
