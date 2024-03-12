using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class Duty : IDuty
    {
        public virtual double Value { get; set; }

        public Duty()
        {
        }

        public Duty(double value)
        {
        }

        public Duty(Duty duty)
        {
            if(duty != null)
            {
                Value = duty.Value;
            }
        }

        public Duty(JObject jObject)
        {
            FromJObject(jObject);
        }

        public virtual bool FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("Value"))
            {
                Value = jObject.Value<double>("Value");
            }

            return true;
        }

        public virtual JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if(!double.IsNaN(Value))
            {
                result.Add("Value", Value);
            }

            return result;
        }
    }
}
