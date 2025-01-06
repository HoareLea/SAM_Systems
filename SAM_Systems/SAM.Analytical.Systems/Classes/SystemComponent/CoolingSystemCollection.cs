using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class CoolingSystemCollection : SystemCollection<CoolingSystem>
    {
        public double MaximumReturnTemperature { get; set; }

        public bool VariableFlowCapacity { get; set; }

        public double PeakDemand { get; set; }

        public double SizeFraction { get; set; }

        public Distribution Distribution { get; set; }

        public double DesignPressureDrop { get; set; }


        public CoolingSystemCollection()
            : base()
        {
        }

        public CoolingSystemCollection(string name)
            : base(name)
        {
        }

        public CoolingSystemCollection(JObject jObject)
            : base(jObject)
        {

        }

        public CoolingSystemCollection(CoolingSystemCollection coolingSystemCollection)
            : base(coolingSystemCollection)
        {
            if(coolingSystemCollection != null)
            {
                MaximumReturnTemperature = coolingSystemCollection.MaximumReturnTemperature;
                VariableFlowCapacity = coolingSystemCollection.VariableFlowCapacity;
                PeakDemand = coolingSystemCollection.PeakDemand;
                SizeFraction = coolingSystemCollection.SizeFraction;
                Distribution = coolingSystemCollection.Distribution?.Clone();
                DesignPressureDrop = coolingSystemCollection.DesignPressureDrop;
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("MaximumReturnTemperature"))
            {
                MaximumReturnTemperature = jObject.Value<double>("MaximumReturnTemperature");
            }

            if (jObject.ContainsKey("VariableFlowCapacity"))
            {
                VariableFlowCapacity = jObject.Value<bool>("VariableFlowCapacity");
            }

            if (jObject.ContainsKey("PeakDemand"))
            {
                PeakDemand = jObject.Value<double>("PeakDemand");
            }

            if (jObject.ContainsKey("SizeFraction"))
            {
                SizeFraction = jObject.Value<double>("SizeFraction");
            }

            if (jObject.ContainsKey("Distribution"))
            {
                Distribution = Core.Query.IJSAMObject<Distribution>(jObject.Value<JObject>("Distribution"));
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject.Value<double>("DesignPressureDrop");
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

            if (!double.IsNaN(MaximumReturnTemperature))
            {
                result.Add("MaximumReturnTemperature", MaximumReturnTemperature);
            }

            result.Add("VariableFlowCapacity", VariableFlowCapacity);

            if (!double.IsNaN(PeakDemand))
            {
                result.Add("PeakDemand", PeakDemand);
            }

            if (!double.IsNaN(SizeFraction))
            {
                result.Add("SizeFraction", SizeFraction);
            }

            if (Distribution != null)
            {
                result.Add("Distribution", Distribution.ToJObject());
            }

            if (!double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            return result;
        }
    }
}
