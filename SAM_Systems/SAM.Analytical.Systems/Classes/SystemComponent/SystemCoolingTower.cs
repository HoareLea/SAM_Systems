using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemCoolingTower : SystemComponent
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

        public SystemCoolingTower(JObject jObject)
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

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject.Value<double>("Capacity");
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject.Value<double>("DesignPressureDrop");
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Setpoint"));
            }

            if (jObject.ContainsKey("MinApproach"))
            {
                MinApproach = jObject.Value<double>("MinApproach");
            }

            if (jObject.ContainsKey("VariableFans"))
            {
                VariableFans = jObject.Value<bool>("VariableFans");
            }

            if (jObject.ContainsKey("FanSFP"))
            {
                FanSFP = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("FanSFP"));
            }

            if (jObject.ContainsKey("HeatTransferCoefficient"))
            {
                HeatTransferCoefficient = jObject.Value<double>("HeatTransferCoefficient");
            }

            if (jObject.ContainsKey("HeatTransferSurfaceAreaSizingType"))
            {
                HeatTransferSurfaceAreaSizingType = Core.Query.Enum<SizingType>(jObject.Value<string>("HeatTransferSurfaceAreaSizingType"));
            }

            if (jObject.ContainsKey("HeatTransferSurfaceArea"))
            {
                HeatTransferSurfaceArea = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("HeatTransferSurfaceArea"));
            }

            if (jObject.ContainsKey("ExternalWetBulbTemperatureSizingType"))
            {
                ExternalWetBulbTemperatureSizingType = Core.Query.Enum<TemperatureSizingType>(jObject.Value<string>("ExternalWetBulbTemperatureSizingType"));
            }

            if (jObject.ContainsKey("ExternalWetBulbTemperature"))
            {
                ExternalWetBulbTemperature = jObject.Value<double>("ExternalWetBulbTemperature");
            }

            if (jObject.ContainsKey("DesignApproach"))
            {
                DesignApproach = jObject.Value<double>("DesignApproach");
            }

            if (jObject.ContainsKey("DesignRange"))
            {
                DesignRange = jObject.Value<double>("DesignRange");
            }

            if (jObject.ContainsKey("DesignWaterFlowRateSizingType"))
            {
                DesignWaterFlowRateSizingType = Core.Query.Enum<DesignWaterFlowRateSizingType>(jObject.Value<string>("DesignWaterFlowRateSizingType"));
            }

            if (jObject.ContainsKey("DesignWaterFlowRate"))
            {
                DesignWaterFlowRate = jObject.Value<double>("DesignWaterFlowRate");
            }

            if (jObject.ContainsKey("MaxAirFlowRateSizingType"))
            {
                MaxAirFlowRateSizingType = Core.Query.Enum<MaxAirFlowRateSizingType>(jObject.Value<string>("MaxAirFlowRateSizingType"));
            }

            if (jObject.ContainsKey("MaxAirFlowRate"))
            {
                MaxAirFlowRate = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("MaxAirFlowRate"));
            }

            if (jObject.ContainsKey("FanLoadRatio"))
            {
                FanLoadRatio = jObject.Value<double>("FanLoadRatio");
            }

            if (jObject.ContainsKey("AirWaterFlowRatio"))
            {
                AirWaterFlowRatio = jObject.Value<double>("AirWaterFlowRatio");
            }

            if (jObject.ContainsKey("MinAirFlowRate"))
            {
                MinAirFlowRate = jObject.Value<double>("MinAirFlowRate");
            }

            if (jObject.ContainsKey("FanMode2Ratio"))
            {
                FanMode2Ratio = jObject.Value<double>("FanMode2Ratio");
            }

            if (jObject.ContainsKey("WaterDriftLoss"))
            {
                WaterDriftLoss = jObject.Value<double>("WaterDriftLoss");
            }

            if (jObject.ContainsKey("BlowdownConcentrationRatio"))
            {
                BlowdownConcentrationRatio = jObject.Value<double>("BlowdownConcentrationRatio");
            }

            if (jObject.ContainsKey("AncillaryLoad"))
            {
                AncillaryLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("AncillaryLoad"));
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject.Value<string>("ScheduleName");
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
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
                result.Add("Setpoint", Setpoint.ToJObject());
            }

            if (!double.IsNaN(MinApproach))
            {
                result.Add("MinApproach", MinApproach);
            }

            result.Add("VariableFans", VariableFans);

            if (FanSFP != null)
            {
                result.Add("FanSFP", FanSFP.ToJObject());
            }

            if (!double.IsNaN(HeatTransferCoefficient))
            {
                result.Add("HeatTransferCoefficient", HeatTransferCoefficient);
            }

            result.Add("HeatTransferSurfaceAreaSizingType", HeatTransferSurfaceAreaSizingType.ToString());

            if (HeatTransferSurfaceArea != null)
            {
                result.Add("HeatTransferSurfaceArea", HeatTransferSurfaceArea.ToJObject());
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
                result.Add("MaxAirFlowRate", MaxAirFlowRate.ToJObject());
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
                result.Add("AncillaryLoad", AncillaryLoad.ToJObject());
            }

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }
    }
}