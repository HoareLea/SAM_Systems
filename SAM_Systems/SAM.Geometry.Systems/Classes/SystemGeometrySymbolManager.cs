using Newtonsoft.Json.Linq;
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

        public SystemGeometrySymbolManager(JObject jObject)
        {
            FromJObject(jObject);
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

        public bool FromJObject(JObject jObject)
        {
            if(jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("SystemGeometrySymbols"))
            {
                JArray jArray = jObject.Value<JArray>("SystemGeometrySymbols");
                if(jArray != null)
                {
                    dictionary = new Dictionary<string, SystemGeometrySymbol>();
                    foreach(JArray jArray_Temp in jArray)
                    {
                        dictionary[(string)jArray_Temp[0]] = new SystemGeometrySymbol(jArray_Temp[1] as JObject);
                    }
                }
            }

            return true;
        }

        public SystemGeometrySymbol GetSystemGeometrySymbol<T>() where T : ISystemObject
        {
            string fullTypeName = Core.Query.FullTypeName(typeof(T));
            if (string.IsNullOrWhiteSpace(fullTypeName))
            {
                return null;
            }

            if(!dictionary.TryGetValue(fullTypeName, out SystemGeometrySymbol result))
            {
                foreach(KeyValuePair<string, SystemGeometrySymbol> keyValuePair in dictionary)
                {
                    System.Type type = Core.Query.Type(keyValuePair.Key);
                    if(type == null)
                    {
                        continue;
                    }

                    if(type.IsAssignableFrom(typeof(T)))
                    {
                        return keyValuePair.Value;
                    }
                }
            }

            return result;
        }

        public JObject ToJObject()
        {
            JObject jObject = new JObject();
            jObject.Add("_type", Core.Query.FullTypeName(this));

            if(dictionary != null)
            {
                JArray jArray = new JArray();
                foreach(KeyValuePair<string, SystemGeometrySymbol> keyValuePair in dictionary)
                {
                    JArray jArray_Temp = new JArray();
                    jArray_Temp.Add(keyValuePair.Key);
                    jArray_Temp.Add(keyValuePair.Value.ToJObject());
                    jArray.Add(jArray_Temp);
                }

                jObject.Add("SystemGeometrySymbols", jArray);
            }

            return jObject;
        }
    }
}
