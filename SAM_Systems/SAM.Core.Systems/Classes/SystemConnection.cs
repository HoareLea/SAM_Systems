﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public class SystemConnection : SystemComponent, ISystemConnection
    {
        private SystemType systemType;
        private Dictionary<ObjectReference, int> dictionary;

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Create.SystemConnectorManager(Create.SystemConnector<IControlSystem>());
            }
        }

        public SystemConnection(SystemConnection systemConnection)
            : base(systemConnection)
        {
            if(systemConnection != null)
            {
                systemType = systemConnection.systemType == null ? null : new SystemType(systemConnection.systemType);
                if(systemConnection.dictionary != null)
                {
                    dictionary = new Dictionary<ObjectReference, int>();
                    foreach(KeyValuePair<ObjectReference, int> keyValuePair in systemConnection.dictionary)
                    {
                        dictionary[new ObjectReference(keyValuePair.Key)] = keyValuePair.Value;
                    }
                }
            }
        }

        public SystemConnection(Guid guid, SystemConnection systemConnection)
            : base(guid, systemConnection)
        {
            if (systemConnection != null)
            {
                systemType = systemConnection.systemType == null ? null : new SystemType(systemConnection.systemType);
                if (systemConnection.dictionary != null)
                {
                    dictionary = new Dictionary<ObjectReference, int>();
                    foreach (KeyValuePair<ObjectReference, int> keyValuePair in systemConnection.dictionary)
                    {
                        dictionary[new ObjectReference(keyValuePair.Key)] = keyValuePair.Value;
                    }
                }
            }
        }

        public SystemConnection(JObject jObject)
            : base(jObject)
        {

        }

        public SystemConnection(ISystemComponent systemComponent_1, ISystemComponent systemComponent_2)
            : base(typeof(SystemConnection).Name)
        {
            systemType = null;

            dictionary = new Dictionary<ObjectReference, int>();

            if(systemComponent_1 != null && systemComponent_1 is SAMObject)
            {
                dictionary[new ObjectReference((SAMObject)systemComponent_1)] = -1;
            }

            if (systemComponent_2 != null && systemComponent_2 is SAMObject)
            {
                dictionary[new ObjectReference((SAMObject)systemComponent_2)] = -1;
            }
        }

        public SystemConnection(SystemType systemType, ISystemComponent systemComponent_1, int index_1, ISystemComponent systemComponent_2, int index_2)
            : base(typeof(SystemConnection).Name)
        {
            if(systemType != null &&  systemType.IsValid())
            {
                this.systemType = systemType;

                dictionary = new Dictionary<ObjectReference, int>();

                if (systemComponent_1 != null && systemComponent_1 is SAMObject)
                {
                    dictionary[new ObjectReference((SAMObject)systemComponent_1)] = index_1;
                }

                if (systemComponent_2 != null && systemComponent_2 is SAMObject)
                {
                    dictionary[new ObjectReference((SAMObject)systemComponent_2)] = index_2;
                }
            }
        }

        public SystemConnection(SystemType systemType, IEnumerable<Tuple<ObjectReference, int>> tuples)
            : base(typeof(SystemConnection).Name)
        {
            this.systemType = systemType;
            if(tuples != null)
            {
                dictionary = new Dictionary<ObjectReference, int>();
                foreach(Tuple<ObjectReference, int> tuple in tuples)
                {
                    if(tuple.Item1 == null)
                    {
                        continue;
                    }

                    dictionary[tuple.Item1] = tuple.Item2;
                }
            }
        }

        public SystemType SystemType
        {
            get
            {
                return systemType == null ? null : new SystemType(systemType);
            }
        }

        public bool TryGetIndex(ISystemComponent systemComponent, out int index)
        {
            index = -1;

            if(systemComponent == null)
            {
                return false;
            }

            return TryGetIndex(new ObjectReference((SAMObject)systemComponent), out index);
        }

        public bool TryGetIndex(ObjectReference objectReference, out int index)
        {
            index = -1;

            if (objectReference == null || !objectReference.IsValid())
            {
                return false;
            }

            if (!dictionary.TryGetValue(objectReference, out index))
            {
                return false;
            }

            return true;
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("SystemType"))
            {
                systemType = new SystemType(jObject.Value<JObject>("SystemType"));
            }

            if(jObject.ContainsKey("ObjectReferences"))
            {
                JArray jArray = jObject.Value<JArray>("ObjectReferences");
                if(jArray != null)
                {
                    dictionary = new Dictionary<ObjectReference, int>();
                    foreach(JArray jArray_ObjectReference in jArray)
                    {
                        if(jArray_ObjectReference == null || jArray.Count == 0)
                        {
                            continue;
                        }

                        JObject jObject_ObjectReference = jArray_ObjectReference[0]?.Value<JObject>(); 
                        if(jObject_ObjectReference == null)
                        {
                            continue;
                        }

                        ObjectReference objectReference = new ObjectReference(jObject_ObjectReference);
                        int index = -1;
                        if(jArray_ObjectReference.Count > 1)
                        {
                            index = jArray_ObjectReference[1].Value<int>();
                        }

                        if(index == -1)
                        {
                            continue;
                        }

                        dictionary[objectReference] = index;
                    }

                }
            }


            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if(result == null)
            {
                return result;
            }

            if(systemType != null)
            {
                result.Add("SystemType", systemType.ToJObject());
            }

            if(dictionary != null)
            {
                JArray jArray = new JArray();
                foreach(KeyValuePair<ObjectReference, int> keyValuePair in dictionary)
                {
                    JArray jArray_ObjectReference = new JArray() { keyValuePair.Key.ToJObject(), keyValuePair.Value };
                    jArray.Add(jArray_ObjectReference);
                }

                result.Add("ObjectReferences", jArray);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemConnection(guid == null ? Guid.NewGuid() : guid.Value, this);
        }

        public List<ObjectReference> ObjectReferences
        {
            get
            {
                return dictionary == null ? null : new List<ObjectReference>(dictionary.Keys);
            }
        }

        public bool Reassign(ObjectReference objectReference_From, ObjectReference objectReference_To)
        {
            if(objectReference_From == null || dictionary == null || dictionary.Count == 0)
            {
                return false;
            }

            if(!dictionary.TryGetValue(objectReference_From, out int index))
            {
                return false;
            }

            dictionary.Remove(objectReference_From);
            dictionary[objectReference_To] = index;
            return true;
        }

        public List<ObjectReference> Reassign(IEnumerable<KeyValuePair<ObjectReference, ObjectReference>> keyValuePairs)
        {
            if (dictionary == null || dictionary.Count == 0 || keyValuePairs == null)
            {
                return null;
            }

            List<ObjectReference> result = new List<ObjectReference>();
            foreach(KeyValuePair<ObjectReference, ObjectReference> keyValuePair in keyValuePairs)
            {
                if (Reassign(keyValuePair.Key, keyValuePair.Value))
                {
                    result.Add(keyValuePair.Key);
                }
            }

            return result;
        }

    }
}
