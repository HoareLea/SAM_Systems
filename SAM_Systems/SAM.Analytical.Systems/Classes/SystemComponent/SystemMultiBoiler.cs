// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemMultiBoiler : SystemMultiComponent<SystemMultiBoilerItem>, ILiquidSystemComponent
    {
        public ModifiableValue Setpoint { get; set; }
        public ISizableValue Duty { get; set; }
        public double DesignTemperatureDifference { get; set; }
        public double DesignPressureDrop { get; set; }
        public double Capacity { get; set; }
        public bool LossesInSizing { get; set; }
        public EquipmentSequence Sequence { get; set; }
        public bool IsDomesticHotWater { get; set; }

        public string ScheduleName { get; set; }

        public SystemMultiBoiler(string name)
            : base(name)
        {

        }

        public SystemMultiBoiler(SystemMultiBoiler systemMultiBoiler)
            : base(systemMultiBoiler)
        {
            if(systemMultiBoiler != null)
            {
                Setpoint = systemMultiBoiler.Setpoint?.Clone();
                Duty = systemMultiBoiler.Duty.Clone();
                DesignTemperatureDifference = systemMultiBoiler.DesignTemperatureDifference;
                DesignPressureDrop = systemMultiBoiler.DesignPressureDrop;
                LossesInSizing = systemMultiBoiler.LossesInSizing;
                Sequence = systemMultiBoiler.Sequence;
                IsDomesticHotWater = systemMultiBoiler.IsDomesticHotWater;
                Capacity = systemMultiBoiler.Capacity;
                ScheduleName = systemMultiBoiler.ScheduleName;
            }
        }

        public SystemMultiBoiler(System.Guid guid, SystemMultiBoiler systemMultiBoiler)
            : base(guid, systemMultiBoiler)
        {
            if (systemMultiBoiler != null)
            {
                Setpoint = systemMultiBoiler.Setpoint?.Clone();
                Duty = systemMultiBoiler.Duty.Clone();
                DesignTemperatureDifference = systemMultiBoiler.DesignTemperatureDifference;
                DesignPressureDrop = systemMultiBoiler.DesignPressureDrop;
                LossesInSizing = systemMultiBoiler.LossesInSizing;
                Sequence = systemMultiBoiler.Sequence;
                IsDomesticHotWater = systemMultiBoiler.IsDomesticHotWater;
                Capacity = systemMultiBoiler.Capacity;
                ScheduleName = systemMultiBoiler.ScheduleName;
            }
        }

        public SystemMultiBoiler(JsonObject jObject)
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

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject["Duty"] as JsonObject);
            }

            if (jObject.ContainsKey("DesignTemperatureDifference"))
            {
                DesignTemperatureDifference = jObject["DesignTemperatureDifference"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject["DesignPressureDrop"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("LossesInSizing"))
            {
                LossesInSizing = jObject["LossesInSizing"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("Sequence"))
            {
                Sequence = Core.Query.Enum<EquipmentSequence>(jObject["Sequence"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject["Capacity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("IsDomesticHotWater"))
            {
                IsDomesticHotWater = jObject["IsDomesticHotWater"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject["ScheduleName"]?.GetValue<string>() ?? null;
            }

            return true;
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

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJsonObject());
            }

            if (!double.IsNaN(DesignTemperatureDifference))
            {
                result.Add("DesignTemperatureDifference", DesignTemperatureDifference);
            }

            if (!double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            if (!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            result.Add("LossesInSizing", LossesInSizing);

            result.Add("IsDomesticHotWater", IsDomesticHotWater);

            result.Add("Sequence", Sequence.ToString());

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemMultiBoiler(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}


