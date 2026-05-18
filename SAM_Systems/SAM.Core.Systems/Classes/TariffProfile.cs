// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
namespace SAM.Core.Systems
{
    public class TariffProfile : ISystemJSAMObject
    {
        public string Description { get; set; }
        public int FirstDay { get; set; }
        public int LastDay { get; set; }
        public double MinimumDemand { get; set; }

        public TariffProfile(TariffProfile tariffProfile)
        {
            if (tariffProfile != null)
            {
                Description = tariffProfile.Description;
                FirstDay = tariffProfile.FirstDay;
                LastDay = tariffProfile.LastDay;
                MinimumDemand = tariffProfile.MinimumDemand;
            }
        }

        public TariffProfile(JsonObject jObject)
        {
            FromJsonObject(jObject);
        }

        public TariffProfile()
        {

        }

        public TariffProfile(string description, int firstDay, int lastDay, double minimumDemand)
        {
            Description = description;
            FirstDay = firstDay;
            LastDay = lastDay;
            MinimumDemand = minimumDemand;
        }

        public bool FromJsonObject(JsonObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if (jObject.ContainsKey("Description"))
            {
                Description = jObject["Description"]?.GetValue<string>() ?? null;
            }

            if (jObject.ContainsKey("FirstDay"))
            {
                FirstDay = jObject["FirstDay"]?.GetValue<int>() ?? default(int);
            }

            if (jObject.ContainsKey("LastDay"))
            {
                LastDay = jObject["LastDay"]?.GetValue<int>() ?? default(int);
            }

            if (jObject.ContainsKey("MinimumDemand"))
            {
                MinimumDemand = jObject["MinimumDemand"]?.GetValue<double>() ?? default(double);
            }

            return true;
        }

        public JsonObject ToJsonObject()
        {
            JsonObject result = new JsonObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if (Description != null)
            {
                result.Add("Description", Description);
            }

            result.Add("FirstDay", FirstDay);

            result.Add("LastDay", LastDay);

            if (!double.IsNaN(MinimumDemand))
            {
                result.Add("MinimumDemand", MinimumDemand);
            }

            return result;
        }
    }
}

