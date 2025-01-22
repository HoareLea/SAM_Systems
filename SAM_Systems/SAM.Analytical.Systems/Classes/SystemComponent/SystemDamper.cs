using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemDamper : SystemComponent
    {
        public double Capacity { get; set; }
        public double DesignCapacitySignal { get; set; }
        public double MinimumFlowFraction { get; set; }
        public double DesignPressureDrop { get; set; }

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
                MinimumFlowFraction = systemDamper.MinimumFlowFraction;
                DesignPressureDrop = systemDamper.DesignPressureDrop;
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
                    Core.Systems.Create.SystemConnector<AirSystem>(Core.Direction.In, 1),
                    Core.Systems.Create.SystemConnector<AirSystem>(Core.Direction.Out, 1),
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

            if (jObject.ContainsKey("MinimumFlowFraction"))
            {
                MinimumFlowFraction = jObject.Value<double>("MinimumFlowFraction");
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject.Value<double>("DesignPressureDrop");
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

            if (double.IsNaN(MinimumFlowFraction))
            {
                result.Add("MinimumFlowFraction", MinimumFlowFraction);
            }

            if (double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            return result;
        }
    }
}
