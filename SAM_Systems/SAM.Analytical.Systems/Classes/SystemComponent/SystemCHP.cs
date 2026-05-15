// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemCHP : SystemComponent, ILiquidSystemComponent
    {
        public ModifiableValue Setpoint { get; set; }
        public ModifiableValue Efficiency { get; set; }
        public ModifiableValue HeatPowerRatio { get; set; }
        public ISizableValue Duty { get; set; }
        public double DesignTemperatureDifference { get; set; }
        public double Capacity { get; set; }
        public double DesignPressureDrop { get; set; }
        public bool LossesInSizing { get; set; }
        public bool IsDomesticHotWater { get; set; }

        public string ScheduleName { get; set; }

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
                DesignTemperatureDifference = systemCHP.DesignTemperatureDifference;
                Capacity = systemCHP.Capacity;
                DesignPressureDrop = systemCHP.DesignPressureDrop;
                LossesInSizing = systemCHP.LossesInSizing;
                IsDomesticHotWater = systemCHP.IsDomesticHotWater;
                ScheduleName = systemCHP.ScheduleName;
            }
        }

        public SystemCHP(System.Guid guid, SystemCHP systemCHP)
            : base(guid, systemCHP)
        {
            if (systemCHP != null)
            {
                Setpoint = systemCHP.Setpoint;
                Efficiency = systemCHP.Efficiency;
                HeatPowerRatio = systemCHP.HeatPowerRatio;
                Duty = systemCHP.Duty;
                DesignTemperatureDifference = systemCHP.DesignTemperatureDifference;
                Capacity = systemCHP.Capacity;
                DesignPressureDrop = systemCHP.DesignPressureDrop;
                LossesInSizing = systemCHP.LossesInSizing;
                IsDomesticHotWater = systemCHP.IsDomesticHotWater;
                ScheduleName = systemCHP.ScheduleName;
            }
        }

        public SystemCHP(JsonObject jObject)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if(!result)
            {
                return false;
            }

            if(jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["Setpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["Efficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatPowerRatio"))
            {
                HeatPowerRatio = Core.Query.IJSAMObject<ModifiableValue>(jObject["HeatPowerRatio"] as JsonObject);
            }

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject["Duty"] as JsonObject);
            }

            if (jObject.ContainsKey("DesignTemperatureDifference"))
            {
                DesignTemperatureDifference = jObject["DesignTemperatureDifference"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject["Capacity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject["DesignPressureDrop"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("LossesInSizing"))
            {
                LossesInSizing = jObject["LossesInSizing"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("IsDomesticHotWater"))
            {
                IsDomesticHotWater = jObject["IsDomesticHotWater"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject["ScheduleName"]?.GetValue<string>() ?? null;
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if(result == null)
            {
                return result;
            }

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJsonObject());
            }

            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJsonObject());
            }

            if (HeatPowerRatio != null)
            {
                result.Add("HeatPowerRatio", HeatPowerRatio.ToJsonObject());
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJsonObject());
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

            result.Add("IsDomesticHotWater", IsDomesticHotWater);

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemCHP(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}