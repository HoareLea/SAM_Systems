// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemSteamHumidifier : SystemHumidifier
    {
        public ISizableValue Duty { get; set; }
        public ModifiableValue Setpoint { get; set; }
        public ModifiableValue WaterSupplyTemperature { get; set; }
        public SizingType WaterTemperatureSource { get; set; }

        public SystemSteamHumidifier(string name)
            : base(name)
        {

        }

        public SystemSteamHumidifier(SystemSteamHumidifier systemSteamHumidifier)
            : base(systemSteamHumidifier)
        {
            if(systemSteamHumidifier != null)
            {
                Duty = systemSteamHumidifier.Duty?.Clone();
                Setpoint = systemSteamHumidifier.Setpoint?.Clone();
                WaterSupplyTemperature = systemSteamHumidifier.WaterSupplyTemperature?.Clone();
                WaterTemperatureSource = systemSteamHumidifier.WaterTemperatureSource;
            }
        }

        public SystemSteamHumidifier(System.Guid guid, SystemSteamHumidifier systemSteamHumidifier)
            : base(guid, systemSteamHumidifier)
        {
            if (systemSteamHumidifier != null)
            {
                Duty = systemSteamHumidifier.Duty?.Clone();
                Setpoint = systemSteamHumidifier.Setpoint?.Clone();
                WaterSupplyTemperature = systemSteamHumidifier.WaterSupplyTemperature?.Clone();
                WaterTemperatureSource = systemSteamHumidifier.WaterTemperatureSource;
            }
        }

        public SystemSteamHumidifier(JsonObject jObject)
            : base(jObject)
        {

        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject["Duty"] as JsonObject);
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["Setpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("WaterSupplyTemperature"))
            {
                WaterSupplyTemperature = Core.Query.IJSAMObject<ModifiableValue>(jObject["WaterSupplyTemperature"] as JsonObject);
            }

            if (jObject.ContainsKey("WaterTemperatureSource"))
            {
                WaterTemperatureSource = Core.Query.Enum<SizingType>(jObject["WaterTemperatureSource"]?.GetValue<string>() ?? null);
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if (result == null)
            {
                return null;
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJsonObject());
            }

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJsonObject());
            }

            if (WaterSupplyTemperature != null)
            {
                result.Add("WaterSupplyTemperature", WaterSupplyTemperature.ToJsonObject());
            }

            result.Add("WaterTemperatureSource", WaterTemperatureSource.ToString());

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemSteamHumidifier(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
