using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemCoolingCoil: SystemComponent
    {
        public double BypassFactor { get; set; }

        public Duty Duty { get; set; }

        public SystemCoolingCoil(string name)
            : base(name)
        {

        }

        public SystemCoolingCoil(SystemCoolingCoil systemCoolingCoil)
            : base(systemCoolingCoil)
        {
            if(systemCoolingCoil != null)
            {
                BypassFactor = systemCoolingCoil.BypassFactor;
                Duty = Core.Query.Clone(systemCoolingCoil.Duty);
            }
        }

        public SystemCoolingCoil(JObject jObject)
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
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.In, 2),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.Out, 2),
                    Core.Systems.Create.SystemConnector<IControlSystem>()
                );
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("BypassFactor"))
            {
                BypassFactor = jObject.Value<double>("BypassFactor");
            }

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<Duty>(jObject.Value<JObject>("Duty"));
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if(result == null)
            {
                return result;
            }

            if(!double.IsNaN(BypassFactor))
            {
                result.Add("BypassFactor", BypassFactor);
            }

            if(Duty != null)
            {
                result.Add("Duty", Duty.ToJObject());
            }

            return result;
        }
    }
}
