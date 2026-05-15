// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;
using SAM.Geometry.Planar;
using SAM.Geometry.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class DisplaySystemSensor : SystemSensor, IDisplaySystemObject<SystemPolyline>
    {
        private SystemPolyline systemPolyline;

        public SystemPolyline SystemGeometry
        {
            get
            {
                return systemPolyline == null ? null : new SystemPolyline(systemPolyline);
            }
        }

        public BoundingBox2D BoundingBox2D
        {
            get
            {
                return systemPolyline?.GetBoundingBox();
            }
        }

        public DisplaySystemSensor(SystemSensor systemSensor, params Point2D[] point2Ds)
            : base(systemSensor)
        {
            systemPolyline = new SystemPolyline(new Polyline2D(point2Ds));
        }

        public DisplaySystemSensor(JsonObject jObject)
            : base(jObject)
        {

        }

        public DisplaySystemSensor(DisplaySystemSensor displaySystemSensor)
            : base(displaySystemSensor)
        {
            systemPolyline = displaySystemSensor?.systemPolyline == null ? null : new SystemPolyline(displaySystemSensor.systemPolyline);
        }

        public DisplaySystemSensor(System.Guid guid, DisplaySystemSensor displaySystemSensor)
            : base(guid, displaySystemSensor)
        {
            systemPolyline = displaySystemSensor?.systemPolyline == null ? null : new SystemPolyline(displaySystemSensor.systemPolyline);
        }

        public bool Move(Vector2D vector2D)
        {
            if (systemPolyline == null || vector2D == null)
            {
                return false;
            }

            return systemPolyline.Move(vector2D);
        }

        public bool Transform(ITransform2D transform2D)
        {
            if (transform2D == null)
            {
                return false;
            }
            systemPolyline = systemPolyline.GetTransformed(transform2D) as SystemPolyline;
            return true;
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("SystemPolyline"))
            {
                systemPolyline = new SystemPolyline(jObject["SystemPolyline"] as JsonObject);
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

            if (systemPolyline != null)
            {
                result.Add("SystemPolyline", systemPolyline.ToJsonObject());
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new DisplaySystemSensor(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
