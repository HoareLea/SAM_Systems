using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public static partial class Modify
    {
        public static void CopyProperties(this SystemEnergyCentre systemEnergyCentre_Source, SystemEnergyCentre systemEnergyCentre_Destination)
        {
            if(systemEnergyCentre_Source is null || systemEnergyCentre_Destination is null)
            {
                return;
            }

            //Copy Analytical Systems Properties
            AnalyticalSystemsProperties analyticalSystemsProperties_Source = systemEnergyCentre_Source.GetValue<AnalyticalSystemsProperties>(SystemEnergyCentreParameter.AnalyticalSystemsProperties);
            if (analyticalSystemsProperties_Source != null)
            {
                AnalyticalSystemsProperties analyticalSystemsProperties_Destination = systemEnergyCentre_Destination.GetValue<AnalyticalSystemsProperties>(SystemEnergyCentreParameter.AnalyticalSystemsProperties);
                if (analyticalSystemsProperties_Destination == null)
                {
                    analyticalSystemsProperties_Destination = new AnalyticalSystemsProperties(analyticalSystemsProperties_Source);
                }
                else
                {
                    List<ISchedule> schedules = analyticalSystemsProperties_Source.Schedules;
                    if (schedules != null)
                    {
                        foreach (ISchedule schedule in schedules)
                        {
                            analyticalSystemsProperties_Destination.Add(schedule);
                        }
                    }

                    List<FluidType> fluidTypes = analyticalSystemsProperties_Source.FluidTypes;
                    if (fluidTypes != null)
                    {
                        foreach (FluidType fluidType in fluidTypes)
                        {
                            analyticalSystemsProperties_Destination.Add(fluidType);
                        }
                    }

                    List<DesignCondition> designConditions = analyticalSystemsProperties_Source.DesignConditions;
                    if (designConditions != null)
                    {
                        foreach (DesignCondition designCondition in designConditions)
                        {
                            analyticalSystemsProperties_Destination.Add(designCondition);
                        }
                    }
                }

                systemEnergyCentre_Destination.SetValue(SystemEnergyCentreParameter.AnalyticalSystemsProperties, analyticalSystemsProperties_Destination);
            }

            //Copy SystemEnergySources
            List<SystemEnergySource> systemEnergySources = systemEnergyCentre_Source.GetSystemEnergySources();
            if (systemEnergySources != null)
            {
                foreach (SystemEnergySource systemEnergySource in systemEnergySources)
                {
                    systemEnergyCentre_Destination.Add(systemEnergySource);
                }
            }
        }
    }
}