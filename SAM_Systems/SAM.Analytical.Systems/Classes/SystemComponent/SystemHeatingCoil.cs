using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemHeatingCoil : SystemComponent
    {
        public SizableValue Duty { get; set; }

        public SystemHeatingCoil(string name)
            : base(name)
        {

        }

        public SystemHeatingCoil(SystemHeatingCoil systemHeatingCoil)
            : base(systemHeatingCoil)
        {
            if(systemHeatingCoil != null)
            {
                Duty = systemHeatingCoil.Duty;
            }
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
                    Core.Systems.Create.SystemConnector<AirSystem>(Core.Direction.In, 2),
                    Core.Systems.Create.SystemConnector<AirSystem>(Core.Direction.Out, 2),
                    Core.Systems.Create.SystemConnector<IControlSystem>(),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.Out, 1),
                    Core.Systems.Create.SystemConnector<ElectricalSystem>(Core.Direction.In)
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

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("Duty"));
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJObject());
            }

            return result;
        }
    }
}
