﻿using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemCHP : SystemComponent
    {
        public ModifiableValue Setpoint { get; set; }
        public ModifiableValue Efficiency { get; set; }
        public ModifiableValue HeatPowerRatio { get; set; }
        public SizableValue Duty { get; set; }
        public double DesignTemperatureDiffrence { get; set; }
        public double Capacity { get; set; }
        public double DesignPressureDrop { get; set; }
        public bool LossesInSizing { get; set; }

        public SystemCHP(string name)
            : base(name)
        {

        }

        public SystemCHP(SystemCHP systemCHP)
            : base(systemCHP)
        {
            if(systemCHP != null)
            {
                Setpoint = systemCHP.Setpoint;
                Efficiency = systemCHP.Efficiency;
                HeatPowerRatio = systemCHP.HeatPowerRatio;
                Duty = systemCHP.Duty;
                DesignTemperatureDiffrence = systemCHP.DesignTemperatureDiffrence;
                Capacity = systemCHP.Capacity;
                DesignPressureDrop = systemCHP.DesignPressureDrop;
                LossesInSizing = systemCHP.LossesInSizing;
            }
        }

        public SystemCHP(JObject jObject)
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
                return false;
            }

            if(jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Setpoint"));
            }

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Efficiency"));
            }

            if (jObject.ContainsKey("HeatPowerRatio"))
            {
                HeatPowerRatio = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("HeatPowerRatio"));
            }

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("Duty"));
            }

            if (jObject.ContainsKey("DesignTemperatureDiffrence"))
            {
                DesignTemperatureDiffrence = jObject.Value<double>("DesignTemperatureDiffrence");
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

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if(result == null)
            {
                return result;
            }

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJObject());
            }

            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJObject());
            }

            if (HeatPowerRatio != null)
            {
                result.Add("HeatPowerRatio", HeatPowerRatio.ToJObject());
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJObject());
            }

            if (!double.IsNaN(DesignTemperatureDiffrence))
            {
                result.Add("DesignTemperatureDiffrence", DesignTemperatureDiffrence);
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

            return result;
        }
    }
}