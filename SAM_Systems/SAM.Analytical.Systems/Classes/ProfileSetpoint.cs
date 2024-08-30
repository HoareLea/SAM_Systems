using Newtonsoft.Json.Linq;
using SAM.Core;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public class ProfileSetpoint : Setpoint
    {
        private SortedDictionary<double, double> values = new SortedDictionary<double, double>();

        public ProfileSetpoint()
            : base()
        {

        }

        public ProfileSetpoint(ProfileSetpoint profileSetpoint)
            :base(profileSetpoint)
        {
            if(profileSetpoint != null)
            {

            }
        }

        public ProfileSetpoint(JObject jObject)
            : base(jObject)
        {

        }

        public Range<double> InputRange
        {
            get
            {
                if(values?.Keys == null)
                {
                    return null;
                }

                return new Range<double>(values.Keys.Min(), values.Keys.Max());
            }
        }

        public Range<double> OutputRange
        {
            get
            {
                if(values?.Values == null)
                {
                    return null;
                }

                return new Range<double>(values.Values.Min(), values.Values.Max());
            }
        }

        public bool Add(double input, double output)
        {
            if(double.IsNaN(input) || double.IsNaN(output))
            {
                return false;
            }

            if(output > 1 || output < 0)
            {
                return false;
            }

            values[input] = output;
            return true;
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("Values"))
            {
                JArray jArray = jObject.Value<JArray>("Values");
                if(jArray != null)
                {
                    values = new SortedDictionary<double, double>();
                    foreach(JArray jArray_Temp in jArray)
                    {
                        values[(double)jArray_Temp[0]] = (double)jArray_Temp[1]; 
                    }
                }
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

            if(values != null)
            {
                JArray jArray = new JArray();
                foreach(KeyValuePair<double, double> keyValuePair in values)
                {
                    jArray.Add(new JArray(keyValuePair.Key, keyValuePair.Value));
                }

                result.Add("Values", jArray);
            }

            return result;
        }
    }
}
