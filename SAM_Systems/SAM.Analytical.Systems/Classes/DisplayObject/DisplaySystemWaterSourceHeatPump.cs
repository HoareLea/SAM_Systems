using System.Text.Json.Nodes;
using SAM.Core.Systems;
using SAM.Geometry.Planar;
using SAM.Geometry.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class DisplaySystemWaterSourceHeatPump : SystemWaterSourceHeatPump, IDisplaySystemObject<SystemGeometryInstance>
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

        public DisplaySystemWaterSourceHeatPump(SystemWaterSourceHeatPump systemWaterSourceHeatPump, SystemGeometrySymbol systemGeometrySymbol, Point2D location)
            :base(systemWaterSourceHeatPump)
        {
            systemGeometryInstance = new SystemGeometryInstance(systemGeometrySymbol, location);
        }

        public DisplaySystemWaterSourceHeatPump(DisplaySystemWaterSourceHeatPump displaySystemHeatPump)
            : base(displaySystemHeatPump)
        {
            systemGeometryInstance = displaySystemHeatPump?.systemGeometryInstance == null ? null : new SystemGeometryInstance(displaySystemHeatPump?.systemGeometryInstance);
        }

        public DisplaySystemWaterSourceHeatPump(System.Guid guid, DisplaySystemWaterSourceHeatPump displaySystemHeatPump)
            : base(guid, displaySystemHeatPump)
        {
            systemGeometryInstance = displaySystemHeatPump?.systemGeometryInstance == null ? null : new SystemGeometryInstance(displaySystemHeatPump?.systemGeometryInstance);
        }

        public DisplaySystemWaterSourceHeatPump(JsonObject jObject)
            : base(jObject)
        {

        }

        public bool Move(Vector2D vector2D)
        {
            if(systemGeometryInstance == null || vector2D == null)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("SystemGeometryInstance"))
            {
                systemGeometryInstance = new SystemGeometryInstance(jObject["SystemGeometryInstance"] as JsonObject);
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if(result == null)
            {
                return result;
            }

            if (systemGeometryInstance != null)
            {
                result.Add("SystemGeometryInstance", systemGeometryInstance.ToJsonObject());
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new DisplaySystemWaterSourceHeatPump(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
