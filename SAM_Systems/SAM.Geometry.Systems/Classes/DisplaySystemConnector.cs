// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemConnector : SystemConnector
    {
        private Point2D location;

        public DisplaySystemConnector(SystemConnector systemConnector, Point2D location)
            :base(systemConnector)
        {
            this.location = location == null ? null : new Point2D(location);
        }

        public DisplaySystemConnector(DisplaySystemConnector displaySystemConnector)
            :base(displaySystemConnector)
        {
            if(displaySystemConnector != null)
            {
                location = displaySystemConnector.Location == null ? null : new Point2D(displaySystemConnector.Location);
            }
        }

        public DisplaySystemConnector(JsonObject jObject)
            :base(jObject)
        {

        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("Location"))
            {
                location = new Point2D(jObject["Location"] as JsonObject);
            }

            return result;
        }

        public Point2D Location
        {
            get
            {
                return location;
            }
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if(result == null)
            {
                return null;
            }

            if(Location != null)
            {
                result.Add("Location", location.ToJsonObject());
            }

            return result;
        }
    }
}
