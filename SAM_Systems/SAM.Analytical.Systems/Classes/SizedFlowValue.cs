using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SizedFlowValue : ISystemJSAMObject
    {
        private double value;
        private double sizeFranction;

        public SizedFlowValue()
        {
        }

        public SizedFlowValue(double value, double sizeFranction)
        {
            this.value = value;
            this.sizeFranction = sizeFranction;
        }

        public SizedFlowValue(SizedFlowValue sizedFlowValue)
        {
            if(sizedFlowValue != null)
            {
                value = sizedFlowValue.value;
                sizeFranction = sizedFlowValue.sizeFranction;
            }
        }

        public SizedFlowValue(JObject jObject)
        {
            FromJObject(jObject);
        }

        public double Value
        {
            get
            {
                return value;
            }
        }

        public double SizeFranction
        {
            get
            {
                return sizeFranction;
            }
        }

        public virtual bool FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("Value"))
            {
                value = jObject.Value<double>("Value");
            }

            if (jObject.ContainsKey("SizeFranction"))
            {
                sizeFranction = jObject.Value<double>("SizeFranction");
            }

            return true;
        }

        public virtual JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if(!double.IsNaN(value))
            {
                result.Add("Value", value);
            }

            if (!double.IsNaN(sizeFranction))
            {
                result.Add("SizeFranction", sizeFranction);
            }

            return result;
        }
    }
}
