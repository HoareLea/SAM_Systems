// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;
using SAM.Geometry.Planar;
using SAM.Geometry.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class DisplayCoolingSystemCollection : CoolingSystemCollection, IDisplaySystemObject<SystemGeometryInstance>
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

        public DisplayCoolingSystemCollection(CoolingSystemCollection coolingSystemCollection, SystemGeometrySymbol systemGeometrySymbol, Point2D location)
            : base(coolingSystemCollection)
        {
            systemGeometryInstance = new SystemGeometryInstance(systemGeometrySymbol, location);
        }

        public DisplayCoolingSystemCollection(DisplayCoolingSystemCollection displayCoolingSystemCollection)
            : base(displayCoolingSystemCollection)
        {
            systemGeometryInstance = displayCoolingSystemCollection?.systemGeometryInstance == null ? null : new SystemGeometryInstance(displayCoolingSystemCollection?.systemGeometryInstance);
        }

        public DisplayCoolingSystemCollection(Guid guid, DisplayCoolingSystemCollection displayCoolingSystemCollection)
            : base(guid, displayCoolingSystemCollection)
        {
            systemGeometryInstance = displayCoolingSystemCollection?.systemGeometryInstance == null ? null : new SystemGeometryInstance(displayCoolingSystemCollection?.systemGeometryInstance);
        }

        public DisplayCoolingSystemCollection(JsonObject jObject)
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
            return new DisplayCoolingSystemCollection(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}