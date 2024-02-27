using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemMixingBox : SystemComponent
    {
        public SystemMixingBox(string name)
            : base(name)
        {

        }

        public SystemMixingBox(SystemMixingBox systemMixingBox)
            : base(systemMixingBox)
        {

        }

        public SystemMixingBox(JObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<AirSystem>(Core.Direction.In, 1),
                    Core.Systems.Create.SystemConnector<AirSystem>(Core.Direction.Out, 1),
                    Core.Systems.Create.SystemConnector<AirSystem>(Core.Direction.In, 2),
                    Core.Systems.Create.SystemConnector<IControlSystem>()
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
