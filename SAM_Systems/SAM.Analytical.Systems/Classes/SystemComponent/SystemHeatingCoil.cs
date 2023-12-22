using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemHeatingCoil : SystemComponent
    {
        public SystemHeatingCoil(string name)
            : base(name)
        {

        }

        public SystemHeatingCoil(SystemHeatingCoil systemHeatingCoil)
            : base(systemHeatingCoil)
        {

        }

        public SystemHeatingCoil(JObject jObject)
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
                    Create.SystemConnector<ElectricalSystem>(Core.Direction.In),
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
