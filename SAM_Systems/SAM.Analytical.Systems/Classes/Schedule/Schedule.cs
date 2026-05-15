// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
namespace SAM.Analytical.Systems
{
    public abstract class Schedule : ISchedule
    {
        private string name;
        public Schedule()
        {

        }

        public Schedule(string name)
        {
            this.name = name;
        }

        public Schedule(Schedule schedule)
        {
            if (schedule != null)
            {
                name = schedule.name;
                Description = schedule.Description;
            }
        }

        public Schedule(JsonObject jObject)
        {
            FromJsonObject(jObject);
        }

        public string Description { get; set; }
        
        public string Name
        {
            get
            {
                return name;
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

            if (jObject.ContainsKey("Description"))
            {
                Description = jObject["Description"]?.GetValue<string>() ?? null;
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

            if (Description != null)
            {
                result.Add("Description", Description);
            }

            return result;
        }
    }
}
