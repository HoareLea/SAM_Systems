using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public class SystemEnergyCentreResult : Result, ISystemResult
    {
        private List<SystemEnergyCentreValues> systemEnergyCentreValues = new List<SystemEnergyCentreValues>();
        
        public SystemEnergyCentreDataType SystemEnergyCentreDataType { private set; get; }

        public SystemEnergyCentreResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemEnergyCentreResult(SystemEnergyCentreResult systemEnergyCentreResult)
            : base(systemEnergyCentreResult)
        {
            if (systemEnergyCentreResult != null)
            {
                SystemEnergyCentreDataType = systemEnergyCentreResult.SystemEnergyCentreDataType;
                systemEnergyCentreValues = systemEnergyCentreResult.systemEnergyCentreValues?.ConvertAll(x => new SystemEnergyCentreValues(x));
            }
        }

        public SystemEnergyCentreResult(string uniqueId, string name, string source, SystemEnergyCentreDataType systemEnergyCentreDataType, IEnumerable<SystemEnergyCentreValues> systemEnergyCentreValues)
            : base(name, source, uniqueId)
        {
            SystemEnergyCentreDataType = systemEnergyCentreDataType;
            this.systemEnergyCentreValues = systemEnergyCentreValues.ToList().ConvertAll(x => new SystemEnergyCentreValues(x));
        }

        public List<SystemEnergyCentreValues> SystemEnergyCentreValues
        {
            get
            {
                return systemEnergyCentreValues?.ConvertAll(x => new SystemEnergyCentreValues(x));
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("SystemEnergyCentreDataType"))
            {
                SystemEnergyCentreDataType = Core.Query.Enum<SystemEnergyCentreDataType>(jObject["SystemEnergyCentreDataType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("SystemEnergyCentreValues"))
            {
                JsonArray jArray = jObject["SystemEnergyCentreValues"] as JsonArray;
                if(jArray != null)
                {
                    systemEnergyCentreValues = new List<SystemEnergyCentreValues>();
                    foreach(JsonNode jsonNode in jArray)
                    {
                        if (!(jsonNode is JsonObject jObject_SystemEnergyCentreValues))
                        {
                            continue;
                        }

                        systemEnergyCentreValues.Add(new SystemEnergyCentreValues(jObject_SystemEnergyCentreValues));
                    }

                }
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

            jObject.Add("SystemEnergyCentreDataType", SystemEnergyCentreDataType.ToString());

            if(systemEnergyCentreValues != null)
            {
                JsonArray jArray = new JsonArray();
                foreach(SystemEnergyCentreValues systemEnergyCentreGroup in systemEnergyCentreValues)
                {
                    jArray.Add(systemEnergyCentreGroup.ToJsonObject());
                }

                jObject.Add("SystemEnergyCentreValues", jArray);
            }

            return jObject;
        }

        
        public static implicit operator SystemIndexedDoublesResult(SystemEnergyCentreResult systemEnergyCentreResult)
        {
            if(systemEnergyCentreResult?.systemEnergyCentreValues == null)
            {
                return null;
            }

            Dictionary<string, IndexedDoubles> dictionary = new Dictionary<string, IndexedDoubles>();
            foreach(SystemEnergyCentreValues systemEnergyCentreValues in systemEnergyCentreResult.systemEnergyCentreValues)
            {
                if(systemEnergyCentreValues == null)
                {
                    continue;
                }

                string key = systemEnergyCentreValues.Name;
                if(string.IsNullOrEmpty(key))
                {
                    key = systemEnergyCentreValues?.Category;
                }

                if(string.IsNullOrEmpty(key))
                {
                    continue;
                }

                dictionary[key] = systemEnergyCentreValues;
            }

            return new SystemIndexedDoublesResult(systemEnergyCentreResult.Reference, systemEnergyCentreResult.Name, systemEnergyCentreResult.Source, dictionary);
        }
    }
}
