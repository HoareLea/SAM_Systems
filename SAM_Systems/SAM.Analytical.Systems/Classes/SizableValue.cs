using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class SizableValue : ISizableValue
    {
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
                ModifiableValue = sizableValue.ModifiableValue;
            }
        }

        public SizableValue(JObject jObject)
        {
            FromJObject(jObject);
        }

        public virtual double GetValue(int index)
        {
            if(ModifiableValue == null)
            {
                return double.NaN;
            }

            return ModifiableValue.GetCalculatedValue(index);
        }

        public virtual bool FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("ModifiableValue"))
            {
                ModifiableValue = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("ModifiableValue"));
            }

            return true;
        }

        public virtual JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if(ModifiableValue != null)
            {
                result.Add("ModifiableValue", ModifiableValue.ToJObject());
            }

            return result;
        }
    }
}
