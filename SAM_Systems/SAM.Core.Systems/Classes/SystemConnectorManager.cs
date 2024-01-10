using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Systems
{
    public class SystemConnectorManager : ISystemJSAMObject
    {
        private SortedDictionary<int, SystemConnector> sortedDictionary;

        public SystemConnectorManager(IEnumerable<SystemConnector> systemConnectors)
        {
            if (systemConnectors == null)
            {
                return;
            }

            sortedDictionary = new SortedDictionary<int, SystemConnector>();
            for (int i = 0; i < systemConnectors.Count(); i++)
            {
                SystemConnector systemConnector = systemConnectors.ElementAt(i);

                sortedDictionary[i] = systemConnector == null ? null : new SystemConnector(systemConnector);
            }
        }

        public SystemConnectorManager()
        {

        }

        public SystemConnectorManager(JObject jObject)
        {
            FromJObject(jObject);
        }

        public SystemConnectorManager(SystemConnectorManager systemConnectorManager)
        {
            if(systemConnectorManager?.sortedDictionary != null)
            {
                sortedDictionary = new SortedDictionary<int, SystemConnector>();
                foreach (KeyValuePair<int, SystemConnector> keyValuePair in systemConnectorManager.sortedDictionary)
                {
                    sortedDictionary[keyValuePair.Key] = keyValuePair.Value == null ? null : new SystemConnector(keyValuePair.Value);
                }
            }
        }

        public SystemConnector this[int index]
        {
            get
            {
                if(sortedDictionary == null)
                {
                    return null;
                }

                if(!sortedDictionary.TryGetValue(index, out SystemConnector systemConnector) || systemConnector == null)
                {
                    return null;
                }

                return new SystemConnector(systemConnector);
            }
        }
        
        public IEnumerable<int> Indexes
        {
            get
            {
                return sortedDictionary?.Keys;
            }
        }

        public IEnumerable<SystemConnector> SystemConnectors
        {
            get
            {
                if(sortedDictionary == null)
                {
                    return null;
                }

                List<SystemConnector> result = new List<SystemConnector>();
                foreach(KeyValuePair<int, SystemConnector> keyValuePair in sortedDictionary)
                {
                    SystemConnector systemConnector = keyValuePair.Value == null ? null : new SystemConnector(keyValuePair.Value);
                    if(systemConnector == null)
                    {
                        continue;
                    }

                    result.Add(systemConnector);
                }

                return result;
            }
        }

        public List<int> GetIndexes(SystemType systemType)
        {
            if(sortedDictionary == null)
            {
                return null;
            }

            List<int> result = new List<int>();
            foreach(KeyValuePair<int, SystemConnector> keyValuePair in sortedDictionary)
            {
                SystemType systemType_Temp = keyValuePair.Value?.SystemType;

                if (systemType == systemType_Temp || (systemType_Temp != null && systemType_Temp.IsValid(systemType)))
                {
                    result.Add(keyValuePair.Key);
                    continue;
                }
            }

            return result;
        }

        public List<int> GetIndexes(SystemType systemType, Direction direction)
        {
            if (sortedDictionary == null)
            {
                return null;
            }

            List<int> result = new List<int>();
            foreach (KeyValuePair<int, SystemConnector> keyValuePair in sortedDictionary)
            {
                SystemType systemType_Temp = keyValuePair.Value?.SystemType;

                if ((systemType == systemType_Temp || (systemType_Temp != null && systemType_Temp.IsValid(systemType))) && keyValuePair.Value?.Direction == direction)
                {
                    result.Add(keyValuePair.Key);
                    continue;
                }
            }

            return result;
        }

        public List<int> GetConnectedIndexes(int index)
        {
            SystemConnector systemConnector = this[index];
            if(systemConnector == null || systemConnector.ConnectionIndex == -1)
            {
                return null;
            }

            int connectionIndex = systemConnector.ConnectionIndex;

            List<int> result = new List<int>();
            foreach(KeyValuePair<int, SystemConnector> keyValuePair in sortedDictionary)
            {
                SystemConnector systemConnector_Temp = keyValuePair.Value;
                if(systemConnector_Temp == null)
                {
                    continue;
                }

                if(systemConnector_Temp.ConnectionIndex == connectionIndex && keyValuePair.Key != index)
                {
                    result.Add(keyValuePair.Key);
                }
            }

            return result;
        }

        public HashSet<int> GetConnectionIndexes()
        {
            IEnumerable<SystemConnector> systemConnectors = SystemConnectors;
            if(systemConnectors == null)
            {
                return null;
            }

            HashSet<int> result = new HashSet<int>();
            foreach(SystemConnector systemConnector in systemConnectors)
            {
                if(systemConnector == null || systemConnector.ConnectionIndex == -1)
                {
                    continue;
                }

                result.Add(systemConnector.ConnectionIndex);
            }

            return result;
        }

        public SystemType GetSystemType(int index)
        {
            if(sortedDictionary == null)
            {
                return null;
            }

            if(!sortedDictionary.TryGetValue(index, out SystemConnector systemConnector))
            {
                return null;
            }

            return systemConnector?.SystemType == null ? null : new SystemType(systemConnector.SystemType);
        }

        public Direction GetDirection(int index)
        {
            if (sortedDictionary == null)
            {
                return Direction.Undefined;
            }

            if (!sortedDictionary.TryGetValue(index, out SystemConnector systemConnector) || systemConnector == null)
            {
                return Direction.Undefined;
            }

            return systemConnector.Direction;
        }

        public bool Contains(int index)
        {
            if(sortedDictionary == null)
            {
                return false;
            }

            return sortedDictionary.ContainsKey(index);
        }

        public bool HasConnectors()
        {
            if(sortedDictionary == null || sortedDictionary.Count == 0)
            {
                return false;
            }

            foreach(KeyValuePair<int, SystemConnector> keyValuePair in sortedDictionary)
            {
                if(keyValuePair.Value != null)
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasConnectors(SystemType systemType)
        {
            if (sortedDictionary == null || sortedDictionary.Count == 0)
            {
                return false;
            }

            foreach (KeyValuePair<int, SystemConnector> keyValuePair in sortedDictionary)
            {
                if (keyValuePair.Value != null)
                {
                    SystemType systemType_Temp = keyValuePair.Value.SystemType;
                    if(systemType == systemType_Temp || (systemType_Temp != null && systemType_Temp.IsValid(systemType)))
                    {
                        return true;
                    }

                }
            }

            return false;
        }

        public bool IsValid(int index, SystemType systemType)
        {
            if(!TryGetSystemConnector(index, out SystemConnector systemConnector) || systemConnector == null)
            {
                return false;
            }

            return systemConnector.IsValid(systemType);
        }

        public bool TryGetSystemConnector(int index, out SystemConnector systemConnector)
        {
            systemConnector = null;

            if(sortedDictionary == null)
            {
                return false;
            }

            if(!sortedDictionary.TryGetValue(index, out systemConnector))
            {
                return false;
            }

            systemConnector = systemConnector == null ? null : new SystemConnector(systemConnector);
            return true;
        }

        public List<SystemConnector> GetSystemConnectors(IEnumerable<int> indexes)
        {
            if(indexes == null || sortedDictionary == null)
            {
                return null;
            }

            List<SystemConnector> result = new List<SystemConnector>();
            foreach(int index in indexes)
            {
                if (sortedDictionary.TryGetValue(index, out SystemConnector systemConnector) && systemConnector != null)
                {
                    result.Add(new SystemConnector(systemConnector));
                }
            }

            return result;
        }

        public List<SystemConnector> GetSystemConnectors(SystemType systemType)
        {
            List<int> indexes = GetIndexes(systemType);
            if(indexes == null)
            {
                return null;
            }

            return GetSystemConnectors(indexes);
        }

        public List<SystemConnector> GetSystemConnectors(SystemType systemType, Direction direction)
        {
            List<int> indexes = GetIndexes(systemType, direction);
            if (indexes == null)
            {
                return null;
            }

            return GetSystemConnectors(indexes);
        }

        public bool FromJObject(JObject jObject)
        {
            if(jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("SystemConnectors"))
            {
                JArray jArray = jObject.Value<JArray>("SystemConnectors");
                if(jArray != null)
                {
                    sortedDictionary = new SortedDictionary<int, SystemConnector>();
                    foreach(JArray jArray_Temp in jArray)
                    {
                        if(jArray_Temp == null || jArray_Temp.Count < 1)
                        {
                            continue;
                        }

                        int index = jArray_Temp[0].Value<int>();

                        SystemConnector systemConnector = null;
                        if(jArray_Temp.Count > 1)
                        {
                            systemConnector = new SystemConnector(jArray_Temp[1].Value<JObject>());
                        }

                        sortedDictionary[index] = systemConnector;
                    }
                }
            }

            return true;
        }

        public JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if(sortedDictionary != null)
            {
                JArray jArray = new JArray();
                foreach(KeyValuePair<int, SystemConnector> keyValuePair in sortedDictionary)
                {
                    JArray jArray_Temp = new JArray() { keyValuePair.Key };
                    if(keyValuePair.Value != null)
                    {
                        jArray_Temp.Add(keyValuePair.Value.ToJObject());
                    }
                    jArray.Add(jArray_Temp);
                }

                result.Add("SystemConnectors", jArray);
            }

            return result;
        }
    }
}
