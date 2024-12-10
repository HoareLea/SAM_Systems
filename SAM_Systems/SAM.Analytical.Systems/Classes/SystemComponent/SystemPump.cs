using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemPump : SystemComponent
    {
        public ModifiableValue OverallEfficiency { get; set; }
        
        public double Pressure { get; set; }

        public double DesignFrowRate { get; set; }

        public double Capacity { get; set; }

        public ModifiableValue PartLoad { get; set; }

        public FanControlType FanControlType { get; set; }

        public SystemPump(string name)
            : base(name)
        {

        }

        public SystemPump(SystemPump systemPump)
            : base(systemPump)
        {

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

            if (jObject.ContainsKey("DesignFrowRate"))
            {
                DesignFrowRate = jObject.Value<double>("DesignFrowRate");
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject.Value<double>("Capacity");
            }

            if (jObject.ContainsKey("PartLoad"))
            {
                PartLoad = Core.Create.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("PartLoad"));
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

            if (!double.IsNaN(DesignFrowRate))
            {
                result.Add("DesignFrowRate", DesignFrowRate);
            }

            if (!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            if (PartLoad != null)
            {
                result.Add("PartLoad", PartLoad.ToJObject());
            }

            return result;
        }
    }
}