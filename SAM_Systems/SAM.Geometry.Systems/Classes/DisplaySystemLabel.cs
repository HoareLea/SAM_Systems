// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemLabel : SystemLabel, IJSAMObject
    {
        private int height;
        private LabelDirection labelDirection;
        private Point2D location;
        private int width;

        public DisplaySystemLabel(SystemLabel systemLabel, Point2D location, LabelDirection labelDirection, int height, int width)
            : base(systemLabel)
        {
            this.location = location == null ? null : new Point2D(location);
            this.labelDirection = labelDirection;
            this.height = height;
            this.width = width;
        }

        public DisplaySystemLabel(DisplaySystemLabel displaySystemLabel)
            : base(displaySystemLabel)
        {
            if (displaySystemLabel != null)
            {
                location = displaySystemLabel.Location == null ? null : new Point2D(displaySystemLabel.Location);
                labelDirection = displaySystemLabel.labelDirection;
                height = displaySystemLabel.height;
                width = displaySystemLabel.width;
            }
        }

        public DisplaySystemLabel(JsonObject jObject)
            : base(jObject)
        {

        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public LabelDirection LabelDirection
        {
            get
            {
                return labelDirection;
            }
        }

        public Point2D Location
        {
            get
            {
                return location;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
        }
        
        public new bool FromJsonObject(JsonObject jObject)
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

            if (jObject.ContainsKey("LabelDirection"))
            {
                labelDirection = Core.Query.Enum<LabelDirection>(jObject["LabelDirection"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("Height"))
            {
                height = jObject["Height"]?.GetValue<int>() ?? default(int);
            }

            if (jObject.ContainsKey("Width"))
            {
                width = jObject["Width"]?.GetValue<int>() ?? default(int);
            }

            return result;
        }
        
        public new JsonObject ToJsonObject()
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

            result.Add("Height", height);

            result.Add("Width", width);

            result.Add("LabelDirection", labelDirection.ToString());

            return result;
        }
    }
}
