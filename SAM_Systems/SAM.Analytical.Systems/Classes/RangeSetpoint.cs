using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class RangeSetpoint : Setpoint
    {
        private Range<double> inputRange;
        private Gradient inputGradient = Gradient.Positive;
        private Range<double> outputRange;
        private Gradient outputGradient = Gradient.Positive;

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
                inputGradient = rangeSetpoint.inputGradient;
                outputRange = rangeSetpoint.OutputRange;
                outputGradient = rangeSetpoint.outputGradient;
            }
        }

        public RangeSetpoint(JObject jObject)
            : base(jObject)
        {

        }

        public Gradient InputGradient
        {
            get
            {
                return inputGradient;
            }

            set
            {
                inputGradient = value;
            }
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

        public Gradient OutputGradient
        {
            get
            {
                return outputGradient;
            }

            set
            {
                outputGradient = value;
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

            if (jObject.ContainsKey("InputGradient"))
            {
                inputGradient = Core.Query.Enum<Gradient>(jObject.Value<string>("InputGradient"));
            }

            if (jObject.ContainsKey("OutputRange"))
            {
                outputRange = new Range<double>(jObject.Value<JObject>("OutputRange"));
            }

            if (jObject.ContainsKey("OutputGradient"))
            {
                outputGradient = Core.Query.Enum<Gradient>(jObject.Value<string>("OutputGradient"));
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

            if(inputGradient != Gradient.Undefined)
            {
                result.Add("InputGradient", inputGradient.ToString());
            }

            if (outputRange != null)
            {
                result.Add("OutputRange", outputRange.ToJObject());
            }

            if (outputGradient != Gradient.Undefined)
            {
                result.Add("OutputGradient", outputGradient.ToString());
            }

            return result;
        }
    }
}
