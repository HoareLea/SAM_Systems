using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemPump : SystemComponent, ILiquidSystemComponent
    {
        public ModifiableValue OverallEfficiency { get; set; }
        
        public double Pressure { get; set; }

        public double DesignFlowRate { get; set; }

        public double Capacity { get; set; }

        public ModifiableValue PartLoad { get; set; }

        public FanControlType FanControlType { get; set; }

        public string ScheduleName { get; set; }

        public SystemPump(string name)
            : base(name)
        {

        }

        public SystemPump(SystemPump systemPump)
            : base(systemPump)
        {
            if(systemPump != null)
            {
                OverallEfficiency = systemPump.OverallEfficiency?.Clone();
                Pressure = systemPump.Pressure;
                DesignFlowRate = systemPump.DesignFlowRate;
                Capacity = systemPump.Capacity;
                PartLoad = systemPump.PartLoad?.Clone();
                FanControlType = systemPump.FanControlType;
                ScheduleName = systemPump.ScheduleName;
            }
        }

        public SystemPump(JObject jObject)
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

            if (jObject.ContainsKey("FanControlType"))
            {
                FanControlType = Core.Query.Enum<FanControlType>(jObject.Value<string>("FanControlType"));
            }

            if (jObject.ContainsKey("OverallEfficiency"))
            {
                OverallEfficiency = Core.Create.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("OverallEfficiency"));
            }

            if (jObject.ContainsKey("Pressure"))
            {
                Pressure = jObject.Value<double>("Pressure");
            }

            if (jObject.ContainsKey("DesignFlowRate"))
            {
                DesignFlowRate = jObject.Value<double>("DesignFlowRate");
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject.Value<double>("Capacity");
            }

            if (jObject.ContainsKey("PartLoad"))
            {
                PartLoad = Core.Create.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("PartLoad"));
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

            result.Add("FanControlType", FanControlType.ToString());

            if(OverallEfficiency != null)
            {
                result.Add("OverallEfficiency", OverallEfficiency.ToJObject());
            }

            if(!double.IsNaN(Pressure))
            {
                result.Add("Pressure", Pressure);
            }

            if (!double.IsNaN(DesignFlowRate))
            {
                result.Add("DesignFlowRate", DesignFlowRate);
            }

            if (!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

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