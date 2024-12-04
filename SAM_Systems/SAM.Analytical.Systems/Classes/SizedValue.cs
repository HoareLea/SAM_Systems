using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SizedValue : SizableValue
    {
        public double SizeFraction { get; set; }

        public SizedValue(double value, double sizeFraction)
            : base(value)
        {
            SizeFraction = sizeFraction;
        }

        public SizedValue(SizedValue sizedValue)
            :base(sizedValue)
        {
            if(sizedValue != null)
            {
                SizeFraction = sizedValue.SizeFraction;
            }
        }

        public SizedValue(JObject jObject)
            :base(jObject)
        {

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

            return result;
        }
    }
}
