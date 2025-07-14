using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Systems
{
    public class SystemEnergyCentre : SystemEnergyCentre<SystemPlantRoom>
    {
        public SystemEnergyCentre(string name)
            : base(name)
        {

        }

        public SystemEnergyCentre(JObject jObject)
            : base(jObject)
        {

        }

        public SystemEnergyCentre(SystemEnergyCentre systemEnergyCentre)
            : base(systemEnergyCentre)
        {

        }

        public SystemEnergyCentre(Guid guid, SystemEnergyCentre systemEnergyCentre)
            : base(guid, systemEnergyCentre)
        {

        }

        public SystemEnergyCentre Duplicate(Guid? guid = null)
        {
            SystemEnergyCentre result = new SystemEnergyCentre(guid == null ? Guid.NewGuid() : guid.Value, this);

            List<SystemPlantRoom> systemPlantRooms = result.GetSystemPlantRooms();
            if(systemPlantRooms != null)
            {
                foreach(SystemPlantRoom systemPlantRoom in systemPlantRooms)
                {
                    Remove(systemPlantRoom);
                    Add(systemPlantRoom.Duplicate());
                }
            }

            List<SystemEnergySource> systemEnergySources = result.GetSystemEnergySources();
            if (systemEnergySources != null)
            {
                foreach (SystemEnergySource systemEnergySource in systemEnergySources)
                {
                    Remove(systemEnergySource);
                    Add((SystemEnergySource)systemEnergySource.Duplicate());
                }
            }

            return result;
        }
    }

    public class SystemEnergyCentre<T> : SAMModel, ISystemJSAMObject where T : SystemPlantRoom
    {
        private Dictionary<Guid, SystemEnergySource> systemEnergySources = new Dictionary<Guid, SystemEnergySource>();

        private Dictionary<Guid, T> systemPlantRooms = new Dictionary<Guid, T>();

        public new string Name
        {
            get
            {
                return base.Name;
            }

            set
            {
                name = value;
            }
        }

        public SystemEnergyCentre(string name)
            : base(name)
        {

        }

        public SystemEnergyCentre(JObject jObject)
            : base(jObject)
        {

        }

        public SystemEnergyCentre(SystemEnergyCentre<T> systemEnergyCentre)
            : base(systemEnergyCentre)
        {
            if(systemEnergyCentre != null)
            {
                Dictionary<Guid, T> systemPlantRooms_Temp = systemEnergyCentre.systemPlantRooms;
                if(systemPlantRooms_Temp != null)
                {
                    foreach(T systemPlantRoom in systemPlantRooms_Temp.Values)
                    {
                        Add(systemPlantRoom);
                    }
                }

                Dictionary<Guid, SystemEnergySource> systemEnergySources_Temp = systemEnergyCentre.systemEnergySources;
                if (systemEnergySources_Temp != null)
                {
                    foreach (SystemEnergySource systemEnergySource in systemEnergySources_Temp.Values)
                    {
                        Add(systemEnergySource);
                    }
                }
            }
        }

        public SystemEnergyCentre(Guid guid, SystemEnergyCentre<T> systemEnergyCentre)
            : base(guid, systemEnergyCentre)
        {
            if (systemEnergyCentre != null)
            {
                Dictionary<Guid, T> systemPlantRooms_Temp = systemEnergyCentre.systemPlantRooms;
                if (systemPlantRooms_Temp != null)
                {
                    foreach (T systemPlantRoom in systemPlantRooms_Temp.Values)
                    {
                        Add(systemPlantRoom);
                    }
                }

                Dictionary<Guid, SystemEnergySource> systemEnergySources_Temp = systemEnergyCentre.systemEnergySources;
                if (systemEnergySources_Temp != null)
                {
                    foreach (SystemEnergySource systemEnergySource in systemEnergySources_Temp.Values)
                    {
                        Add(systemEnergySource);
                    }
                }
            }
        }

        public List<T> GetSystemPlantRooms()
        {
            return systemPlantRooms?.Values.ToList().ConvertAll(x => x?.Clone());
        }

        public List<SystemEnergySource> GetSystemEnergySources()
        {
            return systemEnergySources?.Values.ToList().ConvertAll(x => x?.Clone());
        }

        public SystemEnergySource GetSystemEnergySource(string name)
        {
            if(systemEnergySources == null || name == null)
            {
                return null;
            }

            foreach(SystemEnergySource systemEnergySource in systemEnergySources.Values)
            {
                if(systemEnergySource?.Name == name)
                {
                    return systemEnergySource.Clone();
                }
            }

            return null;
        }

        public bool TryGetSystem<USystem>(Guid guid, out T systemPlantRoom, out USystem system) where USystem : ISystem
        {
            systemPlantRoom = default;
            system = default;

            foreach(T systemPlantRoom_Temp in systemPlantRooms.Values)
            {
                system = systemPlantRoom_Temp.GetSystem<USystem>(x => x.Guid == guid);
                if(system != null)
                {
                    systemPlantRoom = systemPlantRoom_Temp.Clone();
                    system = system.Clone();
                    return true;
                }
            }

            return false;
        }

        public bool Add(T systemPlantRoom)
        {
            T systemPlantRoom_Temp = systemPlantRoom?.Clone();
            if (systemPlantRoom_Temp == null)
            {
                return false;
            }

            systemPlantRooms[systemPlantRoom_Temp.Guid] = systemPlantRoom_Temp;
            return true;
        }

        public bool Add(SystemEnergySource systemEnergySource)
        {
            SystemEnergySource systemEnergySource_Temp = systemEnergySource?.Clone();
            if (systemEnergySource_Temp == null)
            {
                return false;
            }

            systemEnergySources[systemEnergySource_Temp.Guid] = systemEnergySource_Temp;
            return true;
        }

        public bool Remove(T systemPlantRoom)
        {
            if (systemPlantRoom == null || systemPlantRooms == null || systemPlantRooms.Count == 0)
            {
                return false;
            }

            return systemPlantRooms.Remove(systemPlantRoom.Guid);
        }

        public bool Remove(SystemEnergySource systemEnergySource)
        {
            if (systemEnergySource == null || systemEnergySources == null)
            {
                return false;
            }

            bool result = systemEnergySources.Remove(systemEnergySource.Guid);
            if(result)
            {
                foreach(T systemPlantRoom in systemPlantRooms.Values)
                {
                    systemPlantRoom.Remove(systemEnergySource);
                }
            }

            return result;
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("SystemEnergySources"))
            {
                JArray jArray = jObject.Value<JArray>("SystemEnergySources");
                if (jArray != null)
                {
                    systemEnergySources = new Dictionary<Guid, SystemEnergySource>();
                    foreach (JObject jObject_Temp in jArray)
                    {
                        SystemEnergySource systemEnergySource = Core.Query.IJSAMObject<SystemEnergySource>(jObject_Temp);
                        if (systemEnergySource == null)
                        {
                            continue;
                        }

                        systemEnergySources[systemEnergySource.Guid] = systemEnergySource;
                    }
                }
            }

            if (jObject.ContainsKey("SystemPlantRooms"))
            {
                JArray jArray = jObject.Value<JArray>("SystemPlantRooms");
                if (jArray != null)
                {
                    systemPlantRooms = new Dictionary<Guid, T>();
                    foreach (JObject jObject_Temp in jArray)
                    {
                        T systemPlantRoom = Core.Query.IJSAMObject<T>(jObject_Temp);
                        if (systemPlantRoom == null)
                        {
                            continue;
                        }

                        systemPlantRooms[systemPlantRoom.Guid] = systemPlantRoom;
                    }
                }
            }

            return result;
        }

        public T GetSystemPlantRoom(ObjectReference objectReference)
        {
            if (objectReference == null || systemPlantRooms == null)
            {
                return null;
            }

            IEnumerable<T> systemPlantRooms_Temp = systemPlantRooms.Values;
            for (int i = 0; i < systemPlantRooms.Count; i++)
            {
                T systemPlantRoom = systemPlantRooms_Temp.ElementAt(i);
                if (systemPlantRoom == null)
                {
                    continue;
                }

                ObjectReference objectReference_Temp = new ObjectReference(systemPlantRoom);

                if (objectReference_Temp == objectReference)
                {
                    return systemPlantRoom.Clone();
                }
            }

            return null;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return result;
            }

            if (systemPlantRooms != null)
            {
                JArray jArray = new JArray();
                foreach (T systemPlantRoom in systemPlantRooms.Values)
                {
                    jArray.Add(systemPlantRoom.ToJObject());
                }

                result.Add("SystemPlantRooms", jArray);
            }

            if (systemEnergySources != null)
            {
                JArray jArray = new JArray();
                foreach (SystemEnergySource systemEnergySource in systemEnergySources.Values)
                {
                    jArray.Add(systemEnergySource.ToJObject());
                }

                result.Add("SystemEnergySources", jArray);
            }

            return result;
        }

    }
}
