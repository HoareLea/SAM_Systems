using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemSpace : SystemComponent, ISystemSpace
    {
        private double area;
        private double volume;
        private double flowRate;
        private double freshAirRate;

        public SystemSpace(string name, double area, double volume, double flowRate, double freshAirRate)
            : base(name)
        {
            this.area = area;
            this.volume = volume;
            this.flowRate = flowRate;
            this.freshAirRate = freshAirRate;
        }

        public SystemSpace(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemSpace(SystemSpace systemSpace)
            : base(systemSpace)
        {
            if (systemSpace != null)
            {
                area = systemSpace.area;
                volume = systemSpace.volume;
                flowRate = systemSpace.flowRate;
                freshAirRate = systemSpace.freshAirRate;
            }
        }

        public double Area
        {
            get
            {
                return area;
            }
        }

        public double Volume
        {
            get
            {
                return volume;
            }
        }

        public double FlowRate
        {
            get
            {
                return flowRate;
            }
        }

        public double FreshAirRate
        {
            get
            {
                return freshAirRate;
            }
        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<AirSystem>(Core.Direction.In),
                    Core.Systems.Create.SystemConnector<AirSystem>(Core.Direction.Out),
                    Core.Systems.Create.SystemConnector<IControlSystem>(Core.Direction.Out)
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

            if (jObject.ContainsKey("Area"))
            {
                area = jObject.Value<double>("Area");
            }

            if (jObject.ContainsKey("Volume"))
            {
                volume = jObject.Value<double>("Volume");
            }

            if (jObject.ContainsKey("FlowRate"))
            {
                flowRate = jObject.Value<double>("FlowRate");
            }

            if (jObject.ContainsKey("FreshAirRate"))
            {
                freshAirRate = jObject.Value<double>("FreshAirRate");
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

            if (!double.IsNaN(area))
            {
                result.Add("Area", area);
            }

            if (!double.IsNaN(volume))
            {
                result.Add("Volume", volume);
            }

            if (!double.IsNaN(flowRate))
            {
                result.Add("FlowRate", flowRate);
            }

            if (!double.IsNaN(freshAirRate))
            {
                result.Add("FreshAirRate", freshAirRate);
            }

            return result;
        }
    }
}
