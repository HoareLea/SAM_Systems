﻿using Newtonsoft.Json.Linq;
using System;
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

            Guid guid = GetGuid(systemJSAMObject);
            if (guid == Guid.Empty)
            {
                return default(T);
            }

            Dictionary<Guid, ISystemJSAMObject> dictionary = Duplicate(new ISystemJSAMObject[] { systemJSAMObject });
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

        public Dictionary<Guid, ISystemJSAMObject> Duplicate(IEnumerable<ISystemJSAMObject> systemJSAMObjects, bool deepDuplicate = false)
        {
            if(systemJSAMObjects == null)
            {
                return null;
            }

            List<Tuple<Guid, ISystemJSAMObject>> tuples = new List<Tuple<Guid, ISystemJSAMObject>>();

            for (int i = 0; i < systemJSAMObjects.Count(); i++)
            {
                ISystemJSAMObject systemJSAMObject = systemJSAMObjects.ElementAt(i);
                Guid guid = GetGuid(systemJSAMObject);
                if(guid == Guid.Empty)
                {
                    continue;
                }

                if(tuples.Find(x => x.Item1 == guid) != null)
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

                tuples.Add(new Tuple<Guid, ISystemJSAMObject>(guid, systemJSAMObject));
            }

            Dictionary<Guid, ISystemJSAMObject> result = new Dictionary<Guid, ISystemJSAMObject>();

            while(tuples.Count > 0)
            {
                Tuple<Guid, ISystemJSAMObject> tuple = tuples.ElementAt(0);
                tuples.RemoveAt(0);

                ISystemJSAMObject systemJSAMObject_Destination = tuple.Item2;

                result[tuple.Item1] = systemJSAMObject_Destination;

                if (systemJSAMObject_Destination == null)
                {
                    continue;
                }

                ISystemJSAMObject systemJSAMObject_Source = GetObject(systemJSAMObject_Destination.GetType(), tuple.Item1);
                if (systemJSAMObject_Source == null)
                {
                    continue;
                }

                List<ISystemJSAMObject> systemJSAMObjects_Source_Related = GetRelatedObjects(systemJSAMObject_Source);
                if (systemJSAMObjects_Source_Related != null)
                {
                    foreach (ISystemJSAMObject systemJSAMObject_Source_Related in systemJSAMObjects_Source_Related)
                    {
                        Guid guid = GetGuid(systemJSAMObject_Source_Related);
                        if (guid == Guid.Empty)
                        {
                            continue;
                        }

                        if (!result.TryGetValue(guid, out ISystemJSAMObject systemJSAMObject_Destination_Related) || systemJSAMObject_Destination_Related == null)
                        {
                            if (systemJSAMObject_Source_Related is SystemObject)
                            {
                                systemJSAMObject_Destination_Related = ((SystemObject)systemJSAMObject_Source_Related).Duplicate();
                            }
                            else
                            {
                                systemJSAMObject_Destination_Related = systemJSAMObject_Source_Related.Clone();
                            }

                            if (!AddObject(systemJSAMObject_Destination_Related))
                            {
                                continue;
                            }

                            if(deepDuplicate)
                            {
                                tuples.Add(new Tuple<Guid, ISystemJSAMObject>(guid, systemJSAMObject_Destination_Related));
                            }
                            else
                            {
                                result[guid] = systemJSAMObject_Destination_Related;
                            }

                            List<ISystemSpaceComponent> systemSpaceComponents_Source = GetRelatedObjects<ISystemSpaceComponent>(systemJSAMObject_Source_Related);
                            if (systemSpaceComponents_Source != null && systemSpaceComponents_Source.Count != 0)
                            {
                                for (int i = 0; i < systemSpaceComponents_Source.Count; i++)
                                {
                                    SystemObject systemObject_Destination = (systemSpaceComponents_Source[i] as SystemObject)?.Duplicate();
                                    if (systemObject_Destination == null)
                                    {
                                        continue;
                                    }

                                    if (!AddObject(systemObject_Destination))
                                    {
                                        continue;
                                    }

                                    AddRelation(systemObject_Destination, systemJSAMObject_Destination_Related);
                                    result[GetGuid(systemObject_Destination)] = systemObject_Destination;
                                }

                            }

                        }

                        if (systemJSAMObject_Destination_Related != null)
                        {
                            AddRelation(systemJSAMObject_Destination, systemJSAMObject_Destination_Related);
                        }
                    }
                }
            }

            foreach(KeyValuePair<Guid, ISystemJSAMObject> keyValuePair in result)
            {
                ISystemJSAMObject systemJSAMObject_Destination = keyValuePair.Value;

                if (systemJSAMObject_Destination is SystemConnection)
                {
                    SystemConnection systemConnection_Destination = (SystemConnection)systemJSAMObject_Destination;
                    List<ObjectReference> objectReferences_Source = systemConnection_Destination.ObjectReferences;
                    if (objectReferences_Source != null)
                    {
                        foreach (ObjectReference objectReference_Source in objectReferences_Source)
                        {
                            Guid guid_Temp = GetGuid(GetObject(objectReference_Source));
                            if (result.TryGetValue(guid_Temp, out ISystemJSAMObject systemJSAMObject_Destination_ObjectReference) && systemJSAMObject_Destination_ObjectReference is SAMObject)
                            {
                                ObjectReference objectReferences_Destionation = new ObjectReference((SAMObject)systemJSAMObject_Destination_ObjectReference);
                                systemConnection_Destination.Reassign(objectReference_Source, objectReferences_Destionation);
                            }
                        }

                        AddObject(systemConnection_Destination);
                    }
                }

                if (systemJSAMObject_Destination is ISystemSensorController)
                {
                    Guid guid = Guid.Empty;
                    ISystemJSAMObject systemJSAMObject = null;

                    ISystemSensorController systemSensorController = (ISystemSensorController)systemJSAMObject_Destination;
                    if (Guid.TryParse(systemSensorController.SensorReference, out guid) && result.TryGetValue(guid, out systemJSAMObject) && systemJSAMObject != null)
                    {
                        guid = GetGuid(systemJSAMObject);
                        systemSensorController.SensorReference = guid.ToString();
                    }

                    if (systemJSAMObject_Destination is ISystemDifferenceController)
                    {
                        ISystemDifferenceController systemDifferenceController = (ISystemDifferenceController)systemJSAMObject_Destination;
                        if (Guid.TryParse(systemDifferenceController.SecondarySensorReference, out guid) && result.TryGetValue(guid, out systemJSAMObject) && systemJSAMObject != null)
                        {
                            guid = GetGuid(systemJSAMObject);
                            systemDifferenceController.SecondarySensorReference = guid.ToString();
                        }
                    }
                }

                ISystemJSAMObject systemJSAMObject_Source = GetObject(systemJSAMObject_Destination.GetType(), keyValuePair.Key);
                if (systemJSAMObject_Source == null)
                {
                    continue;
                }

                List<ISystemJSAMObject> systemJSAMObjects_Source_Related = GetRelatedObjects(systemJSAMObject_Source);
                if(systemJSAMObjects_Source_Related != null)
                {
                    foreach(ISystemJSAMObject systemJSAMObject_Source_Related in systemJSAMObjects_Source_Related)
                    {
                        if(result.TryGetValue(GetGuid(systemJSAMObject_Source_Related), out ISystemJSAMObject systemJSAMObject))
                        {
                            AddRelation(systemJSAMObject_Destination, systemJSAMObject);
                        }
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
                Dictionary<Guid, ISystemJSAMObject> dictionary = new Dictionary<Guid, ISystemJSAMObject>();

                for (int i = 0; i < systemJSAMObjects.Count; i++)
                {
                    ISystemJSAMObject systemJSAMObject = systemJSAMObjects[i];
                    Guid guid = GetGuid(systemJSAMObject);

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

                foreach (KeyValuePair<Guid, ISystemJSAMObject> keyValuePair in dictionary)
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
                            Guid guid = GetGuid(systemJSAMObject_Source_Related);
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
                                Guid guid = GetGuid(GetObject(objectReference_Source));
                                if (dictionary.TryGetValue(guid, out ISystemJSAMObject systemJSAMObject_Destination_ObjectReference) && systemJSAMObject_Destination_ObjectReference is SAMObject)
                                {
                                    ObjectReference objectReferences_Destionation = new ObjectReference((SAMObject)systemJSAMObject_Destination_ObjectReference);
                                    systemConnection_Destination.Reassign(objectReference_Source, objectReferences_Destionation);
                                }
                            }

                            result.AddObject(systemConnection_Destination);
                        }
                    }

                    if(systemJSAMObject_Destination is ISystemSensorController)
                    {
                        Guid guid = Guid.Empty;
                        ISystemJSAMObject systemJSAMObject = null;

                        ISystemSensorController systemSensorController = (ISystemSensorController)systemJSAMObject_Destination;
                        if(Guid.TryParse(systemSensorController.SensorReference, out guid) && dictionary.TryGetValue(guid, out systemJSAMObject) && systemJSAMObject != null)
                        {
                            guid = result.GetGuid(systemJSAMObject);
                            systemSensorController.SensorReference = guid.ToString();
                        }

                        if (systemJSAMObject_Destination is ISystemDifferenceController)
                        {
                            ISystemDifferenceController systemDifferenceController = (ISystemDifferenceController)systemJSAMObject_Destination;
                            if (Guid.TryParse(systemDifferenceController.SecondarySensorReference, out guid) && dictionary.TryGetValue(guid, out systemJSAMObject) && systemJSAMObject != null)
                            {
                                guid = result.GetGuid(systemJSAMObject);
                                systemDifferenceController.SecondarySensorReference = guid.ToString();
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
