using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Systems
{
    public class SystemPlantRoom : SAMObject, ISystemSpatialObject
    {
        private SystemRelationCluster systemRelationCluster;

        public SystemPlantRoom(SystemPlantRoom systemPlantRoom)
            :base(systemPlantRoom)
        {
            if(systemPlantRoom != null)
            {
                systemRelationCluster = systemPlantRoom?.systemRelationCluster == null ? null : new SystemRelationCluster(systemPlantRoom.systemRelationCluster, true);
            }
        }

        public SystemPlantRoom(JObject jObject)
            : base(jObject)
        {

        }

        public SystemPlantRoom(string name)
            : base(name)
        {

        }

        protected virtual ISystemConnection CreateSystemConnection(ISystemComponent systemComponent_1, ISystemComponent systemComponent_2, ISystem system = null, int index_1 = -1, int index_2 = -1)
        {
            if (systemComponent_1 == null || systemComponent_2 == null)
            {
                return null;
            }

            if (system == null)
            {
                return new SystemConnection(systemComponent_1, systemComponent_2);
            }

            if (!Query.TryGetIndexes(this, system, systemComponent_1, systemComponent_2, index_1, index_2, out int index_1_out, out int index_2_out) || index_1_out == -1 || index_2_out == -1)
            {
                return null;
            }

            return new SystemConnection(system, systemComponent_1, index_1, systemComponent_2, index_2);
        }

        public bool Add(ISystemSpace systemSpace)
        {
            ISystemSpace systemSpace_Temp = systemSpace?.Clone();
            if (systemSpace_Temp == null)
            {
                return false;
            }

            if (systemRelationCluster == null)
            {
                systemRelationCluster = new SystemRelationCluster();
            }

            return systemRelationCluster.AddObject(systemSpace_Temp);
        }

        public bool Add(ISystemComponent systemComponent)
        {
            ISystemComponent systemComponent_Temp = systemComponent?.Clone();
            if (systemComponent_Temp == null)
            {
                return false;
            }

            if (systemRelationCluster == null)
            {
                systemRelationCluster = new SystemRelationCluster();
            }

            return systemRelationCluster.AddObject(systemComponent_Temp);
        }

        public bool Add(ISystem system)
        {
            ISystem system_Temp = system?.Clone();
            if (system_Temp == null)
            {
                return false;
            }

            if (systemRelationCluster == null)
            {
                systemRelationCluster = new SystemRelationCluster();
            }

            return systemRelationCluster.AddObject(system_Temp);
        }

        public bool Add(ISystemResult systemResult)
        {
            ISystemResult systemResult_Temp = systemResult?.Clone();
            if (systemResult_Temp == null)
            {
                return false;
            }

            if (systemRelationCluster == null)
            {
                systemRelationCluster = new SystemRelationCluster();
            }

            return systemRelationCluster.AddObject(systemResult_Temp);
        }

        private bool Add(ISystemConnection systemConnection)
        {
            ISystemConnection systemConnection_Temp = systemConnection?.Clone();
            if (systemConnection_Temp == null)
            {
                return false;
            }

            if (systemRelationCluster == null)
            {
                systemRelationCluster = new SystemRelationCluster();
            }

            return systemRelationCluster.AddObject(systemConnection_Temp);
        }

        public bool Connect(ISystemSpaceComponent systemSpaceComponent, ISystemSpace systemSpace)
        {
            if(systemSpaceComponent == null || systemSpace == null)
            {
                return false;
            }

            if (!systemRelationCluster.Contains(systemSpace))
            {
                Add(systemSpace);
            }

            if (!systemRelationCluster.Contains(systemSpaceComponent))
            {
                Add(systemSpaceComponent);
            }

            List<ISystemSpace> systemSpaces = systemRelationCluster?.GetRelatedObjects<ISystemSpace>(systemSpaceComponent);
            if (systemSpaces != null && systemSpaces.Count != 0)
            {
                systemSpaces.ForEach(x => systemRelationCluster.RemoveRelation(x, systemSpaceComponent));
            }

            return systemRelationCluster.AddRelation(systemSpace, systemSpaceComponent);
        }

        public bool Connect(ISystemComponentResult systemComponentResult, ISystemComponent systemComponent)
        {
            if (systemComponentResult == null || systemComponent == null)
            {
                return false;
            }

            if (!systemRelationCluster.Contains(systemComponent))
            {
                Add(systemComponent);
            }

            if (!systemRelationCluster.Contains(systemComponentResult))
            {
                Add(systemComponentResult);
            }

            return systemRelationCluster.AddRelation(systemComponent, systemComponentResult);
        }

        public bool Connect(ISystemSpaceResult systemSpaceResult, ISystemSpace systemSpace)
        {
            if (systemSpaceResult == null || systemSpace == null)
            {
                return false;
            }

            if (!systemRelationCluster.Contains(systemSpace))
            {
                Add(systemSpace);
            }

            if (!systemRelationCluster.Contains(systemSpaceResult))
            {
                Add(systemSpaceResult);
            }

            return systemRelationCluster.AddRelation(systemSpace, systemSpaceResult);
        }

        public bool Connect(ISystem system, ISystemComponent systemComponent)
        {
            if (systemComponent == null || system == null)
            {
                return false;
            }

            if (!systemRelationCluster.Contains(system))
            {
                Add(system);
            }

            if (!systemRelationCluster.Contains(systemComponent))
            {
                Add(systemComponent);
            }

            return systemRelationCluster.AddRelation(system, systemComponent);
        }

        public bool Connect(ISystemComponent systemComponent_1, ISystemComponent systemComponent_2, ISystem system = null, int index_1 = -1, int index_2 = -1)
        {
            if(systemComponent_1 == null || systemComponent_2 == null)
            {
                return false;
            }

            if (!systemRelationCluster.Contains(systemComponent_1))
            {
                Add(systemComponent_1);
            }

            if (!systemRelationCluster.Contains(systemComponent_2))
            {
                Add(systemComponent_2);
            }

            if(system != null && !systemRelationCluster.Contains(system))
            {
                Add(system);
            }

            ISystemConnection systemConnection = CreateSystemConnection(systemComponent_1, systemComponent_2, system, index_1, index_2);
            if(systemConnection == null)
            {
                return false;
            }

            Add(systemConnection);

            systemRelationCluster.AddRelation(systemComponent_1, systemComponent_2);
            systemRelationCluster.AddRelation(systemComponent_1, systemConnection);
            systemRelationCluster.AddRelation(systemComponent_2, systemConnection);

            if(system != null)
            {
                systemRelationCluster.AddRelation(systemComponent_1, system);
                systemRelationCluster.AddRelation(systemComponent_2, system);
                systemRelationCluster.AddRelation(systemConnection, system);
            }

            return true;
        }

        public bool Connect(ISystemGroup systemGroup, ISystemComponent systemComponent)
        {
            if(systemGroup == null || systemComponent == null)
            {
                return false;
            }

            if(!systemGroup.IsValid(systemComponent))
            {
                return false;
            }

            if (!systemRelationCluster.Contains(systemGroup))
            {
                Add(systemGroup);
            }

            if (!systemRelationCluster.Contains(systemComponent))
            {
                Add(systemComponent);
            }

            return systemRelationCluster.AddRelation(systemGroup, systemComponent);
        }

        public bool Connect(ISystemControl systemControl, ISystemConnection systemConnection)
        {
            if (systemControl == null || systemConnection == null)
            {
                return false;
            }

            if (!systemRelationCluster.Contains(systemControl))
            {
                Add(systemControl);
            }

            if (!systemRelationCluster.Contains(systemConnection))
            {
                Add(systemConnection);
            }

            return systemRelationCluster.AddRelation(systemControl, systemConnection);
        }

        public List<bool> Connect(ISystemGroup systemGroup, IEnumerable<ISystemComponent> systemComponents)
        {
            if (systemGroup == null ||  systemComponents == null)
            {
                return null;
            }

            List<bool> result = new List<bool>();
            foreach(ISystemComponent systemComponent in systemComponents)
            {
                result.Add(Connect(systemGroup, systemComponent));
            }

            return result;
        }

        public List<bool> Connect(ISystem system, IEnumerable<ISystemComponent> systemComponents)
        {
            if(system == null || systemComponents == null)
            {
                return null;
            }

            List<bool> result = new List<bool>();
            foreach(ISystemComponent systemComponent in systemComponents)
            {
                result.Add(Connect(system, systemComponent));
            }

            return result;
        }

        public bool Disconnect(ISystemGroup systemGroup, ISystemComponent systemComponent)
        {
            if (systemGroup == null || systemComponent == null)
            {
                return false;
            }

            return systemRelationCluster.RemoveRelation(systemGroup, systemComponent);
        }
        
        public bool Disconnect(ISystemSpaceComponent systemSpaceComponent, ISystemSpace systemSpace)
        {
            if (systemSpaceComponent == null || systemSpace == null)
            {
                return false;
            }

            return systemRelationCluster.RemoveRelation(systemSpace, systemSpaceComponent);
        }

        public bool Disconnect(ISystemComponentResult systemComponentResult, ISystemComponent systemComponent)
        {
            if (systemComponentResult == null || systemComponent == null)
            {
                return false;
            }

            return systemRelationCluster.RemoveRelation(systemComponent, systemComponentResult);
        }

        public bool Disconnect(ISystemSpaceResult systemSpaceResult, ISystemSpace systemSpace)
        {
            if (systemSpaceResult == null || systemSpace == null)
            {
                return false;
            }

            return systemRelationCluster.RemoveRelation(systemSpace, systemSpaceResult);
        }

        public bool Disconnect(ISystem system, ISystemComponent systemComponent)
        {
            if (system == null || systemComponent == null)
            {
                return false;
            }

            List<ISystemConnection> systemConnections = systemRelationCluster.GetRelatedObjects<ISystemConnection>(LogicalOperator.And, system, systemComponent);
            if(systemConnections != null && systemConnections.Count != 0)
            {
                foreach(ISystemConnection systemConnection in systemConnections)
                {
                    Remove(systemConnection, true);
                }
            }


            return systemRelationCluster.RemoveRelation(system, systemComponent);
        }

        public bool Disconnect(ISystemComponent systemComponent, int index)
        {
            if(systemComponent == null || index == -1)
            {
                return false;
            }

            List<ISystemConnection> systemConnections = systemRelationCluster.GetRelatedObjects<ISystemConnection>(systemComponent);
            if (systemConnections == null || systemConnections.Count == 0)
            {
                return false;
            }

            ISystemConnection systemConnection = Query.SystemConnection(systemConnections, systemComponent, index);
            if(systemConnection == null)
            {
                return false;
            }

            return Remove(systemConnection, true);

        }

        public bool Remove(ISystemConnection systemConnection)
        {
            return Remove(systemConnection, true);
        }

        private bool Remove(ISystemConnection systemConnection, bool removeSystemRelations)
        {
            if(systemConnection == null || systemRelationCluster == null)
            {
                return false;
            }

            if(removeSystemRelations)
            {
                List<ISystem> systems = systemRelationCluster.GetRelatedObjects<ISystem>(systemConnection);
                if(systems != null && systems.Count != 0)
                {
                    List<Guid> guids = systems.ConvertAll(x => systemRelationCluster.GetGuid(x));

                    List<ISystemComponent> systemComponents = systemRelationCluster.GetRelatedObjects<ISystemComponent>(systemConnection);
                    if(systemComponents != null && systemComponents.Count != 0)
                    {
                        for(int i = 0; i < systemComponents.Count - 1; i++)
                        {
                            for (int j = 0; j < systemComponents.Count; j++)
                            {
                                List<ISystem> systems_SystemComponents = systemRelationCluster.GetRelatedObjects<ISystem>(LogicalOperator.And, systemComponents[i], systemComponents[j]);
                                if(systems_SystemComponents != null && systems_SystemComponents.Count != 0)
                                {
                                    List<Guid> guids_SystemComponents = systems.ConvertAll(x => systemRelationCluster.GetGuid(x));
                                    if(guids_SystemComponents.TrueForAll(x => guids.Contains(x)))
                                    {
                                        systemRelationCluster.RemoveRelation(systemComponents[i], systemComponents[j]);
                                    }
                                }
                            }
                        }
                    }
                }

            }

            return systemRelationCluster.RemoveObject(systemConnection);
        }

        public bool Remove(ISystemComponent systemComponent)
        {
            if(systemComponent == null)
            {
                return false;
            }

            List<ISystemConnection> systemConnections = systemRelationCluster.GetRelatedObjects<ISystemConnection>(systemComponent);
            if (systemConnections != null && systemConnections.Count != 0)
            {
                systemConnections.ForEach(x => Remove(x, false));
            }

            return systemRelationCluster.RemoveObject(systemComponent);
        }

        public bool Remove(ISystem system)
        {
            if(system == null)
            {
                return false;
            }

            List<ISystemConnection> systemConnections = systemRelationCluster.GetRelatedObjects<ISystemConnection>(system);
            if (systemConnections != null && systemConnections.Count != 0)
            {
                systemConnections.ForEach(x => Remove(x, true));
            }

            return systemRelationCluster.RemoveObject(system);
        }

        public bool Remove(ISystemGroup systemGroup)
        {
            if(systemGroup == null || systemRelationCluster == null)
            {
                return false;
            }

            return systemRelationCluster.RemoveObject(systemGroup);
        }

        public List<ISystemSpace> GetSystemSpaces()
        {
            return systemRelationCluster?.GetObjects<ISystemSpace>()?.ConvertAll(x => x.Clone());
        }

        public List<ISystem> GetSystems()
        {
            return GetSystems<ISystem>();
        }

        public List<T> GetSystems<T>() where T: ISystem
        {
            return systemRelationCluster?.GetObjects<T>()?.ConvertAll(x => x.Clone());
        }

        public List<T> GetSystemComponents<T>() where T : ISystemComponent
        {
            return systemRelationCluster?.GetObjects<T>()?.ConvertAll(x => Core.Query.Clone(x)).ConvertAll(x => (T)(object)x);
        }

        public List<ISystemComponent> GetSystemComponents()
        {
            return GetSystemComponents<ISystemComponent>();
        }

        public List<T> GetSystemSpaceComponents<T>(ISystemSpace systemSpace) where T : ISystemSpaceComponent
        {
            return systemRelationCluster?.GetRelatedObjects<T>(systemSpace)?.ConvertAll(x => x.Clone());
        }

        public T GetSystemSpace<T>(ISystemSpaceComponent systemSpaceComponent) where T: ISystemSpace
        {
            if(systemSpaceComponent == null)
            {
                return default;
            }

            List<T> systemSpaces = systemRelationCluster?.GetRelatedObjects<T>(systemSpaceComponent);
            if(systemSpaces == null || systemSpaces.Count == 0)
            {
                return default;
            }


            return systemSpaces[0];
        }

        public List<ISystemResult> GetSystemResults(ISystemJSAMObject systemJSAMObject)
        {
            return GetSystemResults<ISystemResult>(systemJSAMObject);
        }

        public List<T> GetSystemResults<T>(ISystemJSAMObject systemJSAMObject) where T : ISystemResult
        {
            if (systemRelationCluster == null || systemJSAMObject == null)
            {
                return null;
            }

            return systemRelationCluster.GetRelatedObjects<T>(systemJSAMObject)?.ConvertAll(x => Core.Query.Clone(x));
        }

        public List<T> GetSystemResults<T>() where T : ISystemResult
        {
            return systemRelationCluster?.GetObjects<T>()?.ConvertAll(x => Core.Query.Clone(x));
        }

        public List<ISystemResult> GetSystemResults()
        {
            return GetSystemResults<ISystemResult>();
        }

        public T Find<T>(Func<T, bool> func) where T : ISystemJSAMObject
        {
            if(systemRelationCluster == null)
            {
                return default;
            }

            List<T> objects = systemRelationCluster.GetObjects(func);
            if(objects == null || objects.Count == 0)
            {
                return default;
            }

            T t = objects.FirstOrDefault();
            if (t == null)
            {
                return t;
            }

            return t.Clone();
        }

        public List<T> FindAll<T>(Func<T, bool> func) where T : ISystemJSAMObject
        {
            List<T> ts = systemRelationCluster.GetObjects<T>(func);
            if (ts == null)
            {
                return ts;
            }

            return ts.ConvertAll(x => x.Clone());
        }

        public List<ISystemJSAMObject> GetRelatedObjects(ISystemJSAMObject systemJSAMObject, Type type = null)
        {
            if (systemJSAMObject == null)
            {
                return null;
            }

            List<ISystemJSAMObject> objects = type == null ? systemRelationCluster?.GetRelatedObjects(systemJSAMObject, typeof(ISystemJSAMObject)) : systemRelationCluster.GetRelatedObjects(systemJSAMObject, type);
            if (objects == null)
            {
                return null;
            }

            List<ISystemJSAMObject> result = new List<ISystemJSAMObject>();
            foreach (ISystemJSAMObject @object in objects)
            {
                ISystemJSAMObject systemObject_Temp = @object?.Clone() as ISystemJSAMObject;
                if (systemObject_Temp == null)
                {
                    continue;
                }

                result.Add(systemObject_Temp);
            }

            return result;
        }

        public List<T> GetRelatedObjects<T>(ISystemJSAMObject systemJSAMObject) where T : ISystemJSAMObject
        {
            if (systemJSAMObject == null)
            {
                return null;
            }

            List<ISystemJSAMObject> systemObjects = GetRelatedObjects(systemJSAMObject, typeof(T));
            if (systemObjects == null)
            {
                return null;
            }

            List<T> result = new List<T>();
            foreach (T systemObject_Temp in systemObjects)
            {
                result.Add(systemObject_Temp);
            }

            return result;
        }

        public List<T> GetRelatedObjects<T>(ISystemConnection systemConnection, ISystemComponent systemComponent) where T : ISystemComponent
        {
            if (systemConnection == null)
            {
                return null;
            }

            List<T> result = GetRelatedObjects<T>(systemConnection);
            if (result == null)
            {
                return null;
            }

            if (systemComponent == null)
            {
                return result;
            }

            Guid guid = systemRelationCluster.GetGuid(systemComponent);

            bool valid = false;
            for (int i = result.Count - 1; i >= 0; i++)
            {
                Guid guid_Temp = systemRelationCluster.GetGuid(result[i]);
                if (guid != guid_Temp)
                {
                    continue;
                }

                valid = true;
                result.RemoveAt(i);
            }

            if (!valid)
            {
                return null;
            }

            return result;
        }

        public override bool FromJObject(JObject jObject)
        {
            return base.FromJObject(jObject);
        }

        public override JObject ToJObject()
        {
            return base.ToJObject();
        }

        public Guid GetGuid(ISystemJSAMObject systemJSAMObject)
        {
            if(systemJSAMObject == null || systemRelationCluster == null)
            {
                return Guid.Empty;
            }

            return systemRelationCluster.GetGuid(systemJSAMObject);
        }

    }
}
