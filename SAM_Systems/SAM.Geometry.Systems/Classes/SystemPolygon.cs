// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using SAM.Geometry.Object.Planar;
using System.Text.Json.Nodes;
using SAM.Geometry.Planar;
using System.Collections.Generic;

namespace SAM.Geometry.Systems
{
    public class SystemPolygon : Polygon2DObject, ISystemGeometry
    {
        public SystemPolygon(Polygon2D polygon2D) 
            : base(polygon2D)
        {
        }

        public SystemPolygon(JsonObject jObject)
            : base(jObject)
        {
        }

        public SystemPolygon(SystemPolygon systemPolygon)
            : base(systemPolygon)
        {
        }

        public SystemPolygon(IEnumerable<Point2D> point2Ds)
            : base(point2Ds == null ? null : new Polygon2D(point2Ds))
        {
        }

        public ISAMGeometry2DObject GetGeometry()
        {
            return new Polygon2DObject(this);
        }
    }
}
