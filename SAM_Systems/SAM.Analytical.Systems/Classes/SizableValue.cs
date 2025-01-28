using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class SizableValue : ISizableValue
    {
        public SizingType SizingType { get; set; }
        public double SizeFraction { get; set; }
        public SizeMethod SizeMethod { get; set; } = SizeMethod.Normal;
        public virtual ModifiableValue ModifiableValue { get; set; }

        public SizableValue()
        {
        }

        public SizableValue(double value)
        {
            ModifiableValue = value;
        }

        public SizableValue(SizableValue sizableValue)
        {
            if(sizableValue != null)
            {
                SizingType = sizableValue.SizingType;
                ModifiableValue = sizableValue.ModifiableValue;
                SizeFraction = sizableValue.SizeFraction;
                SizeMethod = sizableValue.SizeMethod;
            }
        }

        public SizableValue(JObject jObject)
        {
            FromJObject(jObject);
        }

        public virtual bool FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if (jObject.ContainsKey("SizingType"))
            {
                SizingType = Core.Query.Enum<SizingType>(jObject.Value<string>("SizingType"));
            }

            if (jObject.ContainsKey("SizeFraction"))
            {
                SizeFraction = jObject.Value<double>("SizeFraction");
            }

            if (jObject.ContainsKey("SizeMethod"))
            {
                SizeMethod = Core.Query.Enum<SizeMethod>(jObject.Value<string>("SizeMethod"));
            }

            if (jObject.ContainsKey("ModifiableValue"))
            {
                ModifiableValue = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("ModifiableValue"));
            }

            return true;
        }

        public virtual JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            result.Add("SizingType", SizingType.ToString());

            if (!double.IsNaN(SizeFraction))
            {
                result.Add("SizeFraction", SizeFraction);
            }

            result.Add("SizeMethod", SizeMethod.ToString());

            if (ModifiableValue != null)
            {
                result.Add("ModifiableValue", ModifiableValue.ToJObject());
            }

            return result;
        }
    }
}
