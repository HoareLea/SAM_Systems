using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public class SystemEnergyCentre : SAMModel, ISystemObject
    {
        private List<SystemPlantRoom> systemPlantRooms;

        public new string Name 
        {
            set
            {
                name = value;
            }
        }

        public SystemEnergyCentre(string name)
            : base(name)
        {

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
    }
}
