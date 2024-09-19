using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class SystemEnergyCentreGroup : IndexedDoubles
    {
        private string category;
        private string name;

        public SystemEnergyCentreGroup(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemEnergyCentreGroup(SystemEnergyCentreGroup systemEnergyCentreGroup)
            : base(systemEnergyCentreGroup)
        {
            if (systemEnergyCentreGroup != null)
            {
                category = systemEnergyCentreGroup.category;
            }
        }

        public SystemEnergyCentreGroup(string name, string category, IndexedDoubles indexedDoubles)
            : base(indexedDoubles)
        {
            this.category = category;
            this.name = name;
        }

        public string Category
        {
            get
            {
                return category;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Category"))
            {
                category = jObject.Value<string>("Category");
            }

            if (jObject.ContainsKey("Name"))
            {
                name = jObject.Value<string>("Name");
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject jObject = base.ToJObject();
            if (jObject == null)
            {
                return null;
            }

            if (category != null)
            {
                jObject.Add("Category", category);
            }

            if (name != null)
            {
                jObject.Add("Name", name);
            }

            return jObject;
        }
    }
}
