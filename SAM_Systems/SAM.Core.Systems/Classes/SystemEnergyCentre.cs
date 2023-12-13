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

            }
        }
    }
}
