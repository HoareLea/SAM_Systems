﻿using Newtonsoft.Json.Linq;
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

            return new SystemConnection(new SystemType(system), systemComponent_1, index_1, systemComponent_2, index_2);
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

        public bool Add(ISystemGroup systemGroup)
        {
            ISystemGroup systemGroup_Temp = systemGroup?.Clone();
            if (systemGroup_Temp == null)
            {
                return false;
            }

            if (systemRelationCluster == null)
            {
                systemRelationCluster = new SystemRelationCluster();
            }

            return systemRelationCluster.AddObject(systemGroup_Temp);
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

        public bool Connect(ISystemComponent systemComponent_1, ISystemComponent systemComponent_2, out ISystemConnection systemConnection, ISystem system = null, int index_1 = -1, int index_2 = -1)
        {
            systemConnection = null;

            if (systemComponent_1 == null || systemComponent_2 == null)
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

            systemConnection = CreateSystemConnection(systemComponent_1, systemComponent_2, system, index_1, index_2);
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

        public bool Connect(ISystemConnection systemConnection, ISystem system = null)
        {
            List<ISystemComponent> systemComponents = Query.SystemComponents<ISystemComponent>(this, systemConnection);
            if (systemComponents == null || systemComponents.Count == 0)
            {
                return false;
            }

            if(system != null && systemConnection.SystemType != new SystemType(system))
            {
                return false;
            }

            ISystemConnection systemConnection_Temp = systemConnection.Clone();
            if(systemConnection_Temp == null)
            {
                return false;
            }

            systemRelationCluster.AddObject(systemConnection_Temp);
            if(system != null)
            {
                systemRelationCluster.AddRelation(systemConnection_Temp, system);
            }


            if (systemComponents.Count == 1)
            {
                systemRelationCluster.AddRelation(systemConnection_Temp, systemComponents[0]);

                if (system != null)
                {
                    systemRelationCluster.AddRelation(systemComponents[0], system);
                }

                return true;
            }

            foreach(ISystemComponent systemComponent in systemComponents)
            {
                systemRelationCluster.AddRelation(systemConnection_Temp, systemComponent);
                if (system != null)
                {
                    systemRelationCluster.AddRelation(systemComponent, system);
                }
            }

            for (int i = 0; i < systemComponents.Count - 1; i++)
            {
                ISystemComponent systemComponent_1 = systemComponents[i];

                for (int j = i + 1; j < systemComponents.Count; j++)
                {
                    ISystemComponent systemComponent_2 = systemComponents[j];

                    systemRelationCluster.AddRelation(systemComponent_1, systemComponent_2);
                }
            }

            return true;
        }

        public bool Connect(ISystemConnection systemConnection, ISystemComponent systemComponent)
        {
            if (systemConnection == null || systemComponent == null)
            {
                return false;
            }

            if(!systemConnection.TryGetIndex(systemComponent, out int index) || index == -1)
            {
                return false;
            }

            if (!systemRelationCluster.Contains(systemComponent))
            {
                Add(systemComponent);
            }

            if (!systemRelationCluster.Contains(systemConnection))
            {
                Add(systemConnection);
            }

            return systemRelationCluster.AddRelation(systemComponent, systemConnection);
        }

        public bool Connect(ISystemComponent systemComponent_1, ISystemComponent systemComponent_2)
        {
            if (systemComponent_1 == null || systemComponent_2 == null)
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

            return systemRelationCluster.AddRelation(systemComponent_1, systemComponent_2);
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

        public List<T> GetSystems<T>(ISystemComponent systemComponent) where T : ISystem
        {
            return GetRelatedObjects<T>(systemComponent)?.ConvertAll(x => x.Clone());
        }

        public List<T> GetSystems<T>(ISystemGroup systemGroup) where T : ISystem
        {
            return GetRelatedObjects<T>(systemGroup)?.ConvertAll(x => x.Clone());
        }

        public List<ISystemGroup> GetSystemGroups()
        {
            return GetSystemGroups<ISystemGroup>();
        }

        public List<T> GetSystemGroups<T>() where T : ISystemGroup
        {
            return systemRelationCluster?.GetObjects<T>()?.ConvertAll(x => Core.Query.Clone(x)).ConvertAll(x => (T)(object)x);
        }

        public List<T> GetSystemComponents<T>() where T : ISystemComponent
        {
            return systemRelationCluster?.GetObjects<T>()?.ConvertAll(x => Core.Query.Clone(x)).ConvertAll(x => (T)(object)x);
        }

        public List<T> GetSystemComponents<T>(ISystemGroup systemGroup) where T : ISystemComponent
        {
            if (systemGroup == null)
            {
                return default;
            }

            List<T> ts = systemRelationCluster.GetRelatedObjects<T>(systemGroup);
            if (ts == null || ts.Count == 0)
            {
                return default;
            }

            return ts.ConvertAll(x => Core.Query.Clone(x));
        }

        public List<T> GetSystemComponents<T>(ISystem system) where T : ISystemComponent
        {
            if (system == null)
            {
                return default;
            }

            List<T> ts = systemRelationCluster.GetRelatedObjects<T>(system);
            if (ts == null || ts.Count == 0)
            {
                return default;
            }

            return ts.ConvertAll(x => Core.Query.Clone(x));
        }

        public List<T> GetSystemComponents<T>(ISystem system, ConnectorStatus connectorStatus, Direction? direction) where T : ISystemComponent
        {
            List<T> ts = systemRelationCluster.GetRelatedObjects<T>(system);
            if (ts == null || ts.Count == 0)
            {
                return default;
            }

            List<T> result = new List<T>();
            foreach(T t in ts)
            {
                List<SystemConnector> systemConnectors = t.GetSystemConnectors(this, connectorStatus)?.FindAll(x => x.SystemType == new SystemType(system));
                if(systemConnectors == null || systemConnectors.Count == 0)
                {
                    continue;
                }

                if(direction != null && direction.HasValue)
                {
                    systemConnectors.RemoveAll(x => x.Direction != direction.Value);
                }

                if(systemConnectors != null && systemConnectors.Count != 0)
                {
                    result.Add(t);
                }
            }

            return result;
        }

        public List<T> GetNextSystemComponents<T>(ISystemComponent systemComponent, ISystem system, Direction direction) where T : ISystemComponent
        {
            if(systemComponent == null || system == null || direction == Direction.Undefined)
            {
                return null;
            }

            Guid guid = systemRelationCluster.GetGuid(systemComponent);
            if (guid == Guid.Empty)
            {
                return null;
            }

            List<SystemConnector> systemConnectors = systemComponent.GetSystemConnectors(this, ConnectorStatus.Connected)?.FindAll(x => x.SystemType == new SystemType(system));
            if (systemConnectors == null || systemConnectors.Count == 0)
            {
                return null;
            }

            List<T> result = new List<T>();
            foreach(SystemConnector systemConnector in systemConnectors)
            {
                if(systemConnector.Direction != direction)
                {
                    continue;
                }
                
                List<ISystemConnection> systemConnections = systemComponent.GetSystemConnections(this, systemConnector);
                if(systemConnections == null || systemConnections.Count == 0)
                {
                    continue;
                }

                foreach (ISystemConnection systemConnection in systemConnections)
                {
                    List<T> ts = systemRelationCluster.GetRelatedObjects<T>(systemConnection);
                    if(ts != null && ts.Count != 0)
                    {
                        foreach(T t in ts)
                        {
                            Guid guid_Temp = systemRelationCluster.GetGuid(t);

                            if (guid_Temp != guid  && result.Find(x => systemRelationCluster.GetGuid(x) == guid_Temp) == null)
                            {
                                result.Add(t);
                            }
                        }
                    }

                }
            }

            return result;
        }

        private bool TryGetConnectionIndexes(ISystemComponent systemComponent, ISystem system, Direction direction, ConnectorStatus connectorStatus, out List<int> connectionIndexes)
        {
            connectionIndexes = null;
            List<SystemConnector> systemConnectors = systemComponent?.GetSystemConnectors(this, connectorStatus)?.FindAll(x => x.SystemType == new SystemType(system));
            if (systemConnectors == null || systemConnectors.Count == 0)
            {
                return false;
            }

            connectionIndexes = new List<int>();
            foreach (SystemConnector systemConnector in systemConnectors)
            {
                if (systemConnector.Direction != direction)
                {
                    continue;
                }

                int connectionIndex = systemConnector.ConnectionIndex;
                if(connectionIndex != -1)
                {
                    connectionIndexes.Add(connectionIndex);
                }
            }

            return connectionIndexes != null && connectionIndexes.Count != 0;
        }

        private bool TryGetConnectionIndex(ISystemComponent systemComponent_1, ISystemComponent systemComponent_2, ISystem system, int connectionIndex_1, out int connectionIndex_2)
        {
            connectionIndex_2 = -1;
            List<SystemConnector> systemConnectors_1 = systemComponent_1?.GetSystemConnectors(this, ConnectorStatus.Connected)?.FindAll(x => x.SystemType == new SystemType(system));
            if (systemConnectors_1 == null || systemConnectors_1.Count == 0)
            {
                return false;
            }

            foreach(SystemConnector systemConnector_1 in systemConnectors_1)
            {
                if(systemConnector_1.ConnectionIndex != connectionIndex_1)
                {
                    continue;
                }

                List<ISystemConnection> systemConnections = systemComponent_1.GetSystemConnections(this, systemConnector_1);
                if(systemConnections == null || systemConnections.Count == 0)
                {
                    continue;
                }

                foreach(ISystemConnection systemConnection in systemConnections)
                {
                    if(!systemConnection.TryGetIndex(systemComponent_2, out int index) || index == -1)
                    {
                        continue;
                    }

                    if (!systemComponent_2.SystemConnectorManager.TryGetSystemConnector(index, out SystemConnector systemConnector_2) || systemConnector_2 == null)
                    {
                        continue;
                    }

                    connectionIndex_2 = systemConnector_2.ConnectionIndex;
                    return true;
                }

            }

            return false;
        }

        private bool TryGetSystemComponent(ISystemComponent systemComponent, IEnumerable<ISystemComponent> systemComponents, ISystem system, Direction direction, int connectionIndex, out ISystemComponent systemComponent_Out)
        {
            systemComponent_Out = null;

            if(systemComponents == null || systemComponent == null)
            {
                return false;
            }

            List<SystemConnector> systemConnectors = systemComponent?.GetSystemConnectors(this, ConnectorStatus.Connected)?.FindAll(x => x.SystemType == new SystemType(system) && x.Direction == direction && x.ConnectionIndex == connectionIndex);
            if (systemConnectors == null || systemConnectors.Count == 0)
            {
                return false;
            }

            SystemConnector systemConnector = systemConnectors[0];

            List<ISystemConnection> systemConnections = systemComponent.GetSystemConnections(this, systemConnector);
            if (systemConnections == null || systemConnections.Count == 0)
            {
                return false;
            }

            List<Guid> guids = systemComponents.ToList().ConvertAll(x => systemRelationCluster.GetGuid(x));

            foreach(ISystemConnection systemConnection in systemConnections)
            {
                List<ISystemComponent> systemComponents_Related = systemRelationCluster.GetRelatedObjects<ISystemComponent>(systemConnection);
                if(systemComponents_Related == null || systemComponents_Related.Count == 0)
                {
                    continue;
                }

                List<Guid> guids_Temp = systemComponents_Related.ToList().ConvertAll(x => systemRelationCluster.GetGuid(x));

                int index = guids.FindIndex(x => guids_Temp.Contains(x));
                if(index != -1)
                {
                    systemComponent_Out = systemComponents.ElementAt(index);
                    return true;
                }

            }

            return false;
        }

        public List<ISystemComponent> GetOrderedSystemComponents(ISystemComponent systemComponent, ISystem system, Direction direction, int connectionIndex = -1)
        {
            if (systemComponent == null || system == null || direction == Direction.Undefined)
            {
                return null;
            }

            List<ISystemComponent> result = new List<ISystemComponent>();

            HashSet<Guid> guids = new HashSet<Guid>();

            ISystemComponent systemComponent_Temp = systemComponent;
            if(systemComponent_Temp is ISystemGroup)
            {
                List<ISystemComponent> systemComponents_Related = GetRelatedObjects<ISystemComponent>(systemComponent_Temp);
                if(systemComponents_Related == null || systemComponents_Related.Count == 0)
                {
                    return null;
                }

                foreach(ISystemComponent systemComponent_Related in systemComponents_Related)
                {
                    guids.Add(systemRelationCluster.GetGuid(systemComponent_Related));
                }

                systemComponent_Temp = systemComponents_Related[0];
            }

            if(connectionIndex == -1)
            {
                if(TryGetConnectionIndexes(systemComponent_Temp, system, direction, ConnectorStatus.Connected, out List<int> connectionIndexes) && connectionIndexes != null && connectionIndexes.Count != 0)
                {
                    connectionIndex = connectionIndexes[0];
                }
            }

            do
            {
                List<ISystemComponent> systemComponents_Next = GetNextSystemComponents<ISystemComponent>(systemComponent_Temp, system, direction);
                systemComponents_Next?.RemoveAll(x => result.Find(y => systemRelationCluster.GetGuid(x) == systemRelationCluster.GetGuid(y)) != null);
                if (systemComponents_Next == null || systemComponents_Next.Count == 0)
                {
                    break;
                }

                ISystemComponent systemComponent_Next = null;

                if(connectionIndex != -1)
                {
                    TryGetSystemComponent(systemComponent_Temp, systemComponents_Next, system, direction, connectionIndex, out systemComponent_Next);
                }

                if(systemComponent_Next == null)
                {
                    systemComponent_Next = systemComponents_Next.FirstOrDefault();
                }

                if(systemComponent_Next == null)
                {
                    break;
                }


                if (connectionIndex != -1 && TryGetConnectionIndex(systemComponent_Temp, systemComponent_Next, system, connectionIndex, out int connectionIndex_Next))
                {
                    connectionIndex = connectionIndex_Next;
                }
                else
                {
                    connectionIndex = -1;
                }

                systemComponent_Temp = systemComponent_Next;

                Guid guid = systemRelationCluster.GetGuid(systemComponent_Temp);

                if (!guids.Contains(guid))
                {
                    result.Add(systemComponent_Temp);
                }
            }
            while (systemComponent_Temp != null);

            return result;
        }

        public T GetSystemComponent<T>(ObjectReference objectReference) where T : ISystemComponent
        {
            if (objectReference == null || !objectReference.IsValid())
            {
                return default;
            }

            List<T> ts = systemRelationCluster.GetObjects<T>(objectReference);
            if(ts == null || ts.Count == 0)
            {
                return default;
            }

            return Core.Query.Clone(ts[0]);
        }

        public T GetSystemComponent<T>(Func<T, bool> func) where T : ISystemComponent
        {
            List<T> objects = systemRelationCluster?.GetObjects<T>();
            if(objects == null || objects.Count == 0)
            {
                return default;
            }

            if(func == null)
            {
                return Core.Query.Clone(objects[0]);
            }

            for (int i = 0; i < objects.Count; i++)
            {
                if (func.Invoke(objects[i]))
                {
                    return Core.Query.Clone(objects[i]);
                }
            }

            return default;
        }

        public T GetSystem<T>(Func<T, bool> func) where T : ISystem
        {
            List<T> objects = systemRelationCluster?.GetObjects<T>();
            if (objects == null || objects.Count == 0)
            {
                return default;
            }

            if (func == null)
            {
                return Core.Query.Clone(objects[0]);
            }

            for (int i = 0; i < objects.Count; i++)
            {
                if (func.Invoke(objects[i]))
                {
                    return Core.Query.Clone(objects[i]);
                }
            }

            return default;
        }

        public List<T> GetSystemJSAMObjects<T>() where T : ISystemJSAMObject
        {
            return systemRelationCluster?.GetObjects<T>()?.ConvertAll(x => Core.Query.Clone(x)).ConvertAll(x => (T)(object)x);
        }

        public List<ISystemJSAMObject> GetSystemJSAMObjects()
        {
            return GetSystemJSAMObjects<ISystemJSAMObject>();
        }

        public List<ISystemComponent> GetSystemComponents()
        {
            return GetSystemComponents<ISystemComponent>();
        }

        public List<ISystemConnection> GetSystemConnections()
        {
            return systemRelationCluster?.GetObjects<ISystemConnection>()?.ConvertAll(x => Core.Query.Clone(x)).ConvertAll(x => (ISystemConnection)(object)x);
        }

        public List<ISystemConnection> GetSystemConnections(ISystemComponent systemComponent_1, ISystemComponent systemComponent_2, SystemType systemType = null)
        {
            if(systemComponent_1 == null || systemComponent_2 == null)
            {
                return null;
            }

            List<ISystemConnection> systemConnections = GetRelatedObjects<ISystemConnection>(systemComponent_1);
            if(systemConnections == null || systemConnections.Count == 0)
            {
                return null;
            }

            Guid guid = systemRelationCluster.GetGuid(systemComponent_2);
            if(guid == Guid.Empty)
            {
                return null;
            }

            List<ISystemConnection> result = new List<ISystemConnection>();
            foreach (ISystemConnection systemConnection in systemConnections)
            {
                if(systemType != null && systemConnection.SystemType != systemType)
                {
                    continue;
                }

                List<ISystemComponent> systemComponents = GetRelatedObjects<ISystemComponent>(systemConnection);
                if(systemComponents == null || systemComponents.Count == 0)
                {
                    continue;
                }

                foreach(ISystemComponent systemComponent in systemComponents)
                {
                    Guid guid_Temp = systemRelationCluster.GetGuid(systemComponent);
                    if(guid_Temp == guid)
                    {
                        result.Add(systemConnection);
                        break;
                    }
                }
            }

            return result;
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
            List<T> ts = systemRelationCluster.GetObjects(func);
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
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("SystemRelationCluster"))
            {
                systemRelationCluster = Core.Query.IJSAMObject<SystemRelationCluster>(jObject.Value<JObject>("SystemRelationCluster"));
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result =  base.ToJObject();
            if(result == null)
            {
                return result;
            }

            if(systemRelationCluster != null)
            {
                result.Add("SystemRelationCluster", systemRelationCluster.ToJObject());
            }

            return result;
        }

        public Guid GetGuid(ISystemJSAMObject systemJSAMObject)
        {
            if(systemJSAMObject == null || systemRelationCluster == null)
            {
                return Guid.Empty;
            }

            return systemRelationCluster.GetGuid(systemJSAMObject);
        }

        public T GetSystemObject<T>(ObjectReference objectReference) where T: ISystemJSAMObject
        {
            if(objectReference == null || systemRelationCluster == null)
            {
                return default;
            }

            List<T> systemObjects = systemRelationCluster.GetObjects<T>(objectReference);
            if(systemObjects == null || systemObjects.Count == 0)
            {
                return default;
            }

            return systemObjects.FirstOrDefault();
        }

    }
}
