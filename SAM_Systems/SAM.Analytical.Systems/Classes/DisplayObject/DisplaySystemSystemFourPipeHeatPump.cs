using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using SAM.Geometry.Planar;
using SAM.Geometry.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class DisplaySystemFourPipeHeatPump : SystemFourPipeHeatPump, IDisplaySystemObject<SystemGeometryInstance>
    {
        private SystemGeometryInstance systemGeometryInstance;

        public SystemGeometryInstance SystemGeometry
        {
            get
            {
                return systemGeometryInstance == null ? null : new SystemGeometryInstance(systemGeometryInstance);
            }
        }

        public BoundingBox2D BoundingBox2D
        {
            get
            {
                return systemGeometryInstance?.BoundingBox2D;
            }
        }

        public DisplaySystemFourPipeHeatPump(SystemFourPipeHeatPump systemFourPipeHeatPump, SystemGeometrySymbol systemGeometrySymbol, Point2D location)
            : base(systemFourPipeHeatPump)
        {
            systemGeometryInstance = new SystemGeometryInstance(systemGeometrySymbol, location);
        }

        public DisplaySystemFourPipeHeatPump(DisplaySystemFourPipeHeatPump displaySystemFourPipeHeatPump)
            : base(displaySystemFourPipeHeatPump)
        {
            systemGeometryInstance = displaySystemFourPipeHeatPump?.systemGeometryInstance == null ? null : new SystemGeometryInstance(displaySystemFourPipeHeatPump?.systemGeometryInstance);
        }

        public DisplaySystemFourPipeHeatPump(Guid guid, DisplaySystemFourPipeHeatPump displaySystemFourPipeHeatPump)
            : base(guid, displaySystemFourPipeHeatPump)
        {
            systemGeometryInstance = displaySystemFourPipeHeatPump?.systemGeometryInstance == null ? null : new SystemGeometryInstance(displaySystemFourPipeHeatPump?.systemGeometryInstance);
        }

        public DisplaySystemFourPipeHeatPump(JObject jObject)
            : base(jObject)
        {

        }

        public bool Move(Vector2D vector2D)
        {
            if (systemGeometryInstance == null || vector2D == null)
            {
                return false;
            }

            return systemGeometryInstance.Move(vector2D);
        }

        public bool Transform(ITransform2D transform2D)
        {
            if (systemGeometryInstance == null || transform2D == null)
            {
                return false;
            }

            return systemGeometryInstance.Transform(transform2D);
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("SystemGeometryInstance"))
            {
                systemGeometryInstance = new SystemGeometryInstance(jObject.Value<JObject>("SystemGeometryInstance"));
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return result;
            }

            if (systemGeometryInstance != null)
            {
                result.Add("SystemGeometryInstance", systemGeometryInstance.ToJObject());
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new DisplaySystemFourPipeHeatPump(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}