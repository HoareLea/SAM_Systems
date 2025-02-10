using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class DesignCondition : ISystemJSAMObject
    {
        private string name;
        private string description;
        private int precondHours;
        private int startHour;
        private int endHour;

        public DesignCondition(string name, string description, int precondHours, int startHour, int endHour)
        {
            this.name = name;
            this.description = description;
            this.precondHours = precondHours;
            this.startHour = startHour;
            this.endHour = endHour;
        }

        public DesignCondition(DesignCondition designCondition)
        {
            if(designCondition != null)
            {
                name = designCondition.name;
                description = designCondition.description;
                precondHours = designCondition.precondHours;
                startHour = designCondition.startHour;
                endHour = designCondition.endHour;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }

        public int PrecondHours
        {
            get
            {
                return precondHours;
            }
        }

        public int StartHour
        {
            get
            {
                return startHour;
            }
        }

        public int EndHour
        {
            get
            {
                return endHour;
            }
        }

        public DesignCondition(JObject jObject)
        {
            FromJObject(jObject);
        }

        public virtual bool FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if (jObject.ContainsKey("Name"))
            {
                name = jObject.Value<string>("Name");
            }

            if (jObject.ContainsKey("Description"))
            {
                description = jObject.Value<string>("Description");
            }

            if (jObject.ContainsKey("PrecondHours"))
            {
                precondHours = jObject.Value<int>("PrecondHours");
            }

            if (jObject.ContainsKey("StartHour"))
            {
                startHour = jObject.Value<int>("StartHour");
            }

            if (jObject.ContainsKey("EndHour"))
            {
                endHour = jObject.Value<int>("EndHour");
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

            if (description != null)
            {
                result.Add("Description", description);
            }

            result.Add("PrecondHours", precondHours);
            result.Add("StartHour", startHour);
            result.Add("EndHour", endHour);

            return result;
        }
    }
}
