using Newtonsoft.Json.Linq;

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

        public Schedule(JObject jObject)
        {
            FromJObject(jObject);
        }

        public string Description { get; set; }
        
        public string Name
        {
            get
            {
                return name;
            }
        }

        public virtual bool FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("Name"))
            {
                name = jObject.Value<string>("Name");
            }

            if (jObject.ContainsKey("Description"))
            {
                Description = jObject.Value<string>("Description");
            }

            return true;
        }

        public virtual JObject ToJObject()
        {
            JObject result = new JObject();
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
