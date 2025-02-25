using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class UnlimitedValue : ISizableValue
    {
        public UnlimitedValue()
        {
        }

        public UnlimitedValue(UnlimitedValue unlimitedValue)
        {
        }

        public UnlimitedValue(JObject jObject)
        {
            FromJObject(jObject);
        }

        public SizingType SizingType => SizingType.None;
        
        public virtual bool FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            return true;
        }

        public virtual JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            return result;
        }
    }
}
