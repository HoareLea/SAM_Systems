using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class SizedDuty : Duty
    {
        public double SizeFraction { get; set; }

        public SizedDuty(double value, double sizeFraction)
            : base(value)
        {
            SizeFraction = sizeFraction;
        }

        public SizedDuty(SizedDuty sizedDuty)
            :base(sizedDuty)
        {
            if(sizedDuty != null)
            {
                SizeFraction = sizedDuty.SizeFraction;
            }
        }

        public SizedDuty(JObject jObject)
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
