using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SizedValue : SizableValue
    {
        private HashSet<string> names;

        public double SizeFraction { get; set; }

        public SizedValue(double value, double sizeFraction, IEnumerable<string> names)
            : base(value)
        {
            this.names = names == null ? null : new HashSet<string>(names);

            SizeFraction = sizeFraction;
        }

        public SizedValue(SizedValue sizedValue)
            :base(sizedValue)
        {
            if(sizedValue != null)
            {
                SizeFraction = sizedValue.SizeFraction;
                names = sizedValue.names == null ? null : new HashSet<string>(sizedValue.names);
            }
        }

        public SizedValue(JObject jObject)
            :base(jObject)
        {

        }

        public HashSet<string> Names
        {
            get
            {
                return names == null ? null : new HashSet<string>(names);
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            if(!base.FromJObject(jObject))
            {
                return false;
            }

            if (jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("SizeFraction"))
            {
                SizeFraction = jObject.Value<double>("SizeFraction");
            }

            if (jObject.ContainsKey("Names"))
            {
                names = new HashSet<string>();

                foreach(string name in jObject.Value<JArray>("Names"))
                {
                    if(name == null)
                    {
                        continue;
                    }

                    names.Add(name);
                }               
            }

            return true;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if(result == null)
            {
                return result;
            }

            if(!double.IsNaN(SizeFraction))
            {
                result.Add("SizeFraction", SizeFraction);
            }

            if (names != null)
            {
                JArray jArray = new JArray();
                foreach (string name in names)
                {
                    jArray.Add(name);
                }

                result.Add("Names", jArray);
            }

            return result;
        }
    }
}
