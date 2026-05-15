// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemBoiler: SystemComponent, ILiquidSystemComponent
    {
        public ModifiableValue Setpoint { get; set; }        
        public ModifiableValue Efficiency { get; set; }
        public ISizableValue Duty { get; set; }
        public double DesignTemperatureDifference { get; set; }
        public double Capacity { get; set; }
        public double DesignPressureDrop { get; set; }
        public ModifiableValue AncillaryLoad { get; set; }
        public bool LossesInSizing { get; set; }
        public bool IsDomesticHotWater { get; set; }

        public string ScheduleName { get; set; }

        public SystemBoiler(SystemBoiler systemBoiler)
            : base(systemBoiler)
        {
            if(systemBoiler != null)
            {
                Setpoint = systemBoiler.Setpoint?.Clone();
                Efficiency = systemBoiler.Efficiency?.Clone();
                Duty = systemBoiler.Duty?.Clone();
                DesignTemperatureDifference = systemBoiler.DesignTemperatureDifference;
                Capacity = systemBoiler.Capacity;
                DesignPressureDrop = systemBoiler.DesignPressureDrop;
                AncillaryLoad = systemBoiler.AncillaryLoad?.Clone();
                LossesInSizing = systemBoiler.LossesInSizing;
                IsDomesticHotWater = systemBoiler.IsDomesticHotWater;
                ScheduleName = systemBoiler.ScheduleName;
            }
        }

        public SystemBoiler(System.Guid guid, SystemBoiler systemBoiler)
            : base(guid, systemBoiler)
        {
            if (systemBoiler != null)
            {
                Setpoint = systemBoiler.Setpoint?.Clone();
                Efficiency = systemBoiler.Efficiency?.Clone();
                Duty = systemBoiler.Duty?.Clone();
                DesignTemperatureDifference = systemBoiler.DesignTemperatureDifference;
                Capacity = systemBoiler.Capacity;
                DesignPressureDrop = systemBoiler.DesignPressureDrop;
                AncillaryLoad = systemBoiler.AncillaryLoad?.Clone();
                LossesInSizing = systemBoiler.LossesInSizing;
                IsDomesticHotWater = systemBoiler.IsDomesticHotWater;
                ScheduleName = systemBoiler.ScheduleName;
            }
        }


        public SystemBoiler(string name)
            : base(name)
        {

        }

        public SystemBoiler(JsonObject jObject)
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
            if (!result)
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

            if (jObject.ContainsKey("AncillaryLoad"))
            {
                AncillaryLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject["AncillaryLoad"] as JsonObject);
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
            if (result == null)
            {
                return null;
            }

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJsonObject());
            }

            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJsonObject());
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJsonObject());
            }

            if (double.IsNaN(DesignTemperatureDifference))
            {
                result.Add("DesignTemperatureDifference", DesignTemperatureDifference);
            }

            if (double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            if (double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            if (AncillaryLoad != null)
            {
                result.Add("AncillaryLoad", AncillaryLoad.ToJsonObject());
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
            return new SystemBoiler(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
