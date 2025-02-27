using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class TariffProfile : ISystemJSAMObject
    {
        public string Description { get; set; }
        public int FirstDay { get; set; }
        public int LastDay { get; set; }
        public double MinimumDemand { get; set; }

        public TariffProfile(TariffProfile tariffProfile)
        {
            if(tariffProfile != null)
            {
                Description = tariffProfile.Description;
                FirstDay = tariffProfile.FirstDay;
                LastDay = tariffProfile.LastDay;
                MinimumDemand = tariffProfile.MinimumDemand;
            }
        }

        public TariffProfile(JObject jObject)
        {
            FromJObject(jObject);
        }

        public TariffProfile()
        {

        }

        public TariffProfile(string description, int firstDay, int lastDay, double minimumDemand)
        {
            Description = description;
            FirstDay = firstDay;
            LastDay = lastDay;
            MinimumDemand = minimumDemand;
        }

        public bool FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if (jObject.ContainsKey("Description"))
            {
                Description = jObject.Value<string>("Description");
            }

            if (jObject.ContainsKey("FirstDay"))
            {
                FirstDay = jObject.Value<int>("FirstDay");
            }

            if (jObject.ContainsKey("LastDay"))
            {
                LastDay = jObject.Value<int>("LastDay");
            }

            if (jObject.ContainsKey("MinimumDemand"))
            {
                MinimumDemand = jObject.Value<double>("MinimumDemand");
            }

            return true;
        }

        public JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if(Description != null)
            {
                result.Add("Description", Description);
            }

            result.Add("FirstDay", FirstDay);

            result.Add("LastDay", LastDay);

            if (!double.IsNaN(MinimumDemand))
            {
                result.Add("MinimumDemand", MinimumDemand);
            }

            return result;
        }
    }
}
