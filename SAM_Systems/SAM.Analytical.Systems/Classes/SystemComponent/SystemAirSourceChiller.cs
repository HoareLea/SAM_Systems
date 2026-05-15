// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
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

        public SystemAirSourceChiller(JsonObject jObject)
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
                return result;
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["Setpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["Efficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("CondenserFanLoad"))
            {
                CondenserFanLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject["CondenserFanLoad"] as JsonObject);
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

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject["ScheduleName"]?.GetValue<string>() ?? null;
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result =  base.ToJsonObject();
            if(result == null)
            {
                return result;
            }

            if(Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJsonObject());
            }

            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJsonObject());
            }

            if (CondenserFanLoad != null)
            {
                result.Add("CondenserFanLoad", CondenserFanLoad.ToJsonObject());
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