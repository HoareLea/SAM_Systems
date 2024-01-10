using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public class SystemEnergyCentre : SAMModel, ISystemObject
    {
        private List<SystemPlantRoom> systemPlantRooms;

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

        public SystemEnergyCentre(SystemEnergyCentre systemEnergyCentre)
            : base(systemEnergyCentre)
        {
            systemPlantRooms = systemEnergyCentre?.systemPlantRooms == null ? null : systemEnergyCentre.systemPlantRooms.ConvertAll(x => x.Clone());
        }

        public List<SystemPlantRoom> GetSystemPlantRooms()
        {
            return systemPlantRooms == null ? null : systemPlantRooms.ConvertAll(x => new SystemPlantRoom(x));
        }

        public bool Add(SystemPlantRoom systemPlantRoom)
        {
            if(systemPlantRoom == null)
            {
                return false;
            }

            if(systemPlantRooms == null)
            {
                systemPlantRooms = new List<SystemPlantRoom>();
            }

            int index = systemPlantRooms.FindIndex(x => x.Guid == systemPlantRoom.Guid);
            if(index == -1)
            {
                systemPlantRooms.Add(new SystemPlantRoom(systemPlantRoom));
            }
            else
            {
                systemPlantRooms[index] = new SystemPlantRoom(systemPlantRoom);
            }

            return true;
        }

        public bool Remove(SystemPlantRoom systemPlantRoom)
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
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("SystemPlantRooms"))
            {
                JArray jArray = jObject.Value<JArray>("SystemPlantRooms");
                if(jArray != null)
                {
                    systemPlantRooms = new List<SystemPlantRoom>();
                    foreach(JObject jObject_Temp in jArray)
                    {
                        SystemPlantRoom systemPlantRoom = Core.Query.IJSAMObject<SystemPlantRoom>(jObject_Temp);
                        if(systemPlantRoom == null)
                        {
                            continue;
                        }

                        systemPlantRooms.Add(systemPlantRoom);
                    }
                }
            }

            return result;
        }

        public SystemPlantRoom GetSystemPlantRoom(ObjectReference objectReference)
        {
            if(objectReference == null || systemPlantRooms == null)
            {
                return null;
            }

            for(int i =0; i < systemPlantRooms.Count; i++)
            {
                SystemPlantRoom systemPlantRoom = systemPlantRooms[i];
                if(systemPlantRoom == null)
                {
                    continue;
                }

                ObjectReference objectReference_Temp = new ObjectReference(systemPlantRoom);

                if(objectReference_Temp == objectReference)
                {
                    return systemPlantRoom.Clone();
                }
            }

            return null;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if(result == null)
            {
                return result;
            }

            if(systemPlantRooms != null)
            {
                JArray jArray = new JArray();
                foreach(SystemPlantRoom systemPlantRoom in systemPlantRooms)
                {
                    jArray.Add(systemPlantRoom.ToJObject());
                }

                result.Add("SystemPlantRooms", jArray);
            }

            return result;
        }
    }
}
