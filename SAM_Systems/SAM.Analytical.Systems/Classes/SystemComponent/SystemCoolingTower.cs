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
        public SizableValue HeatTransferSurfaceArea { get; set; }
        public double LimitingWetBulbTemperature { get; set; }
        public double DesignApproach { get; set; }
        public double DesignRange { get; set; }
        public double DesignWaterFlowRate { get; set; }
        public ModifiableValue MaxAirFlowRate { get; set; }
        public double FanLoadRatio { get; set; }
        public double AirWaterFlowRatio { get; set; }
        public double MinAirFlowRate { get; set; }
        public double FanMode2Ratio { get; set; }
        public double WaterDriftLoss { get; set; }
        public double BlowdownConcentrationRatio { get; set; }
        public ModifiableValue AncillaryLoad { get; set; }

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
                HeatTransferSurfaceArea = systemCoolingTower?.HeatTransferSurfaceArea?.Clone();
                LimitingWetBulbTemperature = systemCoolingTower.LimitingWetBulbTemperature;
                DesignApproach = systemCoolingTower.DesignApproach;
                DesignRange = systemCoolingTower.DesignRange;
                DesignWaterFlowRate = systemCoolingTower.DesignWaterFlowRate;
                MaxAirFlowRate = systemCoolingTower.MaxAirFlowRate?.Clone();
                FanMode2Ratio = systemCoolingTower.FanMode2Ratio;
                WaterDriftLoss = systemCoolingTower.WaterDriftLoss;
                BlowdownConcentrationRatio = systemCoolingTower.BlowdownConcentrationRatio;
                AncillaryLoad = systemCoolingTower.AncillaryLoad?.Clone();
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

            if (jObject.ContainsKey("HeatTransferSurfaceArea"))
            {
                HeatTransferSurfaceArea = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("HeatTransferSurfaceArea"));
            }

            if (jObject.ContainsKey("LimitingWetBulbTemperature"))
            {
                LimitingWetBulbTemperature = jObject.Value<double>("LimitingWetBulbTemperature");
            }

            if (jObject.ContainsKey("DesignApproach"))
            {
                DesignApproach = jObject.Value<double>("DesignApproach");
            }

            if (jObject.ContainsKey("DesignRange"))
            {
                DesignRange = jObject.Value<double>("DesignRange");
            }

            if (jObject.ContainsKey("DesignWaterFlowRate"))
            {
                DesignWaterFlowRate = jObject.Value<double>("DesignWaterFlowRate");
            }

            if (jObject.ContainsKey("MaxAirFlowRate"))
            {
                MaxAirFlowRate = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("MaxAirFlowRate"));
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

            if (HeatTransferSurfaceArea != null)
            {
                result.Add("HeatTransferSurfaceArea", HeatTransferSurfaceArea.ToJObject());
            }

            if (!double.IsNaN(LimitingWetBulbTemperature))
            {
                result.Add("LimitingWetBulbTemperature", LimitingWetBulbTemperature);
            }

            if (!double.IsNaN(DesignApproach))
            {
                result.Add("DesignApproach", DesignApproach);
            }

            if (!double.IsNaN(DesignRange))
            {
                result.Add("DesignRange", DesignRange);
            }

            if (!double.IsNaN(DesignWaterFlowRate))
            {
                result.Add("DesignWaterFlowRate", DesignWaterFlowRate);
            }

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

            return result;
        }
    }
}