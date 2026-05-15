using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemCoolingTower : SystemComponent, ILiquidSystemComponent
    {
        public double Capacity { get; set; }
        public double DesignPressureDrop { get; set; }
        public ModifiableValue Setpoint { get; set; }
        public double MinApproach { get; set; }
        public bool VariableFans { get; set; }
        public ModifiableValue FanSFP { get; set; }
        public double HeatTransferCoefficient { get; set; }
        public SizingType HeatTransferSurfaceAreaSizingType { get; set; }
        public ISizableValue HeatTransferSurfaceArea { get; set; }
        public TemperatureSizingType ExternalWetBulbTemperatureSizingType { get; set; }
        public double ExternalWetBulbTemperature { get; set; }
        public double DesignApproach { get; set; }
        public double DesignRange { get; set; }
        public DesignWaterFlowRateSizingType DesignWaterFlowRateSizingType { get; set; }
        public double DesignWaterFlowRate { get; set; }
        public MaxAirFlowRateSizingType MaxAirFlowRateSizingType { get; set; }
        public ModifiableValue MaxAirFlowRate { get; set; }
        public double FanLoadRatio { get; set; }
        public double AirWaterFlowRatio { get; set; }
        public double MinAirFlowRate { get; set; }
        public double FanMode2Ratio { get; set; }
        public double WaterDriftLoss { get; set; }
        public double BlowdownConcentrationRatio { get; set; }
        public ModifiableValue AncillaryLoad { get; set; }

        public string ScheduleName { get; set; }

        public SystemCoolingTower(string name)
            : base(name)
        {

        }

        public SystemCoolingTower(System.Guid guid, SystemCoolingTower systemCoolingTower)
            : base(guid, systemCoolingTower)
        {
            if (systemCoolingTower != null)
            {
                Capacity = systemCoolingTower.Capacity;
                DesignPressureDrop = systemCoolingTower.DesignPressureDrop;
                Setpoint = systemCoolingTower.Setpoint?.Clone();
                MinApproach = systemCoolingTower.MinApproach;
                VariableFans = systemCoolingTower.VariableFans;
                FanSFP = systemCoolingTower.FanSFP?.Clone();
                HeatTransferCoefficient = systemCoolingTower.HeatTransferCoefficient;
                HeatTransferSurfaceAreaSizingType = systemCoolingTower.HeatTransferSurfaceAreaSizingType;
                HeatTransferSurfaceArea = systemCoolingTower?.HeatTransferSurfaceArea?.Clone();
                ExternalWetBulbTemperatureSizingType = systemCoolingTower.ExternalWetBulbTemperatureSizingType;
                ExternalWetBulbTemperature = systemCoolingTower.ExternalWetBulbTemperature;
                DesignApproach = systemCoolingTower.DesignApproach;
                DesignRange = systemCoolingTower.DesignRange;
                DesignWaterFlowRateSizingType = systemCoolingTower.DesignWaterFlowRateSizingType;
                DesignWaterFlowRate = systemCoolingTower.DesignWaterFlowRate;
                MaxAirFlowRateSizingType = systemCoolingTower.MaxAirFlowRateSizingType;
                MaxAirFlowRate = systemCoolingTower.MaxAirFlowRate?.Clone();
                FanLoadRatio = systemCoolingTower.FanLoadRatio;
                AirWaterFlowRatio = systemCoolingTower.AirWaterFlowRatio;
                MinAirFlowRate = systemCoolingTower.MinAirFlowRate;
                FanMode2Ratio = systemCoolingTower.FanMode2Ratio;
                WaterDriftLoss = systemCoolingTower.WaterDriftLoss;
                BlowdownConcentrationRatio = systemCoolingTower.BlowdownConcentrationRatio;
                AncillaryLoad = systemCoolingTower.AncillaryLoad?.Clone();
                ScheduleName = systemCoolingTower.ScheduleName;
            }
        }

        public SystemCoolingTower(SystemCoolingTower systemCoolingTower)
            : base(systemCoolingTower)
        {
            if(systemCoolingTower != null)
            {
                Capacity = systemCoolingTower.Capacity;
                DesignPressureDrop = systemCoolingTower.DesignPressureDrop;
                Setpoint = systemCoolingTower.Setpoint?.Clone();
                MinApproach = systemCoolingTower.MinApproach;
                VariableFans = systemCoolingTower.VariableFans;
                FanSFP = systemCoolingTower.FanSFP?.Clone();
                HeatTransferCoefficient = systemCoolingTower.HeatTransferCoefficient;
                HeatTransferSurfaceAreaSizingType = systemCoolingTower.HeatTransferSurfaceAreaSizingType;
                HeatTransferSurfaceArea = systemCoolingTower?.HeatTransferSurfaceArea?.Clone();
                ExternalWetBulbTemperatureSizingType = systemCoolingTower.ExternalWetBulbTemperatureSizingType;
                ExternalWetBulbTemperature = systemCoolingTower.ExternalWetBulbTemperature;
                DesignApproach = systemCoolingTower.DesignApproach;
                DesignRange = systemCoolingTower.DesignRange;
                DesignWaterFlowRateSizingType = systemCoolingTower.DesignWaterFlowRateSizingType;
                DesignWaterFlowRate = systemCoolingTower.DesignWaterFlowRate;
                MaxAirFlowRateSizingType = systemCoolingTower.MaxAirFlowRateSizingType;
                MaxAirFlowRate = systemCoolingTower.MaxAirFlowRate?.Clone();
                FanLoadRatio = systemCoolingTower.FanLoadRatio;
                AirWaterFlowRatio = systemCoolingTower.AirWaterFlowRatio;
                MinAirFlowRate = systemCoolingTower.MinAirFlowRate;
                FanMode2Ratio = systemCoolingTower.FanMode2Ratio;
                WaterDriftLoss = systemCoolingTower.WaterDriftLoss;
                BlowdownConcentrationRatio = systemCoolingTower.BlowdownConcentrationRatio;
                AncillaryLoad = systemCoolingTower.AncillaryLoad?.Clone();
                ScheduleName = systemCoolingTower.ScheduleName;
            }
        }

        public SystemCoolingTower(JsonObject jObject)
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

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject["Capacity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject["DesignPressureDrop"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["Setpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("MinApproach"))
            {
                MinApproach = jObject["MinApproach"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("VariableFans"))
            {
                VariableFans = jObject["VariableFans"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("FanSFP"))
            {
                FanSFP = Core.Query.IJSAMObject<ModifiableValue>(jObject["FanSFP"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatTransferCoefficient"))
            {
                HeatTransferCoefficient = jObject["HeatTransferCoefficient"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("HeatTransferSurfaceAreaSizingType"))
            {
                HeatTransferSurfaceAreaSizingType = Core.Query.Enum<SizingType>(jObject["HeatTransferSurfaceAreaSizingType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("HeatTransferSurfaceArea"))
            {
                HeatTransferSurfaceArea = Core.Query.IJSAMObject<SizableValue>(jObject["HeatTransferSurfaceArea"] as JsonObject);
            }

            if (jObject.ContainsKey("ExternalWetBulbTemperatureSizingType"))
            {
                ExternalWetBulbTemperatureSizingType = Core.Query.Enum<TemperatureSizingType>(jObject["ExternalWetBulbTemperatureSizingType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("ExternalWetBulbTemperature"))
            {
                ExternalWetBulbTemperature = jObject["ExternalWetBulbTemperature"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignApproach"))
            {
                DesignApproach = jObject["DesignApproach"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignRange"))
            {
                DesignRange = jObject["DesignRange"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignWaterFlowRateSizingType"))
            {
                DesignWaterFlowRateSizingType = Core.Query.Enum<DesignWaterFlowRateSizingType>(jObject["DesignWaterFlowRateSizingType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("DesignWaterFlowRate"))
            {
                DesignWaterFlowRate = jObject["DesignWaterFlowRate"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("MaxAirFlowRateSizingType"))
            {
                MaxAirFlowRateSizingType = Core.Query.Enum<MaxAirFlowRateSizingType>(jObject["MaxAirFlowRateSizingType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("MaxAirFlowRate"))
            {
                MaxAirFlowRate = Core.Query.IJSAMObject<ModifiableValue>(jObject["MaxAirFlowRate"] as JsonObject);
            }

            if (jObject.ContainsKey("FanLoadRatio"))
            {
                FanLoadRatio = jObject["FanLoadRatio"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("AirWaterFlowRatio"))
            {
                AirWaterFlowRatio = jObject["AirWaterFlowRatio"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("MinAirFlowRate"))
            {
                MinAirFlowRate = jObject["MinAirFlowRate"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("FanMode2Ratio"))
            {
                FanMode2Ratio = jObject["FanMode2Ratio"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("WaterDriftLoss"))
            {
                WaterDriftLoss = jObject["WaterDriftLoss"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("BlowdownConcentrationRatio"))
            {
                BlowdownConcentrationRatio = jObject["BlowdownConcentrationRatio"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("AncillaryLoad"))
            {
                AncillaryLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject["AncillaryLoad"] as JsonObject);
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

            if (!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            if (!double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJsonObject());
            }

            if (!double.IsNaN(MinApproach))
            {
                result.Add("MinApproach", MinApproach);
            }

            result.Add("VariableFans", VariableFans);

            if (FanSFP != null)
            {
                result.Add("FanSFP", FanSFP.ToJsonObject());
            }

            if (!double.IsNaN(HeatTransferCoefficient))
            {
                result.Add("HeatTransferCoefficient", HeatTransferCoefficient);
            }

            result.Add("HeatTransferSurfaceAreaSizingType", HeatTransferSurfaceAreaSizingType.ToString());

            if (HeatTransferSurfaceArea != null)
            {
                result.Add("HeatTransferSurfaceArea", HeatTransferSurfaceArea.ToJsonObject());
            }

            result.Add("ExternalWetBulbTemperatureSizingType", ExternalWetBulbTemperatureSizingType.ToString());

            if (!double.IsNaN(ExternalWetBulbTemperature))
            {
                result.Add("ExternalWetBulbTemperature", ExternalWetBulbTemperature);
            }

            if (!double.IsNaN(DesignApproach))
            {
                result.Add("DesignApproach", DesignApproach);
            }

            if (!double.IsNaN(DesignRange))
            {
                result.Add("DesignRange", DesignRange);
            }

            result.Add("DesignWaterFlowRateSizingType", DesignWaterFlowRateSizingType.ToString());

            if (!double.IsNaN(DesignWaterFlowRate))
            {
                result.Add("DesignWaterFlowRate", DesignWaterFlowRate);
            }

            result.Add("MaxAirFlowRateSizingType", MaxAirFlowRateSizingType.ToString());

            if (MaxAirFlowRate != null)
            {
                result.Add("MaxAirFlowRate", MaxAirFlowRate.ToJsonObject());
            }

            if (!double.IsNaN(FanLoadRatio))
            {
                result.Add("FanLoadRatio", FanLoadRatio);
            }

            if (!double.IsNaN(AirWaterFlowRatio))
            {
                result.Add("AirWaterFlowRatio", AirWaterFlowRatio);
            }

            if (!double.IsNaN(MinAirFlowRate))
            {
                result.Add("MinAirFlowRate", MinAirFlowRate);
            }

            if (!double.IsNaN(FanMode2Ratio))
            {
                result.Add("FanMode2Ratio", FanMode2Ratio);
            }

            if (!double.IsNaN(WaterDriftLoss))
            {
                result.Add("WaterDriftLoss", WaterDriftLoss);
            }

            if (!double.IsNaN(BlowdownConcentrationRatio))
            {
                result.Add("BlowdownConcentrationRatio", BlowdownConcentrationRatio);
            }

            if (AncillaryLoad != null)
            {
                result.Add("AncillaryLoad", AncillaryLoad.ToJsonObject());
            }

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemCoolingTower(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}