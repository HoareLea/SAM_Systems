﻿namespace SAM.Analytical.Systems
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

                case AnalyticalSystemComponentType.SystemMultiBoiler:
                    return typeof(SystemMultiBoiler);

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

                case AnalyticalSystemComponentType.SystemTank:
                    return typeof(SystemTank);

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

                case AnalyticalSystemComponentType.SystemLiquidDifferenceController:
                    return typeof(SystemLiquidDifferenceController);

                case AnalyticalSystemComponentType.SystemIfLogicalController:
                    return typeof(SystemIfLogicalController);

                case AnalyticalSystemComponentType.SystemNormalController:
                    return typeof(SystemNormalController);

                case AnalyticalSystemComponentType.SystemLiquidNormalController:
                    return typeof(SystemLiquidNormalController);

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

                case AnalyticalSystemComponentType.SystemLiquidPassthroughController:
                    return typeof(SystemLiquidPassthroughController);

                case AnalyticalSystemComponentType.SystemSigLogicalController:
                    return typeof(SystemSigLogicalController);

                case AnalyticalSystemComponentType.CoolingSystemCollection:
                    return typeof(CoolingSystemCollection);

                case AnalyticalSystemComponentType.HeatingSystemCollection:
                    return typeof(HeatingSystemCollection);

                case AnalyticalSystemComponentType.RefrigerantSystemCollection:
                    return typeof(RefrigerantSystemCollection);

                case AnalyticalSystemComponentType.FuelSystemCollection:
                    return typeof(FuelSystemCollection);

                case AnalyticalSystemComponentType.DomesticHotWaterSystemCollection:
                    return typeof(DomesticHotWaterSystemCollection);

                case AnalyticalSystemComponentType.ElectricalSystemCollection:
                    return typeof(ElectricalSystemCollection);

                case AnalyticalSystemComponentType.SystemPipeLossComponent:
                    return typeof(SystemPipeLossComponent);

                case AnalyticalSystemComponentType.SystemLiquidExchanger:
                    return typeof(SystemLiquidExchanger);

                case AnalyticalSystemComponentType.SystemCoolingTower:
                    return typeof(SystemCoolingTower);

                case AnalyticalSystemComponentType.SystemDryCooler:
                    return typeof(SystemDryCooler);

                case AnalyticalSystemComponentType.SystemVerticalBorehole:
                    return typeof(SystemVerticalBorehole);

                case AnalyticalSystemComponentType.SystemSlinkyCoil:
                    return typeof(SystemSlinkyCoil);

                case AnalyticalSystemComponentType.SystemCHP:
                    return typeof(SystemCHP);

                case AnalyticalSystemComponentType.SystemSurfaceWaterExchanger:
                    return typeof(SystemSurfaceWaterExchanger);

                case AnalyticalSystemComponentType.SystemHorizontalExchanger:
                    return typeof(SystemHorizontalExchanger);

                case AnalyticalSystemComponentType.SystemSolarPanel:
                    return typeof(SystemSolarPanel);

                case AnalyticalSystemComponentType.SystemPhotovoltaicPanel:
                    return typeof(SystemPhotovoltaicPanel);

                case AnalyticalSystemComponentType.SystemValve:
                    return typeof(SystemValve);

                case AnalyticalSystemComponentType.SystemWindTurbine:
                    return typeof(SystemWindTurbine);

                case AnalyticalSystemComponentType.SystemLoadComponent:
                    return typeof(SystemLoadComponent);
            }

            return null;
        }
    }
}
