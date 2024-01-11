using Newtonsoft.Json.Linq;
using System.Collections.Generic;

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
    }

    public class SystemEnergyCentre<T> : SAMModel, ISystemObject where T : SystemPlantRoom
    {
        private List<T> systemPlantRooms;

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
            systemPlantRooms = systemEnergyCentre?.systemPlantRooms == null ? null : systemEnergyCentre.systemPlantRooms.ConvertAll(x => x.Clone());
        }

        public List<T> GetSystemPlantRooms()
        {
            return systemPlantRooms == null ? null : systemPlantRooms.ConvertAll(x => x.Clone());
        }

        public bool Add(T systemPlantRoom)
        {
            if (systemPlantRoom == null)
            {
                return false;
            }

            if (systemPlantRooms == null)
            {
                systemPlantRooms = new List<T>();
            }

            int index = systemPlantRooms.FindIndex(x => x.Guid == systemPlantRoom.Guid);
            if (index == -1)
            {
                systemPlantRooms.Add(systemPlantRoom.Clone());
            }
            else
            {
                systemPlantRooms[index] = systemPlantRoom.Clone();
            }

            return true;
        }

        public bool Remove(T systemPlantRoom)
        {
            if (systemPlantRoom == null || systemPlantRooms == null || systemPlantRooms.Count == 0)
            {
                return false;
            }

            int index = systemPlantRooms.FindIndex(x => x.Guid == systemPlantRoom.Guid);
            if (index == -1)
            {
                return false;
            }

            systemPlantRooms.RemoveAt(index);
            return true;
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("SystemPlantRooms"))
            {
                JArray jArray = jObject.Value<JArray>("SystemPlantRooms");
                if (jArray != null)
                {
                    systemPlantRooms = new List<T>();
                    foreach (JObject jObject_Temp in jArray)
                    {
                        T systemPlantRoom = Core.Query.IJSAMObject<T>(jObject_Temp);
                        if (systemPlantRoom == null)
                        {
                            continue;
                        }

                        systemPlantRooms.Add(systemPlantRoom);
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

            for (int i = 0; i < systemPlantRooms.Count; i++)
            {
                T systemPlantRoom = systemPlantRooms[i];
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
                foreach (T systemPlantRoom in systemPlantRooms)
                {
                    jArray.Add(systemPlantRoom.ToJObject());
                }

                result.Add("SystemPlantRooms", jArray);
            }

            return result;
        }
    }
}
