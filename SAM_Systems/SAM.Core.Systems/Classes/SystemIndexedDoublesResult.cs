// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Systems
{
    public class SystemIndexedDoublesResult: Result, ISystemResult
    {
        private Dictionary<string, IndexedDoubles> dictionary;

        public SystemIndexedDoublesResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemIndexedDoublesResult(SystemIndexedDoublesResult systemIndexedDoublesResult)
            : base(systemIndexedDoublesResult)
        {
            if (systemIndexedDoublesResult?.dictionary != null)
            {
                dictionary = new Dictionary<string, IndexedDoubles>();
                foreach (KeyValuePair<string, IndexedDoubles> keyValuePair in systemIndexedDoublesResult.dictionary)
                {
                    dictionary[keyValuePair.Key] = keyValuePair.Value == null ? null : new IndexedDoubles(keyValuePair.Value);
                }
            }
        }

        public SystemIndexedDoublesResult(string uniqueId, string name, string source, Dictionary<string, IndexedDoubles> dictionary)
            : base(name, source, uniqueId)
        {
            if (dictionary != null)
            {
                this.dictionary = new Dictionary<string, IndexedDoubles>();
                foreach (KeyValuePair<string, IndexedDoubles> keyValuePair in dictionary)
                {
                    this.dictionary[keyValuePair.Key] = keyValuePair.Value == null ? null : new IndexedDoubles(keyValuePair.Value);
                }
            }
        }

        public SystemIndexedDoublesResult(string uniqueId, string name, string source, Dictionary<System.Enum, IndexedDoubles> dictionary)
            : base(name, source, uniqueId)
        {
            if (dictionary != null)
            {
                this.dictionary = new Dictionary<string, IndexedDoubles>();
                foreach (KeyValuePair<System.Enum, IndexedDoubles> keyValuePair in dictionary)
                {
                    this.dictionary[keyValuePair.Key.Description()] = keyValuePair.Value == null ? null : new IndexedDoubles(keyValuePair.Value);
                }
            }
        }

        public List<string> Keys
        {
            get
            {
                return dictionary?.Keys?.ToList();
            }
        }

        public List<IndexedDoubles> Values
        {
            get
            {
                return dictionary?.Values?.ToList();
            }
        }

        public IndexedDoubles this[string key]
        {
            get
            {
                if (key == null || dictionary == null)
                {
                    return null;
                }

                return dictionary[key];
            }
        }

        public IndexedDoubles this[System.Enum @enum]
        {
            get 
            {
                return this[@enum.Description()];
            }
        }

        public bool Contains(string key)
        {
            if(key == null)
            {
                return false;
            }

            return dictionary != null && dictionary.ContainsKey(key);
        }

        public bool Contains(System.Enum @enum)
        {
            return dictionary != null && dictionary.ContainsKey(@enum.Description());
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Data"))
            {
                JsonArray jArray = jObject["Data"] as JsonArray;
                if (jArray != null)
                {
                    dictionary = new Dictionary<string, IndexedDoubles>();
                    foreach (JsonNode jsonNode in jArray)
                    {
                        if (!(jsonNode is JsonArray jArray_Temp))
                        {
                            continue;
                        }

                        if (jArray_Temp == null || jArray_Temp.Count != 2)
                        {
                            continue;
                        }

                        string uniqueId = jArray_Temp[0]?.GetValue<string>();
                        if (uniqueId == null)
                        {
                            continue;
                        }

                        JsonObject jObject_Temp = jArray_Temp[1] is JsonObject ? (JsonObject)jArray_Temp[1] : null;

                        dictionary[uniqueId] = new IndexedDoubles(jObject_Temp);
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

            if (dictionary != null)
            {
                JsonArray jArray = new JsonArray();
                foreach (KeyValuePair<string, IndexedDoubles> keyValuePair in dictionary)
                {
                    if (keyValuePair.Key == null)
                    {
                        continue;
                    }

                    jArray.Add(new JsonArray(keyValuePair.Key, keyValuePair.Value?.ToJsonObject()));
                }
                jObject.Add("Data", jArray);
            }

            return jObject;
        }
    }
}
