// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemWaterSourceHeatPump : SystemHeatPump
    {
        public HeatPumpType HeatPumpType { get; set; }
        public ISizableValue CoolingCapacity { get; set; }
        public ModifiableValue CoolingPower { get; set; }
        public ModifiableValue HeatingCapacity { get; set; }
        public ModifiableValue HeatingPower { get; set; }
        public double HeatingCoolingDutyRatio { get; set; }
        public double HeatingCapacityPowerRatio { get; set; }
        public double CoolingCapacityPowerRatio { get; set; }
        public double DesignPressureDrop { get; set; }
        public double Capacity { get; set; }
        public double DesignTemperatureDifference { get; set; }
        public double StandbyPower { get; set; }
        /// <summary>
        /// Exchange Demand Factor for heating mode
        /// </summary>
        public double ADFHeatingMode { get; set; }
        /// <summary>
        /// Exchange Demand Factor for cooling mode
        /// </summary>
        public double ADFCoolingMode { get; set; }
        public double PortHeatingPower { get; set; }
        public double PortCoolingPower { get; set; }
        public ModifiableValue MotorEfficiency { get; set; }
        public double HeatSizeFraction { get; set; }
        public ModifiableValue AncillaryLoad { get; set; }
        public bool IsDomesticHotWater { get; set; }

        public string ScheduleName { get; set; }

        public SystemWaterSourceHeatPump(string name)
            : base(name)
        {

        }

        public SystemWaterSourceHeatPump(SystemWaterSourceHeatPump systemWaterSourceHeatPump)
            : base(systemWaterSourceHeatPump)
        {
            if (systemWaterSourceHeatPump != null)
            {
                HeatPumpType = systemWaterSourceHeatPump.HeatPumpType;
                CoolingCapacity = systemWaterSourceHeatPump.CoolingCapacity?.Clone();
                CoolingPower = systemWaterSourceHeatPump?.CoolingPower?.Clone();
                HeatingCapacity = systemWaterSourceHeatPump.HeatingCapacity?.Clone();
                HeatingPower = systemWaterSourceHeatPump.HeatingPower?.Clone();
                HeatingCoolingDutyRatio = systemWaterSourceHeatPump.HeatingCoolingDutyRatio;
                HeatingCapacityPowerRatio = systemWaterSourceHeatPump.HeatingCapacityPowerRatio;
                CoolingCapacityPowerRatio = systemWaterSourceHeatPump.CoolingCapacityPowerRatio;
                DesignPressureDrop = systemWaterSourceHeatPump.DesignPressureDrop;
                Capacity = systemWaterSourceHeatPump.Capacity;
                DesignTemperatureDifference = systemWaterSourceHeatPump.DesignTemperatureDifference;
                StandbyPower = systemWaterSourceHeatPump.StandbyPower;
                ADFHeatingMode = systemWaterSourceHeatPump.ADFHeatingMode;
                ADFCoolingMode = systemWaterSourceHeatPump.ADFCoolingMode;
                PortHeatingPower = systemWaterSourceHeatPump.PortHeatingPower;
                PortCoolingPower = systemWaterSourceHeatPump.PortCoolingPower;
                MotorEfficiency = systemWaterSourceHeatPump.MotorEfficiency?.Clone();
                HeatSizeFraction = systemWaterSourceHeatPump.HeatSizeFraction;
                AncillaryLoad = systemWaterSourceHeatPump.AncillaryLoad?.Clone();
                IsDomesticHotWater = systemWaterSourceHeatPump.IsDomesticHotWater;
                ScheduleName = systemWaterSourceHeatPump.ScheduleName;
            }
        }

        public SystemWaterSourceHeatPump(System.Guid guid, SystemWaterSourceHeatPump systemWaterSourceHeatPump)
            : base(guid, systemWaterSourceHeatPump)
        {
            if (systemWaterSourceHeatPump != null)
            {
                HeatPumpType = systemWaterSourceHeatPump.HeatPumpType;
                CoolingCapacity = systemWaterSourceHeatPump.CoolingCapacity?.Clone();
                CoolingPower = systemWaterSourceHeatPump?.CoolingPower?.Clone();
                HeatingCapacity = systemWaterSourceHeatPump.HeatingCapacity?.Clone();
                HeatingPower = systemWaterSourceHeatPump.HeatingPower?.Clone();
                HeatingCoolingDutyRatio = systemWaterSourceHeatPump.HeatingCoolingDutyRatio;
                HeatingCapacityPowerRatio = systemWaterSourceHeatPump.HeatingCapacityPowerRatio;
                CoolingCapacityPowerRatio = systemWaterSourceHeatPump.CoolingCapacityPowerRatio;
                DesignPressureDrop = systemWaterSourceHeatPump.DesignPressureDrop;
                Capacity = systemWaterSourceHeatPump.Capacity;
                DesignTemperatureDifference = systemWaterSourceHeatPump.DesignTemperatureDifference;
                StandbyPower = systemWaterSourceHeatPump.StandbyPower;
                ADFHeatingMode = systemWaterSourceHeatPump.ADFHeatingMode;
                ADFCoolingMode = systemWaterSourceHeatPump.ADFCoolingMode;
                PortHeatingPower = systemWaterSourceHeatPump.PortHeatingPower;
                PortCoolingPower = systemWaterSourceHeatPump.PortCoolingPower;
                MotorEfficiency = systemWaterSourceHeatPump.MotorEfficiency?.Clone();
                HeatSizeFraction = systemWaterSourceHeatPump.HeatSizeFraction;
                AncillaryLoad = systemWaterSourceHeatPump.AncillaryLoad?.Clone();
                IsDomesticHotWater = systemWaterSourceHeatPump.IsDomesticHotWater;
                ScheduleName = systemWaterSourceHeatPump.ScheduleName;
            }
        }

        public SystemWaterSourceHeatPump(JsonObject jObject)
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

            if (jObject.ContainsKey("HeatPumpType"))
            {
                HeatPumpType = Core.Query.Enum<HeatPumpType>(jObject["HeatPumpType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("CoolingCapacity"))
            {
                CoolingCapacity = Core.Query.IJSAMObject<SizableValue>(jObject["CoolingCapacity"] as JsonObject);
            }

            if (jObject.ContainsKey("CoolingPower"))
            {
                CoolingPower = Core.Query.IJSAMObject<ModifiableValue>(jObject["CoolingPower"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatingCapacity"))
            {
                HeatingCapacity = Core.Query.IJSAMObject<ModifiableValue>(jObject["HeatingCapacity"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatingPower"))
            {
                HeatingPower = Core.Query.IJSAMObject<ModifiableValue>(jObject["HeatingPower"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatingCoolingDutyRatio"))
            {
                HeatingCoolingDutyRatio = jObject["HeatingCoolingDutyRatio"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("HeatingCapacityPowerRatio"))
            {
                HeatingCapacityPowerRatio = jObject["HeatingCapacityPowerRatio"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("CoolingCapacityPowerRatio"))
            {
                CoolingCapacityPowerRatio = jObject["CoolingCapacityPowerRatio"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject["DesignPressureDrop"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject["Capacity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignTemperatureDifference"))
            {
                DesignTemperatureDifference = jObject["DesignTemperatureDifference"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("StandbyPower"))
            {
                StandbyPower = jObject["StandbyPower"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("ADFHeatingMode"))
            {
                ADFHeatingMode = jObject["ADFHeatingMode"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("ADFCoolingMode"))
            {
                ADFCoolingMode = jObject["ADFCoolingMode"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("PortHeatingPower"))
            {
                PortHeatingPower = jObject["PortHeatingPower"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("PortCoolingPower"))
            {
                PortCoolingPower = jObject["PortCoolingPower"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("MotorEfficiency"))
            {
                MotorEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["MotorEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatSizeFraction"))
            {
                HeatSizeFraction = jObject["HeatSizeFraction"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("AncillaryLoad"))
            {
                AncillaryLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject["AncillaryLoad"] as JsonObject);
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

            result.Add("HeatPumpType", HeatPumpType.ToString());

            if (CoolingCapacity != null)
            {
                result.Add("CoolingCapacity", CoolingCapacity.ToJsonObject());
            }

            if (CoolingPower != null)
            {
                result.Add("CoolingPower", CoolingPower.ToJsonObject());
            }

            if (HeatingCapacity != null)
            {
                result.Add("HeatingCapacity", HeatingCapacity.ToJsonObject());
            }

            if (HeatingPower != null)
            {
                result.Add("HeatingPower", HeatingPower.ToJsonObject());
            }

            if (!double.IsNaN(HeatingCoolingDutyRatio))
            {
                result.Add("HeatingCoolingDutyRatio", HeatingCoolingDutyRatio);
            }

            if (!double.IsNaN(HeatingCapacityPowerRatio))
            {
                result.Add("HeatingCapacityPowerRatio", HeatingCapacityPowerRatio);
            }

            if (!double.IsNaN(CoolingCapacityPowerRatio))
            {
                result.Add("CoolingCapacityPowerRatio", CoolingCapacityPowerRatio);
            }

            if (!double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            if (!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            if (!double.IsNaN(DesignTemperatureDifference))
            {
                result.Add("DesignTemperatureDifference", DesignTemperatureDifference);
            }

            if (!double.IsNaN(StandbyPower))
            {
                result.Add("StandbyPower", StandbyPower);
            }

            if (!double.IsNaN(ADFHeatingMode))
            {
                result.Add("ADFHeatingMode", ADFHeatingMode);
            }

            if (!double.IsNaN(ADFCoolingMode))
            {
                result.Add("ADFCoolingMode", ADFCoolingMode);
            }

            if (!double.IsNaN(PortHeatingPower))
            {
                result.Add("PortHeatingPower", PortHeatingPower);
            }

            if (!double.IsNaN(PortCoolingPower))
            {
                result.Add("PortCoolingPower", PortCoolingPower);
            }

            if (MotorEfficiency != null)
            {
                result.Add("MotorEfficiency", MotorEfficiency.ToJsonObject());
            }

            if (!double.IsNaN(HeatSizeFraction))
            {
                result.Add("HeatSizeFraction", HeatSizeFraction);
            }

            if (AncillaryLoad != null)
            {
                result.Add("AncillaryLoad", AncillaryLoad.ToJsonObject());
            }

            result.Add("IsDomesticHotWater", IsDomesticHotWater);

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemWaterSourceHeatPump(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}