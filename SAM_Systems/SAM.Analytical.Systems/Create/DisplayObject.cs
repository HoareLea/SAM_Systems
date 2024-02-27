using SAM.Core.Systems;
using SAM.Geometry.Planar;
using SAM.Geometry.Systems;

namespace SAM.Analytical.Systems
{
    public static partial class Create
    {
        public static T DisplayObject<T>(this SystemComponent systemComponent, Point2D location, DisplaySystemManager displaySystemManager) where T :IDisplayObject
        {
            if(systemComponent == null || displaySystemManager == null)
            {
                return default(T);
            }

            if(systemComponent is T)
            {
                return (T)(object)systemComponent;
            }

            if(systemComponent is IDisplayObject)
            {
                return default(T);
            }

            IDisplayObject displayObject = null;
            if (systemComponent is SystemHeatingCoil)
            {
                SystemGeometrySymbol systemGeometrySymbol = displaySystemManager.SystemGeometrySymbolManager.GetSystemGeometrySymbol<SystemHeatingCoil>();
                if(systemGeometrySymbol == null)
                {
                    return default(T);
                }

                displayObject = new DisplaySystemHeatingCoil((SystemHeatingCoil)systemComponent, systemGeometrySymbol, location);
            }

            if(!(displayObject is T))
            {
                return default(T);
            }

            return (T)(object)displayObject;
        }
    }
}