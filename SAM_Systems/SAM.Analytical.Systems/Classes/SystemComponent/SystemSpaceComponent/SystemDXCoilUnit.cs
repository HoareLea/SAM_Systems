using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemDXCoilUnit : SystemSpaceComponent
    {
        public ISizableValue HeatingDuty { get; set; }
        public ISizableValue CoolingDuty { get; set; }
        public ModifiableValue BypassFactor { get; set; }
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
        public string ScheduleName { get; set; }

        public SystemDXCoilUnit(string name)
            : base(name)
        {
        }

        public SystemDXCoilUnit(JObject jObject)
            : base(jObject)
        {

        }

        public SystemDXCoilUnit(SystemDXCoilUnit systemDXCoilUnit)
            : base(systemDXCoilUnit)
        {
            if (systemDXCoilUnit != null)
            {
                HeatingDuty = systemDXCoilUnit.HeatingDuty;
                CoolingDuty = systemDXCoilUnit.CoolingDuty;
                BypassFactor = systemDXCoilUnit.BypassFactor?.Clone();
                OverallEfficiency = systemDXCoilUnit.OverallEfficiency?.Clone();
                HeatGainFactor = systemDXCoilUnit.HeatGainFactor;
                Pressure = systemDXCoilUnit.Pressure;
                DesignFlowRate = systemDXCoilUnit.DesignFlowRate?.Clone();
                DesignFlowType = systemDXCoilUnit.DesignFlowType;
                MinimumFlowRate = systemDXCoilUnit.MinimumFlowRate?.Clone();
                MinimumFlowType = systemDXCoilUnit.MinimumFlowType;
                ZonePosition = systemDXCoilUnit.ZonePosition;
                ControlMethod = systemDXCoilUnit.ControlMethod;
                PartLoad = systemDXCoilUnit.PartLoad?.Clone();
                ScheduleName = systemDXCoilUnit.ScheduleName;
            }
        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<RefrigerantSystem>(Direction.In, 1),
                    Core.Systems.Create.SystemConnector<RefrigerantSystem>(Direction.Out, 1),
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

            if (jObject.ContainsKey("DesignFlowType"))
            {
                DesignFlowType = Core.Query.Enum<FlowRateType>(jObject.Value<string>("DesignFlowType"));
            }

            if (jObject.ContainsKey("MinimumFlowRate"))
            {
                MinimumFlowRate = Core.Query.IJSAMObject<SizedFlowValue>(jObject.Value<JObject>("MinimumFlowRate"));
            }

            if (jObject.ContainsKey("MinimumFlowType"))
            {
                MinimumFlowType = Core.Query.Enum<FlowRateType>(jObject.Value<string>("MinimumFlowType"));
            }

            if (jObject.ContainsKey("ZonePosition"))
            {
                ZonePosition = Core.Query.Enum<SystemSpaceComponentPosition>(jObject.Value<string>("ZonePosition"));
            }

            if (jObject.ContainsKey("ControlMethod"))
            {
                ControlMethod = Core.Query.Enum<FanCoilControlMethod>(jObject.Value<string>("ControlMethod"));
            }

            if (jObject.ContainsKey("PartLoad"))
            {
                PartLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("PartLoad"));
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject.Value<string>("ScheduleName");
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

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }
    }
}

