using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public static partial class Create
    {
        public static Log Log(this SystemEnergyCentre systemEnergyCentre)
        {
            if (systemEnergyCentre is null)
            {
                return new Log();
            }

            Log result = new Log();

            AnalyticalSystemsProperties analyticalSystemsProperties = systemEnergyCentre.GetValue<AnalyticalSystemsProperties>(SystemEnergyCentreParameter.AnalyticalSystemsProperties);
            Core.Modify.AddRange(result, Log(analyticalSystemsProperties));

            return result;
        }

        public static Log Log(this AnalyticalSystemsProperties analyticalSystemsProperties)
        {
            if (analyticalSystemsProperties is null)
            {
                return new Log();
            }

            Log result = new Log();

            List<FluidType> fluidTypes = analyticalSystemsProperties.FluidTypes;
            if (fluidTypes != null)
            {
                foreach (FluidType fluidType in fluidTypes)
                {
                    Core.Modify.AddRange(result, Log(fluidType));
                }
            }

            return result;
        }

        public static Log Log(this FluidType fluidType)
        {
            if (fluidType is null)
            {
                return null;
            }

            Log result = new Log();

            string name = fluidType.Name ?? "???";

            if (double.IsNaN(fluidType.SpecificHeatCapacity) || fluidType.SpecificHeatCapacity == 0)
            {
                result.Add("Specific heat capacity has invalid value for fluid {0}", LogRecordType.Warning, name);
            }

            if (double.IsNaN(fluidType.Density) || fluidType.Density == 0)
            {
                result.Add("Density has invalid value for fluid {0}", LogRecordType.Warning, name);
            }

            if (double.IsNaN(fluidType.FreezingPoint))
            {
                result.Add("FreezingPoint has invalid value for fluid {0}", LogRecordType.Warning, name);
            }

            return result;
        }

    }
}
