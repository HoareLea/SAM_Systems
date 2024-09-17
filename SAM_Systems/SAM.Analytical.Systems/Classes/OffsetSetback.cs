using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public abstract class OffsetSetback : Setback
    {
        private double offset;

        public OffsetSetback()
        {

        }

        public OffsetSetback(string scheduleName, double offset)
            :base(scheduleName)
        {
            this.offset = offset;
        }

        public OffsetSetback(OffsetSetback offsetSetback)
            :base(offsetSetback)
        {
            if(offsetSetback != null)
            {
                offset = offsetSetback.offset;
            }
        }

        public OffsetSetback(JObject jObject)
            : base(jObject)
        {

        }

        public double Offset
        {
            get
            {
                return offset;
            }
        }

        public virtual bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Offset"))
            {
                offset = jObject.Value<double>("Offset");
            }

            return true;
        }

        public virtual JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            if (!double.IsNaN(offset))
            {
                result.Add("Offset", offset);
            }

            return result;
        }
    }
}
