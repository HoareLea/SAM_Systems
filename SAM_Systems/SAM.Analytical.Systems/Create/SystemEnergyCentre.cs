using SAM.Core;
using SAM.Core.Systems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public static partial class Create
    {
        public static SystemEnergyCentre SystemEnergyCentre(this AnalyticalModel analyticalModel)
        {
            if(analyticalModel == null)
            {
                return null;
            }

            List<Space> spaces = analyticalModel.GetSpaces();
            if(spaces == null)
            {
                return null;
            }

            List<SystemEnergyCentre> systemEnergyCentres = Query.DefaultSystemEnergyCentres(); 
            if(systemEnergyCentres == null || systemEnergyCentres.Count == 0)
            {
                return null;
            }

            List<Tuple<Space, string>> tuples_AnalyticalModel = new List<Tuple<Space, string>>();

            foreach(Space space in spaces)
            {
                InternalCondition internalCondition = space?.InternalCondition;
                if(internalCondition == null || !internalCondition.TryGetValue(InternalConditionParameter.VentilationSystemTypeName, out string systemTypeName) || string.IsNullOrWhiteSpace(systemTypeName))
                {
                    continue;
                }

                tuples_AnalyticalModel.Add(new Tuple<Space, string>(space, systemTypeName));
            }

            SystemEnergyCentre result = new SystemEnergyCentre(analyticalModel.Name);

            while (tuples_AnalyticalModel.Count > 0)
            {
                Tuple<Space, string> tuple = tuples_AnalyticalModel[0];

                List<Tuple<Space, string>> tuples_Temp = tuples_AnalyticalModel.FindAll(x => x.Item2 == tuple.Item2);
                tuples_AnalyticalModel.RemoveAll(x => tuples_Temp.Contains(x));

                string name = tuple.Item2;

                List<SystemPlantRoom> systemPlantRooms = systemEnergyCentres.DefaultSystemPlantRooms(name);
                if(systemPlantRooms == null || systemPlantRooms.Count == 0)
                {
                    continue;
                }

                SystemPlantRoom systemPlantRoom = systemPlantRooms.FirstOrDefault();
                systemPlantRoom = systemPlantRoom.Clone();

                List<SystemSpace> systemSpaces = systemPlantRoom.GetSystemComponents<SystemSpace>();
                if (systemSpaces == null || systemSpaces.Count == 0)
                {
                    result.Add(systemPlantRoom);
                    continue;
                }

                List<Tuple<string, SystemSpace>> tuples = new List<Tuple<string, SystemSpace>>();
                foreach(SystemSpace systemSpace in systemSpaces)
                {
                    List<AirSystemGroup> airSystemGroups = systemPlantRoom.GetRelatedObjects<AirSystemGroup>(systemSpace);
                    if(airSystemGroups == null || airSystemGroups.Count == 0)
                    {
                        tuples.Add(new Tuple<string, SystemSpace>(null, systemSpace));
                        continue;
                    }

                    airSystemGroups.ForEach(x => tuples.Add(new Tuple<string, SystemSpace>(x.Name, systemSpace)));
                }

                bool single = tuples.ConvertAll(x => x.Item1).FindAll(x => !string.IsNullOrEmpty(x)).Distinct().Count() <= 1;
                if(single)
                {
                    SystemSpace systemSpace = tuples.First().Item2;

                    foreach (Space space in tuples_Temp.ConvertAll(x => x.Item1))
                    {
                        systemPlantRoom.Duplicate(systemSpace, space);
                    }
                }
                else
                {
                    throw new NotImplementedException();
                }

                tuples.ForEach(x => systemPlantRoom.Remove(x.Item2));

                result.Add(systemPlantRoom);
            }

            return result;

        }
    }
}