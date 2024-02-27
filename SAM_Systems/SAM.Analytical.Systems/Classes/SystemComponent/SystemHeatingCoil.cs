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
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.Out, 1),
                    Core.Systems.Create.SystemConnector<ElectricalSystem>(Core.Direction.In),
                    Core.Systems.Create.SystemConnector<AirSystem>(Core.Direction.In, 2),
                    Core.Systems.Create.SystemConnector<AirSystem>(Core.Direction.Out, 2),
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
