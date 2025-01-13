using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class Distribution : ModifiableValue
    {
        private bool isEfficiency;

        public Distribution(IModifier modifier, double value, bool isEfficiency)
            : base(modifier, value)
        {
            this.isEfficiency = isEfficiency;
        }

        public Distribution(double value, bool isEfficiency)
            : base(value)
        {
            this.isEfficiency = isEfficiency;
        }

        public Distribution(Distribution distribution)
            : base(distribution)
        {
            if (distribution != null)
            {
                isEfficiency = distribution.isEfficiency;
            }
        }

        public Distribution(JObject jObject)
            : base(jObject)
        {

        }

        public bool IsEfficiency
        {
            get
            {
                return isEfficiency;
            }
        }

        public virtual bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("IsEfficiency"))
            {
                isEfficiency = jObject.Value<bool>("IsEfficiency");
            }

            return result;
        }

        public virtual JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return result;
            }

            result.Add("IsEfficiency", isEfficiency);

            return result;
        }
    }
}

