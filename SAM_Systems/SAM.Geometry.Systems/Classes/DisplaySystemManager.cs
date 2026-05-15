// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemManager :IJSAMObject, ISystemJSAMObject
    {
        private SystemGeometrySymbolManager systemGeometrySymbolManager;

        public DisplaySystemManager()
        {

        }

        public DisplaySystemManager(JsonObject jObject)
        {
            FromJsonObject(jObject);
        }

        public DisplaySystemManager(DisplaySystemManager displaySystemManager)
        {
            systemGeometrySymbolManager = displaySystemManager?.systemGeometrySymbolManager == null ? null : new SystemGeometrySymbolManager(displaySystemManager.SystemGeometrySymbolManager);
        }

        public SystemGeometrySymbolManager SystemGeometrySymbolManager
        {
            get
            {
                return systemGeometrySymbolManager;
            }

            set
            {
                systemGeometrySymbolManager = value;
            }
        }

        public bool FromJsonObject(JsonObject jObject)
        {
            if(jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("SystemGeometrySymbolManager"))
            {
                systemGeometrySymbolManager = new SystemGeometrySymbolManager(jObject["SystemGeometrySymbolManager"] as JsonObject); 
            }

            return true;
        }

        public JsonObject ToJsonObject()
        {
            JsonObject jObject = new JsonObject();
            jObject.Add("_type", Core.Query.FullTypeName(this));

            if(systemGeometrySymbolManager != null)
            {
                jObject.Add("SystemGeometrySymbolManager", systemGeometrySymbolManager.ToJsonObject());
            }

            return jObject;
        }
    }
}
