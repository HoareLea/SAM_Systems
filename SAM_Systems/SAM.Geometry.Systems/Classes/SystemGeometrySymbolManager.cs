// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Geometry.Systems
{
    public class SystemGeometrySymbolManager : IJSAMObject
    {
        private Dictionary<string, SystemGeometrySymbol> dictionary = new Dictionary<string, SystemGeometrySymbol>();

        public SystemGeometrySymbolManager()
        {

        }

        public SystemGeometrySymbolManager(SystemGeometrySymbolManager systemGeometrySymbolManager)
        {
            if(systemGeometrySymbolManager != null)
            {
                if(systemGeometrySymbolManager.dictionary != null)
                {
                    dictionary = new Dictionary<string, SystemGeometrySymbol>();

                    foreach (KeyValuePair<string, SystemGeometrySymbol> keyValuePair in systemGeometrySymbolManager.dictionary)
                    {
                        dictionary[keyValuePair.Key] = keyValuePair.Value?.Clone();
                    }
                }
            }
        }

        public SystemGeometrySymbolManager(JsonObject jObject)
        {
            FromJsonObject(jObject);
        }

        public bool Add<T>(SystemGeometrySymbol systemGeometrySymbol) where T: ISystemObject
        {
            if(systemGeometrySymbol == null)
            {
                return false;
            }

            string fullTypeName = Core.Query.FullTypeName(typeof(T));

            if(string.IsNullOrWhiteSpace(fullTypeName))
            {
                return false;
            }

            dictionary[fullTypeName] = systemGeometrySymbol;
            return true;
        }

        public bool Add(System.Type type, SystemGeometrySymbol systemGeometrySymbol)
        {
            if (systemGeometrySymbol == null || type == null)
            {
                return false;
            }

            if(!typeof(ISystemObject).IsAssignableFrom(type))
            {
                return false;
            }

            string fullTypeName = Core.Query.FullTypeName(type);

            if (string.IsNullOrWhiteSpace(fullTypeName))
            {
                return false;
            }

            dictionary[fullTypeName] = systemGeometrySymbol;
            return true;
        }

        public bool FromJsonObject(JsonObject jObject)
        {
            if(jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("SystemGeometrySymbols"))
            {
                JsonArray jArray = jObject["SystemGeometrySymbols"] as JsonArray;
                if(jArray != null)
                {
                    dictionary = new Dictionary<string, SystemGeometrySymbol>();
                    foreach(JsonNode jsonNode in jArray)
                    {
                        if (!(jsonNode is JsonArray jArray_Temp))
                        {
                            continue;
                        }

                        dictionary[jArray_Temp[0]?.GetValue<string>()] = new SystemGeometrySymbol(jArray_Temp[1] as JsonObject);
                    }
                }
            }

            return true;
        }

        public SystemGeometrySymbol GetSystemGeometrySymbol<T>() where T : ISystemObject
        {
            return GetSystemGeometrySymbol(typeof(T));
        }

        public SystemGeometrySymbol GetSystemGeometrySymbol(System.Type type)
        {
            if (type == null)
            {
                return null;
            }

            if (!typeof(ISystemObject).IsAssignableFrom(type))
            {
                return null;
            }

            string fullTypeName = Core.Query.FullTypeName(type);
            if (string.IsNullOrWhiteSpace(fullTypeName))
            {
                return null;
            }

            if (!dictionary.TryGetValue(fullTypeName, out SystemGeometrySymbol result))
            {
                foreach (KeyValuePair<string, SystemGeometrySymbol> keyValuePair in dictionary)
                {
                    System.Type type_Temp = Core.Query.Type(keyValuePair.Key);
                    if (type_Temp == null)
                    {
                        continue;
                    }

                    if (type_Temp.IsAssignableFrom(type))
                    {
                        return keyValuePair.Value;
                    }
                }
            }

            return result;
        }

        public List<SystemGeometrySymbol> GetSystemGeometrySymbols()
        {
            if(dictionary == null)
            {
                return null;
            }

            List<SystemGeometrySymbol> result = new List<SystemGeometrySymbol>();
            foreach(KeyValuePair<string, SystemGeometrySymbol> keyValuePair in dictionary)
            {
                result.Add(new SystemGeometrySymbol(keyValuePair.Value));
            }

            return result;
        }

        public JsonObject ToJsonObject()
        {
            JsonObject jObject = new JsonObject();
            jObject.Add("_type", Core.Query.FullTypeName(this));

            if(dictionary != null)
            {
                JsonArray jArray = new JsonArray();
                foreach(KeyValuePair<string, SystemGeometrySymbol> keyValuePair in dictionary)
                {
                    JsonArray jArray_Temp = new JsonArray();
                    jArray_Temp.Add(keyValuePair.Key);
                    jArray_Temp.Add(keyValuePair.Value.ToJsonObject());
                    jArray.Add(jArray_Temp);
                }

                jObject.Add("SystemGeometrySymbols", jArray);
            }

            return jObject;
        }
    }
}
