using System.Text.Json.Nodes;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public class ScheduleDay : IScheduleDay
    {
        private string name;
        private double[] values = new double[24];

        public ScheduleDay()
        {

        }

        public ScheduleDay(string name, IEnumerable<double> values)
        {
            this.name = name;
            if(values != null)
            {
                int count = values.Count();
                for(int i=0; i < 24; i++)
                {
                    this.values[i] = values.ElementAt(i % count);
                }

            }
        }

        public ScheduleDay(ScheduleDay scheduleDay)
        {
            if(scheduleDay != null)
            {
                name = scheduleDay.name;
                values = scheduleDay.values == null ? null : scheduleDay.values.ToArray();
            }
        }

        public ScheduleDay(JsonObject jObject)
        {
            FromJsonObject(jObject);
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public double[] Values
        {
            get
            {
                return values;
            }

            set
            {
                if(value == null)
                {
                    values = new double[24];
                }

                int count = value.Count();
                for (int i = 0; i < 24; i++)
                {
                    values[i] = value[i % count];
                }
            }
        }

        public virtual bool FromJsonObject(JsonObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("Name"))
            {
                name = jObject["Name"]?.GetValue<string>() ?? null;
            }

            if(jObject.ContainsKey("Values"))
            {
                values = new double[24];
                JsonArray jArray = jObject["Values"] as JsonArray;
                int count = jArray.Count;
                for (int i = 0; i < 24; i++)
                {
                    values[i] = (double)jArray[i % count];
                }
            }

            return true;
        }

        public virtual JsonObject ToJsonObject()
        {
            JsonObject result = new JsonObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if(name != null)
            {
                result.Add("Name", name);
            }

            if(values != null)
            {
                JsonArray jArray = new JsonArray();
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
