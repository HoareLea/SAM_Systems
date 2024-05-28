using Newtonsoft.Json.Linq;

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

        public override double GetValue(int index)
        {
            double result = base.GetValue(index);
            if(double.IsNaN(result))
            {
                return result;
            }

            if(double.IsNaN(SizeFraction))
            {
                return result;
            }

            return result * SizeFraction;
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
