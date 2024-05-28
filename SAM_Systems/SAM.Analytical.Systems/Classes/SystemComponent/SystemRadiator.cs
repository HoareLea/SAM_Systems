using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemRadiator : SystemSpaceComponent
    {
        public double Efficiency { get; set; }
        public SizableValue Duty { get; set; }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.Out, 1),
                    Core.Systems.Create.SystemConnector<ElectricalSystem>(Core.Direction.In)
                );
            }
        }

        public SystemRadiator(string name)
            : base(name)
        {
        }

        public SystemRadiator(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemRadiator(SystemRadiator systemRadiator)
            : base(systemRadiator)
        {
            if (systemRadiator != null)
            {
                Efficiency = systemRadiator.Efficiency;
                Duty = systemRadiator.Duty;
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = jObject.Value<double>("Efficiency");
            }

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("Duty"));
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

            if (!double.IsNaN(Efficiency))
            {
                result.Add("Efficiency", Efficiency);
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJObject());
            }

            return result;
        }
    }
}
