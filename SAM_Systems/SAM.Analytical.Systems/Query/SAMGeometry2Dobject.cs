using SAM.Geometry.Object.Planar;
using SAM.Geometry.Systems;

namespace SAM.Analytical.Systems
{
    public static partial class Query
    {
        public static ISAMGeometry2DObject SAMGeometry2Dobject(IDisplaySystemObject displaySystemObject)
        {
            if(displaySystemObject == null)
            {
                return null;
            }

            if (displaySystemObject is IDisplaySystemObject<SystemGeometryInstance>)
            {
                IDisplaySystemObject<SystemGeometryInstance> displaySystemObject_Temp = displaySystemObject as IDisplaySystemObject<SystemGeometryInstance>;
                SystemGeometryInstance systemGeometryInstance = displaySystemObject_Temp.SystemGeometry;
                return systemGeometryInstance.GetGeometry();
            }

            return null;
        }
    }
}
