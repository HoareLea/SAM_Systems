using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemDamper : SystemComponent, IAirSystemComponent
    {
        public double Capacity { get; set; }
        public double DesignCapacitySignal { get; set; }
        public SizedFlowValue DesignFlowRate { get; set; }
        public FlowRateType DesignFlowType { get; set; }
        public SizedFlowValue MinimumFlowRate { get; set; }
        public FlowRateType MinimumFlowType { get; set; }
        public double MinimumFlowFraction { get; set; }
        public double DesignPressureDrop { get; set; }

        public string ScheduleName { get; set; }

        public SystemDamper(string name)
            : base(name)
        {

        }

        public SystemDamper(SystemDamper systemDamper)
            : base(systemDamper)
        {
            if(systemDamper != null)
            {
                Capacity = systemDamper.Capacity;
                DesignCapacitySignal = systemDamper.DesignCapacitySignal;
                DesignFlowRate = systemDamper.DesignFlowRate?.Clone();
                DesignFlowType = systemDamper.DesignFlowType;
                MinimumFlowRate = systemDamper.MinimumFlowRate?.Clone();
                MinimumFlowType = systemDamper.MinimumFlowType;
                MinimumFlowFraction = systemDamper.MinimumFlowFraction;
                DesignPressureDrop = systemDamper.DesignPressureDrop;
                ScheduleName = systemDamper.ScheduleName;
            }
        }

        public SystemDamper(JObject jObject)
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
                    Core.Systems.Create.SystemConnector<ElectricalSystem>(),
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

            if (jObject.ContainsKey("DesignCapacitySignal"))
            {
                DesignCapacitySignal = jObject.Value<double>("DesignCapacitySignal");
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
            if (result == null)
            {
                return null;
            }

            if (double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            if (double.IsNaN(DesignCapacitySignal))
            {
                result.Add("DesignCapacitySignal", DesignCapacitySignal);
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

            if (double.IsNaN(MinimumFlowFraction))
            {
                result.Add("MinimumFlowFraction", MinimumFlowFraction);
            }

            if (double.IsNaN(DesignPressureDrop))
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
