using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemValve : SystemComponent, ILiquidSystemComponent
    {
        public double Capacity { get; set; }
        public double DesignCapacitySignal { get; set; }
        public double DesignFlowRate { get; set; }
        public double DesignPressureDrop { get; set; }

        public string ScheduleName { get; set; }

        public SystemValve(string name)
            : base(name)
        {

        }

        public SystemValve(SystemValve systemValve)
            : base(systemValve)
        {
            if(systemValve != null)
            {
                Capacity = systemValve.Capacity;
                DesignCapacitySignal = systemValve.DesignCapacitySignal;
                DesignFlowRate = systemValve.DesignFlowRate;
                DesignPressureDrop = systemValve.DesignPressureDrop;
                ScheduleName = systemValve.ScheduleName;
            }
        }

        public SystemValve(JObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.Out, 1),
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

            if(jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject.Value<double>("Capacity");
            }

            if (jObject.ContainsKey("DesignCapacitySignal"))
            {
                DesignCapacitySignal = jObject.Value<double>("DesignCapacitySignal");
            }

            if (jObject.ContainsKey("DesignFlowRate"))
            {
                DesignFlowRate = jObject.Value<double>("DesignFlowRate");
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject.Value<double>("DesignPressureDrop");
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
            if(result == null)
            {
                return result;
            }

            if(!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            if (!double.IsNaN(DesignCapacitySignal))
            {
                result.Add("DesignCapacitySignal", DesignCapacitySignal);
            }

            if (!double.IsNaN(DesignFlowRate))
            {
                result.Add("DesignFlowRate", DesignFlowRate);
            }

            if (!double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }
    }
}