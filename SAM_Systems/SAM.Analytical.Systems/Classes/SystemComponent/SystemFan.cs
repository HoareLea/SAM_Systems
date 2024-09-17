using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemFan : SystemComponent
    {
        public double OverallEfficiency { get; set; }

        public double HeatGainFactor { get; set; }

        public double Pressure { get; set; }

        public double DesignFlowRate { get; set; }

        public SystemFan(string name)
            : base(name)
        {

        }

        public SystemFan(SystemFan systemFan)
            : base(systemFan)
        {
            if(systemFan != null)
            {
                OverallEfficiency = systemFan.OverallEfficiency;
                HeatGainFactor = systemFan.HeatGainFactor;
                Pressure = systemFan.Pressure;
                DesignFlowRate = systemFan.DesignFlowRate;
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
                    Core.Systems.Create.SystemConnector<AirSystem>(Core.Direction.In, 1),
                    Core.Systems.Create.SystemConnector<AirSystem>(Core.Direction.Out, 1),
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
                OverallEfficiency = jObject.Value<double>("OverallEfficiency");
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
                DesignFlowRate = jObject.Value<double>("DesignFlowRate");
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

            if (!double.IsNaN(OverallEfficiency))
            {
                result.Add("OverallEfficiency", OverallEfficiency);
            }

            if (!double.IsNaN(HeatGainFactor))
            {
                result.Add("HeatGainFactor", HeatGainFactor);
            }

            if (!double.IsNaN(Pressure))
            {
                result.Add("Pressure", Pressure);
            }

            if (!double.IsNaN(DesignFlowRate))
            {
                result.Add("DesignFlowRate", DesignFlowRate);
            }

            return result;
        }
    }
}
