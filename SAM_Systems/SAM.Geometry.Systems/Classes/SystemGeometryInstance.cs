using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Geometry.Object.Planar;
using SAM.Geometry.Planar;
using SAM.Geometry.Spatial;

namespace SAM.Geometry.Systems
{
    public class SystemGeometryInstance : IJSAMObject, ISystemGeometry
    {
        private SystemGeometrySymbol systemGeometrySymbol;
        private CoordinateSystem2D coordinateSystem;

        public SystemGeometryInstance(SystemGeometryInstance systemGeometryInstance)
        {
            if (systemGeometryInstance != null)
            {
                systemGeometrySymbol = systemGeometryInstance.systemGeometrySymbol?.Clone();
                coordinateSystem = systemGeometryInstance.coordinateSystem?.Clone();
            }
        }

        public SystemGeometryInstance(JObject jObject)
        {
            FromJObject(jObject);
        }

        public SystemGeometryInstance(SystemGeometrySymbol systemGeometrySymbol, Point2D location)
        {
            this.systemGeometrySymbol = systemGeometrySymbol;
            coordinateSystem = new CoordinateSystem2D(location);
        }

        public bool Move(Vector2D vector2D)
        {
            if (vector2D == null)
            {
                return false;
            }

            coordinateSystem?.Move(vector2D);
            return true;
        }

        public bool Transform(Transform2D transform2D)
        {
            if(transform2D == null)
            {
                return false;
            }

            coordinateSystem = coordinateSystem.GetTransformed(transform2D);
            return true;
        }

        public bool FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if (jObject.ContainsKey("SystemGeometrySymbol"))
            {
                systemGeometrySymbol = new SystemGeometrySymbol(jObject.Value<JObject>("SystemGeometrySymbol"));
            }

            if (jObject.ContainsKey("CoordinateSystem"))
            {
                coordinateSystem = new CoordinateSystem2D(jObject.Value<JObject>("CoordinateSystem"));
            }

            return true;
        }

        public JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if (systemGeometrySymbol != null)
            {
                result.Add("SystemGeometrySymbol", systemGeometrySymbol.ToJObject());
            }

            if (coordinateSystem != null)
            {
                result.Add("CoordinateSystem", coordinateSystem.ToJObject());
            }

            return result;
        }

        public ISAMGeometry2DObject GetGeometry()
        {
            ISAMGeometry2DObject sAMGeometry2DObject = systemGeometrySymbol?.Geometry;
            if (sAMGeometry2DObject == null)
            {
                return null;
            }

            ISAMGeometry2DObject result = sAMGeometry2DObject.Clone();
            if (coordinateSystem == null)
            {
                return result;
            }

            Transform2D transform2D = Transform2D.GetCoordinateSystem2DToCoordinateSystem2D(coordinateSystem, CoordinateSystem2D.World);
            if(result is ISAMGeometry2D)
            {
                ISAMGeometry2D sAMGeometry2D = ((ISAMGeometry2D)result).Clone() as ISAMGeometry2D;
                sAMGeometry2D.Transform(transform2D);
                return sAMGeometry2D as ISAMGeometry2DObject;
            }
            else if (result is SAMGeometry2DObjectCollection)
            {
                SAMGeometry2DObjectCollection sAMGeometry2DObjectCollection = new SAMGeometry2DObjectCollection();
                foreach (ISAMGeometry2DObject sAMGeometry2DObject_Temp in (SAMGeometry2DObjectCollection)result)
                {
                    if (sAMGeometry2DObject_Temp == null)
                    {
                        continue;
                    }

                    ISAMGeometry2DObject sAMGeometry2DObject_Clone = sAMGeometry2DObject_Temp.Clone();

                    if (sAMGeometry2DObject_Clone is ISAMGeometry2D)
                    {
                        ((ISAMGeometry2D)sAMGeometry2DObject_Clone).Transform(transform2D);
                    }

                    sAMGeometry2DObjectCollection.Add(sAMGeometry2DObject_Clone);
                }

                result = sAMGeometry2DObjectCollection;
            }

            return result;
        }
    }
}
