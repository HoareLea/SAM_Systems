using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemFan : SystemComponent
    {
        public SystemFan(string name)
            : base(name)
        {

        }

        public SystemFan(SystemFan systemFan)
            : base(systemFan)
        {

        }

        public SystemFan(JObject jObject)
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
                    Create.SystemConnector<ElectricalSystem>(),
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
