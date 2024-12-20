using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemAirSourceChiller : SystemChiller
    {
        public ModifiableValue Setpoint { get; set; }
        public ModifiableValue Efficiency { get; set; }
        public ModifiableValue CondenserFanLoad { get; set; }
        public double DesignTemperatureDifference { get; set; }
        public double Capacity { get; set; }
        public double DesignPressureDrop { get; set; }

        public SystemAirSourceChiller(string name)
            : base(name)
        {

        }

        public SystemAirSourceChiller(SystemAirSourceChiller systemAirSourceChiller)
            : base(systemAirSourceChiller)
        {
            if(systemAirSourceChiller != null)
            {
                Setpoint = systemAirSourceChiller.Setpoint?.Clone();
                Efficiency = systemAirSourceChiller.Efficiency?.Clone();
                CondenserFanLoad = systemAirSourceChiller.CondenserFanLoad?.Clone();
                DesignTemperatureDifference = systemAirSourceChiller.DesignTemperatureDifference;
                Capacity = systemAirSourceChiller.Capacity;
                DesignPressureDrop = systemAirSourceChiller.DesignPressureDrop;
            }
        }

        public SystemAirSourceChiller(JObject jObject)
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

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Setpoint"));
            }

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Efficiency"));
            }

            if (jObject.ContainsKey("CondenserFanLoad"))
            {
                CondenserFanLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("CondenserFanLoad"));
            }

            if (jObject.ContainsKey("DesignTemperatureDifference"))
            {
                DesignTemperatureDifference = jObject.Value<double>("DesignTemperatureDifference");
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject.Value<double>("Capacity");
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject.Value<double>("DesignPressureDrop");
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result =  base.ToJObject();
            if(result == null)
            {
                return result;
            }

            if(Setpoint != null)
            {
                result.Add(Setpoint.ToJObject());
            }

            if (Efficiency != null)
            {
                result.Add(Efficiency.ToJObject());
            }

            if (CondenserFanLoad != null)
            {
                result.Add(CondenserFanLoad.ToJObject());
            }

            if (!double.IsNaN(DesignTemperatureDifference))
            {
                result.Add("DesignTemperatureDifference", DesignTemperatureDifference);
            }

            if (!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            if (!double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            return result;
        }
    }
}