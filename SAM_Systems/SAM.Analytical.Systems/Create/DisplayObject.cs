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

            if (!(displayObject is T))
            {
                return default(T);
            }

            return (T)(object)displayObject;
        }
    }
}