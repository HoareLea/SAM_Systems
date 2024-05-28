using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class Duty : IDuty
    {
        public virtual ModifiableValue ModifiableValue { get; set; }

        public Duty()
        {
        }

        public Duty(double value)
        {
            ModifiableValue = value;
        }

        public Duty(Duty duty)
        {
            if(duty != null)
            {
                ModifiableValue = duty.ModifiableValue;
            }
        }

        public Duty(JObject jObject)
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
