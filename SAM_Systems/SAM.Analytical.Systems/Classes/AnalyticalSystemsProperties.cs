using Newtonsoft.Json.Linq;
using SAM.Core;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public class AnalyticalSystemsProperties : ISystemsProperties
    {
        Dictionary<string, ISchedule> schedules;
        Dictionary<string, FluidType> fluidTypes;

        public AnalyticalSystemsProperties()
        {

        }

        public AnalyticalSystemsProperties(AnalyticalSystemsProperties analyticalSystemsProperties)
        {
            if (analyticalSystemsProperties != null)
            {
                if (analyticalSystemsProperties.schedules != null)
                {
                    schedules = new Dictionary<string, ISchedule>();
                    foreach (ISchedule schedule in analyticalSystemsProperties.schedules.Values)
                    {
                        schedules[schedule.Name] = schedule;
                    }
                }
            }
        }

        public AnalyticalSystemsProperties(JObject jObject)
        {
            FromJObject(jObject);
        }

        public List<ISchedule> Schedules
        {
            get
            {
                return schedules?.Values?.ToList();
            }
        }

        public List<FluidType> FluidTypes
        {
            get
            {
                return fluidTypes?.Values?.ToList();
            }
        }

        public bool Add(ISchedule schedule)
        {
            if (schedule?.Name == null)
            {
                return false;
            }

            if (schedules == null)
            {
                schedules = new Dictionary<string, ISchedule>();
            }

            schedules[schedule.Name] = schedule;
            return true;
        }

        public bool Add(FluidType fluidType)
        {
            if (fluidType?.Name == null)
            {
                return false;
            }

            if (fluidTypes == null)
            {
                fluidTypes = new Dictionary<string, FluidType>();
            }

            fluidTypes[fluidType.Name] = fluidType;
            return true;
        }

        public virtual bool FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if (jObject.ContainsKey("Schedules"))
            {
                JArray jArray = jObject.Value<JArray>("Schedules");
                if (jArray != null)
                {
                    schedules = new Dictionary<string, ISchedule>();

                    foreach (JObject jObject_Schedule in jArray)
                    {
                        ISchedule schedule = Core.Query.IJSAMObject<ISchedule>(jObject_Schedule);
                        if (schedule == null)
                        {
                            continue;
                        }
                        schedules[schedule.Name] = schedule;
                    }
                }
            }

            if (jObject.ContainsKey("FluidTypes"))
            {
                JArray jArray = jObject.Value<JArray>("FluidTypes");
                if (jArray != null)
                {
                    fluidTypes = new Dictionary<string, FluidType>();

                    foreach (JObject jObject_FluidType in jArray)
                    {
                        FluidType fluidType = Core.Query.IJSAMObject<FluidType>(jObject_FluidType);
                        if (fluidType == null)
                        {
                            continue;
                        }

                        fluidTypes[fluidType.Name] = fluidType;
                    }
                }
            }

            return true;
        }

        public virtual JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if (schedules != null)
            {
                JArray jArray = new JArray();
                foreach (ISchedule schedule in schedules.Values)
                {
                    jArray.Add(schedule.ToJObject());
                }

                result.Add("Schedules", jArray);
            }

            if (fluidTypes != null)
            {
                JArray jArray = new JArray();
                foreach (FluidType fluidType in fluidTypes.Values)
                {
                    jArray.Add(fluidType.ToJObject());
                }

                result.Add("FluidTypes", jArray);
            }

            return result;
        }
    }
}
