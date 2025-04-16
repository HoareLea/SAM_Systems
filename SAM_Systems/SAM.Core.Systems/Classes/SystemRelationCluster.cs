using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Systems
{
    public class SystemRelationCluster : SAMObjectRelationCluster<ISystemJSAMObject>
    {
        public SystemRelationCluster(JObject jObject) 
            : base(jObject)
        {
        }

        public SystemRelationCluster(SystemRelationCluster systemRelationCluster)
            : base(systemRelationCluster)
        {
        }

        public SystemRelationCluster(SystemRelationCluster systemRelationCluster, bool deepClone)
            : base(systemRelationCluster, deepClone)
        {
        }

        public SystemRelationCluster()
            : base()
        {
        }

        public T Duplicate<T>(T systemJSAMObject) where T : ISystemJSAMObject
        {
            if (systemJSAMObject == null)
            {
                return default(T);
            }

            System.Guid guid = GetGuid(systemJSAMObject);
            if (guid == System.Guid.Empty)
            {
                return default(T);
            }

            Dictionary<System.Guid, ISystemJSAMObject> dictionary = Duplicate(new ISystemJSAMObject[] { systemJSAMObject });
            if(dictionary  == null || dictionary.Count == 0)
            {
                return default(T);
            }

            if(!dictionary.TryGetValue(guid, out ISystemJSAMObject result))
            {
                return default(T);
            }

            return result is T ? (T)result : default(T);
        }

        public Dictionary<System.Guid, ISystemJSAMObject> Duplicate(IEnumerable<ISystemJSAMObject> systemJSAMObjects)
        {
            if(systemJSAMObjects == null)
            {
                return null;
            }

            Dictionary<System.Guid, ISystemJSAMObject> result = new Dictionary<System.Guid, ISystemJSAMObject>();

            for (int i = 0; i < systemJSAMObjects.Count(); i++)
            {
                ISystemJSAMObject systemJSAMObject = systemJSAMObjects.ElementAt(i);
                System.Guid guid = GetGuid(systemJSAMObject);
                if(guid == System.Guid.Empty)
                {
                    continue;
                }

                if (systemJSAMObject is SystemObject)
                {
                    systemJSAMObject = ((SystemObject)systemJSAMObject).Duplicate();
                }
                else
                {
                    systemJSAMObject = systemJSAMObject.Clone();
                }

                if (!AddObject(systemJSAMObject))
                {
                    continue;
                }

                result[guid] = systemJSAMObject;
            }

            foreach (KeyValuePair<System.Guid, ISystemJSAMObject> keyValuePair in result)
            {
                ISystemJSAMObject systemJSAMObject_Destination = keyValuePair.Value;
                if (systemJSAMObject_Destination == null)
                {
                    continue;
                }

                ISystemJSAMObject systemJSAMObject_Source = GetObject(systemJSAMObject_Destination.GetType(), keyValuePair.Key);
                if (systemJSAMObject_Source == null)
                {
                    continue;
                }

                List<ISystemJSAMObject> systemJSAMObjects_Source_Related = GetRelatedObjects(systemJSAMObject_Source);
                if (systemJSAMObjects_Source_Related != null)
                {
                    foreach (ISystemJSAMObject systemJSAMObject_Source_Related in systemJSAMObjects_Source_Related)
                    {
                        System.Guid guid = GetGuid(systemJSAMObject_Source_Related);
                        if (result.TryGetValue(guid, out ISystemJSAMObject systemJSAMObject_Destination_Related))
                        {
                            AddRelation(systemJSAMObject_Destination, systemJSAMObject_Destination_Related);
                        }
                    }
                }

                if (systemJSAMObject_Destination is SystemConnection)
                {
                    SystemConnection systemConnection_Destination = (SystemConnection)systemJSAMObject_Destination;
                    List<ObjectReference> objectReferences_Source = systemConnection_Destination.ObjectReferences;
                    if (objectReferences_Source != null)
                    {
                        foreach (ObjectReference objectReference_Source in objectReferences_Source)
                        {
                            System.Guid guid = GetGuid(GetObject(objectReference_Source));
                            if (result.TryGetValue(guid, out ISystemJSAMObject systemJSAMObject_Destination_ObjectReference) && systemJSAMObject_Destination_ObjectReference is SAMObject)
                            {
                                ObjectReference objectReferences_Destionation = new ObjectReference((SAMObject)systemJSAMObject_Destination_ObjectReference);
                                systemConnection_Destination.Reassign(objectReference_Source, objectReferences_Destionation);
                            }
                        }

                        AddObject(systemConnection_Destination);
                    }
                }
            }

            return result;
        }

        public SystemRelationCluster Duplicate()
        {
            SystemRelationCluster result = new SystemRelationCluster();

            List<ISystemJSAMObject> systemJSAMObjects = GetObjects();
            if (systemJSAMObjects != null)
            {
                Dictionary<System.Guid, ISystemJSAMObject> dictionary = new Dictionary<System.Guid, ISystemJSAMObject>();

                for (int i = 0; i < systemJSAMObjects.Count; i++)
                {
                    ISystemJSAMObject systemJSAMObject = systemJSAMObjects[i];
                    System.Guid guid = GetGuid(systemJSAMObject);

                    if (systemJSAMObject is SystemObject)
                    {
                        systemJSAMObject = ((SystemObject)systemJSAMObject).Duplicate();
                    }
                    else
                    {
                        systemJSAMObject = systemJSAMObject.Clone();
                    }

                    if (!result.AddObject(systemJSAMObject))
                    {
                        continue;
                    }

                    dictionary[guid] = systemJSAMObject;
                }

                foreach (KeyValuePair<System.Guid, ISystemJSAMObject> keyValuePair in dictionary)
                {
                    ISystemJSAMObject systemJSAMObject_Destination = keyValuePair.Value;
                    if (systemJSAMObject_Destination == null)
                    {
                        continue;
                    }

                    ISystemJSAMObject systemJSAMObject_Source = GetObject(systemJSAMObject_Destination.GetType(), keyValuePair.Key);
                    if (systemJSAMObject_Source == null)
                    {
                        continue;
                    }

                    List<ISystemJSAMObject> systemJSAMObjects_Source_Related = GetRelatedObjects(systemJSAMObject_Source);
                    if (systemJSAMObjects_Source_Related != null)
                    {
                        foreach (ISystemJSAMObject systemJSAMObject_Source_Related in systemJSAMObjects_Source_Related)
                        {
                            System.Guid guid = GetGuid(systemJSAMObject_Source_Related);
                            if (dictionary.TryGetValue(guid, out ISystemJSAMObject systemJSAMObject_Destination_Related))
                            {
                                result.AddRelation(systemJSAMObject_Destination, systemJSAMObject_Destination_Related);
                            }
                        }
                    }

                    if (systemJSAMObject_Destination is SystemConnection)
                    {
                        SystemConnection systemConnection_Destination = (SystemConnection)systemJSAMObject_Destination;
                        List<ObjectReference> objectReferences_Source = systemConnection_Destination.ObjectReferences;
                        if (objectReferences_Source != null)
                        {
                            foreach (ObjectReference objectReference_Source in objectReferences_Source)
                            {
                                System.Guid guid = GetGuid(GetObject(objectReference_Source));
                                if (dictionary.TryGetValue(guid, out ISystemJSAMObject systemJSAMObject_Destination_ObjectReference) && systemJSAMObject_Destination_ObjectReference is SAMObject)
                                {
                                    ObjectReference objectReferences_Destionation = new ObjectReference((SAMObject)systemJSAMObject_Destination_ObjectReference);
                                    systemConnection_Destination.Reassign(objectReference_Source, objectReferences_Destionation);
                                }
                            }

                            result.AddObject(systemConnection_Destination);
                        }
                    }
                }
            }

            return result;
        }
    }
}
