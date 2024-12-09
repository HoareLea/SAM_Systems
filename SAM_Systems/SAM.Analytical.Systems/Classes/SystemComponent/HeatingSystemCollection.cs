using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class HeatingSystemCollection : SystemCollection<HeatingSystem>
    {
        public double MinimumReturnTemperature { get; set; }
        public bool VariableFlowCapacity { get; set; }
        public double PeakDemand { get; set; }
        public double SizeFraction { get; set; }
        public ModifiableValue Distribution { get; set; }

        public HeatingSystemCollection()
            : base()
        {
        }

        public HeatingSystemCollection(string name)
            : base(name)
        {
        }

        public HeatingSystemCollection(JObject jObject)
            : base(jObject)
        {

        }

        public HeatingSystemCollection(HeatingSystemCollection heatingSystemCollection)
            : base(heatingSystemCollection)
        {
            if(heatingSystemCollection != null)
            {
                MinimumReturnTemperature = heatingSystemCollection.MinimumReturnTemperature;
                VariableFlowCapacity = heatingSystemCollection.VariableFlowCapacity;
                PeakDemand = heatingSystemCollection.PeakDemand;
                SizeFraction = heatingSystemCollection.SizeFraction;
                Distribution = heatingSystemCollection.Distribution?.Clone();
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("MinimumReturnTemperature"))
            {
                MinimumReturnTemperature = jObject.Value<double>("MinimumReturnTemperature");
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
                Distribution = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Distribution"));
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

            if (!double.IsNaN(MinimumReturnTemperature))
            {
                result.Add("MinimumReturnTemperature", MinimumReturnTemperature);
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

            return result;
        }
    }
}
