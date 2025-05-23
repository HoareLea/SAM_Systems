﻿using Newtonsoft.Json.Linq;
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

        public SystemSteamHumidifier(JObject jObject)
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

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("Duty"));
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Setpoint"));
            }

            if (jObject.ContainsKey("WaterSupplyTemperature"))
            {
                WaterSupplyTemperature = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("WaterSupplyTemperature"));
            }

            if (jObject.ContainsKey("WaterTemperatureSource"))
            {
                WaterTemperatureSource = Core.Query.Enum<SizingType>(jObject.Value<string>("WaterTemperatureSource"));
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

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJObject());
            }

            if (WaterSupplyTemperature != null)
            {
                result.Add("WaterSupplyTemperature", WaterSupplyTemperature.ToJObject());
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
