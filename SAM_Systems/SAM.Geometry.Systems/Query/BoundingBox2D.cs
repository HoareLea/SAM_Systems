using SAM.Core;
using SAM.Geometry.Object.Planar;
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public static partial class Query
    {
        public static BoundingBox2D BoundingBox2D(this SAMGeometry2DObjectCollection sAMGeometry2DObjectCollection)
        {
            if(sAMGeometry2DObjectCollection == null)
            {
                return null;
            }

            BoundingBox2D result = null;

            foreach(ISAMGeometry2DObject sAMGeometry2DObject in sAMGeometry2DObjectCollection)
            {

                BoundingBox2D boundingBox2D = null;
                
                if (sAMGeometry2DObject is IBoundable2DObject)
                {
                    boundingBox2D = ((IBoundable2DObject)sAMGeometry2DObject).GetBoundingBox();
                }
                else if(sAMGeometry2DObject is SAMGeometry2DObjectCollection)
                {
                    boundingBox2D = BoundingBox2D(sAMGeometry2DObjectCollection);
                }

                if(boundingBox2D == null)
                {
                    continue;
                }

                if(result == null)
                {
                    result = boundingBox2D;
                }
                else
                {
                    result.Include(boundingBox2D);
                }
            }

            return result;

        }
    }
}