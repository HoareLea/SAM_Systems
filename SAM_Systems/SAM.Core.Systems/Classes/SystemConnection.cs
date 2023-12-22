using Newtonsoft.Json.Linq;
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

        public SystemConnection(ISystem system, ISystemComponent systemComponent_1, int index_1, ISystemComponent systemComponent_2, int index_2)
            : base(typeof(SystemConnection).Name)
        {
            SystemType systemType = new SystemType(system);
            if(systemType.IsValid())
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

            ObjectReference objectReference = new ObjectReference((SAMObject)systemComponent);
            if(!objectReference.IsValid())
            {
                return false;
            }

            if(!dictionary.TryGetValue(objectReference, out index))
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
    }
}
