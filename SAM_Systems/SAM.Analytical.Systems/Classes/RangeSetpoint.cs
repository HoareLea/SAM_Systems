// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
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

        public RangeSetpoint(JsonObject jObject)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if(!result)
            {
                return result;
            }

            if (jObject.ContainsKey("InputRange"))
            {
                inputRange = new Range<double>(jObject["InputRange"] as JsonObject);
            }

            if (jObject.ContainsKey("InputGradient"))
            {
                inputGradient = Core.Query.Enum<Gradient>(jObject["InputGradient"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("OutputRange"))
            {
                outputRange = new Range<double>(jObject["OutputRange"] as JsonObject);
            }

            if (jObject.ContainsKey("OutputGradient"))
            {
                outputGradient = Core.Query.Enum<Gradient>(jObject["OutputGradient"]?.GetValue<string>() ?? null);
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if(result == null)
            {
                return null;
            }

            if (inputRange != null)
            {
                result.Add("InputRange", inputRange.ToJsonObject());
            }

            if(inputGradient != Gradient.Undefined)
            {
                result.Add("InputGradient", inputGradient.ToString());
            }

            if (outputRange != null)
            {
                result.Add("OutputRange", outputRange.ToJsonObject());
            }

            if (outputGradient != Gradient.Undefined)
            {
                result.Add("OutputGradient", outputGradient.ToString());
            }

            return result;
        }
    }
}
