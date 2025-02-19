using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Systems
{
    public abstract class SystemConnectorManager<T> : ISystemJSAMObject where T : SystemConnector
    {
        private SortedDictionary<int, T> sortedDictionary;

        public SystemConnectorManager(IEnumerable<T> systemConnectors)
        {
            if (systemConnectors == null)
            {
                return;
            }

            sortedDictionary = new SortedDictionary<int, T>();
            for (int i = 0; i < systemConnectors.Count(); i++)
            {
                T systemConnector = systemConnectors.ElementAt(i);

                sortedDictionary[i] = systemConnector?.Clone();
            }
        }

        public SystemConnectorManager()
        {

        }

        public SystemConnectorManager(JObject jObject)
        {
            FromJObject(jObject);
        }

        public SystemConnectorManager(SystemConnectorManager<T> systemConnectorManager)
        {
            if(systemConnectorManager?.sortedDictionary != null)
            {
                sortedDictionary = new SortedDictionary<int, T>();
                foreach (KeyValuePair<int, T> keyValuePair in systemConnectorManager.sortedDictionary)
                {
                    sortedDictionary[keyValuePair.Key] = keyValuePair.Value?.Clone();
                }
            }
        }

        public T this[int index]
        {
            get
            {
                if(sortedDictionary == null)
                {
                    return null;
                }

                if(!sortedDictionary.TryGetValue(index, out T systemConnector) || systemConnector == null)
                {
                    return null;
                }

                return systemConnector.Clone();
            }
        }
        
        public IEnumerable<int> Indexes
        {
            get
            {
                return sortedDictionary?.Keys;
            }
        }

        public IEnumerable<T> SystemConnectors
        {
            get
            {
                if(sortedDictionary == null)
                {
                    return null;
                }

                List<T> result = new List<T>();
                foreach(KeyValuePair<int, T> keyValuePair in sortedDictionary)
                {
                    T systemConnector = keyValuePair.Value?.Clone();
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
            foreach(KeyValuePair<int, T> keyValuePair in sortedDictionary)
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

        public List<int> GetIndexes(SystemType systemType, int connectionIndex)
        {
            if (sortedDictionary == null)
            {
                return null;
            }

            List<int> result = new List<int>();
            foreach (KeyValuePair<int, T> keyValuePair in sortedDictionary)
            {
                SystemType systemType_Temp = keyValuePair.Value?.SystemType;

                if (systemType == systemType_Temp || (systemType_Temp != null && systemType_Temp.IsValid(systemType)))
                {
                    if (keyValuePair.Value.ConnectionIndex != connectionIndex)
                    {
                        continue;
                    }

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
            foreach (KeyValuePair<int, T> keyValuePair in sortedDictionary)
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

        public List<int> GetIndexes(SystemType systemType, Direction direction, int connectionIndex)
        {
            if (sortedDictionary == null)
            {
                return null;
            }

            List<int> result = new List<int>();
            foreach (KeyValuePair<int, T> keyValuePair in sortedDictionary)
            {
                SystemType systemType_Temp = keyValuePair.Value?.SystemType;

                if ((systemType == systemType_Temp || (systemType_Temp != null && systemType_Temp.IsValid(systemType))) && keyValuePair.Value?.Direction == direction)
                {
                    if(keyValuePair.Value.ConnectionIndex != connectionIndex)
                    {
                        continue;
                    }

                    result.Add(keyValuePair.Key);
                    continue;
                }
            }

            return result;
        }

        public List<int> GetConnectedIndexes(int index)
        {
            T systemConnector = this[index];
            if(systemConnector == null || systemConnector.ConnectionIndex == -1)
            {
                return null;
            }

            int connectionIndex = systemConnector.ConnectionIndex;

            List<int> result = new List<int>();
            foreach(KeyValuePair<int, T> keyValuePair in sortedDictionary)
            {
                T systemConnector_Temp = keyValuePair.Value;
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
            IEnumerable<T> systemConnectors = SystemConnectors;
            if(systemConnectors == null)
            {
                return null;
            }

            HashSet<int> result = new HashSet<int>();
            foreach(T systemConnector in systemConnectors)
            {
                if(systemConnector == null || systemConnector.ConnectionIndex == -1)
                {
                    continue;
                }

                result.Add(systemConnector.ConnectionIndex);
            }

            return result;
        }

        public HashSet<int> GetConnectionIndexes(SystemType systemType)
        {
            IEnumerable<T> systemConnectors = SystemConnectors;
            if (systemConnectors == null)
            {
                return null;
            }

            HashSet<int> result = new HashSet<int>();
            foreach (T systemConnector in systemConnectors)
            {
                if (systemConnector == null || systemConnector.ConnectionIndex == -1)
                {
                    continue;
                }

                SystemType systemType_Temp = systemConnector?.SystemType;
                if (!(systemType == systemType_Temp || (systemType_Temp != null && systemType_Temp.IsValid(systemType))))
                {
                    continue;
                }

                result.Add(systemConnector.ConnectionIndex);
            }

            return result;
        }

        public int GetConnectionIndex(int index)
        {
            T systemConnector = this[index];
            if(systemConnector == null)
            {
                return -1;
            }

            return systemConnector.ConnectionIndex;
        }

        public SystemType GetSystemType(int index)
        {
            if(sortedDictionary == null)
            {
                return null;
            }

            if(!sortedDictionary.TryGetValue(index, out T systemConnector))
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

            if (!sortedDictionary.TryGetValue(index, out T systemConnector) || systemConnector == null)
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

            foreach(KeyValuePair<int, T> keyValuePair in sortedDictionary)
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

            foreach (KeyValuePair<int, T> keyValuePair in sortedDictionary)
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
            if(!TryGetSystemConnector(index, out T systemConnector) || systemConnector == null)
            {
                return false;
            }

            return systemConnector.IsValid(systemType);
        }

        public bool TryGetSystemConnector(int index, out T systemConnector)
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

            systemConnector = systemConnector?.Clone();
            return true;
        }

        public List<T> GetSystemConnectors(IEnumerable<int> indexes)
        {
            if(indexes == null || sortedDictionary == null)
            {
                return null;
            }

            List<T> result = new List<T>();
            foreach(int index in indexes)
            {
                if (sortedDictionary.TryGetValue(index, out T systemConnector) && systemConnector != null)
                {
                    result.Add(systemConnector.Clone());
                }
            }

            return result;
        }

        public List<T> GetSystemConnectors(SystemType systemType)
        {
            List<int> indexes = GetIndexes(systemType);
            if(indexes == null)
            {
                return null;
            }

            return GetSystemConnectors(indexes);
        }

        public List<T> GetSystemConnectors(SystemType systemType, Direction direction)
        {
            List<int> indexes = GetIndexes(systemType, direction);
            if (indexes == null)
            {
                return null;
            }

            return GetSystemConnectors(indexes);
        }

        public virtual bool FromJObject(JObject jObject)
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
                    sortedDictionary = new SortedDictionary<int, T>();
                    foreach(JToken jToken in jArray)
                    {
                        if(jToken is JArray)
                        {
                            JArray jArray_Temp = (JArray)jToken;
                            
                            if (jArray_Temp == null || jArray_Temp.Count < 1)
                            {
                                continue;
                            }

                            int index = jArray_Temp[0].Value<int>();

                            T systemConnector = null;
                            if (jArray_Temp.Count > 1)
                            {
                                systemConnector = Core.Query.IJSAMObject<T>(jArray_Temp[1].Value<JObject>());
                            }

                            sortedDictionary[index] = systemConnector;
                        }
                        else if (jToken is JObject)
                        {
                            int index = sortedDictionary.Keys.Count == 0 ? 0 : sortedDictionary.Keys.Max() + 1;
                            T systemConnector = Core.Query.IJSAMObject<T>((JObject)jToken);
                            sortedDictionary[index] = systemConnector;
                        }


                    }
                }
            }

            return true;
        }

        public virtual JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if(sortedDictionary != null)
            {
                JArray jArray = new JArray();
                foreach(KeyValuePair<int, T> keyValuePair in sortedDictionary)
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

    public class SystemConnectorManager : SystemConnectorManager<SystemConnector>
    {
        public SystemConnectorManager(IEnumerable<SystemConnector> systemConnectors)
            :base(systemConnectors)
        {
        }

        public SystemConnectorManager()
        {

        }

        public SystemConnectorManager(JObject jObject)
            :base(jObject)
        {

        }

        public SystemConnectorManager(SystemConnectorManager systemConnectorManager)
            : base(systemConnectorManager)
        {

        }
    }
}
