using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class SystemSprayHumidifier : SystemHumidifier
    {
        public ModifiableValue Setpoint { get; set; }

        public ModifiableValue Effectiveness { get; set; }

        public ISizableValue WaterFlowCapacity { get; set; }

        public ModifiableValue ElectricalLoad { get; set; }

        public SystemSprayHumidifier(string name)
            : base(name)
        {

        }

        public SystemSprayHumidifier(SystemSprayHumidifier systemSprayHumidifier)
            : base(systemSprayHumidifier)
        {
            if(systemSprayHumidifier != null)
            {
                Setpoint = systemSprayHumidifier.Setpoint?.Clone();
                Effectiveness = systemSprayHumidifier?.Effectiveness?.Clone();
                WaterFlowCapacity = systemSprayHumidifier?.WaterFlowCapacity?.Clone();
                ElectricalLoad = systemSprayHumidifier?.ElectricalLoad?.Clone();
            }
        }

        public SystemSprayHumidifier(JObject jObject)
            : base(jObject)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Setpoint"));
            }

            if (jObject.ContainsKey("Effectiveness"))
            {
                Effectiveness = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Effectiveness"));
            }

            if (jObject.ContainsKey("WaterFlowCapacity"))
            {
                WaterFlowCapacity = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("WaterFlowCapacity"));
            }

            if (jObject.ContainsKey("ElectricalLoad"))
            {
                ElectricalLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("ElectricalLoad"));
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

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJObject());
            }

            if (Effectiveness != null)
            {
                result.Add("Effectiveness", Effectiveness.ToJObject());
            }

            if (WaterFlowCapacity != null)
            {
                result.Add("WaterFlowCapacity", WaterFlowCapacity.ToJObject());
            }

            if (ElectricalLoad != null)
            {
                result.Add("ElectricalLoad", ElectricalLoad.ToJObject());
            }

            return result;
        }
    }
}
