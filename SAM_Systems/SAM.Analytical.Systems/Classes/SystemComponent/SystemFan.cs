using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemFan : SystemComponent
    {
        public ModifiableValue OverallEfficiency { get; set; }
        public double HeatGainFactor { get; set; }
        public double Pressure { get; set; }
        public SizedFlowValue DesignFlowRate { get; set; }
        public FlowRateType DesignFlowType { get; set; }
        public SizedFlowValue MinimumFlowRate { get; set; }
        public FlowRateType MinimumFlowType { get; set; }
        public double MinimumFlowFraction { get; set; }
        public double Capacity { get; set; }
        public FanControlType FanControlType { get; set; }
        public ModifiableValue PartLoad { get; set; }

        public string ScheduleName { get; set; }


        public SystemFan(string name)
            : base(name)
        {

        }

        public SystemFan(SystemFan systemFan)
            : base(systemFan)
        {
            if(systemFan != null)
            {
                OverallEfficiency = systemFan.OverallEfficiency?.Clone();
                HeatGainFactor = systemFan.HeatGainFactor;
                Pressure = systemFan.Pressure;
                DesignFlowRate = systemFan.DesignFlowRate?.Clone();
                DesignFlowType = systemFan.DesignFlowType;
                MinimumFlowRate = systemFan.MinimumFlowRate?.Clone();
                MinimumFlowType = systemFan.MinimumFlowType;
                MinimumFlowFraction = systemFan.MinimumFlowFraction;
                Capacity = systemFan.Capacity;
                FanControlType = systemFan.FanControlType;
                PartLoad = systemFan.PartLoad?.Clone();
                ScheduleName = systemFan.ScheduleName;
            }
        }

        public SystemFan(JObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<AirSystem>(Direction.In, 1),
                    Core.Systems.Create.SystemConnector<AirSystem>(Direction.Out, 1),
                    //Core.Systems.Create.SystemConnector<ElectricalSystem>(),
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

            if (jObject.ContainsKey("MinimumFlowFraction"))
            {
                MinimumFlowFraction = jObject.Value<double>("MinimumFlowFraction");
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject.Value<double>("Capacity");
            }

            if (jObject.ContainsKey("FanControlType"))
            {
                FanControlType = Core.Query.Enum<FanControlType>(jObject.Value<string>("FanControlType"));
            }

            if (jObject.ContainsKey("PartLoad"))
            {
                PartLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("PartLoad"));
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
                return null;
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

            if (!double.IsNaN(MinimumFlowFraction))
            {
                result.Add("MinimumFlowFraction", MinimumFlowFraction);
            }

            if (!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            result.Add("FanControlType", FanControlType.ToString());

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
