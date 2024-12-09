using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class DomesticHotWaterSystemCollection : SystemCollection<DomesticHotWaterSystem>
    {
        public LoadDistribution LoadDistribution { get; set; }

        public double MinimumReturnTemperature { get; set; }

        public ModifiableValue Distribution { get; set; }

        public DomesticHotWaterSystemCollection()
            : base()
        {
        }

        public DomesticHotWaterSystemCollection(string name)
            : base(name)
        {
        }

        public DomesticHotWaterSystemCollection(JObject jObject)
            : base(jObject)
        {

        }

        public DomesticHotWaterSystemCollection(DomesticHotWaterSystemCollection domesticHotWaterSystemCollection)
            : base(domesticHotWaterSystemCollection)
        {
            if(domesticHotWaterSystemCollection != null)
            {
                LoadDistribution = domesticHotWaterSystemCollection.LoadDistribution;
                MinimumReturnTemperature = domesticHotWaterSystemCollection.MinimumReturnTemperature;
                Distribution = domesticHotWaterSystemCollection.Distribution?.Clone();
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("LoadDistribution"))
            {
                LoadDistribution = Core.Query.Enum<LoadDistribution>(jObject.Value<string>("LoadDistribution"));
            }

            if (jObject.ContainsKey("MinimumReturnTemperature"))
            {
                MinimumReturnTemperature = jObject.Value<double>("MinimumReturnTemperature");
            }

            if (jObject.ContainsKey("Dictribution"))
            {
                Distribution = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Dictribution"));
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

            result.Add("LoadDistribution", LoadDistribution.ToString());

            if(!double.IsNaN(MinimumReturnTemperature))
            {
                result.Add("MinimumReturnTemperature", MinimumReturnTemperature);
            }

            if(Distribution != null)
            {
                result.Add("Distribution", Distribution.ToJObject());
            }


            return result;
        }
    }
}