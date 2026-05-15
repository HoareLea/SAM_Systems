// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemAirSourceHeatPump : SystemHeatPump, ILiquidSystemComponent
    {
        public HeatPumpType HeatPumpType { get; set; }
        public ISizableValue CoolingCapacity { get; set; }
        public ModifiableValue CoolingPower { get; set; }
        public ModifiableValue HeatingCapacity { get; set; }
        public ModifiableValue HeatingPower { get; set; }
        public ModifiableValue CondenserFanLoad { get; set; }
        public double HeatingCoolingDutyRatio { get; set; }
        public double HeatingCapacityPowerRatio { get; set; }
        public double CoolingCapacityPowerRatio { get; set; }
        public double MaxDemandFanRatio { get; set; }
        public double StandbyPower { get; set; }
        /// <summary>
        /// Exchange Demand Factor for heating mode
        /// </summary>
        public double ADFHeatingMode { get; set; }
        /// <summary>
        /// Exchange Demand Factor for cooling mode
        /// </summary>
        public double ADFCoolingMode { get; set; }
        /// <summary>
        /// Consumption per port heating power
        /// </summary>
        public double PortHeatingPower { get; set; }
        /// <summary>
        /// Consumption per port cooling power
        /// </summary>
        public double PortCoolingPower { get; set; }
        public double WaterPipeLength { get; set; }
        public ModifiableValue AncillaryLoad { get; set; }
        public double HeatSizeFraction { get; set; }
        public bool IsDomesticHotWater { get; set; }

        public string ScheduleName { get; set; }

        public SystemAirSourceHeatPump(string name)
            : base(name)
        {

        }

        public SystemAirSourceHeatPump(SystemAirSourceHeatPump systemAirSourceHeatPump)
            : base(systemAirSourceHeatPump)
        {
            if(systemAirSourceHeatPump != null)
            {
                HeatPumpType = systemAirSourceHeatPump.HeatPumpType;
                CoolingCapacity = systemAirSourceHeatPump.CoolingCapacity?.Clone();
                CoolingPower = systemAirSourceHeatPump?.CoolingPower?.Clone();
                HeatingCapacity = systemAirSourceHeatPump.HeatingCapacity?.Clone();
                HeatingPower = systemAirSourceHeatPump.HeatingPower?.Clone();
                CondenserFanLoad = systemAirSourceHeatPump.CondenserFanLoad?.Clone();
                HeatingCoolingDutyRatio = systemAirSourceHeatPump.HeatingCoolingDutyRatio;
                HeatingCapacityPowerRatio = systemAirSourceHeatPump.HeatingCapacityPowerRatio;
                CoolingCapacityPowerRatio = systemAirSourceHeatPump.CoolingCapacityPowerRatio;
                MaxDemandFanRatio = systemAirSourceHeatPump.MaxDemandFanRatio;
                StandbyPower = systemAirSourceHeatPump.StandbyPower;
                ADFHeatingMode = systemAirSourceHeatPump.ADFHeatingMode;
                ADFCoolingMode = systemAirSourceHeatPump.ADFCoolingMode;
                PortHeatingPower = systemAirSourceHeatPump.PortHeatingPower;
                PortCoolingPower = systemAirSourceHeatPump.PortCoolingPower;
                WaterPipeLength = systemAirSourceHeatPump.WaterPipeLength;
                AncillaryLoad = systemAirSourceHeatPump.AncillaryLoad?.Clone();
                HeatSizeFraction = systemAirSourceHeatPump.HeatSizeFraction;
                IsDomesticHotWater = systemAirSourceHeatPump.IsDomesticHotWater;
                ScheduleName = systemAirSourceHeatPump.ScheduleName;
            }
        }

        public SystemAirSourceHeatPump(System.Guid guid, SystemAirSourceHeatPump systemAirSourceHeatPump)
            : base(guid, systemAirSourceHeatPump)
        {
            if (systemAirSourceHeatPump != null)
            {
                HeatPumpType = systemAirSourceHeatPump.HeatPumpType;
                CoolingCapacity = systemAirSourceHeatPump.CoolingCapacity?.Clone();
                CoolingPower = systemAirSourceHeatPump?.CoolingPower?.Clone();
                HeatingCapacity = systemAirSourceHeatPump.HeatingCapacity?.Clone();
                HeatingPower = systemAirSourceHeatPump.HeatingPower?.Clone();
                CondenserFanLoad = systemAirSourceHeatPump.CondenserFanLoad?.Clone();
                HeatingCoolingDutyRatio = systemAirSourceHeatPump.HeatingCoolingDutyRatio;
                HeatingCapacityPowerRatio = systemAirSourceHeatPump.HeatingCapacityPowerRatio;
                CoolingCapacityPowerRatio = systemAirSourceHeatPump.CoolingCapacityPowerRatio;
                MaxDemandFanRatio = systemAirSourceHeatPump.MaxDemandFanRatio;
                StandbyPower = systemAirSourceHeatPump.StandbyPower;
                ADFHeatingMode = systemAirSourceHeatPump.ADFHeatingMode;
                ADFCoolingMode = systemAirSourceHeatPump.ADFCoolingMode;
                PortHeatingPower = systemAirSourceHeatPump.PortHeatingPower;
                PortCoolingPower = systemAirSourceHeatPump.PortCoolingPower;
                WaterPipeLength = systemAirSourceHeatPump.WaterPipeLength;
                AncillaryLoad = systemAirSourceHeatPump.AncillaryLoad?.Clone();
                HeatSizeFraction = systemAirSourceHeatPump.HeatSizeFraction;
                IsDomesticHotWater = systemAirSourceHeatPump.IsDomesticHotWater;
                ScheduleName = systemAirSourceHeatPump.ScheduleName;
            }
        }

        public SystemAirSourceHeatPump(JsonObject jObject)
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

            if (jObject.ContainsKey("CondenserFanLoad"))
            {
                CondenserFanLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject["CondenserFanLoad"] as JsonObject);
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

            if (jObject.ContainsKey("MaxDemandFanRatio"))
            {
                MaxDemandFanRatio = jObject["MaxDemandFanRatio"]?.GetValue<double>() ?? default(double);
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

            if (jObject.ContainsKey("WaterPipeLength"))
            {
                WaterPipeLength = jObject["WaterPipeLength"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("AncillaryLoad"))
            {
                AncillaryLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject["AncillaryLoad"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatSizeFraction"))
            {
                HeatSizeFraction = jObject["HeatSizeFraction"]?.GetValue<double>() ?? default(double);
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

            if (CondenserFanLoad != null)
            {
                result.Add("CondenserFanLoad", CondenserFanLoad.ToJsonObject());
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

            if (!double.IsNaN(MaxDemandFanRatio))
            {
                result.Add("MaxDemandFanRatio", MaxDemandFanRatio);
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

            if (!double.IsNaN(WaterPipeLength))
            {
                result.Add("WaterPipeLength", WaterPipeLength);
            }

            if (AncillaryLoad != null)
            {
                result.Add("AncillaryLoad", AncillaryLoad.ToJsonObject());
            }

            if (!double.IsNaN(HeatSizeFraction))
            {
                result.Add("HeatSizeFraction", HeatSizeFraction);
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
            return new SystemAirSourceHeatPump(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}