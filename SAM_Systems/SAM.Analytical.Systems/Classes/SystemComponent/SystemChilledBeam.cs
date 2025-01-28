using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemChilledBeam : SystemSpaceComponent
    {
        public ISizableValue CoolingDuty { get; set; }
        public ISizableValue HeatingDuty { get; set; }
        public double DesignFlowRate { get; set; }
        public double HeatingEfficiency { get; set; }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.Out, 1)
                );
            }
        }

        public SystemChilledBeam(string name)
            : base(name)
        {
        }

        public SystemChilledBeam(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemChilledBeam(SystemChilledBeam systemChilledBeam)
            : base(systemChilledBeam)
        {
            if (systemChilledBeam != null)
            {
                CoolingDuty = systemChilledBeam.CoolingDuty;
                HeatingDuty = systemChilledBeam.HeatingDuty;
                DesignFlowRate = systemChilledBeam.DesignFlowRate;
                HeatingEfficiency = systemChilledBeam.HeatingEfficiency;
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("CoolingDuty"))
            {
                CoolingDuty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("CoolingDuty"));
            }

            if (jObject.ContainsKey("HeatingDuty"))
            {
                HeatingDuty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("HeatingDuty"));
            }

            if (jObject.ContainsKey("DesignFlowRate"))
            {
                DesignFlowRate = jObject.Value<double>("DesignFlowRate");
            }

            if (jObject.ContainsKey("HeatingEfficiency"))
            {
                HeatingEfficiency = jObject.Value<double>("HeatingEfficiency");
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

            if (CoolingDuty != null)
            {
                result.Add("CoolingDuty", CoolingDuty.ToJObject());
            }

            if (HeatingDuty != null)
            {
                result.Add("HeatingDuty", HeatingDuty.ToJObject());
            }

            if (!double.IsNaN(DesignFlowRate))
            {
                result.Add("DesignFlowRate", DesignFlowRate);
            }

            if (!double.IsNaN(HeatingEfficiency))
            {
                result.Add("HeatingEfficiency", HeatingEfficiency);
            }

            return result;
        }
    }
}

