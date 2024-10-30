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

                case AnalyticalSystemComponentType.SystemPump:
                    return typeof(SystemPump);

                case AnalyticalSystemComponentType.SystemWaterSourceHeatPump:
                    return typeof(SystemWaterSourceHeatPump);

                case AnalyticalSystemComponentType.SystemAirSourceHeatPump:
                    return typeof(SystemAirSourceHeatPump);

                case AnalyticalSystemComponentType.SystemWaterToWaterHeatPump:
                    return typeof(SystemWaterToWaterHeatPump);

                case AnalyticalSystemComponentType.SystemCoolingCoil:
                    return typeof(SystemCoolingCoil);

                case AnalyticalSystemComponentType.SystemAirSourceChiller:
                    return typeof(SystemAirSourceChiller);

                case AnalyticalSystemComponentType.SystemWaterSourceChiller:
                    return typeof(SystemWaterSourceChiller);

                case AnalyticalSystemComponentType.SystemMultiChiller:
                    return typeof(SystemMultiChiller);

                case AnalyticalSystemComponentType.SystemAbsorptionChiller:
                    return typeof(SystemAbsorptionChiller);

                case AnalyticalSystemComponentType.SystemAirSourceDirectAbsorptionChiller:
                    return typeof(SystemAirSourceDirectAbsorptionChiller);

                case AnalyticalSystemComponentType.SystemWaterSourceAbsorptionChiller:
                    return typeof(SystemWaterSourceAbsorptionChiller);

                case AnalyticalSystemComponentType.SystemWaterSourceDirectAbsorptionChiller:
                    return typeof(SystemWaterSourceDirectAbsorptionChiller);

                case AnalyticalSystemComponentType.SystemIceStorageChiller:
                    return typeof(SystemIceStorageChiller);

                case AnalyticalSystemComponentType.SystemWaterSourceIceStorageChiller:
                    return typeof(SystemWaterSourceIceStorageChiller);

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

                case AnalyticalSystemComponentType.SystemDXCoil:
                    return typeof(SystemDXCoil);

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

                case AnalyticalSystemComponentType.SystemLiquidJunction:
                    return typeof(SystemLiquidJunction);

                case AnalyticalSystemComponentType.SystemSpace:
                    return typeof(SystemSpace);

                case AnalyticalSystemComponentType.SystemDifferenceController:
                    return typeof(SystemDifferenceController);

                case AnalyticalSystemComponentType.SystemIfLogicalController:
                    return typeof(SystemIfLogicalController);

                case AnalyticalSystemComponentType.SystemNormalController:
                    return typeof(SystemNormalController);

                case AnalyticalSystemComponentType.SystemMaxLogicalController:
                    return typeof(SystemMaxLogicalController);

                case AnalyticalSystemComponentType.SystemMinLogicalController:
                    return typeof(SystemMinLogicalController);

                case AnalyticalSystemComponentType.SystemNotLogicalController:
                    return typeof(SystemNotLogicalController);

                case AnalyticalSystemComponentType.SystemOutdoorController:
                    return typeof(SystemOutdoorController);

                case AnalyticalSystemComponentType.SystemPassthroughController:
                    return typeof(SystemPassthroughController);

                case AnalyticalSystemComponentType.SystemSigLogicalController:
                    return typeof(SystemSigLogicalController);
            }

            return null;
        }
    }
}
