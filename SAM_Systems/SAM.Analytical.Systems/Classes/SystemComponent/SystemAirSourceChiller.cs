using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System;

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
        public bool LossesInSizing { get; set; }

        public string ScheduleName { get; set; }

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
                LossesInSizing = systemAirSourceChiller.LossesInSizing;
                ScheduleName = systemAirSourceChiller.ScheduleName;
            }
        }

        public SystemAirSourceChiller(System.Guid guid, SystemAirSourceChiller systemAirSourceChiller)
            : base(guid, systemAirSourceChiller)
        {
            if (systemAirSourceChiller != null)
            {
                Setpoint = systemAirSourceChiller.Setpoint?.Clone();
                Efficiency = systemAirSourceChiller.Efficiency?.Clone();
                CondenserFanLoad = systemAirSourceChiller.CondenserFanLoad?.Clone();
                DesignTemperatureDifference = systemAirSourceChiller.DesignTemperatureDifference;
                Capacity = systemAirSourceChiller.Capacity;
                DesignPressureDrop = systemAirSourceChiller.DesignPressureDrop;
                LossesInSizing = systemAirSourceChiller.LossesInSizing;
                ScheduleName = systemAirSourceChiller.ScheduleName;
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
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.Out, 1),
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

            if (jObject.ContainsKey("LossesInSizing"))
            {
                LossesInSizing = jObject.Value<bool>("LossesInSizing");
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject.Value<string>("ScheduleName");
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
                result.Add("Setpoint", Setpoint.ToJObject());
            }

            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJObject());
            }

            if (CondenserFanLoad != null)
            {
                result.Add("CondenserFanLoad", CondenserFanLoad.ToJObject());
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

            result.Add("LossesInSizing", LossesInSizing);

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemAirSourceChiller(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}