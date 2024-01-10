using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemExchanger : SystemComponent
    {
        public SystemExchanger(string name)
            : base(name)
        {

        }

        public SystemExchanger(SystemExchanger systemExchanger)
            : base(systemExchanger)
        {

        }

        public SystemExchanger(JObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Create.SystemConnectorManager
                (
                    Create.SystemConnector<AirSystem>(Core.Direction.In, 1),
                    Create.SystemConnector<AirSystem>(Core.Direction.Out, 1),
                    Create.SystemConnector<AirSystem>(Core.Direction.In, 2),
                    Create.SystemConnector<AirSystem>(Core.Direction.Out, 2),
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
