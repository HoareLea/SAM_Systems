using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemDryCooler : SystemComponent, IAirSystemComponent
    {
        public double DesignPressureDrop { get; set; }
        public double Capacity { get; set; }
        public ModifiableValue CoolingSetpoint { get; set; }
        public ISizableValue MaxFlowRate { get; set; }
        public ModifiableValue FanSFP { get; set; }
        public ExchangerCalculationMethod DryCoolerExchangerCalculationMethod { get; set; }
        public ModifiableValue Efficiency { get; set; }
        public double HeatTransferSurfaceArea { get; set; }
        public double HeatTransferCoefficient { get; set; }
        public ExchangerType ExchangerType { get; set; }
        public bool AllowHeating { get; set; }
        public ModifiableValue HeatingSetpoint { get; set; }
        public double MinSetpointTemperatureDifferenceCooling { get; set; }
        public double MinSetpointTemperatureDifferenceHeating { get; set; }
        public bool HasPreCooling { get; set; }
        public ModifiableValue PreCoolingEffectiveness { get; set; }
        public ModifiableValue AncillaryLoad { get; set; }
        public ISizableValue PreCoolingWaterFlowCapacity { get; set; }
        public double MinAirFlowRate { get; set; }
        public double MinAirFlowRatio { get; set; }
        public bool VariableFans { get; set; }
        public double ExternalDryBulbTemperature { get; set; }
        public TemperatureSizingType ExternalDryBulbTemperatureSizingType { get; set; }
        public double LimitingDryBulbTemperature { get; set; }
        public double DesignRange { get; set; }
        public double DesignWaterFlowRate { get; set; }
        public DesignWaterFlowRateSizingType DesignWaterFlowRateSizingType { get; set; }

        public string ScheduleName { get; set; }


        public SystemDryCooler(string name)
            : base(name)
        {

        }

        public SystemDryCooler(System.Guid guid, SystemDryCooler systemDryCooler)
            : base(guid, systemDryCooler)
        {
            if (systemDryCooler != null)
            {
                DesignPressureDrop = systemDryCooler.DesignPressureDrop;
                Capacity = systemDryCooler.Capacity;
                CoolingSetpoint = systemDryCooler.CoolingSetpoint?.Clone();
                MaxFlowRate = systemDryCooler.MaxFlowRate?.Clone();
                FanSFP = systemDryCooler.FanSFP?.Clone();
                DryCoolerExchangerCalculationMethod = systemDryCooler.DryCoolerExchangerCalculationMethod;
                Efficiency = systemDryCooler.Efficiency?.Clone();
                HeatTransferSurfaceArea = systemDryCooler.HeatTransferSurfaceArea;
                HeatTransferCoefficient = systemDryCooler.HeatTransferCoefficient;
                ExchangerType = systemDryCooler.ExchangerType;
                AllowHeating = systemDryCooler.AllowHeating;
                HeatingSetpoint = systemDryCooler.HeatingSetpoint?.Clone();
                MinSetpointTemperatureDifferenceCooling = systemDryCooler.MinSetpointTemperatureDifferenceCooling;
                MinSetpointTemperatureDifferenceHeating = systemDryCooler.MinSetpointTemperatureDifferenceHeating;
                HasPreCooling = systemDryCooler.HasPreCooling;
                PreCoolingEffectiveness = systemDryCooler.PreCoolingEffectiveness?.Clone();
                AncillaryLoad = systemDryCooler.AncillaryLoad?.Clone();
                PreCoolingWaterFlowCapacity = systemDryCooler.PreCoolingWaterFlowCapacity?.Clone();
                MinAirFlowRate = systemDryCooler.MinAirFlowRate;
                MinAirFlowRatio = systemDryCooler.MinAirFlowRatio;
                VariableFans = systemDryCooler.VariableFans;
                ExternalDryBulbTemperature = systemDryCooler.ExternalDryBulbTemperature;
                ExternalDryBulbTemperatureSizingType = systemDryCooler.ExternalDryBulbTemperatureSizingType;
                LimitingDryBulbTemperature = systemDryCooler.LimitingDryBulbTemperature;
                DesignRange = systemDryCooler.DesignRange;
                DesignWaterFlowRate = systemDryCooler.DesignWaterFlowRate;
                DesignWaterFlowRateSizingType = systemDryCooler.DesignWaterFlowRateSizingType;
                ScheduleName = systemDryCooler.ScheduleName;
            }
        }

        public SystemDryCooler(SystemDryCooler systemDryCooler)
            : base(systemDryCooler)
        {
            if(systemDryCooler != null)
            {
                DesignPressureDrop = systemDryCooler.DesignPressureDrop;
                Capacity = systemDryCooler.Capacity;
                CoolingSetpoint = systemDryCooler.CoolingSetpoint?.Clone();
                MaxFlowRate = systemDryCooler.MaxFlowRate?.Clone();
                FanSFP = systemDryCooler.FanSFP?.Clone();
                DryCoolerExchangerCalculationMethod = systemDryCooler.DryCoolerExchangerCalculationMethod;
                Efficiency = systemDryCooler.Efficiency?.Clone();
                HeatTransferSurfaceArea = systemDryCooler.HeatTransferSurfaceArea;
                HeatTransferCoefficient = systemDryCooler.HeatTransferCoefficient;
                ExchangerType = systemDryCooler.ExchangerType;
                AllowHeating = systemDryCooler.AllowHeating;
                HeatingSetpoint = systemDryCooler.HeatingSetpoint?.Clone();
                MinSetpointTemperatureDifferenceCooling = systemDryCooler.MinSetpointTemperatureDifferenceCooling;
                MinSetpointTemperatureDifferenceHeating = systemDryCooler.MinSetpointTemperatureDifferenceHeating;
                HasPreCooling = systemDryCooler.HasPreCooling;
                PreCoolingEffectiveness = systemDryCooler.PreCoolingEffectiveness?.Clone();
                AncillaryLoad = systemDryCooler.AncillaryLoad?.Clone();
                PreCoolingWaterFlowCapacity = systemDryCooler.PreCoolingWaterFlowCapacity?.Clone();
                MinAirFlowRate = systemDryCooler.MinAirFlowRate;
                MinAirFlowRatio = systemDryCooler.MinAirFlowRatio;
                VariableFans = systemDryCooler.VariableFans;
                ExternalDryBulbTemperature = systemDryCooler.ExternalDryBulbTemperature;
                ExternalDryBulbTemperatureSizingType = systemDryCooler.ExternalDryBulbTemperatureSizingType;
                LimitingDryBulbTemperature = systemDryCooler.LimitingDryBulbTemperature;
                DesignRange = systemDryCooler.DesignRange;
                DesignWaterFlowRate = systemDryCooler.DesignWaterFlowRate;
                DesignWaterFlowRateSizingType = systemDryCooler.DesignWaterFlowRateSizingType;
                ScheduleName = systemDryCooler.ScheduleName;
            }
        }

        public SystemDryCooler(JObject jObject)
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
            if (!result)
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

            if (jObject.ContainsKey("CoolingSetpoint"))
            {
                CoolingSetpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("CoolingSetpoint"));
            }

            if (jObject.ContainsKey("MaxFlowRate"))
            {
                MaxFlowRate = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("MaxFlowRate"));
            }

            if (jObject.ContainsKey("FanSFP"))
            {
                FanSFP = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("FanSFP"));
            }

            if (jObject.ContainsKey("DryCoolerExchangerCalculationMethod"))
            {
                DryCoolerExchangerCalculationMethod = Core.Query.Enum<ExchangerCalculationMethod>(jObject.Value<string>("DryCoolerExchangerCalculationMethod"));
            }

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Efficiency"));
            }

            if (jObject.ContainsKey("HeatTransferSurfaceArea"))
            {
                HeatTransferSurfaceArea = jObject.Value<double>("HeatTransferSurfaceArea");
            }

            if (jObject.ContainsKey("HeatTransferCoefficient"))
            {
                HeatTransferCoefficient = jObject.Value<double>("HeatTransferCoefficient");
            }

            if (jObject.ContainsKey("ExchangerType"))
            {
                ExchangerType = Core.Query.Enum<ExchangerType>(jObject.Value<string>("ExchangerType"));
            }

            if (jObject.ContainsKey("AllowHeating"))
            {
                AllowHeating = jObject.Value<bool>("AllowHeating");
            }

            if (jObject.ContainsKey("HeatingSetpoint"))
            {
                HeatingSetpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("HeatingSetpoint"));
            }

            if (jObject.ContainsKey("MinSetpointTemperatureDifferenceCooling"))
            {
                MinSetpointTemperatureDifferenceCooling = jObject.Value<double>("MinSetpointTemperatureDifferenceCooling");
            }

            if (jObject.ContainsKey("MinSetpointTemperatureDifferenceHeating"))
            {
                MinSetpointTemperatureDifferenceHeating = jObject.Value<double>("MinSetpointTemperatureDifferenceHeating");
            }

            if (jObject.ContainsKey("HasPreCooling"))
            {
                HasPreCooling = jObject.Value<bool>("HasPreCooling");
            }

            if (jObject.ContainsKey("PreCoolingEffectiveness"))
            {
                PreCoolingEffectiveness = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("PreCoolingEffectiveness"));
            }

            if (jObject.ContainsKey("AncillaryLoad"))
            {
                AncillaryLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("AncillaryLoad"));
            }

            if (jObject.ContainsKey("PreCoolingWaterFlowCapacity"))
            {
                PreCoolingWaterFlowCapacity = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("HeatPreCoolingWaterFlowCapacityingSetpoint"));
            }

            if (jObject.ContainsKey("MinAirFlowRate"))
            {
                MinAirFlowRate = jObject.Value<double>("MinAirFlowRate");
            }

            if (jObject.ContainsKey("MinAirFlowRatio"))
            {
                MinAirFlowRatio = jObject.Value<double>("MinAirFlowRatio");
            }

            if (jObject.ContainsKey("VariableFans"))
            {
                VariableFans = jObject.Value<bool>("VariableFans");
            }

            if (jObject.ContainsKey("ExternalDryBulbTemperature"))
            {
                ExternalDryBulbTemperature = jObject.Value<double>("ExternalDryBulbTemperature");
            }

            if (jObject.ContainsKey("ExternalDryBulbTemperatureSizingType"))
            {
                ExternalDryBulbTemperatureSizingType = Core.Query.Enum<TemperatureSizingType>(jObject.Value<string>("ExternalDryBulbTemperatureSizingType"));
            }

            if (jObject.ContainsKey("LimitingDryBulbTemperature"))
            {
                LimitingDryBulbTemperature = jObject.Value<double>("LimitingDryBulbTemperature");
            }

            if (jObject.ContainsKey("DesignRange"))
            {
                DesignRange = jObject.Value<double>("DesignRange");
            }

            if (jObject.ContainsKey("DesignWaterFlowRate"))
            {
                DesignWaterFlowRate = jObject.Value<double>("DesignWaterFlowRate");
            }

            if (jObject.ContainsKey("DesignWaterFlowRateSizingType"))
            {
                DesignWaterFlowRateSizingType = Core.Query.Enum<DesignWaterFlowRateSizingType>(jObject.Value<string>("DesignWaterFlowRateSizingType"));
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

            if (!double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            if (!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            if (CoolingSetpoint != null)
            {
                result.Add("CoolingSetpoint", CoolingSetpoint.ToJObject());
            }

            if (MaxFlowRate != null)
            {
                result.Add("MaxFlowRate", MaxFlowRate.ToJObject());
            }

            if (FanSFP != null)
            {
                result.Add("FanSFP", FanSFP.ToJObject());
            }

            result.Add("DryCoolerExchangerCalculationMethod", DryCoolerExchangerCalculationMethod.ToString());

            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJObject());
            }

            if (!double.IsNaN(HeatTransferSurfaceArea))
            {
                result.Add("HeatTransferSurfaceArea", HeatTransferSurfaceArea);
            }

            if (!double.IsNaN(HeatTransferCoefficient))
            {
                result.Add("HeatTransferCoefficient", HeatTransferCoefficient);
            }

            result.Add("ExchangerType", ExchangerType.ToString());

            result.Add("AllowHeating", AllowHeating);

            if (HeatingSetpoint != null)
            {
                result.Add("HeatingSetpoint", HeatingSetpoint.ToJObject());
            }

            if (!double.IsNaN(MinSetpointTemperatureDifferenceCooling))
            {
                result.Add("MinSetpointTemperatureDifferenceCooling", MinSetpointTemperatureDifferenceCooling);
            }

            if (!double.IsNaN(MinSetpointTemperatureDifferenceHeating))
            {
                result.Add("MinSetpointTemperatureDifferenceHeating", MinSetpointTemperatureDifferenceHeating);
            }

            result.Add("HasPreCooling", HasPreCooling);

            if (PreCoolingEffectiveness != null)
            {
                result.Add("PreCoolingEffectiveness", PreCoolingEffectiveness.ToJObject());
            }

            if (AncillaryLoad != null)
            {
                result.Add("AncillaryLoad", AncillaryLoad.ToJObject());
            }

            if (PreCoolingWaterFlowCapacity != null)
            {
                result.Add("PreCoolingWaterFlowCapacity", PreCoolingWaterFlowCapacity.ToJObject());
            }

            if (!double.IsNaN(MinAirFlowRate))
            {
                result.Add("MinAirFlowRate", MinAirFlowRate);
            }

            if (!double.IsNaN(MinAirFlowRatio))
            {
                result.Add("MinAirFlowRatio", MinAirFlowRatio);
            }

            result.Add("VariableFans", VariableFans);

            if (!double.IsNaN(ExternalDryBulbTemperature))
            {
                result.Add("ExternalDryBulbTemperature", ExternalDryBulbTemperature);
            }

            result.Add("ExternalDryBulbTemperatureSizingType", ExternalDryBulbTemperatureSizingType.ToString());

            if (!double.IsNaN(LimitingDryBulbTemperature))
            {
                result.Add("LimitingDryBulbTemperature", LimitingDryBulbTemperature);
            }

            if (!double.IsNaN(DesignRange))
            {
                result.Add("DesignRange", DesignRange);
            }

            if (!double.IsNaN(DesignWaterFlowRate))
            {
                result.Add("DesignWaterFlowRate", DesignWaterFlowRate);
            }

            result.Add("DesignWaterFlowRateSizingType", DesignWaterFlowRateSizingType.ToString());

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemDryCooler(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}