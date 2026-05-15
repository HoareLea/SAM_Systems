// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System.Text.Json.Nodes;
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

        public DailySchedule(JsonObject jObject)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if(!result )
            {
                return result;
            }

            if(jObject.ContainsKey("ScheduleDays"))
            {
                dictionary = new Dictionary<string, ScheduleDay>();

                JsonArray jArray = jObject["ScheduleDays"] as JsonArray;
                foreach(JsonNode jsonNode in jArray)
                {
                    if (!(jsonNode is JsonObject jObject_ScheduleDay))
                    {
                        continue;
                    }

                    ScheduleDay scheduleDay = new ScheduleDay(jObject_ScheduleDay);
                    dictionary[scheduleDay.Name] = scheduleDay;
                }
            }

            if(jObject.ContainsKey("ScheduleDayNames"))
            {
                scheduleDayNames = new List<string>();
                JsonArray jArray = jObject["ScheduleDayNames"] as JsonArray;
                foreach (JsonNode jsonNode in jArray)
                {
                    string scheduleDayName = jsonNode?.GetValue<string>();
                    if(scheduleDayName == null)
                    {
                        continue;
                    }

                    scheduleDayNames.Add(scheduleDayName);
                }
            }

            return true;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if(result == null)
            {
                return result;
            }

            if(dictionary != null)
            {
                JsonArray jArray = new JsonArray();
                foreach (ScheduleDay scheduleDay in dictionary.Values)
                {
                    jArray.Add(scheduleDay.ToJsonObject());
                }

                result.Add("ScheduleDays", jArray);
            }

            if(scheduleDayNames != null)
            {
                JsonArray jArray = new JsonArray();
                scheduleDayNames.ForEach(x => jArray.Add(x));
                result.Add("ScheduleDayNames", jArray);
            }

            return result;
        }
    }
}
