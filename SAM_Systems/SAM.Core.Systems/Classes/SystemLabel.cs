// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using System;

namespace SAM.Core.Systems
{
    public class SystemLabel : ISystemLabel
    {
        public SystemLabel(SystemLabel systemLabel)
        {
            if (systemLabel != null)
            {
                Text = systemLabel.Text;
                Guid = systemLabel.Guid;
                Name = systemLabel.Name;
            }
        }

        public SystemLabel(JsonObject jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemLabel()
        {

        }

        public SystemLabel(string text)
            : base()
        {
            Text = text;
            Guid = Guid.NewGuid();
            Name = null;
        }

        public Guid Guid { get; private set; }
        
        public string Name { get; private set; }
        
        public string Text { get; set; }
        
        public bool FromJsonObject(JsonObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if (jObject.ContainsKey("Text"))
            {
                Text = jObject["Text"]?.GetValue<string>() ?? null;
            }

            Guid = Core.Query.Guid(jObject);

            if (jObject.ContainsKey("Name"))
            {
                Name = jObject["Name"]?.GetValue<string>() ?? null;
            }

            return true;
        }

        public JsonObject ToJsonObject()
        {
            JsonObject result = new JsonObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if (Text != null)
            {
                result.Add("Text", Text);
            }

            result.Add("Guid", Guid);
            
            if (Name != null)
            {
                result.Add("Name", Name);
            }

            return result;
        }
    }
}