using Newtonsoft.Json.Linq;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public class YearlySchedule : Schedule
    {
        private double[] values = new double[8760];

        public YearlySchedule()
        {

        }

        public YearlySchedule(string name)
            :base(name)
        {

        }

        public YearlySchedule(YearlySchedule yearlySchedule)
            :base(yearlySchedule)
        {
            if(yearlySchedule != null)
            {
                if (yearlySchedule.values != null)
                {
                    int count = yearlySchedule.values.Count();
                    for (int i = 0; i < 24; i++)
                    {
                        values[i] = yearlySchedule.values[i];
                    }

                }
            }
        }

        public YearlySchedule(JObject jObject)
            :base(jObject)
        {

        }

        public double[] Values
        {
            get
            {
                return values == null ? null : values.ToArray();
            }

            set
            {
                if (value == null)
                {
                    values = new double[8760];
                }

                int count = value.Count();
                for (int i = 0; i < 8760; i++)
                {
                    values[i] = value[i % count];
                }
            }
        }

        public double this[int i]
        {
            get
            {
                return values[i];
            }

            set
            {
                values[i] = value;
            }
        }

        public virtual bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result )
            {
                return result;
            }

            if (jObject.ContainsKey("Values"))
            {
                values = new double[8760];
                JArray jArray = jObject.Value<JArray>("Values");
                int count = jArray.Count;
                for (int i = 0; i < 8760; i++)
                {
                    values[i] = (double)jArray[i % count];
                }
            }

            return true;
        }

        public virtual JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if(result == null)
            {
                return result;
            }

            if (values != null)
            {
                JArray jArray = new JArray();
                for (int i = 0; i < values.Length; i++)
                {
                    jArray.Add(values[i]);
                }

                result.Add("Values", jArray);
            }

            return result;
        }
    }
}
