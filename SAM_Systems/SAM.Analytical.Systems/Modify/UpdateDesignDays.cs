using SAM.Core;
using SAM.Core.Systems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public static partial class Modify
    {
        public static void UpdateDesignDays(this SystemEnergyCentre systemEnergyCentre, AnalyticalModel analyticalModel)
        {
            if(analyticalModel is null || systemEnergyCentre is null)
            {
                return;
            }

            List<DesignDay> designDays = new List<DesignDay>();

            if (analyticalModel.TryGetValue(Analytical.AnalyticalModelParameter.HeatingDesignDays, out SAMCollection<DesignDay> heatingDesignDays) && heatingDesignDays != null)
            {
                designDays.AddRange(heatingDesignDays);
            }

            if (analyticalModel.TryGetValue(Analytical.AnalyticalModelParameter.CoolingDesignDays, out SAMCollection<DesignDay> coolingDesignDays) && coolingDesignDays != null)
            {
                designDays.AddRange(coolingDesignDays);
            }

            UpdateDesignDays(systemEnergyCentre, designDays);
        }

        public static void UpdateDesignDays(this SystemEnergyCentre systemEnergyCentre, IEnumerable<DesignDay> designDays, bool includeAnnualDesignCondition = true)
        {
            if (systemEnergyCentre is null || designDays is null || !designDays.Any())
            {
                return;
            }

            List<SystemPlantRoom> systemPlantRooms = systemEnergyCentre.GetSystemPlantRooms();
            if(systemPlantRooms is null || !systemPlantRooms.Any())
            {
                return;
            }

            HashSet<string> names = new HashSet<string>();
            foreach(DesignDay designDay in designDays)
            {
                if(designDay?.Name is string name)
                {
                    names.Add(name);
                }
            }

            if(includeAnnualDesignCondition)
            {
                names.Add("Annual Design Condition");
            }

            Func<ISizableValue, ISizableValue> update = new Func<ISizableValue, ISizableValue>(sizableValue => 
            {
                if (sizableValue is DesignConditionSizableValue designConditionSizableValue)
                {
                    designConditionSizableValue.DesignConditionNames = names;
                }

                if (sizableValue is DesignConditionSizedFlowValue designConditionSizedFlowValue)
                {
                    designConditionSizedFlowValue.DesignConditionNames = names;
                }

                return sizableValue;
            });

            foreach(SystemPlantRoom systemPlantRoom in systemPlantRooms)
            {
                List<ISystemSpaceComponent> systemSpaceComponents = systemPlantRoom.GetSystemComponents<ISystemSpaceComponent>();
                if(systemSpaceComponents != null)
                {
                    foreach(ISystemSpaceComponent systemSpaceComponent in systemSpaceComponents)
                    {
                        if(systemSpaceComponent is SystemRadiator systemRadiator)
                        {
                            systemRadiator.Duty = update.Invoke(systemRadiator.Duty);
                        }
                    }
                }

                systemEnergyCentre.Add(systemPlantRoom);
            }
        }
    }
}