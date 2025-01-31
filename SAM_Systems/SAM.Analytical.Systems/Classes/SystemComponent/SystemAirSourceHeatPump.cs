using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

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
        public double ADFHeatingMode { get; set; }
        public double ADFCoolingMode { get; set; }
        public double PortHeatingPower { get; set; }
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

        public SystemAirSourceHeatPump(JObject jObject)
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

            if (jObject.ContainsKey("HeatPumpType"))
            {
                HeatPumpType = Core.Query.Enum<HeatPumpType>(jObject.Value<string>("HeatPumpType"));
            }

            if (jObject.ContainsKey("CoolingCapacity"))
            {
                CoolingCapacity = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("CoolingCapacity"));
            }

            if (jObject.ContainsKey("CoolingPower"))
            {
                CoolingPower = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("CoolingPower"));
            }

            if (jObject.ContainsKey("HeatingCapacity"))
            {
                HeatingCapacity = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("HeatingCapacity"));
            }

            if (jObject.ContainsKey("HeatingPower"))
            {
                HeatingPower = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("HeatingPower"));
            }

            if (jObject.ContainsKey("CondenserFanLoad"))
            {
                CondenserFanLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("CondenserFanLoad"));
            }

            if (jObject.ContainsKey("HeatingCoolingDutyRatio"))
            {
                HeatingCoolingDutyRatio = jObject.Value<double>("HeatingCoolingDutyRatio");
            }

            if (jObject.ContainsKey("HeatingCapacityPowerRatio"))
            {
                HeatingCapacityPowerRatio = jObject.Value<double>("HeatingCapacityPowerRatio");
            }

            if (jObject.ContainsKey("CoolingCapacityPowerRatio"))
            {
                CoolingCapacityPowerRatio = jObject.Value<double>("CoolingCapacityPowerRatio");
            }

            if (jObject.ContainsKey("MaxDemandFanRatio"))
            {
                MaxDemandFanRatio = jObject.Value<double>("MaxDemandFanRatio");
            }

            if (jObject.ContainsKey("StandbyPower"))
            {
                StandbyPower = jObject.Value<double>("StandbyPower");
            }

            if (jObject.ContainsKey("ADFHeatingMode"))
            {
                ADFHeatingMode = jObject.Value<double>("ADFHeatingMode");
            }

            if (jObject.ContainsKey("ADFCoolingMode"))
            {
                ADFCoolingMode = jObject.Value<double>("ADFCoolingMode");
            }

            if (jObject.ContainsKey("PortHeatingPower"))
            {
                PortHeatingPower = jObject.Value<double>("PortHeatingPower");
            }

            if (jObject.ContainsKey("PortCoolingPower"))
            {
                PortCoolingPower = jObject.Value<double>("PortCoolingPower");
            }

            if (jObject.ContainsKey("WaterPipeLength"))
            {
                WaterPipeLength = jObject.Value<double>("WaterPipeLength");
            }

            if (jObject.ContainsKey("AncillaryLoad"))
            {
                AncillaryLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("AncillaryLoad"));
            }

            if (jObject.ContainsKey("HeatSizeFraction"))
            {
                HeatSizeFraction = jObject.Value<double>("HeatSizeFraction");
            }

            if (jObject.ContainsKey("IsDomesticHotWater"))
            {
                IsDomesticHotWater = jObject.Value<bool>("IsDomesticHotWater");
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

            result.Add("HeatPumpType", HeatPumpType.ToString());

            if (CoolingCapacity != null)
            {
                result.Add("CoolingCapacity", CoolingCapacity.ToJObject());
            }

            if (CoolingPower != null)
            {
                result.Add("CoolingPower", CoolingPower.ToJObject());
            }

            if (HeatingCapacity != null)
            {
                result.Add("HeatingCapacity", HeatingCapacity.ToJObject());
            }

            if (HeatingPower != null)
            {
                result.Add("HeatingPower", HeatingPower.ToJObject());
            }

            if (CondenserFanLoad != null)
            {
                result.Add("CondenserFanLoad", CondenserFanLoad.ToJObject());
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
                result.Add("AncillaryLoad", AncillaryLoad.ToJObject());
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
    }
}