using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemFanCoilUnit : SystemSpaceComponent
    {
        public ISizableValue HeatingDuty { get; set; }
        public ISizableValue CoolingDuty { get; set; }
        public ModifiableValue BypassFactor { get; set; }
        public ModifiableValue HeatingEfficiency { get; set; }
        public ModifiableValue OverallEfficiency { get; set; }
        public double HeatGainFactor { get; set; }
        public double Pressure { get; set; }
        public SizedFlowValue DesignFlowRate { get; set; }
        public FlowRateType DesignFlowType { get; set; }
        public SizedFlowValue MinimumFlowRate { get; set; }
        public FlowRateType MinimumFlowType { get; set; }
        public SystemSpaceComponentPosition ZonePosition { get; set; }
        public FanCoilControlMethod ControlMethod { get; set; }
        public ModifiableValue PartLoad { get; set; }


        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (

                );
            }
        }

        public SystemFanCoilUnit(string name)
            : base(name)
        {
        }

        public SystemFanCoilUnit(JObject jObject)
            : base(jObject)
        {

        }

        public SystemFanCoilUnit(SystemFanCoilUnit systemFanCoilUnit)
            : base(systemFanCoilUnit)
        {
            if (systemFanCoilUnit != null)
            {
                HeatingDuty = systemFanCoilUnit.HeatingDuty?.Clone();
                CoolingDuty = systemFanCoilUnit.CoolingDuty?.Clone();
                BypassFactor = systemFanCoilUnit.BypassFactor?.Clone();
                OverallEfficiency = systemFanCoilUnit.OverallEfficiency?.Clone();
                HeatingEfficiency = systemFanCoilUnit.HeatingEfficiency?.Clone();
                HeatGainFactor = systemFanCoilUnit.HeatGainFactor;
                Pressure = systemFanCoilUnit.Pressure;
                DesignFlowRate = systemFanCoilUnit.DesignFlowRate.Clone();
                DesignFlowType = systemFanCoilUnit.DesignFlowType;
                MinimumFlowRate = systemFanCoilUnit.MinimumFlowRate?.Clone();
                MinimumFlowType = systemFanCoilUnit.MinimumFlowType;
                ZonePosition = systemFanCoilUnit.ZonePosition;
                ControlMethod = systemFanCoilUnit.ControlMethod;
                PartLoad = systemFanCoilUnit.PartLoad?.Clone();
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("HeatingDuty"))
            {
                HeatingDuty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("HeatingDuty"));
            }

            if (jObject.ContainsKey("CoolingDuty"))
            {
                CoolingDuty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("CoolingDuty"));
            }

            if (jObject.ContainsKey("BypassFactor"))
            {
                BypassFactor = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("BypassFactor"));
            }

            if (jObject.ContainsKey("HeatingEfficiency"))
            {
                HeatingEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("HeatingEfficiency"));
            }

            if (jObject.ContainsKey("OverallEfficiency"))
            {
                OverallEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("OverallEfficiency"));
            }

            if (jObject.ContainsKey("HeatGainFactor"))
            {
                HeatGainFactor = jObject.Value<double>("HeatGainFactor");
            }

            if (jObject.ContainsKey("Pressure"))
            {
                Pressure = jObject.Value<double>("Pressure");
            }

            if (jObject.ContainsKey("DesignFlowRate"))
            {
                DesignFlowRate = Core.Query.IJSAMObject<SizedFlowValue>(jObject.Value<JObject>("DesignFlowRate"));
            }

            DesignFlowType = Core.Query.Enum<FlowRateType>(jObject.Value<string>("DesignFlowType"));

            if (jObject.ContainsKey("MinimumFlowRate"))
            {
                MinimumFlowRate = Core.Query.IJSAMObject<SizedFlowValue>(jObject.Value<JObject>("MinimumFlowRate"));
            }

            MinimumFlowType = Core.Query.Enum<FlowRateType>(jObject.Value<string>("MinimumFlowType"));

            ZonePosition = Core.Query.Enum<SystemSpaceComponentPosition>(jObject.Value<string>("ZonePosition"));

            ControlMethod = Core.Query.Enum<FanCoilControlMethod>(jObject.Value<string>("ControlMethod"));

            if (jObject.ContainsKey("PartLoad"))
            {
                PartLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("PartLoad"));
            }

            return true;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            if (HeatingDuty != null)
            {
                result.Add("HeatingDuty", HeatingDuty.ToJObject());
            }

            if (CoolingDuty != null)
            {
                result.Add("CoolingDuty", CoolingDuty.ToJObject());
            }

            if (BypassFactor != null)
            {
                result.Add("BypassFactor", BypassFactor.ToJObject());
            }

            if (HeatingEfficiency != null)
            {
                result.Add("HeatingEfficiency", HeatingEfficiency.ToJObject());
            }

            if (OverallEfficiency != null)
            {
                result.Add("OverallEfficiency", OverallEfficiency.ToJObject());
            }

            if (!double.IsNaN(HeatGainFactor))
            {
                result.Add("HeatGainFactor", HeatGainFactor);
            }

            if (!double.IsNaN(Pressure))
            {
                result.Add("Pressure", Pressure);
            }

            if (DesignFlowRate != null)
            {
                result.Add("DesignFlowRate", DesignFlowRate.ToJObject());
            }

            result.Add("DesignFlowType", DesignFlowType.ToString());

            if (MinimumFlowRate != null)
            {
                result.Add("MinimumFlowRate", MinimumFlowRate.ToJObject());
            }

            result.Add("MinimumFlowType", MinimumFlowType.ToString());

            result.Add("ZonePosition", ZonePosition.ToString());

            result.Add("ControlMethod", ControlMethod.ToString());

            if (PartLoad != null)
            {
                result.Add("PartLoad", PartLoad.ToJObject());
            }

            return result;
        }
    }
}
