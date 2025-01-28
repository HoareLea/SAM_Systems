using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemFanCoilUnit : SystemSpaceComponent
    {
        public double Pressure { get; set; }
        public ISizableValue CoolingDuty { get; set; }
        public ISizableValue HeatingDuty { get; set; }
        public double DesignFlowRate { get; set; }
        public double HeatingEfficiency { get; set; }
        public double OverallEfficiency { get; set; }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (

                );
            }
        }

        public SystemFanCoilUnit(string name)
            : base(name)
        {
        }

        public SystemFanCoilUnit(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemFanCoilUnit(SystemFanCoilUnit systemFanCoilUnit)
            : base(systemFanCoilUnit)
        {
            if (systemFanCoilUnit != null)
            {
                Pressure = systemFanCoilUnit.Pressure;
                CoolingDuty = systemFanCoilUnit.CoolingDuty;
                HeatingDuty = systemFanCoilUnit.HeatingDuty;
                DesignFlowRate = systemFanCoilUnit.DesignFlowRate;
                HeatingEfficiency = systemFanCoilUnit.HeatingEfficiency;
                OverallEfficiency = systemFanCoilUnit.OverallEfficiency;
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Pressure"))
            {
                Pressure = jObject.Value<double>("Pressure");
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

            if (jObject.ContainsKey("OverallEfficiency"))
            {
                OverallEfficiency = jObject.Value<double>("OverallEfficiency");
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

            if (!double.IsNaN(Pressure))
            {
                result.Add("Pressure", Pressure);
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

            if (!double.IsNaN(OverallEfficiency))
            {
                result.Add("OverallEfficiency", OverallEfficiency);
            }

            return result;
        }
    }
}
