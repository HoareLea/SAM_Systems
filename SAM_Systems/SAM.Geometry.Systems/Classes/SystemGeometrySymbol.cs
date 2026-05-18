// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using SAM.Geometry.Object.Planar;
using System.Text.Json.Nodes;
using SAM.Core;
using System.Collections.Generic;
using SAM.Core.Systems;
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public class SystemGeometrySymbol : SAMObject, ISAMGeometry2DObject, ISystemJSAMObject
    {
        private ISAMGeometry2DObject geometry;
        private DisplaySystemConnectorManager displaySystemConnectorManager;

        public SystemGeometrySymbol(string name, ISAMGeometry2DObject geometry, IEnumerable<DisplaySystemConnector> displaySystemConnectors)
            : base(name)
        {
            this.geometry = geometry?.Clone();
            displaySystemConnectorManager = displaySystemConnectors == null ? null : new DisplaySystemConnectorManager(displaySystemConnectors); 
        }

        public SystemGeometrySymbol(ISAMGeometry2DObject geometry, IEnumerable<DisplaySystemConnector> displaySystemConnectors)
            :base()
        {
            this.geometry = geometry?.Clone();
            displaySystemConnectorManager = displaySystemConnectors == null ? null : new DisplaySystemConnectorManager(displaySystemConnectors);
        }

        public SystemGeometrySymbol(JsonObject jObject)
            :base(jObject)
        {

        }

        public SystemGeometrySymbol(SystemGeometrySymbol systemGeometrySymbol)
            :base(systemGeometrySymbol)
        {
            geometry = systemGeometrySymbol?.Geometry;
            displaySystemConnectorManager = systemGeometrySymbol.displaySystemConnectorManager == null ? null : new DisplaySystemConnectorManager(systemGeometrySymbol.displaySystemConnectorManager);
        }

        public ISAMGeometry2DObject Geometry
        {
            get
            {
                return geometry?.Clone();
            }
        }

        public IEnumerable<DisplaySystemConnector> DisplaySystemConnectors
        {
            get
            {
                return displaySystemConnectorManager?.SystemConnectors;
            }
        }

        public DisplaySystemConnectorManager DisplaySystemConnectorManager
        {
            get
            {
                return displaySystemConnectorManager == null ? null : new DisplaySystemConnectorManager(displaySystemConnectorManager);
            }
        }

        public Point2D GetPoint2D(int index)
        {
            if(displaySystemConnectorManager == null)
            {
                return null;
            }

            DisplaySystemConnector displaySystemConnector = displaySystemConnectorManager[index];

            return displaySystemConnector?.Location == null ? null : new Point2D(displaySystemConnector.Location);
        }

        public SystemConnector GetSystemConnector(int index)
        {
            if (displaySystemConnectorManager == null)
            {
                return null;
            }

            DisplaySystemConnector displaySystemConnector = displaySystemConnectorManager[index];

            return displaySystemConnector == null ? null : new SystemConnector(displaySystemConnector);
        }

        public Point2D GetPoint2D(SystemType systemType, int connectionIndex = -1, Direction direction = Direction.Undefined)
        {
            IEnumerable<DisplaySystemConnector> displaySystemConnectors = displaySystemConnectorManager?.SystemConnectors;
            if (displaySystemConnectors == null)
            {
                return null;
            }

            foreach(DisplaySystemConnector displaySystemConnector in displaySystemConnectors)
            {
                if(displaySystemConnector?.SystemType != systemType)
                {
                    continue;
                }

                if(connectionIndex != -1 && displaySystemConnector.ConnectionIndex != connectionIndex)
                {
                    continue;
                }

                if (direction != Direction.Undefined && displaySystemConnector.Direction != direction)
                {
                    continue;
                }

                return displaySystemConnector.Location == null ? null : new Point2D(displaySystemConnector.Location);

            }

            return null;
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Geometry"))
            {
                geometry = Core.Query.IJSAMObject<ISAMGeometry2DObject>(jObject["Geometry"] as JsonObject);
            }

            if (jObject.ContainsKey("DisplaySystemConnectorManager"))
            {
                displaySystemConnectorManager = new DisplaySystemConnectorManager(jObject["DisplaySystemConnectorManager"] as JsonObject);
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();

            if(geometry != null)
            {
                result.Add("Geometry", geometry.ToJsonObject());
            }

            if(displaySystemConnectorManager != null)
            {
                result.Add("DisplaySystemConnectorManager", displaySystemConnectorManager.ToJsonObject());
            }

            return result;
        }
    }
}
