using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class SystemEnergyCentreValues : IndexedDoubles
    {
        private string category;
        private string name;
        private string unitName;

        public SystemEnergyCentreValues(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemEnergyCentreValues(SystemEnergyCentreValues systemEnergyCentreValues)
            : base(systemEnergyCentreValues)
        {
            if (systemEnergyCentreValues != null)
            {
                category = systemEnergyCentreValues.category; 
                name = systemEnergyCentreValues.name;
                unitName = systemEnergyCentreValues.unitName;
            }
        }

        public SystemEnergyCentreValues(string name, string category, string unitName, IndexedDoubles indexedDoubles)
            : base(indexedDoubles)
        {
            this.category = category;
            this.name = name;
            this.unitName = unitName;
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

        public string UnitName
        {
            get
            {
                return unitName;
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

            if (jObject.ContainsKey("UnitName"))
            {
                unitName = jObject.Value<string>("UnitName");
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

            if(unitName != null)
            {
                jObject.Add("UnitName", unitName);
            }

            return jObject;
        }
    }
}
