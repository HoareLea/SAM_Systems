// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemDirectEvaporativeCooler : SystemHumidifier, IAirSystemComponent
    {
        public ModifiableValue Setpoint { get; set; }

        public ModifiableValue Effectiveness { get; set; }

        public ISizableValue WaterFlowCapacity { get; set; }

        public ModifiableValue ElectricalLoad { get; set; }

        public ISizableValue TankVolume { get; set; }

        public double HoursBeforePurgingTank { get; set; }

        public new string ScheduleName { get; set; }

        public SystemDirectEvaporativeCooler(string name)
            : base(name)
        {

        }

        public SystemDirectEvaporativeCooler(Guid guid, SystemDirectEvaporativeCooler systemDirectEvaporativeCooler)
            : base(guid, systemDirectEvaporativeCooler)
        {
            if (systemDirectEvaporativeCooler != null)
            {
                Setpoint = systemDirectEvaporativeCooler.Setpoint?.Clone();
                Effectiveness = systemDirectEvaporativeCooler.Effectiveness?.Clone();
                WaterFlowCapacity = systemDirectEvaporativeCooler.WaterFlowCapacity?.Clone();
                ElectricalLoad = systemDirectEvaporativeCooler.ElectricalLoad?.Clone();
                TankVolume = systemDirectEvaporativeCooler.TankVolume?.Clone();
                HoursBeforePurgingTank = systemDirectEvaporativeCooler.HoursBeforePurgingTank;
                ScheduleName = systemDirectEvaporativeCooler.ScheduleName;
            }
        }

        public SystemDirectEvaporativeCooler(SystemDirectEvaporativeCooler systemDirectEvaporativeCooler)
            : base(systemDirectEvaporativeCooler)
        {
            if(systemDirectEvaporativeCooler != null)
            {
                Setpoint = systemDirectEvaporativeCooler.Setpoint?.Clone();
                Effectiveness = systemDirectEvaporativeCooler.Effectiveness?.Clone();
                WaterFlowCapacity = systemDirectEvaporativeCooler.WaterFlowCapacity?.Clone();
                ElectricalLoad = systemDirectEvaporativeCooler.ElectricalLoad?.Clone();
                TankVolume = systemDirectEvaporativeCooler.TankVolume?.Clone();
                HoursBeforePurgingTank = systemDirectEvaporativeCooler.HoursBeforePurgingTank;
                ScheduleName = systemDirectEvaporativeCooler.ScheduleName;
            }
        }

        public SystemDirectEvaporativeCooler(JsonObject jObject)
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

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["Setpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("Effectiveness"))
            {
                Effectiveness = Core.Query.IJSAMObject<ModifiableValue>(jObject["Effectiveness"] as JsonObject);
            }

            if (jObject.ContainsKey("WaterFlowCapacity"))
            {
                WaterFlowCapacity = Core.Query.IJSAMObject<SizableValue>(jObject["WaterFlowCapacity"] as JsonObject);
            }

            if (jObject.ContainsKey("ElectricalLoad"))
            {
                ElectricalLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject["ElectricalLoad"] as JsonObject);
            }

            if (jObject.ContainsKey("TankVolume"))
            {
                TankVolume = Core.Query.IJSAMObject<SizableValue>(jObject["TankVolume"] as JsonObject);
            }

            if (jObject.ContainsKey("HoursBeforePurgingTank"))
            {
                HoursBeforePurgingTank = jObject["HoursBeforePurgingTank"]?.GetValue<double>() ?? default(double);
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

            if (Effectiveness != null)
            {
                result.Add("Effectiveness", Effectiveness.ToJsonObject());
            }

            if (WaterFlowCapacity != null)
            {
                result.Add("WaterFlowCapacity", WaterFlowCapacity.ToJsonObject());
            }

            if (ElectricalLoad != null)
            {
                result.Add("ElectricalLoad", ElectricalLoad.ToJsonObject());
            }

            if (TankVolume != null)
            {
                result.Add("TankVolume", TankVolume.ToJsonObject());
            }

            if (!double.IsNaN(HoursBeforePurgingTank))
            {
                result.Add("HoursBeforePurgingTank", HoursBeforePurgingTank);
            }

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemDirectEvaporativeCooler(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
