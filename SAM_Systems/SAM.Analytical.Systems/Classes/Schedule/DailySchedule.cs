using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class DailySchedule : Schedule
    {
        private Dictionary<string, ScheduleDay> dictionary = new Dictionary<string, ScheduleDay>();
        private List<string> scheduleDayNames = new List<string>();

        public DailySchedule()
        {

        }

        public DailySchedule(string name)
            :base(name)
        {

        }

        public DailySchedule(DailySchedule dailySchedule)
            :base(dailySchedule)
        {
            if(dailySchedule != null)
            {
                if(dailySchedule.dictionary != null)
                {
                    foreach(ScheduleDay scheduleDay in dailySchedule.dictionary.Values)
                    {
                        dictionary[scheduleDay.Name] = scheduleDay;
                    }
                }

                scheduleDayNames = scheduleDayNames == null ? null : new List<string>(scheduleDayNames);
            }
        }

        public DailySchedule(JObject jObject)
            :base(jObject)
        {

        }

        public bool Add(ScheduleDay scheduleDay)
        {
            if(scheduleDay?.Name == null)
            {
                return false;
            }

            dictionary[scheduleDay.Name] = scheduleDay;
            scheduleDayNames.Add(scheduleDay.Name);
            return true;
        }

        public List<string> ScheduleDayNames
        {
            get
            {
                return scheduleDayNames == null ? null : new List<string>(scheduleDayNames);
            }
        }

        public ScheduleDay this[string scheduleDayName]
        {
            get
            {
                if(scheduleDayName == null || !dictionary.TryGetValue(scheduleDayName, out ScheduleDay scheduleDay))
                {
                    return null;
                }

                return Core.Query.Clone(scheduleDay);
            }
        }

        public virtual bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result )
            {
                return result;
            }

            if(jObject.ContainsKey("ScheduleDays"))
            {
                dictionary = new Dictionary<string, ScheduleDay>();

                JArray jArray = jObject.Value<JArray>("ScheduleDays");
                foreach(JObject jObject_ScheduleDay in jArray)
                {
                    ScheduleDay scheduleDay = new ScheduleDay(jObject_ScheduleDay);
                    dictionary[scheduleDay.Name] = scheduleDay;
                }
            }

            if(jObject.ContainsKey("ScheduleDayNames"))
            {
                scheduleDayNames = new List<string>();
                JArray jArray = jObject.Value<JArray>("ScheduleDayNames");
                foreach (string scheduleDayName in jArray)
                {
                    scheduleDayNames.Add(scheduleDayName);
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

            if(dictionary != null)
            {
                JArray jArray = new JArray();
                foreach (ScheduleDay scheduleDay in dictionary.Values)
                {
                    jArray.Add(scheduleDay.ToJObject());
                }

                result.Add("ScheduleDays", jArray);
            }

            if(scheduleDayNames != null)
            {
                JArray jArray = new JArray();
                scheduleDayNames.ForEach(x => jArray.Add(x));
                result.Add("ScheduleDayNames", jArray);
            }

            return result;
        }
    }
}
