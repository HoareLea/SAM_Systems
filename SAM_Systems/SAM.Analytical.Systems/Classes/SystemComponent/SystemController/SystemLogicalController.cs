using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemLogicalController : SystemController
    {
        private LogicalControllerType logicalControllerType;

        public SystemLogicalController(string name)
            :base(name)
        {

        }

        public SystemLogicalController(string name, LogicalControllerType logicalControllerType)
            : base(name)
        {
            this.logicalControllerType = logicalControllerType;
        }

        public SystemLogicalController(SystemLogicalController systemLogicalController)
            : base(systemLogicalController)
        {
            if(systemLogicalController != null)
            {
                logicalControllerType = systemLogicalController.logicalControllerType;
            }
        }

        public SystemLogicalController(JObject jObject)
            : base(jObject)
        {

        }

        public LogicalControllerType LogicalControllerType
        {
            get
            {
                return logicalControllerType;
            }
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
