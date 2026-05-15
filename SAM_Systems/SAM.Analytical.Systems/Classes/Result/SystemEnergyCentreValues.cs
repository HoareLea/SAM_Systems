using System.Text.Json.Nodes;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class SystemEnergyCentreValues : IndexedDoubles
    {
        private string category;
        private string name;
        private string unitName;

        public SystemEnergyCentreValues(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Category"))
            {
                category = jObject["Category"]?.GetValue<string>() ?? null;
            }

            if (jObject.ContainsKey("Name"))
            {
                name = jObject["Name"]?.GetValue<string>() ?? null;
            }

            if (jObject.ContainsKey("UnitName"))
            {
                unitName = jObject["UnitName"]?.GetValue<string>() ?? null;
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject jObject = base.ToJsonObject();
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
