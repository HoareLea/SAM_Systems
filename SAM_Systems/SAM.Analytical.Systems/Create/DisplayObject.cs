using SAM.Core.Systems;
using SAM.Geometry.Planar;
using SAM.Geometry.Systems;

namespace SAM.Analytical.Systems
{
    public static partial class Create
    {
        public static T DisplayObject<T>(this SystemComponent systemComponent, Point2D location, DisplaySystemManager displaySystemManager) where T :IDisplaySystemObject
        {
            if(systemComponent == null || displaySystemManager == null)
            {
                return default(T);
            }

            if(systemComponent is T)
            {
                return (T)(object)systemComponent;
            }

            if(systemComponent is IDisplaySystemObject)
            {
                return default(T);
            }

            SystemGeometrySymbol systemGeometrySymbol = displaySystemManager.SystemGeometrySymbolManager.GetSystemGeometrySymbol(systemComponent.GetType());
            if (systemGeometrySymbol == null)
            {
                return default(T);
            }

            IDisplaySystemObject displayObject = null;
            if (systemComponent is SystemHeatingCoil)
            {
                displayObject = new DisplaySystemHeatingCoil((SystemHeatingCoil)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemCoolingCoil)
            {
                displayObject = new DisplaySystemCoolingCoil((SystemCoolingCoil)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemFan)
            {
                displayObject = new DisplaySystemFan((SystemFan)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemDesiccantWheel)
            {
                displayObject = new DisplaySystemDesiccantWheel((SystemDesiccantWheel)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemExchanger)
            {
                displayObject = new DisplaySystemExchanger((SystemExchanger)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemAirJunction)
            {
                displayObject = new DisplaySystemAirJunction((SystemAirJunction)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemDamper)
            {
                displayObject = new DisplaySystemDamper((SystemDamper)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemSpace)
            {
                displayObject = new DisplaySystemSpace((SystemSpace)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemSteamHumidifier)
            {
                displayObject = new DisplaySystemSteamHumidifier((SystemSteamHumidifier)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemSprayHumidifier)
            {
                displayObject = new DisplaySystemSprayHumidifier((SystemSprayHumidifier)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemDXCoil)
            {
                displayObject = new DisplaySystemDXCoil((SystemDXCoil)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemEconomiser)
            {
                displayObject = new DisplaySystemEconomiser((SystemEconomiser)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemMixingBox)
            {
                displayObject = new DisplaySystemMixingBox((SystemMixingBox)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemDirectEvaporativeCooler)
            {
                displayObject = new DisplaySystemDirectEvaporativeCooler((SystemDirectEvaporativeCooler)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemPump)
            {
                displayObject = new DisplaySystemPump((SystemPump)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemHeatPump)
            {
                displayObject = new DisplaySystemHeatPump((SystemHeatPump)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemAirSourceHeatPump)
            {
                displayObject = new DisplaySystemAirSourceHeatPump((SystemAirSourceHeatPump)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemBoiler)
            {
                displayObject = new DisplaySystemBoiler((SystemBoiler)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemAirSourceChiller)
            {
                displayObject = new DisplaySystemAirSourceChiller((SystemAirSourceChiller)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemWaterSourceChiller)
            {
                displayObject = new DisplaySystemWaterSourceChiller((SystemWaterSourceChiller)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemMultiChiller)
            {
                displayObject = new DisplaySystemMultiChiller((SystemMultiChiller)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemAbsorptionChiller)
            {
                displayObject = new DisplaySystemAbsorptionChiller((SystemAbsorptionChiller)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemAirSourceDirectAbsorptionChiller)
            {
                displayObject = new DisplaySystemAirSourceDirectAbsorptionChiller((SystemAirSourceDirectAbsorptionChiller)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemWaterSourceAbsorptionChiller)
            {
                displayObject = new DisplaySystemWaterSourceAbsorptionChiller((SystemWaterSourceAbsorptionChiller)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemWaterSourceDirectAbsorptionChiller)
            {
                displayObject = new DisplaySystemWaterSourceDirectAbsorptionChiller((SystemWaterSourceDirectAbsorptionChiller)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemIceStorageChiller)
            {
                displayObject = new DisplaySystemIceStorageChiller((SystemIceStorageChiller)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemWaterSourceIceStorageChiller)
            {
                displayObject = new DisplaySystemWaterSourceIceStorageChiller((SystemWaterSourceIceStorageChiller)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemLiquidJunction)
            {
                displayObject = new DisplaySystemLiquidJunction((SystemLiquidJunction)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemNormalController)
            {
                displayObject = new DisplaySystemNormalController((SystemNormalController)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemOutdoorController)
            {
                displayObject = new DisplaySystemOutdoorController((SystemOutdoorController)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemDifferenceController)
            {
                displayObject = new DisplaySystemDifferenceController((SystemDifferenceController)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemPassthroughController)
            {
                displayObject = new DisplaySystemPassthroughController((SystemPassthroughController)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemMinLogicalController)
            {
                displayObject = new DisplaySystemMinLogicalController((SystemMinLogicalController)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemMaxLogicalController)
            {
                displayObject = new DisplaySystemMaxLogicalController((SystemMaxLogicalController)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemNotLogicalController)
            {
                displayObject = new DisplaySystemNotLogicalController((SystemNotLogicalController)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemIfLogicalController)
            {
                displayObject = new DisplaySystemIfLogicalController((SystemIfLogicalController)systemComponent, systemGeometrySymbol, location);
            }
            else if (systemComponent is SystemSigLogicalController)
            {
                displayObject = new DisplaySystemSigLogicalController((SystemSigLogicalController)systemComponent, systemGeometrySymbol, location);
            }

            if (!(displayObject is T))
            {
                return default(T);
            }

            return (T)(object)displayObject;
        }
    }
}