using System.Text.Json.Nodes;
using SAM.Core.Systems;
using SAM.Geometry.Planar;
using SAM.Geometry.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class DisplaySystemAbsorptionChiller : SystemAbsorptionChiller, IDisplaySystemObject<SystemGeometryInstance>
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

        public DisplaySystemAbsorptionChiller(SystemAbsorptionChiller systemAbsorptionChiller, SystemGeometrySymbol systemGeometrySymbol, Point2D location)
            : base(systemAbsorptionChiller)
        {
            systemGeometryInstance = new SystemGeometryInstance(systemGeometrySymbol, location);
        }

        public DisplaySystemAbsorptionChiller(DisplaySystemAbsorptionChiller displaySystemAbsorptionChiller)
            : base(displaySystemAbsorptionChiller)
        {
            systemGeometryInstance = displaySystemAbsorptionChiller?.systemGeometryInstance == null ? null : new SystemGeometryInstance(displaySystemAbsorptionChiller?.systemGeometryInstance);
        }

        public DisplaySystemAbsorptionChiller(System.Guid guid, DisplaySystemAbsorptionChiller displaySystemAbsorptionChiller)
            : base(guid, displaySystemAbsorptionChiller)
        {
            systemGeometryInstance = displaySystemAbsorptionChiller?.systemGeometryInstance == null ? null : new SystemGeometryInstance(displaySystemAbsorptionChiller?.systemGeometryInstance);
        }

        public DisplaySystemAbsorptionChiller(JsonObject jObject)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("SystemGeometryInstance"))
            {
                systemGeometryInstance = new SystemGeometryInstance(jObject["SystemGeometryInstance"] as JsonObject);
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if (result == null)
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
            return new DisplaySystemAbsorptionChiller(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
