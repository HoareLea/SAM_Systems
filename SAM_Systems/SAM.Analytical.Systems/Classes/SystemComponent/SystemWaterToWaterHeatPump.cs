// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemWaterToWaterHeatPump : SystemHeatPump
    {
        public ModifiableValue HeatingSetpoint { get; set; }
        public ModifiableValue CoolingSetpoint { get; set; }
        public ModifiableValue HeatingEfficiency { get; set; }
        public ModifiableValue CoolingEfficiency { get; set; }
        public ISizableValue HeatingDuty { get; set; }
        public ISizableValue CoolingDuty { get; set; }
        public double Capacity1 { get; set; }
        public double DesignPressureDrop1 { get; set; }
        public double DesignTemperatureDifference1 { get; set; }
        public double Capacity2 { get; set; }
        public double DesignPressureDrop2 { get; set; }
        public double DesignTemperatureDifference2 { get; set; }
        public ModifiableValue MotorEfficiency { get; set; }
        public ModifiableValue AncillaryLoad { get; set; }
        public bool LossesInSizing { get; set; }
        public bool IsDomesticHotWater { get; set; }

        public string ScheduleName { get; set; }

        public SystemWaterToWaterHeatPump(string name)
            : base(name)
        {

        }

        public SystemWaterToWaterHeatPump(SystemWaterToWaterHeatPump systemWaterToWaterHeatPump)
            : base(systemWaterToWaterHeatPump)
        {
            if(systemWaterToWaterHeatPump != null)
            {
                HeatingSetpoint = systemWaterToWaterHeatPump.HeatingSetpoint?.Clone();
                CoolingSetpoint = systemWaterToWaterHeatPump.CoolingSetpoint?.Clone();
                HeatingEfficiency = systemWaterToWaterHeatPump.HeatingEfficiency?.Clone();
                CoolingEfficiency = systemWaterToWaterHeatPump.CoolingEfficiency?.Clone();
                HeatingDuty = systemWaterToWaterHeatPump.HeatingDuty?.Clone();
                CoolingDuty = systemWaterToWaterHeatPump.CoolingDuty?.Clone();
                Capacity1 = systemWaterToWaterHeatPump.Capacity1;
                DesignPressureDrop1 = systemWaterToWaterHeatPump.DesignPressureDrop1;
                DesignTemperatureDifference1 = systemWaterToWaterHeatPump.DesignTemperatureDifference1;
                Capacity2 = systemWaterToWaterHeatPump.Capacity2;
                DesignPressureDrop2 = systemWaterToWaterHeatPump.DesignPressureDrop2;
                DesignTemperatureDifference2 = systemWaterToWaterHeatPump.DesignTemperatureDifference2;
                MotorEfficiency = systemWaterToWaterHeatPump.MotorEfficiency?.Clone();
                AncillaryLoad = systemWaterToWaterHeatPump.AncillaryLoad?.Clone();
                LossesInSizing = systemWaterToWaterHeatPump.LossesInSizing;
                IsDomesticHotWater = systemWaterToWaterHeatPump.IsDomesticHotWater;
                ScheduleName = systemWaterToWaterHeatPump.ScheduleName;
            }
        }

        public SystemWaterToWaterHeatPump(System.Guid guid, SystemWaterToWaterHeatPump systemWaterToWaterHeatPump)
            : base(guid, systemWaterToWaterHeatPump)
        {
            if (systemWaterToWaterHeatPump != null)
            {
                HeatingSetpoint = systemWaterToWaterHeatPump.HeatingSetpoint?.Clone();
                CoolingSetpoint = systemWaterToWaterHeatPump.CoolingSetpoint?.Clone();
                HeatingEfficiency = systemWaterToWaterHeatPump.HeatingEfficiency?.Clone();
                CoolingEfficiency = systemWaterToWaterHeatPump.CoolingEfficiency?.Clone();
                HeatingDuty = systemWaterToWaterHeatPump.HeatingDuty?.Clone();
                CoolingDuty = systemWaterToWaterHeatPump.CoolingDuty?.Clone();
                Capacity1 = systemWaterToWaterHeatPump.Capacity1;
                DesignPressureDrop1 = systemWaterToWaterHeatPump.DesignPressureDrop1;
                DesignTemperatureDifference1 = systemWaterToWaterHeatPump.DesignTemperatureDifference1;
                Capacity2 = systemWaterToWaterHeatPump.Capacity2;
                DesignPressureDrop2 = systemWaterToWaterHeatPump.DesignPressureDrop2;
                DesignTemperatureDifference2 = systemWaterToWaterHeatPump.DesignTemperatureDifference2;
                MotorEfficiency = systemWaterToWaterHeatPump.MotorEfficiency?.Clone();
                AncillaryLoad = systemWaterToWaterHeatPump.AncillaryLoad?.Clone();
                LossesInSizing = systemWaterToWaterHeatPump.LossesInSizing;
                IsDomesticHotWater = systemWaterToWaterHeatPump.IsDomesticHotWater;
                ScheduleName = systemWaterToWaterHeatPump.ScheduleName;
            }
        }

        public SystemWaterToWaterHeatPump(JsonObject jObject)
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
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.In, 2),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.Out, 2),
                    Core.Systems.Create.SystemConnector<IControlSystem>(),
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

            if (jObject.ContainsKey("HeatingSetpoint"))
            {
                HeatingSetpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["HeatingSetpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("CoolingSetpoint"))
            {
                CoolingSetpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["CoolingSetpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatingEfficiency"))
            {
                HeatingEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["HeatingEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("CoolingEfficiency"))
            {
                CoolingEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["CoolingEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatingDuty"))
            {
                HeatingDuty = Core.Query.IJSAMObject<SizableValue>(jObject["HeatingDuty"] as JsonObject);
            }

            if (jObject.ContainsKey("CoolingDuty"))
            {
                CoolingDuty = Core.Query.IJSAMObject<SizableValue>(jObject["CoolingDuty"] as JsonObject);
            }

            if (jObject.ContainsKey("Capacity1"))
            {
                Capacity1 = jObject["Capacity1"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Capacity2"))
            {
                Capacity2 = jObject["Capacity2"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop1"))
            {
                DesignPressureDrop1 = jObject["DesignPressureDrop1"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop2"))
            {
                DesignPressureDrop2 = jObject["DesignPressureDrop2"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignTemperatureDifference1"))
            {
                DesignTemperatureDifference1 = jObject["DesignTemperatureDifference1"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignTemperatureDifference2"))
            {
                DesignTemperatureDifference2 = jObject["DesignTemperatureDifference2"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("MotorEfficiency"))
            {
                MotorEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["MotorEfficiency"] as JsonObject);
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
                return result;
            }

            if (HeatingSetpoint != null)
            {
                result.Add("HeatingSetpoint", HeatingSetpoint.ToJsonObject());
            }

            if (CoolingSetpoint != null)
            {
                result.Add("CoolingSetpoint", CoolingSetpoint.ToJsonObject());
            }

            if (HeatingEfficiency != null)
            {
                result.Add("HeatingEfficiency", HeatingEfficiency.ToJsonObject());
            }

            if (CoolingEfficiency != null)
            {
                result.Add("CoolingEfficiency", CoolingEfficiency.ToJsonObject());
            }

            if (HeatingDuty != null)
            {
                result.Add("HeatingDuty", HeatingDuty.ToJsonObject());
            }

            if (CoolingDuty != null)
            {
                result.Add("CoolingDuty", CoolingDuty.ToJsonObject());
            }

            if (!double.IsNaN(Capacity1))
            {
                result.Add("Capacity1", Capacity1);
            }

            if (!double.IsNaN(DesignPressureDrop1))
            {
                result.Add("DesignPressureDrop1", DesignPressureDrop1);
            }

            if (!double.IsNaN(DesignTemperatureDifference1))
            {
                result.Add("DesignTemperatureDifference1", DesignTemperatureDifference1);
            }

            if (!double.IsNaN(Capacity2))
            {
                result.Add("Capacity2", Capacity2);
            }

            if (!double.IsNaN(DesignPressureDrop2))
            {
                result.Add("DesignPressureDrop2", DesignPressureDrop2);
            }

            if (!double.IsNaN(DesignTemperatureDifference2))
            {
                result.Add("DesignTemperatureDifference2", DesignTemperatureDifference2);
            }

            if (MotorEfficiency != null)
            {
                result.Add("MotorEfficiency", MotorEfficiency.ToJsonObject());
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
            return new SystemWaterToWaterHeatPump(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}