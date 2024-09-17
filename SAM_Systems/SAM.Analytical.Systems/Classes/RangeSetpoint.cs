using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class RangeSetpoint : Setpoint
    {
        private Range<double> inputRange;
        private Range<double> outputRange;
        
        public RangeSetpoint()
            : base()
        {

        }

        public RangeSetpoint(RangeSetpoint rangeSetpoint)
            :base(rangeSetpoint)
        {
            if(rangeSetpoint != null)
            {
                inputRange = rangeSetpoint.InputRange;
                outputRange = rangeSetpoint.OutputRange;
            }
        }

        public RangeSetpoint(JObject jObject)
            : base(jObject)
        {

        }

        public Range<double> InputRange
        {
            get
            {
                return inputRange == null ? null : new Range<double>(inputRange);
            }

            set
            {
                inputRange = value == null ? null : new Range<double>(value);
            }
        }

        public Range<double> OutputRange
        {
            get
            {
                return outputRange == null ? null : new Range<double>(outputRange);
            }

            set
            {
                if(value == null || value.Max > 1 || value.Min < 0)
                {
                    return;
                }

                outputRange = new Range<double>(value);
            }
        }


        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return result;
            }

            if (jObject.ContainsKey("InputRange"))
            {
                inputRange = new Range<double>(jObject.Value<JObject>("InputRange"));
            }

            if (jObject.ContainsKey("OutputRange"))
            {
                outputRange = new Range<double>(jObject.Value<JObject>("OutputRange"));
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if(result == null)
            {
                return null;
            }

            if (inputRange != null)
            {
                result.Add("InputRange", inputRange.ToJObject());
            }

            if (outputRange != null)
            {
                result.Add("OutputRange", outputRange.ToJObject());
            }

            return result;
        }
    }
}
