using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemBoiler: SystemComponent
    {
        public SystemBoiler(SystemBoiler systemBoiler)
            : base(systemBoiler)
        {

        }

        public SystemBoiler(JObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Create.SystemConnectorManager
                (
                    Create.SystemConnector<LiquidSystem>(Core.Direction.In, 1),
                    Create.SystemConnector<LiquidSystem>(Core.Direction.Out, 1),
                    Create.SystemConnector<IControlSystem>()
                );
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            return base.FromJObject(jObject);
        }

        public override JObject ToJObject()
        {
            return base.ToJObject();
        }
    }
}
