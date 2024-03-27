namespace SAM.Analytical.Systems
{
    public static partial class Query
    {
        public static System.Type Type(this AnalyticalSystemComponentType analyticalSystemComponentType)
        {
            if(analyticalSystemComponentType == AnalyticalSystemComponentType.Undefined)
            {
                return null;
            }

            switch(analyticalSystemComponentType)
            {
                case AnalyticalSystemComponentType.SystemFan:
                    return typeof(SystemFan);

                case AnalyticalSystemComponentType.SystemCoolingCoil:
                    return typeof(SystemCoolingCoil);

                case AnalyticalSystemComponentType.SystemHeatingCoil:
                    return typeof(SystemHeatingCoil);

                case AnalyticalSystemComponentType.SystemBoiler:
                    return typeof(SystemBoiler);

                case AnalyticalSystemComponentType.SystemAirJunction:
                    return typeof(SystemAirJunction);

                case AnalyticalSystemComponentType.SystemChilledBeam:
                    return typeof(SystemChilledBeam);

                case AnalyticalSystemComponentType.SystemDamper:
                    return typeof(SystemDamper);

                case AnalyticalSystemComponentType.SystemDesiccantWheel:
                    return typeof(SystemDesiccantWheel);

                case AnalyticalSystemComponentType.SystemExchanger:
                    return typeof(SystemExchanger);

                case AnalyticalSystemComponentType.SystemDirectEvaporativeCooler:
                    return typeof(SystemDirectEvaporativeCooler);

                case AnalyticalSystemComponentType.SystemDXCoilUnit:
                    return typeof(SystemDXCoilUnit);

                case AnalyticalSystemComponentType.SystemEconomiser:
                    return typeof(SystemEconomiser);

                case AnalyticalSystemComponentType.SystemHumidifier:
                    return typeof(SystemHumidifier);

                case AnalyticalSystemComponentType.SystemMixingBox:
                    return typeof(SystemMixingBox);

                case AnalyticalSystemComponentType.SystemSprayHumidifier:
                    return typeof(SystemSprayHumidifier);

                case AnalyticalSystemComponentType.SystemSteamHumidifier:
                    return typeof(SystemSteamHumidifier);

                case AnalyticalSystemComponentType.SystemSpace:
                    return typeof(SystemSpace);
            }

            return null;
        }
    }
}
