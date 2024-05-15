using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
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
            coordinateSystem = location == null ? null : new CoordinateSystem2D(location);
        }

        public SystemGeometryInstance(SystemGeometrySymbol systemGeometrySymbol, CoordinateSystem2D coordinateSystem2D)
        {
            this.systemGeometrySymbol = systemGeometrySymbol;
            coordinateSystem = coordinateSystem2D == null ? null : new CoordinateSystem2D(coordinateSystem2D);
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

        public bool Transform(ITransform2D transform2D)
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

        public Point2D GetPoint2D(SystemType systemType, int connectionIndex = -1, Direction direction = Direction.Undefined)
        {
            Point2D point2D = systemGeometrySymbol?.GetPoint2D(systemType, connectionIndex, direction);
            if (point2D == null)
            {
                return null;
            }

            Transform2D transform2D = Transform2D.GetCoordinateSystem2DToCoordinateSystem2D(coordinateSystem, CoordinateSystem2D.World);
            if (transform2D != null)
            {
                point2D.Transform(transform2D);
            }

            return point2D;
        }

        public Point2D GetPoint2D(int index)
        {
            Point2D point2D = systemGeometrySymbol?.GetPoint2D(index);
            if (point2D == null)
            {
                return null;
            }

            Transform2D transform2D = Transform2D.GetCoordinateSystem2DToCoordinateSystem2D(coordinateSystem, CoordinateSystem2D.World);
            if (transform2D != null)
            {
                point2D.Transform(transform2D);
            }

            return point2D;
        }

        public SystemConnector GetSystemConnector(int index)
        {
            return systemGeometrySymbol?.GetSystemConnector(index);
        }

        public DisplaySystemConnector GetDisplaySystemConnector(int index)
        {
            SystemConnector systemConnector = systemGeometrySymbol?.GetSystemConnector(index);
            if(systemConnector == null)
            {
                return null;
            }

            return new DisplaySystemConnector(systemConnector, GetPoint2D(index));
        }

        public BoundingBox2D BoundingBox2D
        {
            get
            {
                ISAMGeometry2DObject sAMGeometry2DObject = GetGeometry();
                if(sAMGeometry2DObject == null)
                {
                    return null;
                }

                if(sAMGeometry2DObject is IBoundable2DObject)
                {
                    return ((IBoundable2DObject)sAMGeometry2DObject).GetBoundingBox();
                }

                if(sAMGeometry2DObject is SAMGeometry2DObjectCollection)
                {
                    return Query.BoundingBox2D(((SAMGeometry2DObjectCollection)sAMGeometry2DObject));
                }

                return null;
            }
        }
    }
}
